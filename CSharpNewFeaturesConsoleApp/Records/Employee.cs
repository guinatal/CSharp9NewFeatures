using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNewFeaturesConsoleApp.Records
{
    public record Employee(string FirstName, string LastName, string Role) : Person(FirstName, LastName)
    {
        public override Employee GetPerson()
        {
            return this;
        }
    };
}
