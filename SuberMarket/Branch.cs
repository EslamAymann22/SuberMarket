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
        public Employee[] employees=new Employee[50];
        int IdxEmp = 0, IdxProd = 0;
        

        public Branch():this ("N\\A"){ }

        public Branch(string Name)
        {
            this.ID = BranID++;
            this.Name = Name;
        }

        public void AddEmp(Employee emp)
        {
            employees[IdxEmp++] = emp.Clone();
        }

        public int SeachProdInBrach(Product prod)
        {
           
            for (int i = 0; i < IdxProd; i++)
            {
                if (prod.ID == Products[i].ID) return i;
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
        }

        public void SetData()
        {
           for(int i = 0; i < IdxEmp; i++)
            {

            }
        }

    }
}
