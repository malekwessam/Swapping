using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MoqaydaGP.Converter;
using MoqaydaGP.Data;
using MoqaydaGP.Repository.Abstract;
using MoqaydaGP.Repository.Implement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MoqaydaGP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Moqayda",


                });
            });
            // services.AddControllers();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateConverter());
            });
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IWishlistService, WishlistService>();
            services.AddScoped<IWishlistRepository, WishlistRepository>();
            services.AddScoped<IProductOwnerService, ProductOwnerService>();
            services.AddScoped<IProductOwnerRepository, ProductOwnerRepository>();
            services.AddScoped<IProdToSwapService, ProdToSwapService>();
            services.AddScoped<IProdToSwapRepository, ProdToSwapRepository>();
            services.AddScoped<IPrivateItemService, PrivateItemService>();
            services.AddScoped<IPrivateItemRepository, PrivateItemRepository>();
            services.AddScoped<IPrivToSwapService, PrivToSwapService>();
            services.AddScoped<IPrivToSwapRepository, PrivToSwapRepository>();
            services.AddScoped<IBarteredPrivService, BarteredPrivService>();
            services.AddScoped<IBarteredPrivRepository, BarteredPrivRepository>();
            services.AddScoped<IBarteredProductService, BarteredProductService>();
            services.AddScoped<IBarteredProductRepository, BarteredProductRepository>();
            services.AddScoped<IPrivateItemOwnerService, PrivateItemOwnerService>();
            services.AddScoped<IPrivateItemOwnerRepository, PrivateItemOwnerRepository>();
            services.AddScoped<IBlockService, BlockService>();
            services.AddScoped<IBlockRepository, BlockRepository>();

            services.AddDbContext<MoqaydaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("conn")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger(); app.UseSwaggerUI(options => options.SwaggerEndpoint("v1/swagger.json", "Moqayda"));
        }
    }
}
