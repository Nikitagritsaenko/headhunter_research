package com.polytech.hh.repository;

import com.polytech.hh.model.Customer;
import org.springframework.data.elasticsearch.repository.ElasticsearchRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface CustomerRepository extends ElasticsearchRepository<Customer, Long> {

    List<Customer> findByFirstName(String firstName);
}
