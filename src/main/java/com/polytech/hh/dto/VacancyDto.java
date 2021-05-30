package com.polytech.hh.dto;

import com.polytech.hh.model.Address;
import com.polytech.hh.model.Experience;
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
public class VacancyDto {
    private Long id;
    private String name;
    private String location;
    private Address address;
    private Salary salary;
    private String published_at;
    private String alternate_url;
    private Experience experience;
    private List<Specialization> specializations;
}
