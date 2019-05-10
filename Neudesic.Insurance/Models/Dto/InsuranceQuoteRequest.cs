using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Models.Dto
{
    public class InsuranceQuoteRequest
    {
        public string PropertyType { get; set; }
        public string Area { get; set; }
        public float CoverageRequired { get; set; }
        public int ZipCode { get; set; }
    }
}
