using AvaliacaoTec_APICore.Library.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AvaliacaoTec_APICore.Data.Context
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }

    }
}
