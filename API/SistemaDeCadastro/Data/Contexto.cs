using Microsoft.EntityFrameworkCore;
using SistemaDeCadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeCadastro.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
                        : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
