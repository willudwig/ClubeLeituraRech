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
        public int numeroEmp;
        public Amigo amigo;
        public Revista revista;
        public DateTime dataPegou;
        public DateTime dataDevolveu;
        public Status status = new();

        public enum Status
        {
            Aberto, Fechado
        } 
       
    }
}
