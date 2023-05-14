using ECommerce.Data.Enums;
using ECommerce.Data.Static;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                if(!context.Lots.Any())
                {
                    context.AddRange(new List<Lot>()
                    {
                        new Lot()
                        {
                            Picture = "https://www.sony-mea.com/image/f1231591e8a1e2fe4e5b6ad229a756c9?fmt=pjpeg&wid=1014&hei=396&bgcolor=F1F5F9&bgc=F1F5F9",
                            Name = "TV",
                            Type = LotType.Appliances,
                            Description = "A default Samsung TV",
                            DealType = DealType.Chargeless,
                            PublishDate = DateTime.Today

                        },
                        new Lot()
                        {
                            Picture = "https://img.joomcdn.net/dea6f2c65cb818c9513b1b79c45d2dff512b40ac_original.jpeg",
                            Name = "Bear",
                            Type = LotType.Toys,
                            Description = "A default flushy bear",
                            DealType = DealType.Chargeless,
                            PublishDate = DateTime.Today
                        },
                        new Lot()
                        {
                            Picture = "https://images.only.com/15171549/2985752/001/only-onlemilyhwstcranmae05noos-blaa.jpg?v=92886bb83f72bd3d90e5759b3db70cc6&format=webp&rsampler=catmull&width=1024&quality=90",
                            Name = "Jeans",
                            Type = LotType.Clothing,
                            Description = "A white baggy Jeans",
                            DealType = DealType.Exchange,
                            PublishDate = DateTime.Today
                        },
                        new Lot()
                        {
                            Picture = "https://www.kmulrooneytrucking.com/wp-content/uploads/2022/08/car-inside.jpg",
                            Name = "Car parts",
                            Type = LotType.Rust,
                            Description = "Doors,backseats and other stuff",
                            DealType = DealType.Exchange,
                            PublishDate = DateTime.Today
                        },
                        new Lot()
                        {
                            Picture = "https://cdn1.it4profit.com/AfrOrF3gWeDA6VOlDG4TzxMv39O7MXnF4CXpKUwGqRM/resize:fill:540/bg:f6f6f6/q:100/plain/s3://catalog-products/201111082124821437/201210170018916895.png@webp",
                            Name = "MacBook",
                            Type = LotType.Appliances,
                            Description = "New MacBook",
                            DealType = DealType.Exchange,
                            PublishDate = DateTime.Today
                        },
                        new Lot()
                        {
                            Picture = "https://ilounge.ua/files/products/new-iphone-15.1000x1000.webp",
                            Name = "Iphone",
                            Type = LotType.Appliances,
                            Description = "New Iphone",
                            DealType = DealType.Exchange,
                            PublishDate = DateTime.Today
                        },
                        new Lot()
                        {
                            Picture = "https://hips.hearstapps.com/goodhousekeeping-uk/main/embedded/40137/toybox.jpg",
                            Name = "Toys",
                            Type = LotType.Toys,
                            Description = "Used toys",
                            DealType = DealType.Exchange,
                            PublishDate = DateTime.Today
                        },
                        new Lot()
                        {
                            Picture = "https://www.cnet.com/a/img/resize/b2467510a3fca2c72acfd45504c6d1ebd549349a/hub/2022/09/12/b8e646a6-b39d-430b-ba9e-7cb04384ff1f/amazon-toys-we-love.png?auto=webp&fit=crop&height=900&width=1200",
                            Name = "Toys",
                            Type = LotType.Toys,
                            Description = "Used toys",
                            DealType = DealType.Chargeless,
                            PublishDate = DateTime.Today
                        },
                        new Lot()
                        {
                            Picture = "https://images.vans.com/is/image/VansEU/VN0A3WMAVNE-HERO?$PDP-FULL-IMAGE$",
                            Name = "Shoes",
                            Type = LotType.Clothing,
                            Description = "New shoes",
                            DealType = DealType.Chargeless,
                            PublishDate = DateTime.Today
                        },
                        new Lot()
                        {
                            Picture = "https://www.thespruce.com/thmb/tTOSB7tJHim06W0c6gYggLW31cY=/6623x0/filters:no_upscale():max_bytes(150000):strip_icc()/tips-to-make-clothes-last-longer-2146476-hero-baa47cec8e714b0e80f181da2f7d8dd0.jpg",
                            Name = "Clothes",
                            Type = LotType.Clothing,
                            Description = "New dresses",
                            DealType = DealType.Chargeless,
                            PublishDate = DateTime.Today
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@ecommerce.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@ecommerce.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}