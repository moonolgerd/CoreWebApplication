using Heroic.Shared;
using Newtonsoft.Json;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App3.ViewModels
{
    public class MainPageViewModel
    {
        public MainPageViewModel() => GetDataCommand = new DelegateCommand(async () => await GetDataAsync());

        public ICommand GetDataCommand { get; set; }

        public ObservableCollection<Hero> Items { get; } = new ObservableCollection<Hero>();

        private async Task GetDataAsync()
        {
            var foo = await App.Remora_azureClient.GetTable<Hero>().ToListAsync();

            var client = new HttpClient();
            var data = await client.GetAsync(new Uri("http://localhost:5000/api/heroes"));

            var message = await data.Content.ReadAsStringAsync();
            var hero = JsonConvert.DeserializeObject<List<Hero>>(message);
            hero.ForEach(Items.Add);
        }
    }
}