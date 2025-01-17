﻿using BattleshipClone.DB;
using BattleshipClone.Game;
using BattleshipClone.Pages;
using Microsoft.Extensions.Logging;

namespace BattleshipClone
{
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            
            builder.Services.AddSingleton<ISavedStateRepository, SavedStateRepository>();
            builder.Services.AddSingleton<Enemy>();


            return builder.Build();
        }
    }
}
