using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonthlyExpenses.Api.Database;
using MonthlyExpenses.Api.Service;
using System;

namespace MonthlyExpenses.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddTransient<IExpenseService, ExpenseService>()
                .AddScoped<Repository.ExpensesRepository>()
                ;

            services
                .AddDbContext<ExpenseDbContext>(options =>
                       options
                       .UseSqlServer(Configuration.GetConnectionString("ExpenseDb")));

            // mapper configuration
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AddProfile(new CategoryMapProfile());
                cfg.AddProfile(new ExpenseMapProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public static void AdditionalConfiguration(IConfigurationBuilder configurationBuilder, IHostingEnvironment env) => configurationBuilder
              .AddJsonFile($"{AppContext.BaseDirectory}appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
