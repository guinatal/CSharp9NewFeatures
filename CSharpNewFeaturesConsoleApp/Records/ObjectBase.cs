using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNewFeaturesConsoleApp.Records
{
    public abstract record ObjectBase(string Name)
    {
        public string Test { get; set; }
    };
}
