using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuberMarket
{
    internal class Branch
    {
        public static int BranID = 1;
        public int ID;
        public string Name;
        public Product[] Products=new Product[50];
        public Employee[] Employees=new Employee[50];
        int IdxEmp = 0, IdxProd = 0;
        

        public Branch():this ("N\\A"){ }

        public Branch(string Name)
        {
            this.ID = BranID++;
            this.Name = Name;
        }

        public void AddEmp(Employee emp)
        {
            Employees[IdxEmp++] = emp.Clone();
            SetDataInFiles();
        }

        public int SeachProdInBrach(Product prod)
        {
           
            for (int i = 0; i < IdxProd; i++)
            {
                if (prod.Name == Products[i].Name) return i;
            }
            return -1;
        }

        public void AddProd(Product prod) {
            int idx= SeachProdInBrach(prod);
            if (idx >= 0)
            {
                Products[idx].Amount += prod.Amount;
            }
            else
            {
                Products[IdxProd++] = prod.Clone();
            }
            SetDataInFiles();
        }

        public void SetDataInFiles()
        {
            string path = $"{Program.MyFiles}Employees.txt";
            File.WriteAllText(path, "");
            for (int i = 0; i < IdxEmp; i++)
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(Employees[i].GetData());
                }
            }
            path = $"{Program.MyFiles}Products.txt";
            File.WriteAllText(path, "");
            for (int i = 0; i < IdxProd; i++)
            {
                using (StreamWriter writer = new StreamWriter(path,true))
                {
                    writer.WriteLine(Products[i].GetData());
                }
            }
        }

        public void ShowAllProducts()
        {
            for(int i = 0;i < IdxProd; i++)
            {
                System.Console.WriteLine(Products[i].ToString());
            }
        }
        public void ShowAllEmployees()
        {
            for (int i = 0; i < IdxEmp; i++)
            {
                System.Console.WriteLine(Employees[i].ToString());
            }
        }
    }
}
