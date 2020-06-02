using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiefOfTheFoundry.DataAccess;
using ChiefOfTheFoundry.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FoundryApi
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
            // Db Services - Dependency Injection
            CollectionDbSettings setServiceDbSettings = new CollectionDbSettings()
            {
                CollectionName = Configuration.GetSection("DbSettings")["SetCollectionName"],
                ConnectionString = Configuration.GetSection("DbSettings")["ConnectionString"],
                DatabaseName = Configuration.GetSection("DbSettings")["DatabaseName"]
            };
            services.AddSingleton<IMtgSetService>(s => new MtgSetService(setServiceDbSettings));

            CollectionDbSettings metaCardServiceDbSettings = new CollectionDbSettings()
            {
                CollectionName = Configuration.GetSection("DbSettings")["MetaCardsCollectionName"],
                ConnectionString = Configuration.GetSection("DbSettings")["ConnectionString"],
                DatabaseName = Configuration.GetSection("DbSettings")["DatabaseName"]
            };
            services.AddSingleton<IMetaCardService>(s => new MetaCardService(metaCardServiceDbSettings));

            CollectionDbSettings cardServiceDbSettings = new CollectionDbSettings()
            {
                CollectionName = Configuration.GetSection("DbSettings")["CardsCollectionName"],
                ConnectionString = Configuration.GetSection("DbSettings")["ConnectionString"],
                DatabaseName = Configuration.GetSection("DbSettings")["DatabaseName"]
            };
            services.AddSingleton<IMtgCardService>(s => new MtgCardService(cardServiceDbSettings));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
