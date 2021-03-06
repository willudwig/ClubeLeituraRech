using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp
{
    public class Amigo
    {
        static int contadorAmigo;

        public int id;
        public string nome;
        public string nomeResp;
        public string endereco;
        public int telefone;

        public Amigo()
        {
            id = ++contadorAmigo;
        }

        #region validações
        public Status ValidarNome()
        {
            Status validacao = (Status)0;

            if (string.IsNullOrEmpty(nome))
                validacao = (Status)1;

            if (nome.Contains("0") || nome.Contains("1") || nome.Contains("2") || nome.Contains("3") || nome.Contains("4") || nome.Contains("5") || nome.Contains("6") || nome.Contains("7") || nome.Contains("8") || nome.Contains("9"))
                validacao = (Status)1;

            return validacao;
        }

        public Status ValidarNomeResp()
        {
            Status validacao = (Status)0;

            if (string.IsNullOrEmpty(nomeResp))
                validacao = (Status)1;

            if (nomeResp.Contains("0") || nomeResp.Contains("1") || nomeResp.Contains("2") || nomeResp.Contains("3") || nomeResp.Contains("4") || nomeResp.Contains("5") || nomeResp.Contains("6") || nomeResp.Contains("7") || nomeResp.Contains("8") || nomeResp.Contains("9"))
                validacao = (Status)1;

            return validacao;
        }

        public Status ValidarEndereco()
        {
            Status validacao = (Status)0;

            if (string.IsNullOrEmpty(endereco))
                validacao = (Status)1;
   
            return validacao;
        }

        public Status ValidarTelefone()
        {
            Status validacao = (Status)0;

            if (string.IsNullOrEmpty(telefone.ToString()))
                validacao = (Status)1;

            if (telefone.ToString().Length > 9 && telefone.ToString().Length < 8)
                validacao = (Status)1;

            return validacao;
        }

        public enum Status { válido, inválido }
        #endregion
    }
}
