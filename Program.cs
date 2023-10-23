using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        async static Task Main(string[] args)
        {
            // This is our employee-getting code now
            List<Employee> employees = new List<Employee>();

            if (args.Length > 0 && args[0] == "help")
            {
                Console.WriteLine("Use the 'api' argument to fetch employee data from API");
            }
            else if (args.Length > 0 && args[0] == "api")
            {
                employees = await PeopleFetcher.GetFromApi();
            }
            else
            {
                employees = PeopleFetcher.GetEmployees();
            }

            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadges(employees);
        }
    }
}