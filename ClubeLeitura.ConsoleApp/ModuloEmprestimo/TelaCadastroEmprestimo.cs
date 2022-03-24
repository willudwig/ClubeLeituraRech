using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeLeitura.ConsoleApp.ModuloAmigo;


namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    public class TelaCadastroEmprestimo
    {
        Emprestimo emprestimo;

        public RepositorioEmprestimo repoEmp = new();
        public Notificador notificador = new();

        public TelaCadastroAmigo telaAmigo;
        public TelaCadastroRevista telaRevista;
 
        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Emprestimos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoEmprestimo()
        {
            MostrarTitulo("Inserindo novo Emprestimo");

            emprestimo = InputarEmprestimo();

            repoEmp.Inserir(emprestimo);

            notificador.ApresentarMensagem("Emprestimo inserido com sucesso!", "Sucesso");
        }

        public void EditarEmprestimo()
        {
            MostrarTitulo("Editando Emprestimo");

            if (VisualizarEmprestimosCadastrados() == false)
                return;

            int numEmprestimo;

            while (true)
            {
                Console.Write("Digite o número do empréstimo que deseja editar: ");
                try { numEmprestimo = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", "Erro"); continue; }

                if (repoEmp.VerificarInputNumeroEmprestimo(numEmprestimo) == true)
                {
                    break;
                }
                else
                {
                    notificador.ApresentarMensagem("O número digitado não existe\n", "Atencao");
                    continue;
                }
            }

            emprestimo = InputarEmprestimo();
            emprestimo.numeroEmp = numEmprestimo;
            repoEmp.Editar(emprestimo, emprestimo.numeroEmp);

            notificador.ApresentarMensagem("Emprestimo editado com sucesso", "Sucesso");
        }

        public void ExcluirEmprestimo()
        {
            MostrarTitulo("Excluindo Emprestimo");

            if (VisualizarEmprestimosCadastrados() == false)
                return;

            int numEmp;

            while (true)
            {
                Console.Write("Digite o número do empréstimo que deseja excluir: ");
                try { numEmp = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", "Erro"); continue; }

                if (repoEmp.VerificarInputNumeroEmprestimo(numEmp) == true)
                {
                    break;
                }
                else
                {
                    notificador.ApresentarMensagem("O número digitado não existe\n", "Atencao");
                    continue;
                }
            }

            repoEmp.Excluir(numEmp);

            notificador.ApresentarMensagem("Empréstimo excluído com sucesso", "Sucesso");
        }

        public bool VisualizarEmprestimosCadastrados()
        {
            MostrarTitulo("Visualização de Caixas");

            if (repoEmp.VerificarVetorEmprestimosVazio() == true)
            {
                notificador.ApresentarMensagem("Registro de emprestimos vazio", "Atencao");
                return false;
            }
            else
            {
                repoEmp.Visualizar();
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

        private Emprestimo InputarEmprestimo()
        {
            Emprestimo emprestimo = new();

            //Escolhendo Amigo
            Console.WriteLine("Escolha o amigo: \n");

            telaAmigo.VisualizarAmigosCadastrados();

            int opcao;

            while (true)
            {
                Console.Write("\nDigite um número: ");
                try { opcao = int.Parse(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", "Erro"); continue; }

                if (telaAmigo.repoAmigo.VerificarInputID(opcao) == false)
                {
                    notificador.ApresentarMensagem("ID não existe", "Atencao");
                    continue;
                }
                else if (repoEmp.VerificarAmigoRepetido(emprestimo) == true)
                {
                    notificador.ApresentarMensagem("Este amigo já fez um emprestimo","Atencao");
                    continue;
                }
                else
                    break;
            }

            emprestimo.amigo = new();
            Amigo amigoSelecionado = telaAmigo.repoAmigo.RetornarAmigoSelecionado(opcao);

            emprestimo.amigo = amigoSelecionado;
            //============ fim amigo

            //Escolhendo Revista
            Console.WriteLine("Escolha a revista: \n");

            telaRevista.VisualizarRevistasCadastradas();

            while (true)
            {
                Console.Write("\nDigite um número: ");
                try { opcao = int.Parse(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", "Erro"); continue; }

                if (telaRevista.repoRevista.VerificarInputNumeroRevista(opcao) == false)
                {
                    notificador.ApresentarMensagem("O número não existe", "Atencao");
                    continue;
                }
                else
                    break;
            }

            emprestimo.revista = new();
            Revista revistaSelecionada = telaRevista.repoRevista.RetornarRevistaSelecionada(opcao);

            emprestimo.revista = revistaSelecionada;
            //============ fim revista

            while (true)
            {
                Console.Write("Digite a data que o amigo pegou: ");
                try { DateTime.TryParse(Console.ReadLine(), out emprestimo.dataPegou); break; } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", "Erro"); continue; }
            }

            while (true)
            {
                Console.Write("Digite a data que devolveu: ");
                try { DateTime.TryParse(Console.ReadLine(), out emprestimo.dataPegou); break; } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", "Erro"); continue; }
            }

            Console.WriteLine("Status:\n");
            Console.WriteLine("1- Aberto\n2- Fechado");

            while (true) 
            {
                Console.Write("Digite um número: ");
                try { opcao = int.Parse(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", "Erro"); continue; }

                if (opcao != 1 && opcao != 2)
                {
                    notificador.ApresentarMensagem("Opção inváilda", "Atencao");
                    continue;
                }
                else
                    break;
            }

            switch (opcao)
            {
                case 1:
                    emprestimo.status = (Emprestimo.Status)0;
                    break;
                case 2:
                    emprestimo.status = (Emprestimo.Status)1;
                    break;
            }

            return emprestimo;
        }
    }

}
