using System.Collections.Generic;

namespace TemplateMethodRefactored.Models
{
    public class Pizza : PanFood
    {
        public string CrustType { get; set; } = "no crust";

        public int NumSlices { get; set; } = 1;

        public List<string> Toppings { get; private set; } = new();

        public bool WasBaked { get; set; }
    }
}
