using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectSignalR.SignalR;
using Newtonsoft.Json;

namespace ProjectSignalR
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            //��������
            services.AddCors(options => {
                options.AddPolicy("any", builder =>
                {
                    builder.SetIsOriginAllowed(origin => true)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });
            services.AddControllers();
      
            //    services.AddControllers().AddJsonOptions(
            //        options =>
            //        {
            //            //����ѭ������
            //            options.JsonSerializerOptions. = ReferenceLoopHandling.Ignore;
            //            //�������л�ʱʱ���ʽΪyyyy-MM-dd HH:mm:ss
            //            options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            //            //���ô�Сд���⣬Ĭ��������ĸСд
            //            options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();

            //        });
            //}
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
            //����Cors
            app.UseCors("any");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chatHub");
                endpoints.MapControllers();
            });
        }
    }
}
