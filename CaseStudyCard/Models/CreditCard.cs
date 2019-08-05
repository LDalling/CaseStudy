using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyCard.Models
{
    public class CreditCard
    {
        private CreditCard c;

        public CreditCard(CreditCard c)
        {
            this.c = c;
        }
        public CreditCard()
        {
        }


        public int Id { get; set; }
        public String CardName { get; set; }
        public String PromotionalMessage { get; set; }
        public String ImageURL { get; set; }
        public float APR { get; set; }
        public int MinimumAge { get; set; }
        public int MinimumEarnings { get; set; }
        public int MaximumEarnings { get; set; }
    }
}
