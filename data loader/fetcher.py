import requests
import json
from elasticsearch import Elasticsearch
from elasticsearch_dsl import Search

ES_INDEX = 'vacancyidx'


def fetch_all_entries():
    es = Elasticsearch()
    s = Search(using=es, index=ES_INDEX)

    s = s.source([])
    entries = [h for h in s.scan()]

    return entries


def fetch_all_ids():
    es = Elasticsearch()
    s = Search(using=es, index=ES_INDEX)

    s = s.source([])
    ids = [h.meta.id for h in s.scan()]

    return ids


def fetch_by_id(id):

    params = (
        ('pretty', ''),
    )

    r = requests.get('http://localhost:9200/vacancyidx/_doc/'+id, params=params)
    body = r.text

    return json.loads(body)
