using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    
    public class CountryCityController : Controller
    {
        private readonly ApplicationDbContext db;

        public CountryCityController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public JsonResult getCities(int id)
        {
            var cities = new List<City>();
            cities = db.Cities.Where(c => c.CountryId == id).ToList();
            return new JsonResult(cities.Select(x => new City { CityId = x.CityId, CityName = x.CityName }));
        }
    }
}
