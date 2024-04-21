using System;                     //Systems used
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml.Linq;

namespace Lab2
{
    class Product
    {
        public string Name { get; set; }
        public double Cost { get; set; }
    }

    class OrderDetail
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
           
            List<Product> products = new List<Product>(); //use this to create order detail
            List<OrderDetail> orderDetailList = new List<OrderDetail>();

            products.Add(new Product { Name = "Banana", Cost = 8 });
            products.Add(new Product { Name = "Strawerry", Cost = 12 });
            products.Add(new Product { Name = "Sunglasses", Cost = 10 });
            products.Add(new Product { Name = "Beachball", Cost = 5 });
            products.Add(new Product { Name = "Pool Floatie", Cost = 20 });
            products.Add(new Product { Name = "Waterbottles", Cost = 15 });
            products.Add(new Product { Name = "JuiceBoxes", Cost = 35 });
            products.Add(new Product { Name = "PinkSwimsuit", Cost = 5 });
            products.Add(new Product { Name = "BlueSwimsuit", Cost = 5 });
            products.Add(new Product { Name = "RedSwimsuit", Cost = 5 });
            products.Add(new Product { Name = "Coconuts", Cost = 15 }); 
            products.Add(new Product { Name = "Sunscreen", Cost = 7 });
           
            int maxSelection = products.Count; //tells u how many products in list
            int maxLolQuantity = 100; 
            int index = 1;

            foreach (Product product in products)
            {
                Console.WriteLine($"{index, 3}. {product.Name , -15 } {product.Cost , 8:C2}");
                index++;
            }

            Console.WriteLine();
            //  Console.Write("Enter the number of your selection: ");
            // string selection;
            // outer loop starts here
            bool done = false;

            int quantity = 0; ///for quantity 
            while (!done)
            {

                int sel = 0;
                bool more = true;
                while (more)
                {
                    Console.Write($"Please input a number of your selection between 1-{maxSelection} (-1 to Exit) : ");
                    int.TryParse(Console.ReadLine(), out sel);
                    more = !((sel >= 1 && sel <= maxSelection) || sel == -1);
                }
                if (sel > 0)
                {
                 
                 
                    bool lol = true;

                    while (lol)
                    {
                        Console.Write($"Enter the quantity of {products[sel - 1].Name} (Max 100): ");
                        int.TryParse(Console.ReadLine(), out quantity);

                        lol = !(quantity >= 1 && quantity <= maxLolQuantity);
                    }
                    Console.WriteLine();
                     OrderDetail detail = new OrderDetail {  Name = products[sel - 1].Name, Cost = products[sel - 1].Cost, Quantity = quantity };
                     orderDetailList.Add(detail);
                }
                else
                {
                    done = true;
                }
            
            }
            double subTotal = 0;
            double taxRate = 0.13;
            // double tax;
            // double totalWithtax;

            Console.WriteLine();
           // Console.WriteLine("header goes here");
            string[] hdr = { "name", "cost", "quantity", "extension" };
            Console.WriteLine($"{hdr[0], -15} {hdr[1], 7} {hdr[2], 9} {hdr[3], 12}");
            Console.WriteLine(new String('-', 46));
            foreach (OrderDetail detail1 in orderDetailList)
            {
                double total = detail1.Quantity * detail1.Cost;
                subTotal = subTotal + total;
                Console.WriteLine($"{detail1.Name, -12} {detail1.Cost, 10:N2} {detail1.Quantity, 6:N0} {total, 15:N2} "); //will tell us if we put stuff into the list
            }
            Console.WriteLine(new String('-', 46));
            double tax = subTotal * taxRate;
            double totalWithtax = subTotal + tax; 
            string[] ftr = { "subTotal:", "tax:", "totalWithtax:" };
            Console.WriteLine($"{ftr[0], -30} {subTotal, 15:N2}");
            Console.WriteLine($"{ftr[1],-30} {tax, 15:N2}");
            Console.WriteLine($"{ftr[2],-30} {totalWithtax, 15:N2}");
            Console.ReadKey();

            //Outer loop ends HEREEEEEEE

        }
    }
}