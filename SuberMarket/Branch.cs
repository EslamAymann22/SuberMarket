using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuberMarket
{
    public class Branch
    {
        public static int BranID = 1;
        public int ID;
        public string Name;
        public Product[] Products=new Product[90];
        public Employee[] Employees=new Employee[90];
        int IdxEmp = 0, IdxProd = 0;
        

        public Branch():this ("N/A"){
            for (int i = 0; i < 50; i++)
            {
                Products[i] = new Product();
                Employees[i] = new Employee();
            }
        }

        public Branch(string Name)
        {
            this.ID = BranID++;
            this.Name = Name;
        }

        public void AddEmp(Employee emp)
        {
            Employees[IdxEmp++] = emp.Clone();
        }

        

        public int SeachProdInBrach(Product prod)
        {
           
            for (int i = 0; i < IdxProd; i++)
            {
                if (prod.Name == Products[i].Name) return i;
            }
            return -1;
        }

        public void AddProd(Product prod)
        {
            int idx = SeachProdInBrach(prod);
            if (idx >= 0)
            {
                Products[idx].Amount += prod.Amount;
            }
            else
            {
                Products[IdxProd++] = prod;
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

        public Branch Clone()
        {
            Branch ret = (Branch)this.MemberwiseClone();
            for(int i = 0; i < 50; ++i)
            {
                ret.Employees[i]= this.Employees[i].Clone();
                ret.Products[i]= this.Products[i].Clone();
            }

            return ret;
        }

    }
}
