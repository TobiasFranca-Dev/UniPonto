using System;
using System.Linq;
using System.Windows;
using UniPonto.Models;
using UniPonto.Repositorios;

namespace UniPonto.Views
{
    public partial class RegistroView : Window
    {        
        Ponto ponto = new Ponto();
        private PontoRepositorio _pontoRepositorio;
        

        public RegistroView(Usuario usuario)
        {          
            ponto = usuario.Historico?.Where(x => x.Data == DateTime.Today).FirstOrDefault();

            if (ponto == null)
            {
                ponto = new Ponto();
                ponto.Id = Guid.NewGuid();
            }

            InitializeComponent();
            HabilitarBotoes();

            if (!usuario.Admin)
            {
                btnUsuarios.IsEnabled = false;
                btnUsuarios.Visibility = Visibility.Hidden;
            }
        
        }

        private void HabilitarBotoes()
        {            

            lblEntrada.Text = ponto.Entrada?.ToShortTimeString();
            lblIntervalo.Text = ponto.Intervalo?.ToShortTimeString();
            lblRetorno.Text = ponto.Retorno?.ToShortTimeString();
            lblSaida.Text = ponto.Saida?.ToShortTimeString();


            if (ponto.Entrada == null)
            {
                btnEntrada.IsEnabled = true;
                btnIntervalo.IsEnabled = false;
                btnRetorno.IsEnabled = false;
                btnSaida.IsEnabled = false;
                return;
            }

            if (ponto.Intervalo == null)
            {
                btnEntrada.IsEnabled = false;
                btnIntervalo.IsEnabled = true;
                btnRetorno.IsEnabled = false;
                btnSaida.IsEnabled = false;
                return;
            }

            if (ponto.Retorno == null)
            {
                btnEntrada.IsEnabled = false;
                btnIntervalo.IsEnabled = false;
                btnRetorno.IsEnabled = true;
                btnSaida.IsEnabled = false;
                return;
            }

            if (ponto.Saida == null)
            {
                btnEntrada.IsEnabled = false;
                btnIntervalo.IsEnabled = false;
                btnRetorno.IsEnabled = false;
                btnSaida.IsEnabled = true;
                return;
            }
        }

        private void SalvarPonto()
        {
            _pontoRepositorio = new PontoRepositorio();
            _pontoRepositorio.Salvar(ponto);
            _pontoRepositorio.Dispose();
        }

        private void btnEntrada_Click(object sender, RoutedEventArgs e)
        {
            ponto.Entrada = DateTime.Now;
            HabilitarBotoes();
            SalvarPonto();
        }

        private void btnIntervalo_Click(object sender, RoutedEventArgs e)
        {
            ponto.Intervalo = DateTime.Now;
            HabilitarBotoes();
            SalvarPonto();
        }

        private void btnRetorno_Click(object sender, RoutedEventArgs e)
        {
            ponto.Retorno = DateTime.Now;
            HabilitarBotoes();
            SalvarPonto();
        }

        private void btnSaida_Click(object sender, RoutedEventArgs e)
        {
            ponto.Saida = DateTime.Now;
            HabilitarBotoes();
            SalvarPonto();
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            var frm = new UsuarioListView();
            frm.ShowDialog();
        }
    }
}