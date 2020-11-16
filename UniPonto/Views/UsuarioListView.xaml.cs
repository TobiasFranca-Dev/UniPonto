using System.Windows;
using UniPonto.Interface;
using UniPonto.Models;
using UniPonto.Repositorios;

namespace UniPonto.Views
{
    public partial class UsuarioListView : Window
    {
        private IUsuarioRepositorio _usuarioRepositorio;


        public UsuarioListView()
        {
            InitializeComponent();

            CarregarDados();
        }

        private void CarregarDados()
        {
            _usuarioRepositorio = new UsuarioRepositorio();

            lvUsuarios.ItemsSource = _usuarioRepositorio.ObterTodos();

            _usuarioRepositorio.Dispose();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var frm = new UsuarioRegistroView(new Usuario());
            frm.ShowDialog();
            CarregarDados();

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lvUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item da lista.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            var user = (Usuario)lvUsuarios.SelectedItem;
            var frm = new UsuarioRegistroView(user);
            frm.ShowDialog();

            CarregarDados();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (lvUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item da lista.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir este usuário? \n Esse processo será irreversível", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var user = (Usuario)lvUsuarios.SelectedItem;

                _usuarioRepositorio = new UsuarioRepositorio();
                _usuarioRepositorio.Excluir(user.Id);
                _usuarioRepositorio.Dispose();

                MessageBox.Show("Usuário excluído com sucesso!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);

                CarregarDados();
            }
        }

        private void btnRelatorios_Click(object sender, RoutedEventArgs e)
        {
            var frm = new RelatorioView();
            frm.ShowDialog();
        }
    }
}
