using MarquitoUtils.Main.Common.Tools;
using MarquitoUtils.Main.Translate.Services;
using MarquitoUtils.Main.Translate.Tools;
using MarquitoUtils.MAUI.Common.Models;
using System.ComponentModel;
using System.Globalization;
using static MarquitoUtils.Main.Translate.Enums.Language.EnumLang;

namespace MarquitoUtils.MAUI.Pages.Models
{
    /// <summary>
    /// Base class for page models, which are used as the BindingContext for pages. It inherits from CommonModel and implements INotifyPropertyChanged to support data binding and property change notifications.
    /// </summary>
    public abstract class PageModel : CommonModel, INotifyPropertyChanged
    {
        /// <summary>
        /// Translation service used to get translations for the page, allowing the page to support multiple languages 
        /// and provide a localized experience for users. It is injected through the constructor and can be used in derived classes to get translations for specific keys.
        /// </summary>
        private ITranslateService TranslateService { get; }

        /// <summary>
        /// Title of the page
        /// </summary>
        public string Title { get; set; }

        public PageModel()
        {
        }

        public PageModel(ITranslateService translateService) : base()
        {
            this.TranslateService = translateService;
        }

        protected string GetTranslation<T>(string translationKey)
        {
            if (Utils.IsNotNull(this.TranslateService))
            {
                LanguageType language = LanguageUtils.GetLanguage(CultureInfo.CurrentCulture);

                return this.TranslateService.GetTranslation<T>(translationKey, language);
            }
            else
            {
                return translationKey;
            }
        }
    }
}
