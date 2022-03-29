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
        int numeroEmp;
        Amigo amigo;
        Revista revista;
        public DateTime dataPegou;
        public DateTime dataDevolveu;
        public StatusEmprestimo status;


       

        public Amigo Amigo
        {
            get { return amigo; }
            set { amigo = value; }
        }

        public Revista Revista
        {
            get { return revista; }
            set { revista = value; }
        }

        public int NumeroEmp
        {
            get { return numeroEmp; }
            set { numeroEmp = value; }
        }

 
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

        public enum StatusEmprestimo
        {
            Aberto, Fechado
        } 
       
    }
}
