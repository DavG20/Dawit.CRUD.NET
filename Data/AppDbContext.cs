﻿using Microsoft.EntityFrameworkCore;
using SampleCRUD.Models;
namespace SampleCRUD.Data;
public class AppDbContext : DbContext
{

public DbSet<Team> Team { get; set; }


public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
{
    
}
}
