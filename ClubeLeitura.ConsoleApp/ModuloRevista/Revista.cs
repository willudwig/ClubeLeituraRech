
using System;

namespace ClubeLeitura.ConsoleApp

{
    public class Revista
    {
        static int contadorRevista; 
        int numeroRevista;
        string colecao;
        int edicao;
        int ano;
        Caixa caixa;

        public int NumeroRevista  
        {
            get { return numeroRevista; }
            set { numeroRevista = value; }
        }
        public string Colecao     
        {
            get { return colecao; }
            set { colecao = value; }
        }
        public int Edicao         
        {
            get { return edicao; }
            set { edicao = value; }
        }
        public int Ano            
        {
            get { return ano; }
            set { ano = value; }
         }
        public Caixa Caixa
        {
            get { return caixa; }
            set { caixa = value; }
        }

        public Revista()
        {
            numeroRevista = ++contadorRevista;
        }

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