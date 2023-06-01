using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LifeSpot
{
	public static class EndpointMapper
	{
		public static void MapCss(this IEndpointRouteBuilder builder)
		{
			string[] cssFiles = new[] { "index.css" };

			foreach (string fileName in cssFiles)
			{
				builder.MapGet($"/Static/CSS/{fileName}", async context =>
				{
					string cssPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "CSS", fileName);
					string css = await File.ReadAllTextAsync(cssPath);
					await context.Response.WriteAsync(css);
				});
			}
		}

		public static void MapJs(this IEndpointRouteBuilder builder)
		{
			string[] jsFiles = new[] { "index.js", "testing.js", "about.js" };

			foreach (string fileName in jsFiles)
			{
				builder.MapGet($"/Static/JS/{fileName}", async context =>
				{
					string jsPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "JS", fileName);
					string js = await File.ReadAllTextAsync(jsPath);
					await context.Response.WriteAsync(js);
				});
			}
		}

		public static void MapHtml(this IEndpointRouteBuilder builder)
		{
			string footerHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "footer.html"));
			string sideBarHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "sidebar.html"));

			builder.MapGet("/", async context =>
			{
				string viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "index.html");
				string viewText = await File.ReadAllTextAsync(viewPath);

				StringBuilder html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
					.Replace("<!--SIDEBAR-->", sideBarHtml)
					.Replace("<!--FOOTER-->", footerHtml);

				await context.Response.WriteAsync(html.ToString());
			});

			builder.MapGet("/testing", async context =>
			{
				string viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "testing.html");

				StringBuilder html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
					.Replace("<!--SIDEBAR-->", sideBarHtml)
					.Replace("<!--FOOTER-->", footerHtml);

				await context.Response.WriteAsync(html.ToString());
			});

			builder.MapGet("/about", async context =>
			{
				string viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "about.html");

				StringBuilder html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
					.Replace("<!--SIDEBAR-->", sideBarHtml)
					.Replace("<!--FOOTER-->", footerHtml);

				await context.Response.WriteAsync(html.ToString());
			});
		}
	}
}