using System;
using System.Collections.Generic;

namespace ShopMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Product Catalog

            List<Product> catalog = new()
            {
                new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
                new Product { Id=2, Name="Phone", Category="Electronics", Price=800, Stock=25 },
                new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
                new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
                new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
                new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
                new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
                new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
                new Product { Id=9, Name="Headphones", Category="Electronics", Price=150, Stock=40 },
                new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
            };

            #endregion


            #region Task 01 - Smart Product Search

            #region 1 - Electronics Products

            Console.WriteLine("--- Electronics ---");

            List<Product> electronics =
                ProductOperations.SearchProducts(
                    catalog,
                    p => p.Category == "Electronics");

            foreach (Product p in electronics)
            {
                Console.WriteLine(
                    $"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }

            #endregion


            #region 2 - Products Under $50

            Console.WriteLine("\n--- Under $50 ---");

            List<Product> cheapProducts =
                ProductOperations.SearchProducts(
                    catalog,
                    p => p.Price < 50);

            foreach (Product p in cheapProducts)
            {
                Console.WriteLine(
                    $"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }

            #endregion


            #region 3 - Products In Stock

            Console.WriteLine("\n--- In Stock ---");

            List<Product> inStock =
                ProductOperations.SearchProducts(
                    catalog,
                    p => p.Stock > 0);

            foreach (Product p in inStock)
            {
                Console.WriteLine(
                    $"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }

            #endregion


            #region 4 - Clothing Under $100

            Console.WriteLine("\n--- Clothing Under $100 ---");

            List<Product> clothing =
                ProductOperations.SearchProducts(
                    catalog,
                    p => p.Category == "Clothing" && p.Price < 100);

            foreach (Product p in clothing)
            {
                Console.WriteLine(
                    $"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }

            #endregion

            #endregion


            #region Task 03 - Custom Report Generator

            #region 3.1 - Print Reports

            #region Scenario 1 - Short Report

            // Action<Product> is used because no value is returned.

            Console.WriteLine("\n--- Short Report ---");

            ProductOperations.PrintReport(
                catalog,
                p => Console.WriteLine(
                    $"{p.Name} - ${p.Price}"));

            #endregion


            #region Scenario 2 - Detailed Report

            Console.WriteLine("\n--- Detailed Report ---");

            ProductOperations.PrintReport(
                catalog,
                p => Console.WriteLine(
                    $"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));

            #endregion

            #endregion


            #region 3.2 - Transform Products

            #region Scenario 3 - Summary List

            // Func<Product, string> converts each product to a string.

            Console.WriteLine("\n--- Summary List ---");

            List<string> summaries =
                ProductOperations.TransformProducts(
                    catalog,
                    p => $"{p.Name} (${p.Price})");

            foreach (string summary in summaries)
            {
                Console.WriteLine(summary);
            }

            #endregion


            #region Scenario 4 - Price Labels

            Console.WriteLine("\n--- Price Labels ---");

            List<string> labels =
                ProductOperations.TransformProducts(
                    catalog,
                    p => p.Price > 100
                        ? "Expensive!"
                        : "Affordable");

            for (int i = 0; i < catalog.Count; i++)
            {
                Console.WriteLine(
                    $"{catalog[i].Name}: {labels[i]}");
            }

            #endregion

            #endregion


            #region 3.3 - Filter Products

            #region Scenario 5 - Low-Stock Alert

            // Predicate<Product> returns true or false.

            Console.WriteLine("\n--- Low-Stock Alert ---");

            List<Product> lowStock =
                ProductOperations.FilterProducts(
                    catalog,
                    p => p.Stock < 20);

            foreach (Product p in lowStock)
            {
                Console.WriteLine(
                    $"[LOW STOCK] {p.Name}: only {p.Stock} left!");
            }

            #endregion

            #endregion

            #endregion
        }
    }
}