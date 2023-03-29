using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadCard.Data.Entities
{
    public class CCCDCard
    {
        public additionalPersonDetails additionalPersonDetails { get; set; }
        public string docType { get; set; }
        public PersonDetails PersonDetails { get; set; }
    }
}