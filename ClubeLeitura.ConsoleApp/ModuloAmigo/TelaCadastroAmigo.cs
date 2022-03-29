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
        Notificador notificador = new();

        public RepositorioAmigo RepoAmigo
        {
            get { return repoAmigo; }
        }

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

            notificador.ApresentarMensagem("Amigo inserido com sucesso!", Notificador.Mensagem.sucesso);
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
                try { id = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (repoAmigo.VerificarInputID(id) == true)
                {
                    break;
                }
                else
                {
                    notificador.ApresentarMensagem("O ID digitado não existe\n", Notificador.Mensagem.atencao);
                    continue;
                }
            }

            amigo = InputarAmigo();
            amigo.Id = id;
            repoAmigo.Editar(amigo, amigo.Id);

            notificador.ApresentarMensagem("amigo editado com sucesso", Notificador.Mensagem.sucesso);
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
                try { id = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (repoAmigo.VerificarInputID(id) == true)
                {
                    break;
                }
                else
                {
                    notificador.ApresentarMensagem("O ID digitado não existe\n", Notificador.Mensagem.atencao);
                    continue;
                }
            }

            repoAmigo.Excluir(id);

            notificador.ApresentarMensagem("Amigo excluído com sucesso", Notificador.Mensagem.sucesso);
        }

        public bool VisualizarAmigosCadastrados()
        {
            MostrarTitulo("Visualização de Amigos");

            if (repoAmigo.VerificarVetorCaixasVazio() == true)
            {
                notificador.ApresentarMensagem("Registro de amigos vazio", Notificador.Mensagem.atencao);
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

            while (true)
            {
                Console.Write("Nome: ");
                amigo.Nome = Console.ReadLine();

                if (amigo.ValidarNome() == Amigo.Status.inválido)
                {
                    notificador.ApresentarMensagem("Campo inválido\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            while (true)
            {
                Console.Write("Nome Responsável: ");
                amigo.NomeResp = Console.ReadLine();

                if (amigo.ValidarNomeResp() == Amigo.Status.inválido)
                {
                    notificador.ApresentarMensagem("Campo inválido\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            while (true)
            {
                Console.Write("Endereço: ");
                amigo.Endereco = Console.ReadLine();

                if (amigo.ValidarEndereco() == Amigo.Status.inválido)
                {
                    notificador.ApresentarMensagem("Campo inválido\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            while (true)
            {
                Console.Write("Telefone: ");
                try { amigo.Telefone = int.Parse(Console.ReadLine()); break; } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n",Notificador.Mensagem.erro); continue; };

                if (amigo.ValidarTelefone() == Amigo.Status.inválido )
                {
                    notificador.ApresentarMensagem("Campo inválido\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }
   
            return amigo;
        }
    }
}
