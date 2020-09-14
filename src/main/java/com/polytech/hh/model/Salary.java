package com.polytech.hh.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class Salary {

    @Id
    private Long id;

    private Integer from;
    private Integer to;
    private String currency;
    private Boolean gross;
}
