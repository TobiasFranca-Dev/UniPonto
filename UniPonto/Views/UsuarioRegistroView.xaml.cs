using System.Collections.Generic;
using System.Windows;
using UniPonto.Interface;
using UniPonto.Models;
using UniPonto.Repositorios;

namespace UniPonto.Views
{
    public partial class UsuarioRegistroView : Window
    {

        IEnumerable<Ponto> lista;
        private IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioRegistroView(Usuario user)
        {
            InitializeComponent();

            lista = user.Historico;
            txtSenha.Password = user.Senha;

            DataContext = user;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var usuario = (Usuario)DataContext;

            usuario.Senha = txtSenha.Password;

            if (!ValidaUsuario(usuario))
            {
                return;
            }

            _usuarioRepositorio = new UsuarioRepositorio();
            _usuarioRepositorio.Salvar(usuario);
            _usuarioRepositorio.Dispose();

            MessageBox.Show("Usuário salvo com sucesso!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);

            Close();
        }

        private bool ValidaUsuario(Usuario usuario)
        {

            if (string.IsNullOrWhiteSpace(usuario.Nome))
            {
                MessageBox.Show("Nome deve ser informado.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.Funcao))
            {
                MessageBox.Show("Função deve ser informada.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.Login))
            {
                MessageBox.Show("Login deve ser informado.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario.Senha))
            {
                MessageBox.Show("Senha deve ser informada.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }

            _usuarioRepositorio = new UsuarioRepositorio();

            if (_usuarioRepositorio.UsuarioExistente(usuario.Login))
            {
                MessageBox.Show("Login já existente! utilize outro nome de login.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }

            _usuarioRepositorio.Dispose();

            return true;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            _usuarioRepositorio.Dispose();
            Close();
        }
    }
}
