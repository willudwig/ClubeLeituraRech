
using System;

namespace ClubeLeitura.ConsoleApp

{
    public class Revista
    {
        public int numeroRevista;
        public string colecao;
        public int edicao;
        public int ano;
        public Caixa caixa;

        

        public Status ValidarAno()
        {
            Status validacao = (Status)0 ;

            if(ano.ToString().Length != 4)
                validacao = (Status)1 ;

            if(string.IsNullOrEmpty( ano.ToString() ))
                validacao = (Status)1 ;

            if(ano > DateTime.Now.Year)
                validacao |= (Status)1 ;

            return validacao;
        }

        public Status ValidarEdicao()
        {
            Status validacao = (Status)0 ;

            if (edicao < 0)
                validacao = (Status)1 ;

            if (string.IsNullOrEmpty(edicao.ToString()))
                validacao = (Status)1 ;

            return validacao;
        } 

        public Status ValidarColecao()
        {
            Status validacao = (Status)0;

            if (string.IsNullOrEmpty(colecao))
                validacao = (Status)1;

            return validacao;
        }

        public enum Status { válido, inválido}
    }
}