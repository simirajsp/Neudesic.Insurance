using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Models.Entities
{
    public class Property: BaseEntity
    {
        public string Address { get; set; }
        public string Type { get; set; }
        public float Area { get; set; }
        public int ZipCode { get; set; }
    }
}
