using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace SuberMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Employee x = new Employee("Eslam",15000,(Role)(Role.Cashier|Role.Security),1);


            //WriteLine(x.Salary);
            //Employee y = x + 50;
            //WriteLine(x.Salary);
            //x += 50;
            //WriteLine(x.Salary);
            Product x = new Product("Al3arosa",15,20);

            WriteLine(x.ToString());
            x.ChangePriceWithpercentage(-50);  
            WriteLine(x.ToString());
            x.ChangePriceWithpercentage(-50);  
            WriteLine(x.ToString());
            x.ChangePriceWithpercentage(-50);  
            WriteLine(x.ToString());
            
        }
    }
}
