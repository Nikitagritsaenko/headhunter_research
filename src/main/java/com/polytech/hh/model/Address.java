package com.polytech.hh.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class Address {

    @Id
    private Long id;

    private String city;

    private String street;

    private String building;

    private Double lat;

    private Double lng;

    private Metro metro;
}
