using System;

namespace ProductsApp
{
    class Program
    {
        // Get an entire entity set.
        static void ListAllProducts(Default.Container container)
        {
            foreach (var p in container.Products)
            {
                Console.WriteLine("{0} {1} {2}", p.Name, p.Price, p.Category);
            }
        }

        static void AddProduct(Default.Container container, ProductService.Models.Product product)
        {
            container.AddToProducts(product);
            var serviceResponse = container.SaveChanges();
            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }
        }
        static void AddSupplier(Default.Container container, ProductService.Models.Supplier supplier)
        {
            container.AddToSuppliers(supplier);
            var serviceResponse = container.SaveChanges();
            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }
        }


        static void Main(string[] args)
        {
            // TODO: Replace with your local URI.
            string serviceUri = "http://localhost:58374/";
            var container = new Default.Container(new Uri(serviceUri));
            //Lisää uuden tietokantaan, aina kun ohjelma ajetaan
            var product = new ProductService.Models.Product()
            {
                Name = "Yo-yo",
                Category = "Toys",
                Price = 4.95M
            };
            var product2 = new ProductService.Models.Product()
            {
                Name = "Car",
                Category = "Toys",
                Price = 2.50M
            };

            var supplier = new ProductService.Models.Supplier()
            {
                Id = 12,
                Name = "Lelutehdas Oy"
            };

            AddProduct(container, product);
            AddProduct(container, product2);
            AddSupplier(container, supplier);
            ListAllProducts(container);
            Console.ReadLine();
        }
    }
}