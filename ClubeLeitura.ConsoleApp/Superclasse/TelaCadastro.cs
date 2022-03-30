using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Superclasse
{
    abstract public class TelaCadastro
    {
        Notificador _notificador = new();

        public Notificador Notificador { get { return _notificador; } }

        public virtual string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de [OBJETOS]");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public virtual void InserirNovoObjeto()
        {
            MostrarTitulo("");
        }

        public virtual void EditarObjeto()
        {
            MostrarTitulo("");
        }

        public virtual void ExcluirObjeto()
        {
            MostrarTitulo("");
        }
    

        public virtual bool VisualizarObjetosCadastrados()
        {
            MostrarTitulo("");
            return false;
   
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

    }
}
