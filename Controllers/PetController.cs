using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tamagotchi.Models;

namespace tamagotchi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PetController : ControllerBase
  {
    public DatabaseContext db { get; set; } = new DatabaseContext();


//get id int
    [HttpGet("pets")]
    public List<Pet> GetAllPets()
    {
      var pets = db.Pets.OrderBy(m => m.Name);
      return pets.ToList();
    }
//get name string
    [HttpGet("{id}")]
    public Pet GetOnePet(int id)
    {
      var item = db.Pets.FirstOrDefault(i => i.Id == id);
      return item;

    }
//post birthday datetime now
    [HttpPost]
    public Pet CreatePet(Pet item)
    {
      db.Pets.Add(item);
      db.SaveChanges();
      return item;
    }

    // [HttpPost("multiple")]
    // public List<Pet> AddManyItems(List<Pet> items)
    // {
    //   db.Pets.AddRange(items);
    //   db.SaveChanges();
    //   return items;
    // }


//put id play
//add 5 to happiness level
//add 3 to hungry
    [HttpPut("{id}/play")]
    public Pet UpdateOneItem(int id)
    {
      var item = db.Pets.FirstOrDefault(i => i.Id == id);
      item.HappinessLevel += 5;
      item.HungerLevel += 3;
      //newData.Id = id;
      //db.Entry(newData).State = EntityState.Modified;
      db.SaveChanges();
      return item;
    }

//put id feed
//remove 5 from hungry level
//add 3 to happiness level
    [HttpPut("{id}/feed")]
    public Pet RemoveHappiness(int id)
    {
      var item = db.Pets.FirstOrDefault(i => i.Id == id);
      item.HappinessLevel += 3;
      item.HungerLevel -= 5;
      //newData.Id = id;
      //db.Entry(newData).State = EntityState.Modified;
      db.SaveChanges();
      return item;
    }

//put id scold
//remove 5 from happiness
     [HttpPut("{id}/scold")]
    public Pet PetInTrouble(int id)
    {
      var item = db.Pets.FirstOrDefault(i => i.Id == id);
      item.HappinessLevel -= 5;
      //newData.Id = id;
      //db.Entry(newData).State = EntityState.Modified;
      db.SaveChanges();
      return item;
    }
    // [HttpPatch("{id}")]
    // public Pet UpdateCalories(int id, Pet data)
    // {
    //   var item = db.Pets.FirstOrDefault(i => i.Id == id);
    //   item.Calories = data.Calories;
    //   db.SaveChanges();
    //   return item;
    // }


    [HttpDelete("{id}")]
    public ActionResult DeleteOne(int id)
    {
      var item = db.Pets.FirstOrDefault(f => f.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      db.Pets.Remove(item);
      db.SaveChanges();
      return Ok();
    }
  }
}