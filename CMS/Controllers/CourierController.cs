using CMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourierController : ControllerBase
    {

        CMSContext db = new CMSContext();
        [HttpGet]
        public IEnumerable<Courier> get()
        {
            return db.Couriers;
        }

        [HttpGet("{id}")]
        public Courier get(int id)
        {
            return db.Couriers.FirstOrDefault(o => o.CId == id);
        }

        [HttpPost]
        public IActionResult post(Courier courier)
        {
            db.Couriers.Add(courier);
            db.SaveChanges();
            return Ok(new { status = "your record is added suceessfully" });
        }
        [HttpPut]
        public IActionResult put(Courier courier)
        {
            db.Couriers.Update(courier);
            db.SaveChanges();
            return Ok(new { status = "your record is updated suceessfully" });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var courier = db.Couriers.Where(x => x.CId == id).FirstOrDefault();
            db.Couriers.Remove(courier);
            db.SaveChanges();
            return Ok(new { status = "your record is deleted suceessfully" });
        }
    }
}

    

