using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNewFeaturesConsoleApp.Records
{
    public record Airplane
    {
        public string Name { get; init; }
        public string Type { get; init; }
    }
}
