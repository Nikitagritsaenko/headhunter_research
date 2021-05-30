package com.polytech.hh.dto;

import com.polytech.hh.model.Address;
import com.polytech.hh.model.Experience;
import com.polytech.hh.model.Metro;
import com.polytech.hh.model.Salary;
import com.polytech.hh.model.Specialization;
import java.util.List;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Builder
public class SearchVacancyDto {
    private Double lat;
    private Double lng;
    private String name;
    private String location;
    private String city;
    private Metro metro;
    private Specialization specialization;
}
