using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeology.ActiveHours.Slider.Console
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            System.Console.WriteLine("Active Hours Slider for Windows Update");
            System.Console.WriteLine();

            try
            {
                System.Console.WriteLine("Running...");

                var slider = new ActiveHoursSlider();
                var newHours = slider.Slide();

                if (newHours == null)
                {
                    System.Console.WriteLine("No changes to apply.");
                }
                else
                {
                    System.Console.WriteLine($"New Active Hours: {newHours.Start:D2} - {newHours.End:D2}");
                }

                System.Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error: {ex}");

                return 666;
            }

            System.Console.WriteLine();

            return 0;
        }
    }
}
