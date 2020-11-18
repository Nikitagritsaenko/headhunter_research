import requests
import json
from datetime import date, timedelta
from corrector import preprocess

vacancies_url = "https://api.hh.ru/vacancies"
add_vacancies_url = "http://localhost:8080/saveVacancies"
vacancies_out_dir = "out/"
days_limit = 30
page_limit = 20

if __name__ == '__main__':

    today = date.today()
    today_minus_month = today - timedelta(days=days_limit)

    request_params = {'specialization': '1.221',
                      'per_page': '100',
                      'page': None,
                      'date_from': None,
                      'date_to': None
                      }

    for i in range(0, days_limit):

        day_from = today_minus_month + i * timedelta(days=1)
        day_to = today_minus_month + (i + 1) * timedelta(days=1)
        request_params['date_from'] = day_from
        request_params['date_to'] = day_to

        for page in range(0, page_limit):
            request_params['page'] = page
            response = requests.get(vacancies_url, params=request_params)

            print(str(i) + " " + str(page))
            body = json.loads(response.text)
            body['items'] = preprocess(body['items'])
            response = requests.post(add_vacancies_url, json=body['items'])
            print(response.text)


