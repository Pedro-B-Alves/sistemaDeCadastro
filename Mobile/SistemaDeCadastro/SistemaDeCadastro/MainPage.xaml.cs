using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using SistemaDeCadastro.Model;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using SistemaDeCadastro.Service;

namespace SistemaDeCadastro
{
    public partial class MainPage : ContentPage
    {
        DataService dataService;
        List<Usuario> usuarios;
        public MainPage()
        {
            dataService = new DataService();
            InitializeComponent();
        }

        private async void btnAdicionar_Clicked(object sender, EventArgs e)
        {
                Usuario novoUsuario = new Usuario
                {
                    nome = txtNome.Text.Trim(),
                    idade = dtData.Date.ToString("yyyy'-'MM'-'dd"),
                    sexo = txtSexo.Items[txtSexo.SelectedIndex]
                };
                try
                {
                    await dataService.AddUserAsync(novoUsuario);
                    await DisplayAlert("OK", "Usuario cadastrado com sucesso", "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", ex.Message + " nome: "+novoUsuario.nome + " idade: " + novoUsuario.idade + " sexo: " + novoUsuario.sexo, "OK");
                }
        }

        async void btMudarPagList(object remetente, EventArgs e)
        {
            await Navigation.PushAsync(new ListPage());
        }

        async void btLogo(object remetente, EventArgs e)
        {
            await Navigation.PushAsync(new WelcomePage());
        }
    }
}
