using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.Superclasse;

namespace ClubeLeitura.ConsoleApp
{
    public class TelaCadastroAmigo : TelaCadastro
    {
        Amigo amigo;
        RepositorioAmigo repoAmigo = new();

        public RepositorioAmigo RepoAmigo
        {
            get { return repoAmigo; }
        }


        public override string MostrarOpcoes()
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

        public override void InserirNovoObjeto()
        {
            MostrarTitulo("Inserindo novo Amigo");

            amigo = InputarAmigo();

            repoAmigo.Inserir(amigo);

            Notificador.ApresentarMensagem("Amigo inserido com sucesso!", Notificador.Mensagem.sucesso);
        }

        public override void EditarObjeto()
        {
            MostrarTitulo("Editando Amigo");

            if (VisualizarObjetosCadastrados() == false)
                return;

            int id;

            while (true)
            {
                Console.Write("Digite o número da caixa que deseja editar: ");
                try { id = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { Notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (repoAmigo.VerificarInputID(id) == true)
                {
                    break;
                }
                else
                {
                    Notificador.ApresentarMensagem("O ID digitado não existe\n", Notificador.Mensagem.atencao);
                    continue;
                }
            }

            amigo = InputarAmigo();
            amigo.id = id;
            repoAmigo.Editar(amigo, amigo.id);

            Notificador.ApresentarMensagem("amigo editado com sucesso", Notificador.Mensagem.sucesso);
        }

        public override void ExcluirObjeto()
        {
            MostrarTitulo("Excluindo Amigo");

            if (VisualizarObjetosCadastrados() == false)
                return;

            int id;

            while (true)
            {
                Console.Write("Digite o número da caixa que deseja excluir: ");
                try { id = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { Notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (repoAmigo.VerificarInputID(id) == true)
                {
                    break;
                }
                else
                {
                    Notificador.ApresentarMensagem("O ID digitado não existe\n", Notificador.Mensagem.atencao);
                    continue;
                }
            }

            repoAmigo.Excluir(id);

            Notificador.ApresentarMensagem("Amigo excluído com sucesso", Notificador.Mensagem.sucesso);
        }

        public override bool VisualizarObjetosCadastrados()
        {
            MostrarTitulo("Visualização de Amigos");

            if (repoAmigo.VerificarVetorCaixasVazio() == true)
            {
                Notificador.ApresentarMensagem("Registro de amigos vazio", Notificador.Mensagem.atencao);
                return false;
            }
            else
            {
                repoAmigo.Visualizar();
                Console.WriteLine();
                return true;
            }
        }

        private Amigo InputarAmigo()
        {
            Amigo amigo = new();

            while (true)
            {
                Console.Write("Nome: ");
                amigo.nome = Console.ReadLine();

                if (amigo.ValidarNome() == Amigo.Status.inválido)
                {
                    Notificador.ApresentarMensagem("Campo inválido\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            while (true)
            {
                Console.Write("Nome Responsável: ");
                amigo.nomeResp = Console.ReadLine();

                if (amigo.ValidarNomeResp() == Amigo.Status.inválido)
                {
                    Notificador.ApresentarMensagem("Campo inválido\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            while (true)
            {
                Console.Write("Endereço: ");
                amigo.endereco = Console.ReadLine();

                if (amigo.ValidarEndereco() == Amigo.Status.inválido)
                {
                    Notificador.ApresentarMensagem("Campo inválido\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            while (true)
            {
                Console.Write("Telefone: ");
                amigo.telefone = int.Parse(Console.ReadLine()); 

                if (amigo.ValidarTelefone() == Amigo.Status.inválido )
                {
                    Notificador.ApresentarMensagem("Campo inválido\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }
   
            return amigo;
        }

    }
}
