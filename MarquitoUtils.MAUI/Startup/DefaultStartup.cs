using MarquitoUtils.Main.Translate.Entities;
using MarquitoUtils.Main.Translate.Services;
using MarquitoUtils.MAUI.Views;
using System.Reflection;

namespace MarquitoUtils.MAUI.Startup
{
    public abstract class DefaultStartup<TApp>
        where TApp : Application
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

            this.ConfigureTranslations(assembly);

            this.ConfigurePages(this.AppBuilder);

            this.ConfigureViews(this.AppBuilder);

            this.ConfigureOptions(this.AppBuilder);

            this.ManageViews(this.AppBuilder);
            }

        private void ConfigureTranslations(Assembly assembly)
        {
            ITranslateService translateService = new TranslateService();

            List<Translation> translations = translateService
                .GetTranslations(Properties.Resources.TranslateFilePath, assembly);

            translateService = new TranslateService(translations);

            this.AppBuilder.Services.AddSingleton(translateService);
        }

        protected virtual void ConfigurePages(MauiAppBuilder builder)
        {
        }

        protected virtual void ConfigureViews(MauiAppBuilder builder)
        {
            builder.Services.AddTransient<ErrorView>();
        }

        protected virtual void ManagePages(MauiAppBuilder builder)
        {
        }

        protected abstract void ConfigureOptions(MauiAppBuilder builder);

        /// <summary>
        /// Register a SyncFusion license key ?
        /// </summary>
        /// <remarks>Config file need to be File\Configuration\SyncFusion.config (as embedded resource)</remarks>
        /// <returns></returns>
        protected abstract bool RegisterSyncFusionLicenseKeyFromConfigFile();
    }
}
