using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using UniPonto.Interface;
using UniPonto.Models;
using UniPonto.Repositorios;

namespace UniPonto.Views
{

    public partial class LoginView : Window
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private IPontoRepositorio _pontoRepositorio;
        public LoginView()
        {
            _usuarioRepositorio = new UsuarioRepositorio();

            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            _usuarioRepositorio.Dispose();
            Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var usuario = txtUsuario.Text;
            var senha = txtSenha.Password;

            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("Usuário deve ser informado.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Senha deve ser informada.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtSenha.Focus();
                return;
            }

            var user = _usuarioRepositorio.Login(usuario, senha);
            _usuarioRepositorio.Dispose();

            if (user == null)
            {
                MessageBox.Show("Usuário ou senha inválidos! verifique.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            _pontoRepositorio = new PontoRepositorio();
         
             user.Historico = _pontoRepositorio.ObterPorusuario(user.Id);
          
            
            _pontoRepositorio.Dispose();

            var frm = new RegistroView(user);
            frm.Show();
            Close();

            //if (user.Admin)
            //{
            //    var frm = new UsuarioListView();
            //    frm.Show();
            //    Close();
            //}
            //else
            //{
            //    var frm = new RegistroView(user);
            //    frm.Show();
            //    Close();
            //}
        }

        private void txtSenha_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin.Focus();
            }
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtSenha.Focus();
            }
        }
    }
}
