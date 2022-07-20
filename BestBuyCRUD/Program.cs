using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;


namespace BestBuyCRUD
{
    class Program
    {
        #region Configuration
        
        static IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        static string connString = config.GetConnectionString("DefaultConnection");

        //gives us a connection to the MySQL data
        static IDbConnection conn = new MySqlConnection(connString);
        #endregion


        static void Main(string[] args)
        {
            ListProducts();

            DeleteThisProduct();

            ListProducts();

        }

        public static void DeleteThisProduct()
        {
            var prodRepo = new DapperProductRepository(conn);

            Console.WriteLine("Please enter the Product ID of the product you would like to delete");
            var productID = Convert.ToInt32(Console.ReadLine());

            prodRepo.DeleteProduct(productID);
        }

        public static void UpdateProductName()
        {
            var prodRepo = new DapperProductRepository(conn);

            Console.WriteLine($"What is the Product ID of the product you wish to update?");
            var productID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"What is the new name you would like for the product with the ID of {productID}");
            var updatedName = Console.ReadLine();

            prodRepo.UpdateProduct(productID, updatedName);
        }

 
        public static void CreateNewProducts()
        {
            var prodRepo = new DapperProductRepository(conn);

            Console.WriteLine($"What is the new product name?");
            var prodName = Console.ReadLine();

            Console.WriteLine($"What is the price of the new product?");
            var price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"What is the new product's Category ID (Number should be between 1 and 10)");
            var categoryID = Convert.ToInt32(Console.ReadLine());

            prodRepo.CreateProduct(prodName, price, categoryID);

            var products = prodRepo.GetAllProducts();

            Console.WriteLine("Updated Product List:");
            
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID:  {product.ProductID}     Product Name:  {product.Name}");
            }
        }


 
        public static void AddDepartment()
        {
            
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);


            //gives user ability to add a department
            Console.WriteLine("Hello user, here are the current departments:");
            Console.WriteLine("Please press enter . . .");
            Console.ReadLine();

            var depos = repo.GetAllDepartments();
            ListDepartments();


            Console.WriteLine("Do you want to add a department?");
            string userResponse = Console.ReadLine();

            if (userResponse.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of you new Department?");
                userResponse = Console.ReadLine();

                repo.InsertDepartment(userResponse);
                ListDepartments();
            }

            Console.WriteLine("Have a great day.");

        }




        public static void ListDepartments()
        {
            var repo = new DapperDepartmentRepository(conn);

            var departments = repo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"Department ID: {department.DepartmentID}      Name: {department.Name} ");
                Console.WriteLine("                                                                  ");
            }

            Console.WriteLine("------------------------------------");

        }


  
        public static void ListProducts()
        {
            var repo = new DapperProductRepository(conn);

            var products = repo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductID}      Name: {product.Name} ");                
            }

            Console.WriteLine("------------------------------------");
        }




    }
}
