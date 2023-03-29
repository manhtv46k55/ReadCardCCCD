using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadCard.Data.Entities
{
    public class PersonDetails
    {
        public string birthDate { get;set; }
        public string expiryDate { get;set; }
        public faceImage faceImage { get; set; }
        public string faceImageBase64 { get; set; }
        public string gender { get; set; }
        public string issuerAuthority { get; set; }
        public string name { get; set; }
        public string nationality { get; set; }
        public string personalNumber { get; set; }
        public string serialNumber { get; set; }
        public string surname { get; set; }
    }
}