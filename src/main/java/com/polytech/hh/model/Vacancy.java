package com.polytech.hh.model;

import com.fasterxml.jackson.annotation.JsonFormat;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.Document;
import org.springframework.format.annotation.DateTimeFormat;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.Date;

@Document(indexName = "vacancyidx", indexStoreType = "vacancy")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Vacancy {

    @Id
    private Long id;

    private String name;

    private Area area;

    private Salary salary;

    private Address address;

    private Employer employer;

    private String published_at;

    private String created_at;

    private Snippet snippet;

    private Schedule schedule;
}
