using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace SuberMarket
{

    internal class Program
    {
        public static string MyFiles = "C:\\Users\\hhhh\\source\\repos\\SuberMarket\\SuberMarket\\MyFiles\\";

        static void Main(string[] args)
        {

            //Employee x = new Employee("Eslam",15000,(Role)(Role.Cashier|Role.Security),1);


            //WriteLine(x.Salary);
            //Employee y = x + 50;
            //WriteLine(x.Salary);
            //x += 50;
            //WriteLine(x.Salary);
            //Product x = new Product("Al3arosa",15,20);

            //WriteLine(x.ToString());
            //x.ChangePriceWithpercentage(-50);  
            //WriteLine(x.ToString());
            //x.ChangePriceWithpercentage(-50);  
            //WriteLine(x.ToString());
            //x.ChangePriceWithpercentage(-50);  
            //WriteLine(x.ToString());






            return;
            // to read from file
            string path = $"{MyFiles}Employees.txt";
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            //to write in file with last data
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine("This is a new line.");
            }


            // to write in file after clean the file data
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("This will overwrite the file content.");
            }

     

        }
    }
}
