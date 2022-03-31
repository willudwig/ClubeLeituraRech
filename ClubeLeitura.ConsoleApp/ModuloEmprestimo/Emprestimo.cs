using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using ClubeLeitura.ConsoleApp.ModuloEmprestimo;


namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo
    {
        static int contadorEmprestimo;
        
        public int numeroEmp;
        public Amigo amigo;
        public Revista revista;
        public DateTime dataPegou;
        public DateTime dataDevolveu;
        public StatusEmprestimo status;

        public Emprestimo()
        {
            numeroEmp = ++contadorEmprestimo;
        }

        public enum StatusEmprestimo
        {
            Aberto, Fechado
        }

        #region validações
        public StatusValidacao ValidarDataPegou()
        {
            StatusValidacao validacao = (StatusValidacao)0;

            if (string.IsNullOrEmpty(dataPegou.ToString()))
                validacao = (StatusValidacao)1;

            return validacao;
        }

        public StatusValidacao ValidarDataDevolveu()
        {
            StatusValidacao validacao = (StatusValidacao)0;

            if (string.IsNullOrEmpty(dataDevolveu.ToString()))
                validacao = (StatusValidacao)1;

            return validacao;
        }

        public enum StatusValidacao { válido, inválido }
        #endregion

       
       
    }
}
