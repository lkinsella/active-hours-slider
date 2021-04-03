using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Codeology.ActiveHours.Slider
{
    public static class Program
    {
        public static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new Service()
            };

            ServiceBase.Run(servicesToRun);
        }
    }
}
