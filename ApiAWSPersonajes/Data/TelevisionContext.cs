using ApiAWSPersonajes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAWSPersonajes.Data
{
    public class TelevisionContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public TelevisionContext(DbContextOptions<TelevisionContext> opt)
            :base(opt)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Personaje> Personajes { get; set; }
        
    }
}
