using ReadCard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadCard.Models
{
    public class CCCDCardView
    {
        public int ID { get; set; }
        public CCCDCard CCCDCard { get; set; }
        public DateTime UploadTime { get; set; }
    }
}