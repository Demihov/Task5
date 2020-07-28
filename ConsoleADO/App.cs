using BLL.ADO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleADO
{
    public class App
    {
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;

        public App(IProductService productService, ISupplierService supplierService)
        {
            _supplierService = supplierService;
            _productService = productService;
        }

        public void Run()
        {
            var cont = true;
            while (cont)
            {
                Console.WriteLine("1.Get a list of products of a given category\n" +
                                  "2.Define a list of products of a given supplier\n" +
                                  "3.Define all suppliers of a given category\n" +
                                  "4.Search a product of a given price\n" +
                                  "Esc - exit");
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("enter id:");
                        var category = int.Parse(Console.ReadLine());
                        foreach (var productDto in _productService.GetByCategory(category))
                            Console.WriteLine(productDto);
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("enter id:");
                        var supplier = int.Parse(Console.ReadLine());
                        foreach (var productDto in _productService.GetBySupplier(supplier))
                            Console.WriteLine(productDto);
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("enter id:");
                        var category1 = int.Parse(Console.ReadLine());
                        foreach (var supplierDto in _supplierService.GetByCategory(category1))
                            Console.WriteLine(supplierDto);
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("enter price:");
                        var price = int.Parse(Console.ReadLine());
                        foreach (var products in _productService.GetByPrice(price))
                            Console.WriteLine(products);
                        break;
                    case ConsoleKey.Escape:
                        cont = false;
                        break;
                }
            }
        }
    }
}
