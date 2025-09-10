using MarquitoUtils.Main.Class.Service.General;
using MarquitoUtils.Main.Class.Service.Sql;
using MarquitoUtils.Main.Class.Tools;
using System.Globalization;
using static MarquitoUtils.Main.Class.Enums.EnumLang;

namespace MarquitoUtils.MAUI.Class.Views
{
    public abstract partial class DefaultView : ContentView, IContentView
    {
        protected IServiceProvider ServiceProvider { get; }
        protected ITranslateService TranslateService { get; }
        protected IEntityService EntityService { get; }

        protected DefaultView(IServiceProvider serviceProvider, ITranslateService translateService,
            IEntityService entityService)
        {
            this.ServiceProvider = serviceProvider;
            this.TranslateService = translateService;
            this.EntityService = entityService;
        }

        /// <summary>
        /// Get current language
        /// </summary>
        /// <returns>The current language</returns>
        protected LanguageType GetCurrentLanguage()
        {
            return LanguageUtils.GetLanguage(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Get translation for a class and a translation key
        /// </summary>
        /// <typeparam name="T">The class need the translation</typeparam>
        /// <param name="translationKey">The translation key for translate</param>
        /// <param name="language">The language for translate</param>
        /// <returns>The translation</returns>
        protected string GetTranslation<T>(string translationKey)
        {
            return this.TranslateService.GetTranslation<T>(translationKey, this.GetCurrentLanguage());
        }

        public abstract void Init();

        protected abstract void ManageTranslations();
    }
}
