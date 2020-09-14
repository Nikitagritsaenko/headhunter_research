package com.polytech.hh.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.Document;

@Document(indexName = "areaidx", indexStoreType = "area")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Area {

    @Id
    private Long id;

    private String name;
}
