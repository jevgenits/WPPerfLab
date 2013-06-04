using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WPPerfLab.Common.Utils;

namespace WPPerfLab.Common.Entities
{
    public static class ProductRepository
    {
        public static List<ProductEntity> GetProducts()
        {
            return GetProducts(100, 3);
        }

        public static List<ProductEntity> GetProducts(int numberOfProducts, double delayInSeconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(delayInSeconds));
            var products = new List<ProductEntity>();
            for (int i = 1; i < numberOfProducts; i++)
            {
                var newProduct = GetProduct(string.Format("Item {0}", i));
                products.Add(newProduct);

                if (productAddedActions != null)
                {
                    productAddedActions.ForEach(action => action(newProduct));
                }
            }
            return products;
        }

        public static ProductEntity GetProduct(string productTitle = "some product", int numberOfKeys = 1)
        {
            return new ProductEntity()
            {
                Title = productTitle,
                Description = TextUtils.GetStaticText(),
                ImagePath = ImageUtils.GetRandomImagePath(),
                Keys = GetRandomKeys(numberOfKeys)
            };
        }

        private static List<Action<ProductEntity>> productAddedActions = new List<Action<ProductEntity>>();
        public static void RegisterForProductAddedAction(Action<ProductEntity> productAdded)
        {
            productAddedActions.Add(productAdded);
        }

        public static void UnregisterForProductAddedAction(Action<ProductEntity> productAdded)
        {
            if (productAddedActions.Contains(productAdded))
            {
                productAddedActions.Remove(productAdded);
            }
        }

        private static List<string> GetRandomKeys(int numberOfKeys)
        {
            var list = new List<string>();
            for (int i = 0; i < numberOfKeys; i++)
            {
                list.Add(string.Format("Key{0}", i));
            }
            return list;
        } 
    }
}
