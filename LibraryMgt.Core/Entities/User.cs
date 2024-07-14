using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryMgt.Core.Entities
{
    // Derived class
    public class User : BaseUser // Syntax for inheritance
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        public string UserType { get; set; } // Customer, Owner, Book keeper, Librarian

        // Access Modifiers
        // public is avalaiable to everyone
        // private is only available in this Object i.e User
        // protected are only available here in the object and derived objects
        // internal only objects in same can see or use this guys
        // protected internal - Only to derived class/object and same Assembly
        private DateTime _lastUpdateTime = DateTime.Now;

        internal DateTime LastUpdateTime { get; set; } = DateTime.Now;
        protected internal string ActiveTime;

        // method of User object...
    }
}