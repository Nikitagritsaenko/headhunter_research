package com.polytech.hh.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.Document;

@Document(indexName = "vacancyidx", indexStoreType = "vacancy")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Vacancy {

    @Id
    private Long id;

    private String name;

    private String language;

    private Area area;

    private String location;

    private Salary salary;

    private Address address;

    private Employer employer;

    private String published_at;

    private String created_at;

    private String alternate_url;

    private Snippet snippet;

    private Schedule schedule;

    private String level;

    private String english;

    private String framework;

    private String role;
}
