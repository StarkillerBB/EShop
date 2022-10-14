using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Repository;
using ServiceLayer.Interface;
using DataLayer.Entities;

namespace ConsoleApp
{
    internal class Program
    {
        #region ServiceProvider
        static ServiceProvider? SP = new ServiceCollection()
                .AddSingleton<IRepo, Repo>()
                .BuildServiceProvider();

        static IRepo _repo = SP.GetService<IRepo>();
        #endregion

        static void Main(string[] args)
        {
            while (true)
            {
                MainMenu();
            }
        }

        private static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) See all products");
            Console.WriteLine("2) See all products with pagination");
            Console.WriteLine("3) Search on a product.");
            Console.WriteLine("4) Add a product");
            Console.WriteLine("5) Remove a product");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    DisplayAllProducts();
                    return;
                case "2":
                    DisplayAllProductsWithPaging();
                    return;
                case "3":
                    DisplayProductWithSearch();
                    return;
                case "4":
                    AddProduct();
                    return;
                case "5":
                    RemoveProduct();
                    return;
                default:
                    return;
            }
        }

        private static void DisplayAllProducts()
        {
            Console.Clear();

            foreach (var item in _repo.GetAllProducts().OrderBy(x => x.TypeID))
            {
                Console.WriteLine("ID: " + item.ID + item.ProductName + " - " + item.Price + "kr. - " + item.Type.TypeName);
            }
            Console.WriteLine("Press enter to go back to menu");
            Console.ReadLine();
        }

        private static void DisplayAllProductsWithPaging()
        {
            Console.Clear();
            Console.WriteLine("Write the page you want to go to.");
            List<Product> products = _repo.GetAllProductsWithPagination(Convert.ToInt32(Console.ReadLine()));

            foreach (var item in products)
            {
                Console.WriteLine(item.ProductName + " - " + item.Price + "kr. - " + item.Type.TypeName);
            }
            Console.WriteLine("Press enter to go back to menu");
            Console.ReadLine();

        }

        private static void DisplayProductWithSearch()
        {
            Console.Clear();
            Console.WriteLine("Write the name you want to search on");
            List<Product> products = _repo.GetProductByNameSearch(Console.ReadLine());

            foreach (var item in products)
            {
                Console.WriteLine(item.ProductName + " - " + item.Price + "kr. - " + item.Type.TypeName);
            }
            Console.WriteLine("Press enter to go back to menu");
            Console.ReadLine();
        }

        private static void AddProduct()
        {
            Console.Clear();

            Console.WriteLine("Add a Product Name:");
            string productName = Console.ReadLine();

            Console.WriteLine("Add a price:");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Add an image path (Optional, keep empty if no picture is wanted)");
            string imagePath = Console.ReadLine();

            Console.WriteLine("Add the ID of the type you want it to be");
            int typeId = Convert.ToInt32(Console.ReadLine());

            Product product = new Product{ ProductName = productName, Price = price, ImagePath = imagePath, TypeID = typeId };
            _repo.AddEntry(product);

            Console.WriteLine("Product has been created \nPress enter to go back to menu");
            Console.ReadLine();
        }

        private static void RemoveProduct()
        {
            Console.Clear();

            Console.WriteLine("Remove a product by the ID:");

            _repo.DeleteEntry(_repo.GetProductById(Convert.ToInt32(Console.ReadLine())));

            Console.WriteLine("Product has been soft deleted \nPress enter to go back to menu");
            Console.ReadLine();
        }


    }
}