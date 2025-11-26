using MarquitoUtils.Main.Sql.Context;
using MarquitoUtils.Main.Translate.Entities;
using MarquitoUtils.Main.Translate.Services;
using MarquitoUtils.MAUI.Views;
using System.Reflection;

namespace MarquitoUtils.MAUI.Startup
{
    public abstract class DefaultStartup<TApp, DBContext>
        where TApp : Application
        where DBContext : DefaultDbContext
    {
        private MauiAppBuilder AppBuilder { get; }
        protected DefaultStartup(MauiAppBuilder builder, Assembly assembly)
        {
            this.AppBuilder = builder;

            this.AppBuilder
                .UseMauiApp<TApp>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            this.ManageTranslations(assembly);

            this.ManageViews(this.AppBuilder);
        }

        private void ManageTranslations(Assembly assembly)
        {
            ITranslateService translateService = new TranslateService();

            List<Translation> translations = translateService
                .GetTranslations(Properties.Resources.translateFilePath, assembly);

            translateService = new TranslateService(translations);

            this.AppBuilder.Services.AddSingleton(translateService);
        }

        protected virtual void ManageViews(MauiAppBuilder builder)
        {
            builder.Services.AddTransient<ErrorView>();
        }
    }
}
