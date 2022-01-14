using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _55.HelloStaticAndDynamicResources
{

    public class SuperClass
    {
        public string Str1 { get; set; } = "По умолчанию";

        public override string ToString()
        {
            return Str1+" Super";
        }
    }
}
