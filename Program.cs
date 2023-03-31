using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("CalculatorCliTest")]
namespace CalculatorCli
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.MainLoop();
        }
    }
}
