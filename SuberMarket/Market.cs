using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuberMarket.Program;

namespace SuberMarket
{

    public class DataBaseFile
    {
        public static string MyFiles = "C:\\Users\\hhhh\\source\\repos\\SuberMarket\\SuberMarket\\MyFiles\\";
        public static void SetDataInFileEmployee(Market MyMarket)
        {
            string path = $"{MyFiles}Employees.txt";

            File.WriteAllText(path, ""); // to clear file data

            using (StreamWriter writer = new StreamWriter(path))
            {

                for (int i = 0; i < 50; ++i)
                {
                    if (MyMarket.Branchs[i].Name == "N/A") break;
                    for (int j = 0; j < 50; ++j)
                    {
                        if (MyMarket.Branchs[i].Employees[j].Name == "N/A") break;

                        writer.WriteLine($"{i},{MyMarket.Branchs[i].Employees[j].GetData()}");

                    }
                }
            }
        }
        public static void SetDataInFileProduct (Market MyMarket)
        {
            string path = $"{MyFiles}Products.txt";

            File.WriteAllText(path, ""); // to clear file data

            using (StreamWriter writer = new StreamWriter(path))
            {

                for (int i = 0; i < 50; ++i)
                {
                    if (MyMarket.Branchs[i].Name == "N/A") break;
                    for (int j = 0; j < 50; ++j)
                    {
                        if (MyMarket.Branchs[i].Products[j].Name == "N/A") break;

                        writer.WriteLine($"{i},{MyMarket.Branchs[i].Products[j].GetData()}");

                    }



                }
            }
        }
        public static void SetDataInFileAll(Market MyMArket)
        {
            SetDataInFileEmployee(MyMArket);
            SetDataInFileProduct(MyMArket);
        }
        public static void GetDataInFileEmployee()
        {
            string path = $"{MyFiles}Employees.txt";
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        public static void GetDataInFileProduct()
        {
            string path = $"{MyFiles}Products.txt";
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        public static void GetDataInFileAll()
        {
            GetDataInFileEmployee();
            GetDataInFileProduct();
        }
    }
    public class Market
    {

        public Branch[] Branchs=new Branch[50];
        public string Name;
        public Market(string Name) 
        {
            this.Name = Name;
            DataBaseFile.GetDataInFileAll();
        }


        ~Market()
        {
            DataBaseFile.SetDataInFileAll(this);
        }

    }
}
