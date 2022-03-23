using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.ModuloAmigo;

namespace ClubeLeitura.ConsoleApp
{
    public class TelaCadastroAmigo
    {
        Amigo amigo;
        RepositorioAmigo repoAmigo = new();

        public Notificador notificador = new();


        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Amigos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoAmigo()
        {
            MostrarTitulo("Inserindo novo Amigo");

            amigo = InputarAmigo();

            repoAmigo.Inserir(amigo);

            notificador.ApresentarMensagem("Amigo inserido com sucesso!", "Sucesso");
        }

        public void EditarAmigo()
        {
            MostrarTitulo("Editando Amigo");

            if (VisualizarAmigosCadastrados() == false)
                return;

            int id;

            while (true)
            {
                Console.Write("Digite o número da caixa que deseja editar: ");
                try { id = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", "Erro"); continue; }

                if (repoAmigo.VerificarInputID(id) == true)
                {
                    break;
                }
                else
                {
                    notificador.ApresentarMensagem("O ID digitado não existe\n", "Atencao");
                    continue;
                }
            }

            amigo = InputarAmigo();
            amigo.id = id;
            repoAmigo.Editar(amigo, amigo.id);

            notificador.ApresentarMensagem("amigo editado com sucesso", "Sucesso");
        }

        public void ExcluirAmigo()
        {
            MostrarTitulo("Excluindo Amigo");

            if (VisualizarAmigosCadastrados() == false)
                return;

            int id;

            while (true)
            {
                Console.Write("Digite o número da caixa que deseja excluir: ");
                try { id = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", "Erro"); continue; }

                if (repoAmigo.VerificarInputID(id) == true)
                {
                    break;
                }
                else
                {
                    notificador.ApresentarMensagem("O ID digitado não existe\n", "Atencao");
                    continue;
                }
            }

            repoAmigo.Excluir(id);

            notificador.ApresentarMensagem("Amigo excluído com sucesso", "Sucesso");
        }

        public bool VisualizarAmigosCadastrados()
        {
            MostrarTitulo("Visualização de Amigos");

            if (repoAmigo.VerificarVetorCaixasVazio() == true)
            {
                notificador.ApresentarMensagem("Registro de amigos vazio", "Atencao");
                return false;
            }
            else
            {
                repoAmigo.Visualizar();
                Console.WriteLine();
                return true;
            }
        }

        private void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        private Amigo InputarAmigo()
        {
            Amigo amigo = new();

            Console.Write("Nome: ");
            amigo.nome = Console.ReadLine();

            Console.Write("Nome Responsável: ");
            amigo.nomeResp = Console.ReadLine();

            Console.Write("Endereço: ");
            amigo.endereco = Console.ReadLine();

            while (true)
            {
                Console.Write("Telefone: ");
                try { amigo.telefone = int.Parse(Console.ReadLine()); break; } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n","Erro"); continue; };
            }
   
            return amigo;
        }
    }
}
