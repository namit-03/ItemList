using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MenuItemListingWebApi.Models;

namespace MenuItemListingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        
       public List<MenuItem> item = new List<MenuItem>(){
            new MenuItem
            {
            Id =1,
            freeDelivery=true,
            Name="Burger",
            Price=50.0,
            dateofLaunch=Convert.ToDateTime("07/05/2020"),
            Active=true
            },
          new MenuItem
            {
                Id =2,
            freeDelivery=true,
            Name="CheeseCake",
            Price=120.0,
            dateofLaunch=Convert.ToDateTime("07/12/2020"),
            Active=true
            },
          new MenuItem
            {
                Id =3,
            freeDelivery=true,
            Name="PlainPizza",
            Price=90.0,
            dateofLaunch=Convert.ToDateTime("07/05/2020"),
            Active=true
            },
           new MenuItem
            {
                Id =4,
            freeDelivery=true,
            Name="Icecream",
            Price=90.0,
            dateofLaunch=Convert.ToDateTime("07/05/2020"),
            Active=true
            }
};

      // GET: api/MenuItem

      [HttpGet]
        public  List<MenuItem> Get()
        {
            
            return item;

    }

        // GET: api/MenuItem/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string name = "";
            var check = item.FirstOrDefault((p) => p.Id == id);
            name = check.Name;
            return name;
        }

        // POST: api/MenuItem
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MenuItem/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
