import requests
import json
import threading
from fetcher import fetch_all_ids
import time
from concurrent.futures import ThreadPoolExecutor as PoolExecutor
from random import randint

get_full_vacancy_by_id_url = "https://api.hh.ru/vacancies/"
add_vacancies_url = "http://localhost:8080/saveVacancies"
get_url = "http://localhost:9200/vacancyidx/_search"

ids = list(set(fetch_all_ids()))

replacements = {
    "С++": "C++",
    "С#": "C#",
    "с++": "C++",
    "с#": "C#",
    "csharp": "C#",
    "1C": "1С",
    "1с": "1С",
    "c++": "C++",
    "c#": "C#",
    "С/C++": "C/C++",
    "C/С++": "C/C++",
    "java script": "js",
    "javascript": "js",
    "Java Script": "js",
    "node js": "Node.js",
    "nodejs": "Node.js",
    "typescript": "ts",
}

languages = ["1С", "Java", "C++", "C#", "Go", "Python", "Scala", "Ruby",
             "PHP", "SQL", "js", "Node.js", "Matlab", "Arduino", "Perl",
             "Lisp", "Haskell", "Kotlin", "Rust", "Swing", "bash"]

frameworks = ["Flask", "Express.js", "Django", "Ruby on Rails", "Meteor",
              "Spring", "Koa", "Nest.js", "Beego", "Symfony"]

english = ["A1", "A1+", "A2", "A2+", "B1", "B1+",
           "B2", "B2+", "C1", "C1+", "C2", "C2+"]

level = ["Junior", "Middle", "Senior"]

roles = ["Backend", "Frontend", "Mobile", "Devops", "Gamedev", "Desktop"]

keywords = {
    'framework': frameworks,
    'language': languages,
    'english': english,
    'level': level,
    'role': roles
}

headers = {
    'Content-Type': 'application/json',
}

threshold = 500

params = (
    ('pretty', ''),
    ('size', threshold)
)


def preprocess_by_field(body, values, param):
    for item in body:
        if '_source' not in item:
            entry = item
        else:
            entry = item['_source']

        if 'name' not in entry:
            continue

        if 'snippet' not in entry:
            snippet = {}
        else:
            snippet = entry['snippet']

        for v in values:
            if v.lower() in entry['name'].lower():
                entry[param] = v
                break

        if param not in entry:
            if len(snippet) > 0 and 'requirement' in snippet and snippet['requirement'] is not None:
                for v in values:
                    if v.lower() in snippet['requirement'].lower():
                        entry[param] = v
                        break

        if param not in entry:
            if 'description' in entry and entry['description'] is not None:
                for v in values:
                    if v.lower() in entry['description'].lower():
                        entry[param] = v
                        break
    return


def preprocess(body):
    N = len(body)
    i = 0
    for item in body:
        if '_source' not in item:
            entry = item
        else:
            entry = item['_source']

        if 'description' in entry:
            continue

        # entry_id = entry['id']

        # if entry_id in ids:
        #    fetched = fetch_by_id(entry_id)
        #    fetched = fetched['_source']
        #    if 'description' in fetched:
        #        entry['description'] = fetched['description']
        #    if 'experience' in fetched:
        #        entry['experience'] = fetched['experience']
        # else:
        query = get_full_vacancy_by_id_url + str(entry['id'])
        response = None
        while response == None:
            try:
                response = requests.get(query)
            except:
                print("Connection refused by the server..")
                print("Zzzzzz...")
                time.sleep(5)
                print("Trying to continue...")
                continue

        vacancy = json.loads(response.text)
        if 'description' in vacancy:
            full_description = vacancy['description']
            entry['description'] = full_description
        if 'experience' in vacancy:
            experience = vacancy['experience']
            entry['experience'] = experience

        print(str(threading.current_thread().ident) + " " + str(i) + "/" + str(N) + " code " + str(response.status_code))
        i = i + 1

    for item in body:
        if '_source' not in item:
            entry = item
        else:
            entry = item['_source']
        if 'name' not in entry:
            continue

        for r in replacements:

            entry['name'] = entry['name'].replace(r, replacements[r])
            if 'snippet' not in entry:
                snippet = {}
            else:
                snippet = entry['snippet']
            if len(snippet) > 0 and 'requirement' in snippet and snippet['requirement'] is not None:
                entry['snippet']['requirement'] = snippet['requirement'].replace(r, replacements[r])

    for key in keywords:
        preprocess_by_field(body, keywords[key], key)

    for item in body:
        if '_source' not in item:
            entry = item
        else:
            entry = item['_source']
        if 'name' not in entry:
            continue
        if 'address' in entry:
            address = entry['address']
            if address is not None:
                if 'lat' in address and 'lng' in address:
                    lat = address['lat']
                    lng = address['lng']
                    if lat is not None and lng is not None:
                        entry['location'] = str(lat) + "," + str(lng)

    return body


def correct_all_entries(S, E):
    total = E - S
    if len(ids) - E < total:
        total = len(ids) - E

    chunks_processed = 0

    while total > 0:
        str_id = "["
        if total >= threshold:
            chunks_size = threshold
        else:
            chunks_size = total

        start_idx = S + threshold * chunks_processed
        end_idx = start_idx + chunks_size

        for i in range(start_idx, end_idx):
            str_id = str_id + "\"" + ids[i] + "\"" + ','
        str_id = str_id.rstrip(',') + "]"

        data = ' { "query": { "terms": { "_id": ' + str_id + ' } } }'

        response = requests.post(get_url, headers=headers, params=params, data=data)
        body = json.loads(response.text)
        if 'hits' in body:
            body = body['hits']
        if 'hits' in body:
            body = body['hits']

        body = preprocess(body)

        entries = []
        for b in body:
            entry = b['_source']
            entries.append(entry)

        r = requests.post(add_vacancies_url, json=entries)
        print(str(threading.current_thread().ident) + " " + str(start_idx) + " " + str(end_idx) + " code " + str(r.status_code))

        time.sleep(randint(1, 5))

        total = total - chunks_size
        chunks_processed = chunks_processed + 1


if __name__ == '__main__':

    ss = []
    ee = []
    chunk_size = 1000
    N = int(len(ids) / chunk_size) + 1
    for i in range(0, N):
        s = i * chunk_size
        e = s + chunk_size
        ss.append(s)
        ee.append(e)

    with PoolExecutor(max_workers=100) as executor:
        for _ in executor.map(correct_all_entries, ss, ee):
            pass
