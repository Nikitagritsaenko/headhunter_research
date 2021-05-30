package com.polytech.hh.repository;

import com.polytech.hh.model.Vacancy;
import java.util.List;
import org.springframework.data.elasticsearch.repository.ElasticsearchRepository;

public interface VacancyRepository extends ElasticsearchRepository<Vacancy, Long> {

    List<Vacancy> findByName(String name);

    List<Vacancy> findByNameLikeAndAddressCity(String name, String city);
}
