using ExampleWebServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebServer.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Book> Books{ get; set; }
}