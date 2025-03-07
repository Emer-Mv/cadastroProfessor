using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace cadastroProfessor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Código de inicialização, se necessário
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textNome.Text) &&
                    !string.IsNullOrEmpty(textTitulacao.Text) &&
                    !string.IsNullOrEmpty(textFormacao.Text) &&
                    !string.IsNullOrEmpty(textEmail.Text))
                {
                    Professores cadProfessor = new Professores
                    {
                        Professor = textNome.Text,
                        Titulacao = textTitulacao.Text,
                        Formacao = textFormacao.Text,
                        EmailProfessor = textEmail.Text
                    };

                    if (cadProfessor.CadastrarProfessores())
                    {
                        MessageBox.Show($"O Professor {cadProfessor.Professor} foi cadastrado com sucesso!");
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível cadastrar o professor!");
                    }
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos corretamente!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar Professor: " + ex.Message);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textNome.Text))
                {
                    Professores cadProfessor = new Professores
                    {
                        Professor = textNome.Text
                    };

                    MySqlDataReader reader = cadProfessor.localizarProfessor();

                    if (reader != null && reader.HasRows)
                    {
                        reader.Read();
                        lblID.Text = reader["id_professor"].ToString();
                        textNome.Text = reader["professor"].ToString();
                        textTitulacao.Text = reader["titulacao"].ToString();
                        textFormacao.Text = reader["formacao"].ToString();
                        textEmail.Text = reader["email_professor"].ToString();
                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show("Professor não encontrado!");
                        LimparCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Preencha o campo nome do professor para realizar a pesquisa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível localizar o professor: " + ex.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(lblID.Text) &&
                    !string.IsNullOrEmpty(textNome.Text) &&
                    !string.IsNullOrEmpty(textTitulacao.Text) &&
                    !string.IsNullOrEmpty(textFormacao.Text) &&
                    !string.IsNullOrEmpty(textEmail.Text))
                {
                    Professores cadProfessor = new Professores
                    {
                        Id = int.Parse(lblID.Text),
                        Professor = textNome.Text,
                        Titulacao = textTitulacao.Text,
                        Formacao = textFormacao.Text,
                        EmailProfessor = textEmail.Text
                    };

                    if (cadProfessor.atualizarProfessor())
                    {
                        MessageBox.Show("Os dados do Professor foram atualizados com sucesso!");
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível atualizar as informações do Professor.");
                    }
                }
                else
                {
                    MessageBox.Show("Favor localizar o Professor que deseja atualizar as informações.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar dados do Professor: " + ex.Message);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(lblID.Text))
                {
                    Professores cadProfessor = new Professores
                    {
                        Id = int.Parse(lblID.Text)
                    };

                    if (cadProfessor.deletarProfessor())
                    {
                        MessageBox.Show("O professor foi excluido com sucesso");
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel excluir o professor");
                    }
                }
                else
                {
                    MessageBox.Show("Favor pesquisar qual Professor deseja excluir.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir professor: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            textNome.Clear();
            textTitulacao.Clear();
            textFormacao.Clear();
            textEmail.Clear();
            lblID.Text = "";
            textNome.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Limpe os campos do formulário
            textNome.Clear();
            textTitulacao.Clear();
            textFormacao.Clear();
            textEmail.Clear();
            lblID.Text = "";
            textNome.Focus();
        }
    }
}
