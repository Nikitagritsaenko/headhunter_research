package com.polytech.hh.service;

import static org.elasticsearch.index.query.QueryBuilders.regexpQuery;

import com.polytech.hh.dto.SearchVacancyDto;
import com.polytech.hh.dto.VacancyDto;
import com.polytech.hh.model.Vacancy;
import com.polytech.hh.repository.VacancyRepository;
import java.util.List;
import java.util.stream.Collectors;
import org.modelmapper.ModelMapper;
import org.springframework.boot.autoconfigure.condition.ConditionalOnBean;
import org.springframework.data.elasticsearch.core.ElasticsearchRestTemplate;
import org.springframework.data.elasticsearch.core.SearchHit;
import org.springframework.data.elasticsearch.core.SearchHits;
import org.springframework.data.elasticsearch.core.mapping.IndexCoordinates;
import org.springframework.data.elasticsearch.core.query.NativeSearchQueryBuilder;
import org.springframework.data.elasticsearch.core.query.Query;
import org.springframework.stereotype.Service;

@Service
public class VacancyService {

    private final VacancyRepository repository;
    private final ElasticsearchRestTemplate elasticsearchTemplate;

    private final ModelMapper modelMapper = new ModelMapper();

    public VacancyService(VacancyRepository repository, ElasticsearchRestTemplate template) {
        this.repository = repository;
        this.elasticsearchTemplate = template;
    }


    public List<VacancyDto> searchVacancy(SearchVacancyDto dto, int limit) {
        // TODO: use all dto fields for search
        Query searchQuery = new NativeSearchQueryBuilder()
            .withFilter(regexpQuery("name", ".*Java.*"))
            .build();
        SearchHits<Vacancy> vacancies =
            elasticsearchTemplate.search(searchQuery, Vacancy.class, IndexCoordinates.of("vacancyidx"));
        return vacancies.stream()
            .map(SearchHit::getContent)
            .map(vacancy -> modelMapper.map(vacancy, VacancyDto.class))
            .limit(limit)
            .collect(Collectors.toList());
    }
}
