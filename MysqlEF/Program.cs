using System;
using System.Collections.Generic;
using System.Linq;

namespace MysqlEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new ContextBehavior())
            {
                //добавляем даные
                context.Add<User>(new User()
                {
                    Name = "Vlad",
                    Age = 19
                });
                context.Add<Product>(new Product()
                {
                    Name = "IPhone"
                });

                // добавляем юзеру продукт
                var user = context.GetUserWithProducts().First();
                var product = context.Get<Product>(x => x.Name == "IPhone").First();
                if (user.Products == null)
                {
                    user.Products = new List<Product>();
                }
                user.Products.Add(product);
                context.Update(product);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(user.Products.Where(x => x.Name == "IPhone").First());
                Console.WriteLine(product);
                Console.ForegroundColor = ConsoleColor.White;

                
                context.Delete(user);
                context.Delete(product);
                Console.ReadKey();
            }
        }
    }
}
