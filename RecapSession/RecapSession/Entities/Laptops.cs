using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoreLib.Entities
{
    public class Laptops
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public string SerialNumber { get; set; }
        public string EmpName { get; set; }
    }
}
