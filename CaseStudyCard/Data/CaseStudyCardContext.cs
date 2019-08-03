using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace CaseStudyCard.Models
{
    public class CaseStudyCardContext : DbContext
    {
        public CaseStudyCardContext (DbContextOptions<CaseStudyCardContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Movie> Movie { get; set; }
    }
}
