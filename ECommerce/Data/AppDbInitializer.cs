using ECommerce.Data.Enums;
using ECommerce.Models;

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
                            Description = "A default Sasung TV",
                            Price = 1000,
                            PublishDate = DateTime.Today

                        },
                        new Lot()
                        {
                            Picture = "https://img.joomcdn.net/dea6f2c65cb818c9513b1b79c45d2dff512b40ac_original.jpeg",
                            Name = "Bear",
                            Type = LotType.Toys,
                            Description = "A default flushy bear",
                            Price = 10,
                            PublishDate = DateTime.Today
                        },
                        new Lot()
                        {
                            Picture = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fassets.vogue.com%2Fphotos%2F6303e996be0e9b0e8c9fc4d9%2F3%3A4%2Fw_1280%252Cc_limit%2Fslide_17.jpg&imgrefurl=https%3A%2F%2Fwww.vogue.com%2Farticle%2Fbest-jeans-for-women&tbnid=pSu9j0ZBBkBZpM&vet=12ahUKEwjd186Kms_9AhVDmIsKHRgcDowQMygAegUIARC4Ag..i&docid=F4JSxQkZitXHiM&w=1280&h=1707&q=jeans&ved=2ahUKEwjd186Kms_9AhVDmIsKHRgcDowQMygAegUIARC4Ag",
                            Name = "Jeans",
                            Type = LotType.Clothing,
                            Description = "A white baggy Jeans",
                            Price = 1000,
                            PublishDate = DateTime.Today
                        },
                        new Lot()
                        {
                            Picture = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fdi-uploads-pod7.s3.amazonaws.com%2Fmercedesbenzofcharlottesville%2Fuploads%2F2019%2F01%2FMercedes-Benz-of-Charlottesville-Parts-FAQ.jpg&imgrefurl=https%3A%2F%2Fwww.mbofcharlottesville.com%2Fauto-parts-questions%2F&tbnid=865RD_lEdGUugM&vet=12ahUKEwiY5KuSms_9AhXIuSoKHT6sDEIQMygUegUIARDsAQ..i&docid=8ROxFHhDOjgDfM&w=799&h=599&q=car%20parts&ved=2ahUKEwiY5KuSms_9AhXIuSoKHT6sDEIQMygUegUIARDsAQ",
                            Name = "Car parts",
                            Type = LotType.Rust,
                            Description = "Doors,backseats and other stuff",
                            Price = 1000,
                            PublishDate = DateTime.Today
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}