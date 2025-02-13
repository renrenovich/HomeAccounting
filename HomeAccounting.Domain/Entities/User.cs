﻿using System.ComponentModel.DataAnnotations;

namespace HomeAccounting.Domain.Entities;

public class User 
{
    [Key]
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
}