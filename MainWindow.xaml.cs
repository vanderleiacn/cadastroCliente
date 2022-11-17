using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cadastroCliente
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string operacao;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void LimpaCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtCep.Clear();
            txtLogradouro.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            
        }

        private void Adicionar(object sender, RoutedEventArgs e)
        {

            cliente cliente = new cliente();
            cliente.nome = txtNome.Text;
            cliente.email = txtEmail.Text;
            cliente.telefone = txtTelefone.Text;
            cliente.cep = txtCep.Text;
            cliente.lougradouro = txtLogradouro.Text;
            cliente.numero = txtNumero.Text;
            cliente.bairro = txtBairro.Text;
            cliente.cidade = txtCidade.Text;
            cliente.estado = txtEstado.Text;

            using (cadastroDeClienteEntities ctx = new cadastroDeClienteEntities())
            {
                ctx.clientes.Add(cliente);
                ctx.SaveChanges();
            }
            txtId.Text = cliente.id.ToString();
        }

        private void Alterar(object sender, RoutedEventArgs e)
        {
            using (cadastroDeClienteEntities ctx = new cadastroDeClienteEntities())
            {
                cliente cliente = ctx.clientes.Find(Convert.ToInt32(txtId.Text));
                if (cliente != null)
                {
                    cliente.nome = txtNome.Text;
                    cliente.email = txtEmail.Text;
                    cliente.telefone = txtTelefone.Text;
                    cliente.cep = txtCep.Text;
                    cliente.lougradouro = txtLogradouro.Text;
                    cliente.numero = txtNumero.Text;
                    cliente.bairro = txtBairro.Text;
                    cliente.cidade = txtCidade.Text;
                    cliente.estado = txtEstado.Text;
                    ctx.SaveChanges();
                }
            }
        }

        private void Pesquisar(object sender, RoutedEventArgs e)
        {
            using (cadastroDeClienteEntities ctx = new cadastroDeClienteEntities())
            {
                cliente cliente = ctx.clientes.Find(Convert.ToInt32(txtId.Text));
                if (cliente != null)
                {
                    txtNome.Text = cliente.nome;
                    txtEmail.Text = cliente.email;
                    txtTelefone.Text = cliente.telefone;
                    txtCep.Text = cliente.cep;
                    txtLogradouro.Text = cliente.lougradouro;
                    txtNumero.Text = cliente.numero;
                    txtBairro.Text = cliente.bairro;
                    txtCidade.Text = cliente.cidade;
                    txtEstado.Text = cliente.estado;

                }

            }
        }

        private void Excluir(object sender, RoutedEventArgs e)
        {
            using (cadastroDeClienteEntities ctx = new cadastroDeClienteEntities())
            {
                cliente cliente = ctx.clientes.Find(Convert.ToInt32(txtId.Text));
                if (cliente != null)
                {
                    ctx.clientes.Remove(cliente);
                    ctx.SaveChanges();
                }
            }
        }

        private void Limpar(object sender, RoutedEventArgs e)
        {
            this.LimpaCampos();
        }
    }
}
