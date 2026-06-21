using MarquitoUtils.Main.Translate.Services;
using MarquitoUtils.Main.Translate.Tools;
using MarquitoUtils.MAUI.Pages;
using System.Globalization;
using static MarquitoUtils.Main.Translate.Enums.Language.EnumLang;

namespace MarquitoUtils.MAUI.Shell
{
    public partial class DefaultAppShell : Microsoft.Maui.Controls.Shell
    {
        protected IServiceProvider ServiceProvider { get; }
        private ITranslateService TranslateService { get; }

        public DefaultAppShell(IServiceProvider serviceProvider, ITranslateService translateService)
        {
            this.ServiceProvider = serviceProvider;
            this.TranslateService = translateService;
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
        /// <returns>The translation</returns>
        protected string GetTranslation<T>(string translationKey)
        {
            return this.TranslateService.GetTranslation<T>(translationKey, this.GetCurrentLanguage());
        }

        /// <summary>
        /// Register a route for a page
        /// </summary>
        /// <typeparam name="TPage">The page</typeparam>
        protected void RegisterPage<TPage>()
            where TPage : DefaultPage
        {
            Routing.RegisterRoute(typeof(TPage).Name, typeof(TPage));
        }
    }
}
