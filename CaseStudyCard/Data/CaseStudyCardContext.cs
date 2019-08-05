using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CaseStudyCard.Models;

namespace CaseStudyCard.Models
{
    public class CaseStudyCardContext : DbContext
    {
        public CaseStudyCardContext (DbContextOptions<CaseStudyCardContext> options)
            : base(options)
        {
        }
        public DbSet<CaseStudyCard.Models.ApplicationForm> ApplicationForm { get; set; }
        public DbSet<CaseStudyCard.Models.CreditCard> CreditCard { get; set; }
    }
}
