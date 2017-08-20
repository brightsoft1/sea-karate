using Prism.Mvvm;

namespace Adre.SEA.Karate
{
    class DataContext : BindableBase
    {
        string _time, _status, _visibility;
        float _value;

        public DataContext()
        {
            Visibility = "Collapsed";
        }

        public string Time
        {
            get => _time; set => SetProperty(ref _time, value);
        }

        public string Status
        {
            get => _status; set => SetProperty(ref _status, value);
        }

        public float Value
        {
            get => _value; set => SetProperty(ref _value, value);
        }

        public string Visibility
        {
            get => _visibility; set => SetProperty(ref _visibility, value);
        }
    }
}
