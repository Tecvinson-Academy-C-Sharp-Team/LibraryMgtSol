using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgt.Core.Entities
{
    public abstract class Animal
    {
        public string Move()
        {
            Console.WriteLine("Moving .....");
            return "Moving";
        }

        public void Eat()
        {
            Console.WriteLine("Eating....");
        }
    }
}