using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using ClubeLeitura.ConsoleApp.Superclasse;


namespace ClubeLeitura.ConsoleApp
{
    public class TelaCadastroRevista : TelaCadastro
    {
        RepositorioRevista repoRevista = new();
        Revista revista;
        TelaCadastroCaixa telaCaixa;
        RepositorioCaixa repositorioCaixa = new();
       

        public RepositorioRevista RepoRevista
        {
            get { return repoRevista; }
        }

        public TelaCadastroCaixa TelaCaixa
        {
            get { return telaCaixa; }
            set { telaCaixa = value; }
        }

        public RepositorioCaixa RepositorioCaixa
        {
            get { return repositorioCaixa; }
            set { repositorioCaixa = value; }
        }


        public override string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Revistas");

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
            MostrarTitulo("Inserindo Nova Revista");

            if(telaCaixa.VisualizarObjetosCadastrados() == false)
            {
                return;
            }

            int numCaixa;

            while (true)
            {
                Console.Write("Selecione a caixa em que a revista será inserida. Digite um número: ");
                try { numCaixa = int.Parse(Console.ReadLine()); } catch (Exception) { Notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (repositorioCaixa.VerificarInputNumeroCaixa(numCaixa) == false)
                {
                    Notificador.ApresentarMensagem("O número digitado não existe\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            Caixa caixaSelecionada = repositorioCaixa.RetornarObjetoSelecionado(numCaixa);

            Revista novaRevista = InputarRevista();
            novaRevista.Caixa = caixaSelecionada;

            repoRevista.Inserir(novaRevista);

            Notificador.ApresentarMensagem("Revista inserida", Notificador.Mensagem.sucesso);
        }

        public override void EditarObjeto()
        {
            MostrarTitulo("Editando Revista");

            if (VisualizarObjetosCadastrados() == false)
                return;

            int numRevista;

            while (true)
            {
                Console.Write("Digite o número da revista que deseja editar: ");
                try { numRevista = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { Notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (repoRevista.VerificarInputNumeroRevista(numRevista) == true)
                {
                    break;
                }
                else
                {
                    Notificador.ApresentarMensagem("O número digitado não existe\n", Notificador.Mensagem.atencao);
                    continue;
                }
            }

            revista = InputarRevista();
            revista.NumeroRevista = numRevista;
            repoRevista.Editar(revista, revista.NumeroRevista);

            Notificador.ApresentarMensagem("Revista editada com sucesso", Notificador.Mensagem.sucesso);
        }

        public void ExcluirObjeto()
        {
            MostrarTitulo("Excluindo Revista");

            if (VisualizarObjetosCadastrados() == false)
                return;

            int numRevista;

            while (true)
            {
                Console.Write("Digite o número da revista que deseja excluir: ");
                try { numRevista = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { Notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (repoRevista.VerificarInputNumeroRevista(numRevista) == true)
                {
                    break;
                }
                else
                {
                    Notificador.ApresentarMensagem("O número digitado não existe\n", Notificador.Mensagem.atencao);
                    continue;
                }
            }

            repoRevista.Excluir(numRevista);

            Notificador.ApresentarMensagem("Revista excluída com sucesso", Notificador.Mensagem.sucesso);
        }

        public bool VisualizarObjetosCadastrados()
        {
            MostrarTitulo("Visualização de Revistas");

            if (repoRevista.VerificarVetorRevistasVazio() == true)
            {
                Notificador.ApresentarMensagem("Registro de revistas vazio", Notificador.Mensagem.atencao);
                return false;
            }
            else
            {
                repoRevista.Visualizar();
                Console.WriteLine();
                return true;
            }
            
        }


        private Revista InputarRevista()
        {
            revista = new();

            while (true)
            {
                Console.Write("Digite a coleção: ");
                revista.Colecao = Console.ReadLine();

                if (revista.ValidarColecao() == Revista.Status.inválido)
                {
                    Notificador.ApresentarMensagem("Campo inválido", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            while (true)
            {
                Console.Write("Digite o número da edição: ");
                try { revista.Edicao = int.Parse(Console.ReadLine()); } catch (Exception) { Notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (revista.ValidarEdicao() == Revista.Status.inválido)
                {
                    Notificador.ApresentarMensagem("Número de edição inválido", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            while (true)
            {
                Console.Write("Digite o ano: ");
                try { revista.Ano = int.Parse(Console.ReadLine()); } catch (Exception) { Notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (revista.ValidarAno() == Revista.Status.inválido)
                {
                    Notificador.ApresentarMensagem("Ano incorreto\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else 
                    break;
            }

            return revista;
        }

    }
}
