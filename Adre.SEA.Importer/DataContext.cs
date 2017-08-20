using Prism.Mvvm;

namespace Adre.SEA.Importer
{
    public class DataContext: BindableBase
    {
        string _status;

        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }
    }
}
