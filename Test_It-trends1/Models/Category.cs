﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_It_trends1.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Article> Articles { get; set; } = new();
    }
}
