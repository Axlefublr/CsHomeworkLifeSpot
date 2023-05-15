using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LifeSpot
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseRouting();

			string footerHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "footer.html"));
			string sideBarHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "sideBar.html"));

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGet("/", async context =>
				{
					string viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "index.html");

					StringBuilder html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
						.Replace("<!--SIDEBAR-->", sideBarHtml)
						.Replace("<!--FOOTER-->", footerHtml);

					await context.Response.WriteAsync(html.ToString());
				});

				endpoints.MapGet("/testing", async context =>
				{
					string viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "testing.html");

					StringBuilder html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
						.Replace("<!--SIDEBAR-->", sideBarHtml)
						.Replace("<!--FOOTER-->", footerHtml);

					await context.Response.WriteAsync(html.ToString());
				});

				endpoints.MapGet("/about", async context =>
				{
					string viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "about.html");

					StringBuilder html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
						.Replace("<!--SIDEBAR-->", sideBarHtml)
						.Replace("<!--FOOTER-->", footerHtml);

					await context.Response.WriteAsync(html.ToString());
				});

				endpoints.MapGet("/Static/CSS/index.css", async context =>
				{
					string cssPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "CSS", "index.css");
					string css = await File.ReadAllTextAsync(cssPath);
					await context.Response.WriteAsync(css);
				});

				endpoints.MapGet("/Static/JS/index.js", async context =>
				{
					string jsPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "JS", "index.js");
					string js = await File.ReadAllTextAsync(jsPath);
					await context.Response.WriteAsync(js);
				});

				endpoints.MapGet("/Static/JS/testing.js", async context =>
				{
					string jsPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "JS", "testing.js");
					string js = await File.ReadAllTextAsync(jsPath);
					await context.Response.WriteAsync(js);
				});
			});
		}
	}
}