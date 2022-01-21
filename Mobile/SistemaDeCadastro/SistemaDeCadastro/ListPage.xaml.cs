using Newtonsoft.Json;
using SistemaDeCadastro.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaDeCadastro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        private const string Url = "http://192.168.0.103/api/Usuarios";

        private readonly HttpClient _client = new HttpClient();

        private ObservableCollection<Usuario> _posts;
        public ListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            string content = await _client.GetStringAsync(Url);
            List<Usuario> posts = JsonConvert.DeserializeObject<List<Usuario>>(content);
            _posts = new ObservableCollection<Usuario>(posts);
            
            base.OnAppearing();
        }
    }
}