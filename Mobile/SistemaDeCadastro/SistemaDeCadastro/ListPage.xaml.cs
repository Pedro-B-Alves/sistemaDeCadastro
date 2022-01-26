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
        List<UsuarioExibir> usuariosExibir;
        
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
            try
            {
                usuariosExibir = new List<UsuarioExibir>();
                usuarios = await dataService.GetUserAsync();
                foreach(Usuario cliente in usuarios)
                {
                    UsuarioExibir usuarioMod = new UsuarioExibir();
                    if (cliente.nome == "")
                    {
                        continue;
                    }
                    usuarioMod.id = cliente.id;
                    usuarioMod.nome = cliente.nome;
                    usuarioMod.idade = cliente.idade;
                    usuarioMod.numIdade = CalculaIdade(cliente.idade);
                    usuarioMod.sexo = cliente.sexo;
               
                    usuariosExibir.Add(usuarioMod);

                }

                listaUsuarios.ItemsSource = usuariosExibir.ToList();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message + usuariosExibir.ToList(), "OK");
            }

        }

        private int CalculaIdade(string dataNascimento)
        {
            DateTime dataNas = Convert.ToDateTime(dataNascimento);
            int idade = DateTime.Now.Year - dataNas.Year;
            if(DateTime.Now.DayOfYear < dataNas.DayOfYear)
            {
                idade = idade - 1;
            }
            return idade;
        }

        private async void OnDeletar(object sender, EventArgs e)
        {
            try
            {
                var mi = ((MenuItem)sender);
                UsuarioExibir usuarioDeletar = (UsuarioExibir)mi.CommandParameter;
                Usuario usuarioDel = new Usuario();
                usuarioDel.id = usuarioDeletar.id;
                usuarioDel.nome = usuarioDeletar.nome;
                usuarioDel.idade = usuarioDeletar.idade;
                usuarioDel.sexo = usuarioDeletar.sexo;
                await dataService.DeletaUserAsync(usuarioDel);
                AtualizaDados();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void listaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var usuario = e.SelectedItem as UsuarioExibir;
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
                UsuarioExibir usuarioAtualizar = (UsuarioExibir)mi.CommandParameter;
                Usuario usuarioAtu = new Usuario();
                usuarioAtu.id = usuarioAtualizar.id;
                usuarioAtu.nome = txtNome.Text;
                usuarioAtu.idade = dtData.Date.ToString("yyyy'-'MM'-'dd");
                usuarioAtu.sexo = txtSexo.Items[txtSexo.SelectedIndex];
                await dataService.UpdateUserAsync(usuarioAtu);

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