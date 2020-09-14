package com.polytech.hh.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.Document;

@Document(indexName = "snippetidx", indexStoreType = "snippet")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Snippet {

    @Id
    private Long id;

    private String requirement;

    private String responsibility;
}
