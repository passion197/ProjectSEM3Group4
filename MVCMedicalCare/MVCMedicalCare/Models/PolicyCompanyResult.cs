using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMedicalCare.Models
{
    public class PolicyCompanyResult
    {
        public string PolicyId { get; set; }
        public string PolicyName { get; set; }
        public string PolicyDesc { get; set; }
        public string Amount { get; set; }
        public string EMI { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ComAddress { get; set; }
        public string ComPhone { get; set; }
        public string ComUrl { get; set; }
    }
}