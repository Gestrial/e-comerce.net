using EComerce.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EComerce.Api.Data;

public class ComerceDbContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long> {

    public ComerceDbContext(DbContextOptions options) : base(options) {
    }

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
    }

#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
    public DbSet<Product?> Products { get; set; }











#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
}
