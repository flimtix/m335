using MemeChat.Database.Context;
using MemeChat.Database.Interfaces;
using MemeChat.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Diagnostics;

namespace MemeChat;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

		// MudBlazor UI
		builder.Services.AddMudServices();

		// Datenbanken mit Dependency Injection hinterlegen
		builder.Services.AddDbContext<ClientDbContext>(options => options.UseSqlite(Constants.LocalDatabasePath));
		builder.Services.AddDbContext<ServerDbContext>(options =>
			options.UseMySql(Constants.ServerDbConnectionString, ServerVersion.Create(10, 5, 12, ServerType.MariaDb)));
        // m => m.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)

        // Repositories hinterlegen
        builder.Services.AddTransient<IMemeChatRepository, MemeChatRepository>();

		var app = builder.Build();

		using (var scope = app.Services.CreateScope())
		{
			try
			{
				var repository = scope.ServiceProvider.GetService<IMemeChatRepository>();
				repository.CreateDatabase();
			}
			catch (Exception ex)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					Debugger.Log((int)LogLevel.Critical, nameof(LogLevel.Critical), "Init Databse throws error: " + ex.Message);
				}
			}
		}

		return app;
	}
}
