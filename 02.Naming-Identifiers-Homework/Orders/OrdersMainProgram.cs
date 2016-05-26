namespace Orders
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    class OrdersMainProgram
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var mapper = new DataMapper();

            var categories = mapper.GetAllCategories();
            var products = mapper.GetAllProducts();
            var orders = mapper.GetAllOrders();


            // Names of the 5 most expensive products
            var mostExpensiveProducts = products
                .OrderByDescending(p => p.UnitPrice)
                .Take(5)
                .Select(p => p.Name);

            Console.WriteLine(string.Join(Environment.NewLine, mostExpensiveProducts));
            Console.WriteLine(new string('-', 10));


            // Number of products in each category
            var productsByCategories = products
                .GroupBy(p => p.CategoryId)
                .Select(grp => new
                {
                    Category = categories
                        .First(c => c.Id == grp.Key).Name,
                    Count = grp.Count()
                })
                .ToList();

            foreach (var productsGroup in productsByCategories)
            {
                Console.WriteLine("{0}: {1}", productsGroup.Category, productsGroup.Count);
            }
            Console.WriteLine(new string('-', 10));


            // The 5 top products (by order Quantity)
            var mostOrderedProducts = orders
                .GroupBy(o => o.ProductId)
                .Select(g => new
                {
                    Product = products
                        .First(p => p.Id == g.Key).Name,
                    Quantities = g.Sum(o => o.Quantity)
                })
                .OrderByDescending(q => q.Quantities)
                .Take(5);

            foreach (var order in mostOrderedProducts)
            {
                Console.WriteLine("{0}: {1}", order.Product, order.Quantities);
            }
            Console.WriteLine(new string('-', 10));


            // The most profitable category
            var mostProfitableCategory = orders
                .GroupBy(o => o.ProductId)
                .Select(g => new
                {
                    CategoryId = products
                        .First(p => p.Id == g.Key).CategoryId,
                    Price = products
                        .First(p => p.Id == g.Key).UnitPrice,
                    Quantity = g.Sum(p => p.Quantity)
                })
                .GroupBy(g => g.CategoryId)
                .Select(g => new
                {
                    CategoryName = categories
                        .First(c => c.Id == g.Key).Name,
                    TotalSum = g.Sum(o => o.Quantity * o.Price)
                })
                .OrderByDescending(g => g.TotalSum)
                .First();

            Console.WriteLine("{0}: {1}", mostProfitableCategory.CategoryName, mostProfitableCategory.TotalSum);
        }
    }
}
