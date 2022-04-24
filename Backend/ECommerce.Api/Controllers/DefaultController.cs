using EComerce.Api.Data;
using EComerce.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComerce.Api.Controllers;

[ApiController]
public class DefaultController : ControllerBase {

    private readonly ComerceDbContext _db;

    public DefaultController(ComerceDbContext db) {
        _db = db;
    }




    [HttpGet]
    [Route("api")]
    public IActionResult GetOk() {
        return Ok("Ok");
    }

    [HttpGet]
    [Authorize]
    [Route("api/testauth")]
    public IActionResult GetCUlo() {
        var a = _db.Products.ToList();

        return Ok(a);
    }

    [HttpGet]
    [Route("api/culo2")]
    public IActionResult AddCulo() {
        var prod = new Product();
        prod.Nombre = "Tu Vieja";
        prod.Descripcion = "En Tanga";
        prod.PrecioVenta = 0;
        prod.Stock = 10;
        prod.FechaAlta = new DateTime();
        _db.Products.Add(prod);

        _db.SaveChanges();
        
        return Ok("Ok");
    }


}
