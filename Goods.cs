using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW1
{
    public class Goods
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Color { get; set; }
        public int Calories { get; set; }

        public Goods(int id, string? name, string? type, string? color, int calories)
        {
            Id = id;
            Name = name;
            Type = type;
            Color = color;
            Calories = calories;
        }
    }
}
