using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_It_trends1.Entities
{
    internal class Category
    {
        public int Id { get; set; }
        public ICollection<New> News { get; set; }
        public string Name { get; set; }
    }
}
