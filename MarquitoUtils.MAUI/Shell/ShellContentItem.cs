using MarquitoUtils.MAUI.Pages;

namespace MarquitoUtils.MAUI.Shell
{
    /// <summary>
    /// Represents a content item for the Shell, which includes a title and a page template. The page template is created using the specified page type, which must inherit from DefaultPage.
    /// </summary>
    /// <typeparam name="TPage">The page for the shell</typeparam>
    public sealed class ShellContentItem<TPage> where TPage : DefaultPage
    {
        /// <summary>
        /// The page title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The page template, which is created using the specified page type. This template will be used to generate the content for the Shell when this item is selected.
        /// </summary>
        public DataTemplate PageTemplate { get; set; }

        /// <summary>
        /// Represents a content item for the Shell, which includes a title and a page template.
        /// </summary>
        /// <param name="title">The page title</param>
        public ShellContentItem(string title)
        {
            this.Title = title;
            this.PageTemplate = new DataTemplate(typeof(TPage));
        }
    }
}
