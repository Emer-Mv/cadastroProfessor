using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroProfessor
{
    static class ConexaoBanco
    {
        private const string server = "localhost";
        private const string bancoDados = "escola";
        private const string user = "root";
        private const string password = "@3637766Mv";

        static public string conexao = $"server={server}; user id={user}; database={bancoDados}; password={password}";
    }
}

