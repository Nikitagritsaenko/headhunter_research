package com.polytech.hh.controller;

import com.polytech.hh.model.Customer;
import com.polytech.hh.repository.CustomerRepository;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@Controller
public class CustomerController {

    private final CustomerRepository repository;

    public CustomerController(CustomerRepository repository) {
        this.repository = repository;
    }

    @PostMapping("/saveCustomer")
    public @ResponseBody int saveCustomer(@RequestBody List<Customer> customers) {
        repository.saveAll(customers);
        return customers.size();
    }

    @GetMapping("/findAll")
    public @ResponseBody Iterable<Customer> findAllCustomers() {
        return repository.findAll();
    }

    @GetMapping("/findByName/{firstName}")
    public @ResponseBody List<Customer> findByFirstName(@PathVariable String firstName) {
        return repository.findByFirstName(firstName);
    }
}
