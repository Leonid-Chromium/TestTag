﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTag
{
    public class Tag
    {
        public string name { get; set; }
        public string color { get; set; }

        public Tag(string name, string color)
        {
            this.name = name;
            this.color = color;
        }
    }
}
