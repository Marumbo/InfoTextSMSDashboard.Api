using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using InfoTextSMSDashboard.BLL.Models;
using Microsoft.EntityFrameworkCore;
using InfoTextSMSDashboard.BLL.Services;
using InfoTextSMSDashboard.DAL.Models;
using InfoTextSMSDashboard.BLL.Interfaces;

namespace InfoTextSMSDashboard.Api
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

            services.AddControllers();

            services.AddEntityFrameworkNpgsql().AddDbContext<sms_dashboardContext>(opt =>
       opt.UseNpgsql(Configuration.GetConnectionString("InfoTextSMSDashboard")));

            services.AddTransient<ISmsService,SmsService>();
            services.AddTransient<IContactsService, ContactsService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IGroupContactService, GroupContactService>();


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
