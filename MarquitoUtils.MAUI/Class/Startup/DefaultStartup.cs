using MarquitoUtils.Main.Class.Entities.File;
using MarquitoUtils.Main.Class.Entities.Translation;
using MarquitoUtils.Main.Class.Service.Files;
using MarquitoUtils.Main.Class.Service.General;
using MarquitoUtils.Main.Class.Service.Sql;
using MarquitoUtils.Main.Class.Sql;
using System.Reflection;

namespace MarquitoUtils.MAUI.Class.Startup
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

            this.ManageEntityService(assembly);

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

        private void ManageEntityService(Assembly assembly)
        {
            // Init startup db contexts
            IFileService fileService = new FileService();
            IEntityService entityService = new EntityService();

            DatabaseConfiguration databaseConfiguration = fileService
                .GetDefaultDatabaseConfiguration(assembly);
            entityService.DbContext = DefaultDbContext.GetDbContext<DBContext>(databaseConfiguration);

            this.AppBuilder.Services.AddSingleton(entityService);
        }

        protected abstract void ManageViews(MauiAppBuilder builder);
    }
}
