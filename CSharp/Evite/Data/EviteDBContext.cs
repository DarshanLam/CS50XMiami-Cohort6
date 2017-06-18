using Evite.Models;
using Microsoft.EntityFrameworkCore;

namespace Evite.Data
{
    public class EviteDBContext : DbContext
    {
        public EviteDBContext(DbContextOptions<EviteDBContext> options) : base(options)
        {
        }

        public DbSet<ResponseToEvite> ResponseToEvites { get; set; }

    }
}