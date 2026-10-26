using System;
using System.Collections.Generic;

namespace ShopMaster
{
    internal class ProductOperations
    {
        #region Task 01 - Smart Product Search

        // Func<Product, bool> allows different search conditions.
        public static List<Product> SearchProducts(
            List<Product> products,
            Func<Product, bool> filter)
        {
            List<Product> result = new List<Product>();

            foreach (Product product in products)
            {
                if (filter(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }

        #endregion


        #region Task 03 - Custom Report Generator

        #region 3.1 - Print Reports

        // Action<Product> performs an action without returning a value.
        public static void PrintReport(
            List<Product> products,
            Action<Product> action)
        {
            foreach (Product product in products)
            {
                action(product);
            }
        }

        #endregion


        #region 3.2 - Transform Products

        // Func<Product, T> transforms a product into another type.
        public static List<T> TransformProducts<T>(
            List<Product> products,
            Func<Product, T> transform)
        {
            List<T> result = new List<T>();

            foreach (Product product in products)
            {
                result.Add(transform(product));
            }

            return result;
        }

        #endregion


        #region 3.3 - Filter Products

        // Predicate<Product> checks a condition and returns bool.
        public static List<Product> FilterProducts(
            List<Product> products,
            Predicate<Product> condition)
        {
            List<Product> result = new List<Product>();

            foreach (Product product in products)
            {
                if (condition(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }

        #endregion

        #endregion
    }
}