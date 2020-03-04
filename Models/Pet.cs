using System;
using System.Collections.Generic;

namespace tamagotchi.Models
{
  public class Pet
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; } = DateTime.Now;
    public DateTime? DeathDate { get; set; } 
//? makes the statement null without crashing program 
//if you dont want to enter a death date
    public int HungerLevel { get; set; }
    public int HappinessLevel { get; set; }
  }
}