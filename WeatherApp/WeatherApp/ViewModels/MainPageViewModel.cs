using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Core;
using WeatherApp.Core.Clients.Implementations;
using WeatherApp.Core.Models.REST;
using WeatherApp.Enums;
using WeatherApp.Helpers;
using WeatherApp.Helpers.REST;
using WeatherApp.Models;
using WeatherApp.Views;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Commands
        private ICommand addCommand;
        public ICommand AddCommand => addCommand ?? (addCommand = new CommandHandler(() => AddCity(), true));


        private ICommand optionsCommand;
        public ICommand OptionsCommand => optionsCommand ?? (optionsCommand = new CommandHandler(async () => await App.Current.MainPage.Navigation.PushModalAsync(new OptionsView()), true));


        private ICommand getDataCommand;
        public ICommand GetDataCommand => getDataCommand ?? (getDataCommand = new CommandHandler(async () => Task.Run(() => GetData()), true));

        private ICommand itemTappedCommand;
        public ICommand ItemTappedCommand => itemTappedCommand ?? (itemTappedCommand = new CommandHandler(async (item) => await App.Current.MainPage.Navigation.PushModalAsync(new DetailsView(item as WeatherModel)), true));

        private ICommand markAsDefaultCommand;
        public ICommand MarkAsDefaultCommand => markAsDefaultCommand ?? (markAsDefaultCommand = new CommandHandler(async () =>
        {
            Settings.DefaultCity = EntryText;
        }, true));

        #endregion

        #region Properties

        private readonly string locationEndpoint = "http://api.openweathermap.org/geo/1.0/direct?q=Wrocław&limit=1&appid=5644d38f623183d217506ff92a82cafe";

        private bool isRefreshing = false;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetProperty(ref isRefreshing, value);
        }

        private string entryText;
        public string EntryText
        {
            get => entryText;
            set => SetProperty(ref entryText, value);
        }

        private ObservableCollection<WeatherModel> weatherCollection = new ObservableCollection<WeatherModel>();
        public ObservableCollection<WeatherModel> WeatherCollection
        {
            get => weatherCollection;
            set => SetProperty(ref weatherCollection, value);
        }
        #endregion

        private void AddCity()
        {
            var a = " ";
        }

        public async Task GetData()
        {
            IsRefreshing = true;
            WeatherCollection = new ObservableCollection<WeatherModel>();
            if (String.IsNullOrEmpty(EntryText))
            {
                IsRefreshing = false;
                return;
            }
            var locations = await WeatherREST.GetLocation(EntryText);
            List<Task> tasks = new List<Task>();
            foreach (var location in locations)
                tasks.Add(GetWeather(location.Name, location.Lon, location.Lat));
            await Task.WhenAll(tasks.ToArray());
            ObservableCollection<WeatherModel> tempCollection = new ObservableCollection<WeatherModel>();
            foreach (var task in tasks)
                tempCollection.Add(((Task<WeatherModel>)task).Result);
            WeatherCollection = tempCollection;
            IsRefreshing = false;

        }

        private async Task<WeatherModel> GetWeather(string name, double longitude, double latitude)
        {
            var weather = await WeatherREST.GetWeather(longitude, latitude);
            return new WeatherModel(weather, name);
        }

    }
}
