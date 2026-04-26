using MarquitoUtils.Main.Common.Tools;
using MarquitoUtils.Main.Translate.Services;
using MarquitoUtils.Main.Translate.Tools;
using MarquitoUtils.MAUI.Pages.Models;
using MarquitoUtils.MAUI.Views;
using System.Globalization;
using static MarquitoUtils.Main.Translate.Enums.Language.EnumLang;

namespace MarquitoUtils.MAUI.Pages
{
    public abstract partial class DefaultPage : ContentPage, IContentView
    {
        protected IServiceProvider ServiceProvider { get; }
        private ITranslateService TranslateService { get; }

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
        protected void Redirect<TPage>(PageModel pageModel = null)
            where TPage : DefaultPage
        {
            Microsoft.Maui.Controls.Shell.Current.GoToAsync($"{typeof(TPage).Name}", new Dictionary<string, object>()
            {
                { "ViewModel", pageModel },
            });
        }

        /// <summary>
        /// Redirect to another page
        /// </summary>
        /// <typeparam name="TMainPage">The main page, parent of the page</typeparam>
        /// <typeparam name="TPage">The page to redirect</typeparam>
        protected void Redirect<TMainPage, TPage>(PageModel pageModel = null)
            where TMainPage : DefaultPage
            where TPage : DefaultPage
        {
            Microsoft.Maui.Controls.Shell.Current.GoToAsync($"//{typeof(TMainPage).Name}/{typeof(TPage).Name}", new Dictionary<string, object>()
            {
                { "ViewModel", pageModel },
            });
        }

        /// <summary>
        /// Creates an instance of the specified view type, applies an optional initialization action before calling its
        /// Init method, and returns the initialized view.
        /// </summary>
        /// <remarks>The view instance is resolved from the service provider. The Init method is always
        /// called after the optional initialization action. This method is typically used to prepare views with custom
        /// setup logic before they are initialized.</remarks>
        /// <typeparam name="TView">The type of view to create. Must inherit from DefaultView.</typeparam>
        /// <param name="beforeInit">An optional action to perform on the view instance before initialization. Can be null if no
        /// pre-initialization is required.</param>
        /// <returns>An initialized instance of the specified view type.</returns>
        protected TView CreateView<TView>(Action<TView> beforeInit = null)
            where TView : DefaultView
        {
            TView view = this.ServiceProvider.GetRequiredService<TView>();

            if (Utils.IsNotNull(beforeInit))
            {
                beforeInit(view);
            }

            view.Init();

            return view;
        }
    }
}
