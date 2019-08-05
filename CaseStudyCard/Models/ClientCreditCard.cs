using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyCard.Models
{
    public class ClientCreditCard
    {
        public ClientCreditCard(CreditCard c)
        {
            this.ID = c.Id;
            this.CardName = c.CardName;
            this.PromotionalMessage = c.PromotionalMessage;
            this.ImageURL = c.ImageURL;
            this.APR = c.APR;
        }
        public int ID { get; set; }
        public String CardName { get; set; }
        public String PromotionalMessage { get; set; }
        public String ImageURL { get; set; }
        public float APR { get; set; }
    }
}
