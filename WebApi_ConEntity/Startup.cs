using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_ConEntity.Models;
using Microsoft.AspNetCore.Cors;

namespace WebApi_ConEntity
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
               services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
   );
               services.AddDbContext<tareacovidContext>(options => options.UseMySql("server=localhost;user=root;database=tareacovid", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.18-mysql")));
               services.AddSwaggerGen(c =>
               {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi_ConEntity", Version = "v1" });
               });
               
               services.AddCors();
     
               // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
          }

          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi_ConEntity v1"));
               }

               app.UseHttpsRedirection();

               app.UseRouting();
               app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials                                ); //This needs to set everything allowed
               

               app.UseEndpoints(endpoints =>
               {
                    endpoints.MapControllers();
               });
               Console.WriteLine("mamaguevo");
          }
     }
}
