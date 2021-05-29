package com.polytech.hh.model;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class Specialization {
  @Id
  private String id;

  private String name;

  private String profarea_id;

  private String profarea_name;
}
