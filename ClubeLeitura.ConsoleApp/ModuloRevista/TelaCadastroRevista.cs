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
        public int numeroCaixa;
        public RepositorioRevista repoRevista;

        Revista revista;

        public TelaCadastroCaixa telaCaixa;
        public RepositorioCaixa repositorioCaixa = new();

        public Notificador notificador = new();

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

            if(telaCaixa.VisualizarCaixasCadastradas()== false)
            {
                return;
            }

            int numRevista;

            while (true)
            {
                Console.Write("Selecione a caixa que a revista será inserida. Digite um número: ");
                try { numRevista = int.Parse(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", "Erro"); continue; }

                if (repositorioCaixa.VerificarInputNumeroCaixa(numRevista) == false)
                {
                    notificador.ApresentarMensagem("O número digitado não existe\n", "Atencao");
                    continue;
                }
                else
                    break;
            }

            Caixa caixaSelecionada = repositorioCaixa.RetornarCaixaSelecionada(numRevista);

            Revista novaRevista = InputarRevista();
            novaRevista.caixa = caixaSelecionada;

            repoRevista.Inserir(novaRevista);

            notificador.ApresentarMensagem("Revista inserida", "Sucesso");
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
                try { numRevista = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", "Erro"); continue; }

                if (repoRevista.VerificarInputNumeroRevista(numRevista) == true)
                {
                    break;
                }
                else
                {
                    notificador.ApresentarMensagem("O número digitado não existe\n", "Atencao");
                    continue;
                }
            }

            revista = InputarRevista();
            revista.numeroRevista = numRevista;
            repoRevista.Editar(revista, revista.numeroRevista);

            notificador.ApresentarMensagem("Revista editada com sucesso", "Sucesso");
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
                try { numRevista = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", "Erro"); continue; }

                if (repoRevista.VerificarInputNumeroRevista(numRevista) == true)
                {
                    break;
                }
                else
                {
                    notificador.ApresentarMensagem("O número digitado não existe\n", "Atencao");
                    continue;
                }
            }

            repoRevista.Excluir(numRevista);

            notificador.ApresentarMensagem("Revista excluída com sucesso", "Sucesso");
        }

        public bool VisualizarRevistasCadastradas()
        {
            MostrarTitulo("Visualização de Revistas");

            if (repoRevista.VerificarVetorRevistasVazio() == true)
            {
                notificador.ApresentarMensagem("Registro de revistas vazio", "Atencao");
                return false;
            }
            else
            {
                repoRevista.Visualizar();
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

        private Revista InputarRevista()
        {
            revista = new();

            Console.Write("Digite a coleção: ");
            revista.colecao = Console.ReadLine();

            while (true)
            {
                Console.Write("Digite o número da edição: ");
                try { revista.edicao = int.Parse(Console.ReadLine()); break; } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", "erro"); continue; }

            }

            while (true)
            {
                Console.Write("Digite o ano: ");
                try { revista.ano = int.Parse(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", "erro"); continue; }

                if (revista.ano.ToString().Length != 4)
                {
                    notificador.ApresentarMensagem("Ano incorreto\n", "Atencao");
                    continue;
                }
                else 
                    break;
            }

            return revista;
        }
    }
}
