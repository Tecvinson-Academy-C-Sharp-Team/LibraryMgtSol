using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgt.Core.Entities
{
    public class Dog : Animal
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public void Move(string direction)
        {
            Console.WriteLine($"{direction}");
        }

        public void EatAndMove(string direction)
        {
            this.Eat();
            this.Move(direction);
        }
    }
}