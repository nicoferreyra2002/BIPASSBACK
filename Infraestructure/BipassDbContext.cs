using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class BipassDbContext : DbContext
    {
        public BipassDbContext(DbContextOptions<BipassDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Concert> Concerts => Set<Concert>();
        public DbSet<Ticket> Tickets => Set<Ticket>();

    }
}
