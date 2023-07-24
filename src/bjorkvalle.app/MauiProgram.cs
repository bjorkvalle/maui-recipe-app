using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace bjorkvalle.app
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton(typeof(data.DatabaseHandler<>));
            builder.Services.AddSingleton(typeof(infrastructure.Utilities.Mapper<,>));
            builder.Services.AddScoped<IRecipeService, RecipeService>();

            return builder.Build();
        }
    }
}