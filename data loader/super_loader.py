import requests
import json
import threading
import time
import pathlib
from concurrent.futures import ThreadPoolExecutor as PoolExecutor
from random import randint

get_full_vacancy_by_id_url = "https://api.hh.ru/vacancies/"
add_vacancies_url = "http://localhost:8080/saveVacancies"

first_id = 1000000
last_id = 2000000
starts = []
ends = []
chunk_size = 5000

total = last_id - first_id
N = int(total / chunk_size) + 1
for i in range(0, N):
    s = first_id + i * chunk_size
    e = s + chunk_size
    starts.append(s)
    ends.append(e)

finished = 0

def load_by_id(S, E):
    entries = []

    print(str(threading.current_thread().ident) + " [" + str(S) + ", " + str(E) + "]")
    time.sleep(randint(1, 10))

    N = E - S
    for i in range(S, E):
        print(str(threading.current_thread().ident) + " " + str(i-S) + "/" + str(N))
        query = get_full_vacancy_by_id_url + str(i)
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
        if 'specializations' in vacancy:
            specializations = vacancy['specializations']
            for s in specializations:
                if s['id'] == '1.221':
                    entries.append(vacancy)
                    break

    if len(entries) > 0:
        filename = 'out' + '/' + str(threading.current_thread().ident) + '_' + str(S) + '_' + str(E) + '.json'
        with open(filename, 'w') as outfile:
            json.dump(entries, outfile)

    global finished
    finished = finished + E - S
    print("progress: " + str(finished) + "/" + str(total))


if __name__ == '__main__':

    pathlib.Path('out').mkdir(parents=True, exist_ok=True)

    with PoolExecutor(max_workers=250) as executor:
        for _ in executor.map(load_by_id, starts, ends):
            pass
