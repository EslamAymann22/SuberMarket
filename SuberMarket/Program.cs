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
      


        class test
        {
            test()
            {
                Console.WriteLine("Eslam");
            }
        }

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

            //Branch x = new Branch("Sohag");

            //x.AddProd(new Product("Al3arosa", 15, 300));
            //x.AddProd(new Product("lepton", 50, 900));
            //x.AddProd(new Product("Al3arosa", 15, 300));

            //x.ShowAllProducts();

            Market M = new Market("Eslam");

            M.AddBranch(new Branch("Sohag"));
            M.Branchs[0].AddProd(new Product("Al3arosa", 15, 600));
            M.Branchs[0].AddProd(new Product("Lepton", 30, 900));
            return;
            M.AddBranch(new Branch("Assiut"));






            // to read from file
            string path = $"{DataBaseFile.MyFiles}Employees.txt";
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
