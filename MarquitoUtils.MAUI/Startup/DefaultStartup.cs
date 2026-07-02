using CommunityToolkit.Maui;
using MarquitoUtils.Main.Common.Tools;
using MarquitoUtils.Main.Translate.Entities;
using MarquitoUtils.Main.Translate.Services;
using MarquitoUtils.MAUI.Config;
using MarquitoUtils.MAUI.Pages;
using MarquitoUtils.MAUI.Views;
using Syncfusion.Licensing;
using Syncfusion.Maui.Core.Hosting;
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
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular")
                        .AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold")
                        // Icons
                        .AddFont("marquito.ttf", "marquito");
                });

            if (this.RegisterSyncFusionLicenseKeyFromConfigFile())
            {
                this.AppBuilder.ConfigureSyncfusionCore();
                SyncfusionLicenseProvider.RegisterLicense(this.GetSyncFusionLicenseKeyFromConfigFile().LicenseKey);
            }

            this.ConfigureTranslations(assembly);

            this.ConfigurePages(assembly);

            this.ConfigureViews(assembly);

            this.ConfigureOptions(this.AppBuilder);
        }

        private void ConfigureTranslations(Assembly assembly)
        {
            ITranslateService translateService = new TranslateService();

            List<Translation> translations = translateService
                .GetTranslations(Properties.Resources.TranslateFilePath, assembly);

            translateService = new TranslateService(translations);

            this.AppBuilder.Services.AddSingleton(translateService);
        }

        #region Register pages and views

        /// <summary>
        /// Configure all the pages of the app as transient services.
        /// </summary>
        /// <param name="builder">App builder</param>
        /// <param name="assembly">Assembly</param>
        private void ConfigurePages(Assembly assembly)
        {
            assembly.GetTypes()
                .Where(type => type.IsInheritedBy<DefaultPage>())
                .ForEach(pageType =>
                {
                    this.AppBuilder.Services.AddTransient(pageType);
                });
        }

        /// <summary>
        /// Configure all the views of the app as transient services.
        /// </summary>
        /// <param name="builder">App builder</param>
        /// <param name="assembly">Assembly</param>
        private void ConfigureViews(Assembly assembly)
        {
            this.AppBuilder.Services.AddTransient<ErrorView>();


            assembly.GetTypes()
                .Where(type => type.IsInheritedBy<DefaultView>())
                .ForEach(viewType =>
                {
                    this.AppBuilder.Services.AddTransient(viewType);
                });
        }

        #endregion Register pages and view
        #endregion Register pages and views

        protected abstract void ConfigureOptions(MauiAppBuilder builder);

        /// <summary>
        /// Register a SyncFusion license key ?
        /// </summary>
        /// <remarks>Config file need to be File\Configuration\SyncFusion.config (as embedded resource)</remarks>
        /// <returns></returns>
        protected abstract bool RegisterSyncFusionLicenseKeyFromConfigFile();

        protected abstract SyncFusionConfiguration GetSyncFusionLicenseKeyFromConfigFile();
    }
}
