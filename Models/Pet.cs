using System;
using System.Collections.Generic;

namespace tamagotchi
{
  public class Pet
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; } = DateTime.Now;
    public DateTime DeathDate { get; set; } = DateTime.Now;
    public int HungerLevel { get; set; }
    public int HappinessLevel { get; set; }
  }
}