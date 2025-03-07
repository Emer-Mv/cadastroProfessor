using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace cadastroProfessor
{
    internal class Professores
    {
        // Propriedades da classe
        public int Id { get; set; }
        public string Professor { get; set; }
        public string Titulacao { get; set; }
        public string Formacao { get; set; }
        public string EmailProfessor { get; set; }

        // Método para cadastrar o Professor no banco de dados
        public bool CadastrarProfessores()
        {
            try
            {
                using (MySqlConnection MysqlconexaoBanco = new MySqlConnection(ConexaoBanco.conexao))
                {
                    MysqlconexaoBanco.Open();
                    string insert = "INSERT INTO escola.tb_professor (professor, titulacao, formacao, email_professor) VALUES (@Professor, @Titulacao, @Formacao, @EmailProfessor)";

                    using (MySqlCommand comandoSql = new MySqlCommand(insert, MysqlconexaoBanco))
                    {
                        comandoSql.Parameters.AddWithValue("@Professor", Professor);
                        comandoSql.Parameters.AddWithValue("@Titulacao", Titulacao);
                        comandoSql.Parameters.AddWithValue("@Formacao", Formacao);
                        comandoSql.Parameters.AddWithValue("@EmailProfessor", EmailProfessor);
                        comandoSql.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - método cadastrarProfessores: " + ex.Message);
                return false;
            }
        }

        // Método para localizar o Professor no banco de dados
        public MySqlDataReader localizarProfessor()
        {
            try
            {
                MySqlConnection mySqlConexaoBanco = new MySqlConnection(ConexaoBanco.conexao);
                mySqlConexaoBanco.Open();
                string select = "SELECT id_professor, professor, titulacao, formacao, email_professor FROM escola.tb_professor WHERE professor = @NomeProfessor";
                MySqlCommand comandoSql = mySqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = select;
                comandoSql.Parameters.AddWithValue("@NomeProfessor", this.Professor);
                MySqlDataReader reader = comandoSql.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - Método localizarProfessor: " + ex.Message);
                return null;
            }
        }

        // Método para atualizar o Professor no banco de dados
        public bool atualizarProfessor()
        {
            try
            {
                using (MySqlConnection mySqlConexaoBanco = new MySqlConnection(ConexaoBanco.conexao))
                {
                    mySqlConexaoBanco.Open();
                    string update = "UPDATE escola.tb_professor SET professor = @Professor, titulacao = @Titulacao, formacao = @Formacao, email_professor = @EmailProfessor WHERE id_professor = @Id";
                    using (MySqlCommand comandoSql = new MySqlCommand(update, mySqlConexaoBanco))
                    {
                        comandoSql.Parameters.AddWithValue("@Id", Id);
                        comandoSql.Parameters.AddWithValue("@Professor", Professor);
                        comandoSql.Parameters.AddWithValue("@Titulacao", Titulacao);
                        comandoSql.Parameters.AddWithValue("@Formacao", Formacao);
                        comandoSql.Parameters.AddWithValue("@EmailProfessor", EmailProfessor);
                        comandoSql.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - método atualizarProfessor: " + ex.Message);
                return false;
            }
        }

        // Método para deletar o Professor no banco de dados
        public bool deletarProfessor()
        {
            try
            {
                using (MySqlConnection mySqlConexaoBanco = new MySqlConnection(ConexaoBanco.conexao))
                {
                    mySqlConexaoBanco.Open();
                    string delete = "DELETE FROM escola.tb_professor WHERE id_professor = @Id";
                    using (MySqlCommand comandoSql = new MySqlCommand(delete, mySqlConexaoBanco))
                    {
                        comandoSql.Parameters.AddWithValue("@Id", Id);
                        comandoSql.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - método deletarProfessor: " + ex.Message);
                return false;
            }
        }
    }
}