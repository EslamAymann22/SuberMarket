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

        public int IdxEmp = 0, IdxProd = 0;
        
        public Branch(string Name)
        {
            this.ID = BranID++;
            this.Name = Name;
        }

        public void AddEmp(Employee emp)
        {
            Employees[IdxEmp++] = emp.Clone();
        }

        

        public int SeachProdInBrach(string Name)
        {
           
            for (int i = 0; i < IdxProd; i++)
            {
                if (Name == Products[i].Name) return i;
            }
            return -1;
        }

        public void AddProd(string FName,double FPrice,int FAmount)
        {
            int idx = SeachProdInBrach(FName);
            if (idx >= 0)
            {
                Products[idx].Amount += FAmount;
            }
            else
            {
                Products[IdxProd++] = new Product(FName,FPrice,FAmount);
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
            ret.Employees = new Employee[50];
            ret.Products = new Product[50];
            for(int i = 0; i < 50; ++i)
            {
                if (this.Employees[i] != null)
                    ret.Employees[i] = this.Employees[i].Clone();
                if (this.Products[i] != null)
                    ret.Products[i] = this.Products[i].Clone();
            }
            return ret;
        }


        public int NumberOfEmployees() { return IdxEmp; }
        public int NumberOfProducts() { return IdxProd; }

    }
}
