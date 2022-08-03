using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Models
{
    public class Item
    {
        public Item()
        {
            Name = string.Empty;
        }

        public string Name { get; set; }
        public int Type { get; set; }
        public int Value { get; set; }
    }
}
