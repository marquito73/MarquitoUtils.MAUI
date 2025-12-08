using MarquitoUtils.Main.Translate.Services;
using MarquitoUtils.Main.Translate.Tools;
using MarquitoUtils.MAUI.Pages.Models;
using System.Globalization;
using static MarquitoUtils.Main.Translate.Enums.Language.EnumLang;

namespace MarquitoUtils.MAUI.Pages
{
    public abstract partial class DefaultPage : ContentPage, IContentView
    {
        protected IServiceProvider ServiceProvider { get; }
        protected ITranslateService TranslateService { get; }

        protected DefaultPage(IServiceProvider serviceProvider, ITranslateService translateService)
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

        public abstract void Init();

        protected abstract void ConfigureTranslations();

        protected TPageModel GetPageModel<TPageModel>() where TPageModel : PageModel
        {
            return this.BindingContext as TPageModel;
        }

        protected IDispatcherTimer InitTimer(double intervalInSeconds, Action action)
        {
            IDispatcherTimer timer = Application.Current.Dispatcher.CreateTimer();

            timer.Interval = TimeSpan.FromSeconds(intervalInSeconds);
            timer.Tick += (s, e) => action();
            timer.Start();

            return timer;
        }

        /// <summary>
        /// Show an alert message
        /// </summary>
        /// <param name="title">Popup title</param>
        /// <param name="message">Popup message</param>
        /// <param name="cancel">Popup cancel button text</param>
        /// <param name="windowIndex">Index of the window</param>
        /// <returns>Async task</returns>
        protected async Task ShowAlert(string title, string message, string cancel, int windowIndex = 0)
        {
            await Application.Current?.Windows[windowIndex]?.Page?.DisplayAlert(title, message, cancel);
        }

        /// <summary>
        /// Show a question message
        /// </summary>
        /// <param name="title">Popup title</param>
        /// <param name="message">Popup message</param>
        /// <param name="validate">Popup validate button text</param>
        /// <param name="cancel">Popup cancel button text</param>
        /// <param name="windowIndex">Index of the window</param>
        /// <returns>Question was validated ?</returns>
        protected async Task<bool> ShowQuestion(string title, string message, string validate, string cancel, int windowIndex = 0)
        {
            return await Application.Current?.Windows[windowIndex]?.Page?.DisplayAlert(title, message, validate, cancel);
        }

        /// <summary>
        /// Redirect to another page
        /// </summary>
        /// <typeparam name="TPage">The page to redirect</typeparam>
        /// <param name="page">The page to redirect</param>
        protected void Redirect<TPage>(TPage page)
            where TPage : DefaultPage
        {
            this.Navigation.PushAsync(page);
        }
    }
}
