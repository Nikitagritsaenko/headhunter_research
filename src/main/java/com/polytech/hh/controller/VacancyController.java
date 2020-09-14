package com.polytech.hh.controller;

import com.polytech.hh.model.Vacancy;
import com.polytech.hh.repository.VacancyRepository;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@Controller
public class VacancyController {

    private final VacancyRepository repository;

    public VacancyController(VacancyRepository repository) {
        this.repository = repository;
    }

    @PostMapping("/saveVacancy")
    public @ResponseBody
    int saveCustomer(@RequestBody List<Vacancy> vacancies) {
        repository.saveAll(vacancies);
        return vacancies.size();
    }

    @GetMapping("/vacancies")
    public @ResponseBody Iterable<Vacancy> findAllVacancies() {
        return repository.findAll();
    }

    @GetMapping("/vacancy/{name}")
    public @ResponseBody List<Vacancy> findByName(@PathVariable String name) {
        return repository.findByName(name);
    }
}
