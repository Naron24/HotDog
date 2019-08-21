using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotDog.Models
{
    public class HotDogContext : DbContext
    {
        public HotDogContext (DbContextOptions<HotDogContext> options)
            : base(options)
        {
        }

        public DbSet<HotDog.Models.HotDogViewModel> HotDogViewModel { get; set; }
    }
}
