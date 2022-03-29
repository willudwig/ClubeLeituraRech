using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloRevista;

namespace ClubeLeitura.ConsoleApp
{
    public class TelaCadastroRevista
    {
        RepositorioRevista repoRevista = new();
        Revista revista;
        TelaCadastroCaixa telaCaixa;
        RepositorioCaixa repositorioCaixa = new();
        Notificador notificador = new();

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


        public string MostrarOpcoes()
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

        public void InserirNovaRevista()
        {
            MostrarTitulo("Inserindo Nova Revista");

            if(telaCaixa.VisualizarCaixasCadastradas() == false)
            {
                return;
            }

            int numCaixa;

            while (true)
            {
                Console.Write("Selecione a caixa em que a revista será inserida. Digite um número: ");
                try { numCaixa = int.Parse(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (repositorioCaixa.VerificarInputNumeroCaixa(numCaixa) == false)
                {
                    notificador.ApresentarMensagem("O número digitado não existe\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            Caixa caixaSelecionada = repositorioCaixa.RetornarCaixaSelecionada(numCaixa);

            Revista novaRevista = InputarRevista();
            novaRevista.Caixa = caixaSelecionada;

            repoRevista.Inserir(novaRevista);

            notificador.ApresentarMensagem("Revista inserida", Notificador.Mensagem.sucesso);
        }

        public void EditarRevista()
        {
            MostrarTitulo("Editando Revista");

            if (VisualizarRevistasCadastradas() == false)
                return;

            int numRevista;

            while (true)
            {
                Console.Write("Digite o número da revista que deseja editar: ");
                try { numRevista = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (repoRevista.VerificarInputNumeroRevista(numRevista) == true)
                {
                    break;
                }
                else
                {
                    notificador.ApresentarMensagem("O número digitado não existe\n", Notificador.Mensagem.atencao);
                    continue;
                }
            }

            revista = InputarRevista();
            revista.NumeroRevista = numRevista;
            repoRevista.Editar(revista, revista.NumeroRevista);

            notificador.ApresentarMensagem("Revista editada com sucesso", Notificador.Mensagem.sucesso);
        }

        public void ExcluirRevista()
        {
            MostrarTitulo("Excluindo Revista");

            if (VisualizarRevistasCadastradas() == false)
                return;

            int numRevista;

            while (true)
            {
                Console.Write("Digite o número da revista que deseja excluir: ");
                try { numRevista = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (repoRevista.VerificarInputNumeroRevista(numRevista) == true)
                {
                    break;
                }
                else
                {
                    notificador.ApresentarMensagem("O número digitado não existe\n", Notificador.Mensagem.atencao);
                    continue;
                }
            }

            repoRevista.Excluir(numRevista);

            notificador.ApresentarMensagem("Revista excluída com sucesso", Notificador.Mensagem.sucesso);
        }

        public bool VisualizarRevistasCadastradas()
        {
            MostrarTitulo("Visualização de Revistas");

            if (repoRevista.VerificarVetorRevistasVazio() == true)
            {
                notificador.ApresentarMensagem("Registro de revistas vazio", Notificador.Mensagem.atencao);
                return false;
            }
            else
            {
                repoRevista.Visualizar();
                Console.WriteLine();
                return true;
            }
            
        }

        #region metodos privados
        private void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
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
                    notificador.ApresentarMensagem("Campo inválido", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            while (true)
            {
                Console.Write("Digite o número da edição: ");
                try { revista.Edicao = int.Parse(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (revista.ValidarEdicao() == Revista.Status.inválido)
                {
                    notificador.ApresentarMensagem("Número de edição inválido", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            while (true)
            {
                Console.Write("Digite o ano: ");
                try { revista.Ano = int.Parse(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (revista.ValidarAno() == Revista.Status.inválido)
                {
                    notificador.ApresentarMensagem("Ano incorreto\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else 
                    break;
            }

            return revista;
        }
        #endregion
    }
}
