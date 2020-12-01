import os
import json
import requests

add_vacancies_url = "http://localhost:8080/saveVacancies"
source_dir = "json_data"

if __name__ == '__main__':

    this_dir = os.getcwd()
    files = []
    for r, d, f in os.walk(this_dir):
        for file in f:
            if file.endswith(".json"):
                files.append(os.path.join(r, file))

    N = len(files)
    i = 0
    for f in files:
        with open(f) as json_file:
            entries = json.load(json_file)
            response = requests.post(add_vacancies_url, json=entries)
            print(str(i) + "/" + str(N) + " code = " + str(response.status_code))
        i = i + 1
