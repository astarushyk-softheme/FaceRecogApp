using FaceRecog.Domain.Settings;
using FaceRecog.Web.API.Services.FaceRecognition;
using FaceRecog.Web.API.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace FaceRecog.Web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiSettings>(options => Configuration.GetSection(nameof(ApiSettings)).Bind(options));

            services.AddTransient<IFaceRecognitionClient, FaceRecognitionClient>();

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<FileOperationFilter>();
                c.SwaggerDoc("v1", new Info { Title = "Face Recog App", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //URL: .../swagger
            app
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Face Recog App API V1");
                });

            app.UseMvc();
        }
    }
}
