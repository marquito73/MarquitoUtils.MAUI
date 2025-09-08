using MarquitoUtils.Main.Class.Entities.Translation;
using MarquitoUtils.Main.Class.Service.General;
using System.Reflection;

namespace MarquitoUtils.MAUI.Class.Startup
{
    public abstract class DefaultStartup
    {
        private MauiAppBuilder AppBuilder { get; }
        protected DefaultStartup(MauiAppBuilder builder)
        {
            this.AppBuilder = builder;

            this.ManageTranslations();

            this.ManageViews(builder);
        }

        private void ManageTranslations()
        {
            ITranslateService translateService = new TranslateService();

            List<Translation> translations = translateService.GetTranslations(Properties.Resources.translateFilePath, Assembly.GetExecutingAssembly());

            translateService = new TranslateService(translations);

            this.AppBuilder.Services.AddSingleton(translateService);
        }

        protected abstract void ManageViews(MauiAppBuilder builder);
    }
}
