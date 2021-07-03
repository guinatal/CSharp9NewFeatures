using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNewFeaturesConsoleApp.Records
{
    public record Desk(string Name, string Color) : ObjectBase(Name);
}
