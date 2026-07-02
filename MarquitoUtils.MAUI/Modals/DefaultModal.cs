using MarquitoUtils.Main.Translate.Services;
using MarquitoUtils.Main.Translate.Tools;
using System.Globalization;
using static MarquitoUtils.Main.Translate.Enums.Language.EnumLang;

namespace MarquitoUtils.MAUI.Modals
{
    /// <summary>
    /// Default modal class that can be used to show a modal with a title, description, confirm button and cancel button
    /// </summary>
    public abstract class DefaultModal
    {
        /// <summary>
        /// The translate service used to get translations for the modal
        /// </summary>
        private ITranslateService TranslateService { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultModal"/> class with the specified translate service.
        /// </summary>
        /// <param name="translateService">The translate service used to get translations for the modal</param>
        public DefaultModal(ITranslateService translateService)
        {
            this.TranslateService = translateService;
        }

        /// <summary>
        /// Show the modal and return true if the user confirmed, false if the user canceled
        /// </summary>
        /// <returns>True if the user confirmed, false if the user canceled</returns>
        public abstract Task<bool> ShowModal();

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
        /// Get current language
        /// </summary>
        /// <returns>The current language</returns>
        protected LanguageType GetCurrentLanguage()
        {
            return LanguageUtils.GetLanguage(CultureInfo.CurrentCulture);
        }
    }
}
