using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using SistemaDeCadastro.Model;
using SistemaDeCadastro.Service;
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
    public partial class ListPage : ContentPage
    {
        DataService dataService;
        List<Usuario> usuarios;
        public ListPage()
        {
            InitializeComponent();
            dataService = new DataService();
            AtualizaDados();
            atualizarVis.IsVisible = false;
            listagemVis.IsVisible = true;
        }

        async void AtualizaDados()
        {
            usuarios = await dataService.GetUserAsync();
            listaUsuarios.ItemsSource = usuarios.ToList();
        }

        private async void OnDeletar(object sender, EventArgs e)
        {
            try
            {
                var mi = ((MenuItem)sender);
                Usuario usuarioDeletar = (Usuario)mi.CommandParameter;
                await dataService.DeletaUserAsync(usuarioDeletar);
                AtualizaDados();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void listaUsuarios_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            var usuario = e.Item as Usuario;
            txtNome.Text = usuario.nome;
            dtData.Date = Convert.ToDateTime(usuario.idade);
            txtSexo.SelectedItem = usuario.sexo;

            atualizarVis.IsVisible = true;
        }

        private async void OnAtualizar(object sender, EventArgs e)
        {
            try
            {
                var mi = ((MenuItem)sender);
                Usuario usuarioAtualizar = (Usuario)mi.CommandParameter;

                usuarioAtualizar.nome = txtNome.Text;
                usuarioAtualizar.idade = dtData.Date.ToString("yyyy'-'MM'-'dd");
                usuarioAtualizar.sexo = txtSexo.Items[txtSexo.SelectedIndex];

                await dataService.UpdateUserAsync(usuarioAtualizar);

                AtualizaDados();
                atualizarVis.IsVisible = false;
                listagemVis.IsVisible = true;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        void btFechaAtualiza(object sender, EventArgs e)
        {
            atualizarVis.IsVisible = false;
        }

        async void btMudarPagCad(object remetente, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async void btLogo(object remetente, EventArgs e)
        {
            await Navigation.PushAsync(new WelcomePage());
        }
    }
}