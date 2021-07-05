﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNewFeaturesConsoleApp.Records
{
    public abstract record Person(string FirstName, string LastName)
    {
        public virtual Person GetPerson()
        {
            return this;
        }
    };
}
