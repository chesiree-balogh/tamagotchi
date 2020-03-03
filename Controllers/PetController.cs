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

    [HttpGet]
    public List<Pet> GetAllPets()
    {
      var pets = db.Pets.OrderBy(m => m.Name);

      return pets.ToList();
    }
    [HttpGet("{id}")]
    public Pet GetOneMenuItem(int id)
    {
      var item = db.Pets.FirstOrDefault(i => i.Id == id);
      return item;

    }

    [HttpPost]
    public Pet CreateMenuItem(Pet item)
    {
      db.Pets.Add(item);
      db.SaveChanges();
      return item;
    }

    [HttpPost("multiple")]
    public List<Pet> AddManyItems(List<Pet> items)
    {
      db.Pets.AddRange(items);
      db.SaveChanges();
      return items;
    }

    [HttpPut("{id}")]
    public Pet UpdateOneItem(int id, Pet newData)
    {
      newData.Id = id;
      db.Entry(newData).State = EntityState.Modified;
      db.SaveChanges();
      return newData;
    }

    [HttpPatch("{id}")]
    public Pet UpdateCalories(int id, Pet data)
    {
      var item = db.Pets.FirstOrDefault(i => i.Id == id);
      item.Calories = data.Calories;
      db.SaveChanges();
      return item;
    }


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