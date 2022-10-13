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


            MainMenu();            
        }

        private static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) See all products");
            Console.WriteLine("2) Add a product");
            Console.WriteLine("3) Remove a product");
            Console.WriteLine("4) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    DisplayAllProducts();
                    return;
                case "2":
                    AddProduct();
                    return;
                case "3":
                    return;
                case "4":
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
                Console.WriteLine(item.ProductName + " - " + item.Price + "kr. - " + item.TypeID);
            }
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

            Product product = new Product{ ProductName = productName, Price = price, ImagePath = imagePath };
            _repo.AddEntry(product);
        }

        private static void RemoveProduct()
        {
            int writeCounter = 0;
            int caseCounter = 0;
            List<Product> products = _repo.GetAllProducts();
            Console.Clear();

            Console.WriteLine("Choose a product to remove:");
        }


    }
}