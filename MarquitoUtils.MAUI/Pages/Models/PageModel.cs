using MarquitoUtils.MAUI.Common.Models;
using System.ComponentModel;

namespace MarquitoUtils.MAUI.Pages.Models
{
    /// <summary>
    /// Base class for page models, which are used as the BindingContext for pages. It inherits from CommonModel and implements INotifyPropertyChanged to support data binding and property change notifications.
    /// </summary>
    public abstract class PageModel : CommonModel, INotifyPropertyChanged
    {
        /// <summary>
        /// Title of the page
        /// </summary>
        public string Title { get; set; }
    }
}
