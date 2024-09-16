using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;
namespace SuberMarket
{

    public static class RunProg
    {
        public static string CatchMSG = "Your input was wrong !!!";

        public static void Run(Market MyMarket)
        {

            if (MyMarket.Name == "")
            {
                WriteLine("Enter your market name");
                MyMarket.Name = ReadLine();
            }

            int Button = -1;

            while (Button >= -1) {

                WriteLine("1. Add new branch.\n" +
                          "2. Show all branches.\n" +
                          "3. To exit from program");


                WriteLine("Choose number !");
                string s = ReadLine();
                try
                {
                    Button = int.Parse(s);
                    if (Button == 1)
                    {
                        WriteLine("Enter branch name");
                        s = ReadLine();
                        MyMarket.AddBranch(new Branch(s));
                    }
                    else if (Button == 2)
                    {
                        while (true)
                        {
                            MyMarket.ShowAllBranches();

                            WriteLine($"Choose one branch with ID ! from 1 - {MyMarket.NumberOfBranches()}\n" +
                                $"Enter -1 for exit ");
                            int id = int.Parse(ReadLine());
                            if (id <= MyMarket.NumberOfBranches() && id > 0)
                            {
                                BrancheConfig(MyMarket.Branches[id - 1]);
                            }
                            else return;
                        }
                    }
                    else if (Button == 3) return;
                    else continue;

                }
                catch {
                    WriteLine(CatchMSG);
                    Button = -1;
                }

            }



        }

        public static void BrancheConfig(Branch MyBranch)
        {
            bool IsPowerOf2(int n)
            {
                while (n > 0 && n % 2 == 0) n >>= 1;
                return n == 1;

            }
            void EditBranchName()
            {
                WriteLine("Enter new name for this branch !");
                string newName = ReadLine();
                MyBranch.Name = newName;
            }
            void AddEmployee()
            {
                string EName;
                double ESalary;
                int ERole = 0;

                WriteLine("Enter employee name !");
                EName = ReadLine();
                WriteLine("Enter employee salary !");
                ESalary = double.Parse(ReadLine());

                WriteLine("Enter employee role (multiple role is valid with separated space ) !\n" +
                    $"{(int)Role.Cashier}. as a Cashier\n" +
                    $"{(int)Role.Cleaner}. as a Cleaner\n" +
                    $"{(int)Role.Security}. as a Security\n" +
                    $"{(int)Role.ProduceClerk} as a ProduceClerk");

                string[] ERoleA = ReadLine().Split(' ');
                foreach (string e in ERoleA) {
                    int Num = int.Parse(e);
                    if (Num > 8 || !IsPowerOf2(Num)) continue;
                    ERole |= Num;
                }
                Employee NewEmp = new Employee(EName, ESalary, ERole);


                MyBranch.Employees[MyBranch.IdxEmp++] = NewEmp;
            }
            void AddProduct()
            {
                try
                {
                    string PName;
                    double PPrice;
                    int PAmount;
                    WriteLine("Enter product name !");
                    PName = ReadLine();
                    WriteLine("Enter product price !");
                    PPrice = double.Parse(ReadLine());
                    WriteLine("Enter product amount !");
                    PAmount = int.Parse(ReadLine());

                    Product NewProd = new Product(PName, PPrice, PAmount);
                    MyBranch.Products[MyBranch.IdxProd++] = NewProd;
                }
                catch { WriteLine(CatchMSG); }

            }
            void ShowAllProducts()
            {
                while (true)
                {
                    MyBranch.ShowAllProducts();
                    WriteLine($"Choose number from 1 - {MyBranch.NumberOfProducts()}\n" +
                        $"Enter -1 for return back");
                    try
                    {
                        int ch = int.Parse(ReadLine());
                        if (ch <= -1) return;
                        else
                        {
                            ProductConfig(MyBranch.Products[ch - 1]);
                        }
                    }
                    catch { WriteLine(CatchMSG); }
                }
            }
            void ShowAllEmployees()
            {
                MyBranch.ShowAllEmployees();
                WriteLine($"Choose number from 1 - {MyBranch.NumberOfEmployees()}\n" +
                    $"Enter -1 for return back");
                try
                {
                    int ch = int.Parse(ReadLine());
                    if (ch <= -1) return;
                    else
                    {
                        EmployeeConfig(MyBranch.Employees[ch - 1]);
                    }
                }
                catch { WriteLine(CatchMSG); }
            }
            string SearchProdInBrach()
            {
                WriteLine("Enter the Product Name!");
                int idx = MyBranch.SeachProdInBrach(ReadLine());
                if (idx < 0) return "Product not founded";
                return MyBranch.Products[idx].ToString();
            }
            void ShowAllBranchData()
            {
                WriteLine($"Branch name is {MyBranch.Name}\n" +
                    $"Branch ID = {MyBranch.Name}\n" +
                    $"Number of employees = {MyBranch.NumberOfEmployees()}\n" +
                    $"Number of products = {MyBranch.NumberOfProducts()}");
            }

            while (true)
            {

                WriteLine("1. To edit branch name\n" +
                    "2. To add new employee \n" +
                    "3. To add new product \n" +
                    "4. To show all employees\n" +
                    "5. To show all products\n" +
                    "6. To search for product \n" +
                    "7. To show all branch Data\n" +
                    "8. To return back.");

                try
                {
                    int ch=int.Parse(ReadLine());
                    switch(ch)
                    {
                        case 1:EditBranchName();break;
                        case 2:AddEmployee();break;
                        case 3:AddProduct();break;
                        case 4:ShowAllEmployees(); break; 
                        case 5: ShowAllProducts(); break;
                        case 6: SearchProdInBrach(); break;
                        case 7: ShowAllBranchData(); break;
                        case 8:return;
                    }

                }
                catch { WriteLine(CatchMSG); }

            }
        }

    
        public static void EmployeeConfig(Employee MyEmployee)
        {

        }
        public static void ProductConfig(Product MyProduct)
        {

        }
    }
}