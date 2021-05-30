package com.polytech.hh.controller;

import com.polytech.hh.dto.SearchVacancyDto;
import com.polytech.hh.dto.VacancyDto;
import com.polytech.hh.model.Vacancy;
import com.polytech.hh.repository.VacancyRepository;
import com.polytech.hh.service.VacancyService;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Sort;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@Controller
public class VacancyController {

    private final VacancyRepository repository;
    private final VacancyService service;

    public VacancyController(VacancyRepository repository, VacancyService service) {
        this.repository = repository;
        this.service = service;
    }

    @PostMapping("/saveVacancies")
    public @ResponseBody
    int saveVacancies(@RequestBody List<Vacancy> vacancies) {
        repository.saveAll(vacancies);
        return vacancies.size();
    }

    @PostMapping("/saveOneVacancy")
    public @ResponseBody
    void saveVacancy(@RequestBody Vacancy vacancy) {
        repository.save(vacancy);
    }

    @GetMapping
    @ResponseStatus(HttpStatus.OK)
    public @ResponseBody String checkConnection() {
        return "Service is running!";
    }

    @GetMapping("/vacancies/{pageId}")
    public @ResponseBody Page<Vacancy> findAllVacancies(@PathVariable int pageId) {

        return repository.findAll(
                PageRequest.of(pageId, 100, Sort.by(Sort.Direction.ASC, "id")));
    }

    @GetMapping("/vacancy/name/{name}")
    public @ResponseBody List<Vacancy> findByName(@PathVariable String name) {
        return repository.findByName(name);
    }

    @PutMapping("/vacancies/{limit}")
    public @ResponseBody List<VacancyDto> searchVacancy(@RequestBody SearchVacancyDto dto, @PathVariable int limit) {
        return service.searchVacancy(dto, limit);
    }
}
