using SmartStore.Core.MapperConfiguration.ItemsManagement;
using SmartStore.Core.Repository;
using SmartStore.Core.Services.ItemsMangement.Abstraction;
using SmartStore.Core.Services.ItemsMangement.Implementation;
using SmartStore.Core.Services.Shared.Abstraction;
using SmartStore.Core.Services.Shared.Implementation;
using SmartStore.Domain.Abstraction.ItemsManagement;
using SmartStore.Shared.UnitOfWork;
using ZadRestaurant.Core.MapperConfiguration.InventoryManagement;

namespace SmartStore.Extention
{
    public static class ConfigureServicesExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IItemCategoryRepo, ItemCategoryRepo>();
            services.AddScoped<IItemGroupRepo, ItemGroupRepo>();
            services.AddScoped<IItemUnitRepo, ItemUnitRepo>();

            //Identity Service
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IEmailService, EmailService>();
            //Entity Service
            services.AddScoped<IItemCategoryService, ItemCategoryService>();
            services.AddScoped<IItemGroupService, ItemGroupService>();

            services.AddAutoMapper(typeof(ItemCategoryProfile));
            services.AddAutoMapper(typeof(ItemGroupProfile));

            services.AddSingleton<IMessageService, MessageService>();
        }
    }
}
