using System;
using BlazorApp.Modules.Users.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  public DbSet<User> Users { get; set; }
}
