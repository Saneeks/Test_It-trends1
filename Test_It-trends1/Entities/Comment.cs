using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_It_trends1.Entities
{
    internal class Comment
    {
        public int Id { get; set; }
        public ICollection<New> News { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Time { get; set; }

    }
}
