using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using OnlineShoePortal_ECommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoePortal_ECommerce.Data
{
    public class ShoeSeeder
    {
        private readonly ShoeContext _ctx;
        private readonly IHostEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public ShoeSeeder(ShoeContext ctx, IHostEnvironment hosting, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();

            StoreUser user = await _userManager.FindByNameAsync("amarpendlya1999@gmail.com");
            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Amar",
                    LastName = "Pendlya",
                    Email = "Amarpendlya1999@gmail.com",
                    UserName = "AmarPendlya1999@gmail.com"
                };
                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in Seeder");
                }
            }

            if (!_ctx.Products.Any())
            {
                // Need to create sample data
                var filepath = Path.Combine("Data/shoes.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                    _ctx.Products.AddRange(products);

                var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null)
                {
                    order.User = user;
                    //order.Items = new List<OrderItem>()
                    //{
                    //    new OrderItem()
                    //    {
                    //        Product = products.First(),
                    //        Quantity =5,
                    //        UnitPrice = products.First().Price
                    //    }
                    //};
                }

                _ctx.SaveChanges();
            }
        }
    }
}

