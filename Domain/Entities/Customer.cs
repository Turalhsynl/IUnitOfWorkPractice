﻿using Domain.BaseEntities;

namespace Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
}
