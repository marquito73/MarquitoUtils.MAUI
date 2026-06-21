using MarquitoUtils.Main.Translate.Services;

namespace MarquitoUtils.MAUI.App
{
    public abstract partial class DefaultApp : Application
    {
        protected IServiceProvider ServiceProvider { get; }
        protected ITranslateService TranslateService { get; }

        public DefaultApp(IServiceProvider serviceProvider, ITranslateService translateService)
        {
            this.ServiceProvider = serviceProvider;
            this.TranslateService = translateService;
        }
    }
}
