using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System.Linq;

namespace Entities.DAL
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                /*var context = serviceScope.ServiceProvider.GetService<TNRContext>();
                if (!context.Services.Any())
                {
                    context.Services.Add(new Service() { Name = "Xét ngiệm/siêu âm/nội soi/điện cơ/điện não", Status = 0, Price = 50000 ,SpecialPrice= 100000, GroupService = 4});
                    context.Services.Add(new Service() { Name = "Xquang", Status = 0, Price = 70000, SpecialPrice = 150000, GroupService = 4 });
                    context.Services.Add(new Service() { Name = "CT Scanner", Status = 0, Price = 100000, SpecialPrice = 200000, GroupService = 4 });
                    context.Services.Add(new Service() { Name = "MRI", Status = 0, Price = 100000, SpecialPrice = 300000, GroupService = 4 });
                    context.Services.Add(new Service() { Name = "DSA", Status = 0, Price = 100000, SpecialPrice = 300000, GroupService = 4 });
                    context.Services.Add(new Service() {  Name = "Đăng ký khám theo yêu cầu", Status = 0, Price = 150000, GroupService = 1, SpecialPrice = 300000 });
                    context.Services.Add(new Service() {  Name = "Tra cứu lịch sử khám bệnh", Status = 0 ,Price = 50000, SpecialPrice = 100000, GroupService = 3 });
                    context.Services.Add(new Service() { Name = "Đặt câu hỏi", Status = 0 , Price = 50000 , GroupService = 6 , SpecialPrice = 100000 });
             
                    context.SaveChanges();
                }
              */
              

            }
        }
    }
}
