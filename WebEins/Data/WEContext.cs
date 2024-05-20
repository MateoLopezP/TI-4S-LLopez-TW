using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebEins.Models;

    public class WEContext : DbContext
    {
        public WEContext (DbContextOptions<WEContext> options)
            : base(options)
        {
        }

        public DbSet<WebEins.Models.Produkte> Produkte { get; set; } = default!;

        public DbSet<WebEins.Models.Künde> Künde { get; set; } = default!;

        public DbSet<Bestellung> Bestellungen { get; set; } = default!;
}
