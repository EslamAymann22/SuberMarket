using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuberMarket
{
    class Product
    {


        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

        public static int ProdID = 1;

        public Product() : this("N\\A", 0, 0) { }
        public Product(string Name, double Price, int Amount)
        {
            ID = ProdID++;
            this.Name = Name;
            this.Price = Price;
            this.Amount = Amount;
        }

        public override string ToString()
        {
            return $"ID = {ID} , Name = {Name} , Amount = {Amount} , Price {Price}$";
        }

        public static bool SameProd(Product p1,Product p2)
        {
            return (p1.ID == p2.ID);
        }

        public void ChangeAmount(int amount)
        {

            string Msg= "Amount not enough";
            
            try
            {
                if (Amount + amount < 0) throw new Exception();
               
                this.Amount += amount;

            }
            catch {
                System.Console.WriteLine(Msg);
            }
        

        }

        public void ChangePrice(double price)
        {

            string Msg = "Price Can't be less than 0 !!";

            try
            {
                if (price < 0) throw new Exception();
                this.Price = price;
            }
            catch
            {
                System.Console.WriteLine(Msg);
            }

        }

        public void ChangePriceWithpercentage(double percentage) {

            percentage /= 100;

            this.Price += percentage * this.Price;

            this.Price = Math.Max(this.Price, 0);


        }

    }
}
