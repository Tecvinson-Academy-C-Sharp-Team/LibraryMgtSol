﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgt.Core.Entities
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message) : base(message) { }
    }
}
