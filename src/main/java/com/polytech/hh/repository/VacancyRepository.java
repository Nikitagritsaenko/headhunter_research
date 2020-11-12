package com.polytech.hh.repository;

import com.polytech.hh.model.Vacancy;
import org.springframework.data.elasticsearch.repository.ElasticsearchRepository;
import java.util.List;

public interface VacancyRepository extends ElasticsearchRepository<Vacancy, Long> {

    List<Vacancy> findByName(String name);
}
