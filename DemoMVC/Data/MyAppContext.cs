using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Data
{
    public class MyAppContext :DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {
            
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemSpecs> ItemSpecs { get; set; }
    }
}