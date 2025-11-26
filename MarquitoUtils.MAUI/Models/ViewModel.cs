using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MarquitoUtils.MAUI.Models
{
    /// <summary>
    /// Provides a base class that implements the INotifyPropertyChanged interface to support property change
    /// notification in data-binding scenarios.
    /// </summary>
    /// <remarks>Derive from this class to enable property change notifications in view models or other
    /// classes that participate in data binding. The PropertyChanged event is raised when a property value changes,
    /// allowing UI elements or other listeners to respond accordingly. This class is commonly used in MVVM
    /// (Model-View-ViewModel) patterns.</remarks>
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event to notify listeners that a property value has changed.
        /// </summary>
        /// <remarks>Call this method in a property's setter to notify subscribers that the property's
        /// value has changed. This is commonly used to support data binding in applications that implement the
        /// INotifyPropertyChanged interface.</remarks>
        /// <param name="name">The name of the property that changed. This value is optional and will be automatically supplied by the
        /// compiler if not specified.</param>
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
