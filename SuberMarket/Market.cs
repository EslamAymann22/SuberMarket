using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuberMarket.Program;
using static System.Console;


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
                    WriteLine(i);
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
        public static void GetDataInFileEmployee(Market MyMarket)
        {
            string path = $"{MyFiles}Employees.txt";
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
                string[] s = line.Split(',');
                int IdBranch=int.Parse(s[0]);
                int IdEmp=int.Parse(s[1]);
                string EmpName=s[2];
                double Salary=double.Parse(s[3]);
                int Rolee=int.Parse(s[4]);
                MyMarket.Branchs[IdBranch].Employees[IdEmp].ID = IdEmp;
                MyMarket.Branchs[IdBranch].Employees[IdEmp].Name = EmpName;
                MyMarket.Branchs[IdBranch].Employees[IdEmp].Salary = Salary;
                MyMarket.Branchs[IdBranch].Employees[IdEmp].role = (Role)Rolee;
            }
        }
        public static void GetDataInFileProduct(Market MyMarket)
        {
            string path = $"{MyFiles}Products.txt";
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] s = line.Split(',');
                int IdBranch = int.Parse(s[0]);
                int IdProd = int.Parse(s[1]);
                string ProdName = s[2];
                double Price = double.Parse(s[3]);
                int Amount = int.Parse(s[4]);
    
                MyMarket.Branchs[IdBranch].Products[IdProd].ID = IdProd;
                MyMarket.Branchs[IdBranch].Products[IdProd].Name = ProdName;
                MyMarket.Branchs[IdBranch].Products[IdProd].Price = Price;
                MyMarket.Branchs[IdBranch].Products[IdProd].Amount = Amount;
            }
        }
        public static void GetDataInFileAll(Market MyMarket)
        {
            GetDataInFileProduct(MyMarket);
            GetDataInFileEmployee(MyMarket);
        }
    }
    public class Market
    {

        int IdxBranch = 0;
        public Branch[] Branchs=new Branch[90];
        public string Name;
        public Market(string Name) 
        {
            for (int i = 0; i < 50; i++) { 
                Branchs[i] = new Branch();
            }
            this.Name = Name;
            //WriteLine("STaaaaaaaaaaaaaaaaaaart!!!!!!!!!!");///////////////////////////////de
            DataBaseFile.GetDataInFileAll(this);
            //WriteLine("EnDDDDDDDDDDDDDDDDDDDDd~~~~~~~~~~");///////////////////////////////de
        }


        public void AddBranch(Branch branch)
        {
            Branchs[IdxBranch++] = branch;
        }


        ~Market()
        {
            DataBaseFile.SetDataInFileAll(this);
        }

    }
}
