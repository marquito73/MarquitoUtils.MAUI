using MarquitoUtils.Main.Common.Tools;
using MarquitoUtils.MAUI.Pages;
using System.Text;

namespace MarquitoUtils.MAUI.Tools
{
    /// <summary>
    /// Utility class for building page URIs based on page types. It allows constructing URIs by adding page types in a fluent manner.
    /// </summary>
    public class PageUriBuilder
    {
        /// <summary>
        /// StringBuilder to construct the URI. It starts with "//" if useAbsoluteUri is true, otherwise it starts empty. 
        /// Pages are added to the URI separated by "/".
        /// </summary>
        private StringBuilder Uri { get; set; } = new StringBuilder();

        /// <summary>
        /// Constructor for PageUriBuilder. It takes an optional parameter useAbsoluteUri which determines whether 
        /// the URI should start with "//" (indicating an absolute URI) or not (indicating a relative URI).
        /// </summary>
        /// <param name="useAbsoluteUri">If true, the URI will start with "//". If false, it will start empty. Default is false.</param>
        public PageUriBuilder(bool useAbsoluteUri = false)
        {
            if (useAbsoluteUri)
            {
                this.Uri.Append("//");
            }
        }

        /// <summary>
        /// Adds a page type to the URI. The page type is determined by the generic parameter TPage, which must be a subclass of <see cref="DefaultPage"/>.
        /// </summary>
        /// <typeparam name="TPage">The type of the page to add to the URI. It must inherit from <see cref="DefaultPage"/>.</typeparam>
        /// <returns>The current instance of <see cref="PageUriBuilder"/> to allow for method chaining.</returns>
        public PageUriBuilder AddPage<TPage>()
            where TPage : DefaultPage
        {
            if (Utils.IsNotEmpty(this.Uri.ToString()) && this.Uri.ToString() != "//")
            {
                this.Uri.Append("/");
            }

            this.Uri.Append(typeof(TPage).Name);

            return this;
        }

        /// <summary>
        /// Builds the final URI string based on the added page types. 
        /// The resulting URI will be in the format of "Page1/Page2/Page3" for relative URIs or "//Page1/Page2/Page3" for absolute URIs, depending on how the builder was initialized.
        /// </summary>
        /// <returns>The constructed URI as a string.</returns>
        public string Build()
        {
            return this.Uri.ToString();
        }
    }
}
