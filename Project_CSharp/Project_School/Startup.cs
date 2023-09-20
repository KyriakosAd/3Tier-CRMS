using LOGIC.Services.Implementation;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Project_School
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project_School", Version = "v1" });
            });

            #region CUSTOM SERVICES [D-I]
            services.AddScoped<IUser_Service, User_Service>();
            services.AddScoped<IRoom_Service, Room_Service>();
            services.AddScoped<IReservation_Service, Reservation_Service>();
            services.AddScoped<IRoomAvailability_Service, RoomAvailability_Service>();
            services.AddScoped<ILecture_Service, Lecture_Service>();
            services.AddScoped<ITeacher_Service, Teacher_Service>();
            services.AddScoped<ITeacherLecture_Service, TeacherLecture_Service>();
            #endregion

            #region CORS
            string corsUrl = Configuration["CORS:site"];
            string[] corsUrls;
            if (corsUrl.Contains(","))
            {
                corsUrls = corsUrl.Split(',').ToArray();
            }
            else
            {
                corsUrls = new string[1];
                corsUrls[0] = corsUrl;
            }

            services.AddCors(options =>
            {
                options.AddPolicy("angular",
                    builder =>
                    {
                        builder.WithOrigins(corsUrls)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project_School v1"));
            }

            app.UseRouting();

            app.UseCors("angular");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
