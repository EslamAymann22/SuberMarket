using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace SuberMarket
{
    public static class RunProg
    {

        public static void Run(Market MyMarket)
        {

            if (MyMarket.Name == "")
            {
                WriteLine("Enter your market name");
                MyMarket.Name = ReadLine();
            }

            int Button = -1;

            while (Button>=-1) {

                WriteLine("1. Add new branch.\n" +
                          "2. Show all branches.");


                WriteLine("Choose number !");
                string s = ReadLine();
                try
                {
                    Button=int.Parse(s);
                    if (Button == 1)
                    {
                        WriteLine("Enter branch name");
                        s= ReadLine();
                        MyMarket.AddBranch(new Branch(s));
                    }
                    else if (Button == 2)
                    {
                        MyMarket.ShowAllBranches();
                    }
                    else continue;

                }
                catch {
                    Button = -1;
                }

            }



        }



    }
}
