using System.ComponentModel.DataAnnotations;

namespace EComerce.Api.Models;

public class Product {

    [Key]
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public decimal PrecioVenta { get; set; }
    public int? Stock { get; set; }
    public DateTime? FechaAlta { get; set; }

    public Product() {

    }

    public Product(int id, string nombre, string descripcion, decimal precioVenta, DateTime fechaAlta) {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        PrecioVenta = precioVenta;
        FechaAlta = fechaAlta;
    }
    

}
