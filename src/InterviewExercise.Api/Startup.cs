using Dapper;
using InterviewExercise.Core.Repositories;
using InterviewExercise.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewExercise.Api
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
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            var sqlConnection = "Data Source=(LOCALDB)\\PROJECTSV13;Initial Catalog = Database.InterviewExercise";

            services.AddTransient<IMemberRepository>(container => new MemberRepository(sqlConnection));
            services.AddTransient<IAccountRepository>(container => new AccountRepository(sqlConnection));
            services.AddTransient<IAccountService, AccountService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
