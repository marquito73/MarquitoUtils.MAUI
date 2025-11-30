using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MarquitoUtils.MAUI.Models
{
    public abstract class PageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
