package com.polytech.hh.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.Document;

@Document(indexName = "employeridx", indexStoreType = "employer")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Employer {

    @Id
    private Long id;

    private String name;

    private Boolean trusted;
}
