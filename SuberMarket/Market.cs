using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
                    if (MyMarket.Branchs[i] == null) continue;
                    for (int j = 0; j < 50; ++j)
                    {
                        if (MyMarket.Branchs[i].Employees[j] == null) continue;

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
       
                    if (MyMarket.Branchs[i] == null) continue;
                    for (int j = 0; j < 50; ++j)
                    {
                        if (MyMarket.Branchs[i].Products[j] == null) continue;

                        writer.WriteLine($"{i},{MyMarket.Branchs[i].Products[j].GetData()}");

                    }
                }
            }
        }
        public static void SetDataInFileBraName(Market MyMarket)
        {
            string path = $"{MyFiles}BraName.txt";

            File.WriteAllText(path, ""); // to clear file data

            using (StreamWriter writer = new StreamWriter(path))
            {

                for (int i = 0; i < MyMarket.IdxBranch; ++i)
                {
                    writer.WriteLine(MyMarket.BraName[i]);   
                }
            }
        }
        public static void SetDataInFileAll(Market MyMarket)
        {
            SetDataInFileProduct(MyMarket);
            SetDataInFileBraName(MyMarket);
            SetDataInFileEmployee(MyMarket);
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

                if (MyMarket.Branchs[IdBranch] == null)
                    MyMarket.Branchs[IdBranch] = new Branch(MyMarket.BraName[IdBranch]);

                MyMarket.
                    Branchs[IdBranch].
                    Employees[MyMarket.Branchs[IdBranch].IdxEmp++] = new Employee(EmpName, Salary, Rolee);
            }
        }
        public static void GetDataInFileProduct(Market MyMarket)
        {
            string path = $"{MyFiles}Products.txt";
            string[] lines = File.ReadAllLines(path);
            //int ProdID = 1;
            foreach (string line in lines)
            {
                string[] s = line.Split(',');
                int IdBranch = int.Parse(s[0]);
                int IdProd = int.Parse(s[1]);
                string ProdName = s[2];
                double Price = double.Parse(s[3]);
                int Amount = int.Parse(s[4]);
                //if (MyMarket.Branchs[IdBranch] == null)
                    //MyMarket.Branchs[IdBranch] = new Branch(MyMarket.BraName[IdBranch]);

                MyMarket.
                    Branchs[IdBranch].
                    Products[MyMarket.Branchs[IdBranch].IdxProd++]
                    = new Product(ProdName, Price, Amount);
            }
        }
        public static void GetDataInFileBraName(Market MyMarket)
        {
            string path = $"{MyFiles}BraName.txt";
            string[] lines = File.ReadAllLines(path);
            int id = 0;
            foreach (string line in lines)
            {
                MyMarket.BraName[id] = line;
                MyMarket.Branchs[id]=new Branch(MyMarket.BraName[id]);
                id++;
              //  WriteLine(MyMarket.BraName[id - 1]);
            }
        }
        public static void GetDataInFileAll(Market MyMarket)
        {
            GetDataInFileBraName(MyMarket);
            GetDataInFileProduct(MyMarket);
            GetDataInFileEmployee(MyMarket);
            return;
        }
    }
    public class Market
    {

        public int IdxBranch = 0;
        public Branch[] Branchs=new Branch[50];
        public string[] BraName = new string[50];
        public string Name;
        public Market(string Name) 
        {
            this.Name = Name;
            //DataBaseFile.GetDataInFileAll(this);
        }


        public void AddBranch(Branch branch)
        {
            Branchs[IdxBranch] = branch.Clone();
            BraName[IdxBranch++] = branch.Name;
        }


        ~Market()
        {
            DataBaseFile.SetDataInFileAll(this);
        }

    }
}
