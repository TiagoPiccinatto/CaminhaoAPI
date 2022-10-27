using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Context
{
    public class CaminhaoContext : DbContext
    {
        public CaminhaoContext(DbContextOptions <CaminhaoContext> options) : base(options)
        {

        }

        public DbSet<CaminhaoModel> Caminhoes { get; set; }
    }
}