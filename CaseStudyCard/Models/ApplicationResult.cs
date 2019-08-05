using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudyCard.Models
{
    public class ApplicationResult
    {
        
        public ApplicationResult(ApplicationForm form)
        {
            
        }

        public List<ClientCreditCard> Cards { get; set; }
    }
}
