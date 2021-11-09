using WeatherApp.Commands;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class WindDataViewModel: BaseViewModel
    {
        public IWindDataService WindDataService { get; set; }
        public DelegateCommand<string> GetDataCommand { get; set; }
        private WindDataModel currentData;
        public WindDataModel CurrentData
        {
            get => currentData;
            set
            {
                currentData = value;
                OnPropertyChanged();
            }
        }

        public WindDataViewModel()
        {
            WindDataService = new OpenWeatherService(AppConfiguration.GetValue("ApiKey"));
            GetDataCommand = new DelegateCommand<string>(GetData);
        }

        public double KPHtoMPS(double kph) => kph * 1.0 / 36.0;
        public double MPStoKPH(double mps) => mps * 3.6;
        
        private async void GetData(string s)
        {
            CurrentData = await WindDataService.GetDataAsync();  
            
        }
    }
}
