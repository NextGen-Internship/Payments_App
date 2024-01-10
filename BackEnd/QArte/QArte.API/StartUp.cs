using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QArte.Persistance;

namespace QArte.API
{
	public class StartUp
	{
		public StartUp(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigurationServices(IServiceCollection services)
		{
			services.AddDbContext<QArtèDBContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"))
			);

			services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);
		}

		public void Configure(IApplicationBuilder app,IHostEnvironment env)
		{
			app.UseMvc();
		}

	}
}

