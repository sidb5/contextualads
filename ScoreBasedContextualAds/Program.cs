using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreBasedContextualAds
{

    public class Product
    {
        public string Tag { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }

    }

    public class ProductList
    {
 
        public List<Product> _products = new List<Product>();
        private Random _rnd = new Random();
        private int totalWeight = 0;

        public void Add(Product item)
        {
            _products.Add(item);
            totalWeight = totalWeight + item.Weight;
        }

        public Product GetProductToDisplay()
        {
            int randomNumber = _rnd.Next(0, totalWeight);

            Product selectedProduct = null;
            foreach (Product product in _products)
            {
                if (randomNumber < product.Weight)
                {
                    selectedProduct = product;
                    break;
                }

                randomNumber = randomNumber - product.Weight;
            }

            return selectedProduct;

        }
    }
    
        

    class Program
    {



        static void Main(string[] args)
        {
            var products = new ProductList();
            products.Add(new Product { Tag = "C101", Description = "SLR Camera", Weight = 13 });
            products.Add(new Product { Tag = "C102", Description = "hybrid camera", Weight = 13 });
            products.Add(new Product { Tag = "C103", Description = "pocket camera", Weight = 12 });
            products.Add(new Product { Tag = "I101", Description = "telephoto lens", Weight = 11 });
            products.Add(new Product { Tag = "I102", Description = "macro lens", Weight = 8 });
            products.Add(new Product { Tag = "I103", Description = "2x lens", Weight = 6 });
            products.Add(new Product { Tag = "I104", Description = "100mm lens", Weight = 7 });
            products.Add(new Product { Tag = "I105", Description = "50mm lens", Weight = 7 });
            products.Add(new Product { Tag = "I106", Description = "25 mm lens", Weight = 7 });
            products.Add(new Product { Tag = "I107", Description = "3-80mm zoom lens", Weight = 8 });
            products.Add(new Product { Tag = "m101", Description = "micro fiber cloth", Weight = 3 });
            products.Add(new Product { Tag = "m102", Description = "anti-static brush", Weight = 5 });



            while (true)
            {
                Dictionary<string, int> result = new Dictionary<string, int>();

                Product selectedProduct = null;

                for (int i = 0; i < 100000; i++)
                {
                    
                    selectedProduct = products.GetProductToDisplay();
                    if (selectedProduct != null)
                    {
                        if (result.ContainsKey(selectedProduct.Tag))
                        {
                            result[selectedProduct.Tag] = result[selectedProduct.Tag] + 1;
                        }
                        else
                        {
                            result.Add(selectedProduct.Tag, 1);
                        }
                    }
                }


                foreach (Product product in products._products)
                {
                    Console.WriteLine(product.Tag + "\t\t" + result[product.Tag] + "\t\t" + (result[product.Tag]/ 1000) + "%");
                }

                result.Clear();
                Console.WriteLine();
                Console.ReadLine();
            }
        }


    }
}
