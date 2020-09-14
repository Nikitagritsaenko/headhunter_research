package com.polytech.hh.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.Document;

@Document(indexName = "metroidx", indexStoreType = "metro")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Metro {

    @Id
    private Long id;

    private String station_name;

    private String line_name;
}
