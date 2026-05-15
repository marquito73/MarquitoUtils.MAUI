using MarquitoUtils.Main.Translate.Services;

namespace MarquitoUtils.MAUI.Pages
{
    /// <summary>
    /// Abstract base class for pages that are used for creating new entries or items. 
    /// This class provides common functionality and structure for creation pages, such as handling user input and interactions related to the creation process. 
    /// It inherits from <see cref="DefaultPage"/> and implements the <see cref="IContentView"/> interface, allowing it to be used as a content view within the application.
    /// Subclasses of <see cref="DefaultCreationPage"/> are expected to implement the specific logic for handling the creation of new entries based on user input and interactions.
    /// </summary>
    public abstract partial class DefaultCreationPage : DefaultPage, IContentView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultCreationPage"/> class with the specified service provider and translate service.
        /// </summary>
        /// <param name="serviceProvider">Service provider for dependency injection and accessing application services.</param>
        /// <param name="translateService">Translation service for handling localization and providing translated content based on the current language settings of the application.</param>
        protected DefaultCreationPage(IServiceProvider serviceProvider, ITranslateService translateService) : base(serviceProvider, translateService)
        {
        }

        /// <summary>
        /// Abstract method that must be implemented by subclasses to handle the creation logic when a user initiates the creation process (e.g., by clicking a "Create" button).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected abstract void OnCreation(object sender, EventArgs e);
    }
}
