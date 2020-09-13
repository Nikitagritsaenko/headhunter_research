import requests
import json
from datetime import date, timedelta

vacancies_url = "https://api.hh.ru/vacancies"
vacancies_out_dir = "out/"
days_limit = 6
page_limit = 20

if __name__ == '__main__':

    today = date.today()
    today_minus_month = today - timedelta(days=30)

    request_params = {'specialization': '1.221',
                      'per_page': '100',
                      'page': None,
                      'date_from': None,
                      'date_to': None
                      }

    for i in range(0, days_limit):

        day_from = today_minus_month + i * timedelta(days=2)
        day_to = today_minus_month + (i + 1) * timedelta(days=2)
        request_params['date_from'] = day_from
        request_params['date_to'] = day_to

        for page in range(0, page_limit):
            request_params['page'] = page
            response = requests.get(vacancies_url, params=request_params)
            filename = "vacancies_" + str(day_from) + "_" + str(day_to) + "_" + "page" + str(page)
            print(filename)
            with open(vacancies_out_dir + filename + ".json", 'w') as outfile:
                json.dump(json.loads(response.text), outfile)

