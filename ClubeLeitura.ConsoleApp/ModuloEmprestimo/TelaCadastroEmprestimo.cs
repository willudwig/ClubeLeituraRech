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

        RepositorioEmprestimo repoEmp = new();
        Notificador notificador = new();

        TelaCadastroAmigo telaAmigo;
        TelaCadastroRevista telaRevista;

        public TelaCadastroAmigo TelaAmigo
        {
            set { telaAmigo = value; }
        }
        public TelaCadastroRevista TelaRevista
        {
            set { telaRevista = value; }  
            get { return telaRevista; }
        }

 
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

            if (emprestimo == null)
                return;

            repoEmp.Inserir(emprestimo);

            notificador.ApresentarMensagem("Emprestimo inserido com sucesso!", Notificador.Mensagem.sucesso);
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
                try { numEmprestimo = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (repoEmp.VerificarInputNumeroEmprestimo(numEmprestimo) == true)
                {
                    break;
                }
                else
                {
                    notificador.ApresentarMensagem("O número digitado não existe\n", Notificador.Mensagem.atencao);
                    continue;
                }
            }

            emprestimo = InputarEmprestimo();
            emprestimo.NumeroEmp = numEmprestimo;
            repoEmp.Editar(emprestimo, emprestimo.NumeroEmp);

            notificador.ApresentarMensagem("Emprestimo editado com sucesso", Notificador.Mensagem.sucesso);
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
                try { numEmp = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (repoEmp.VerificarInputNumeroEmprestimo(numEmp) == true)
                {
                    break;
                }
                else
                {
                    notificador.ApresentarMensagem("O número digitado não existe\n", Notificador.Mensagem.atencao);
                    continue;
                }
            }

            repoEmp.Excluir(numEmp);

            notificador.ApresentarMensagem("Empréstimo excluído com sucesso", Notificador.Mensagem.sucesso);
        }

        public bool VisualizarEmprestimosCadastrados()
        {
            MostrarTitulo("Visualização de Caixas");

            if (repoEmp.VerificarVetorEmprestimosVazio() == true)
            {
                notificador.ApresentarMensagem("Registro de emprestimos vazio",Notificador.Mensagem.atencao);
                return false;
            }
            else
            {
                repoEmp.Visualizar();
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

        private Emprestimo InputarEmprestimo()
        {
            Emprestimo emprestimo = new();

            //Escolhendo Amigo
            Console.WriteLine("Escolha o amigo: \n");

             if (telaAmigo.VisualizarAmigosCadastrados() == false)
            {
                return null;
            }

            int opcao;

            while (true)
            {
                Console.Write("\nDigite um número: ");
                try { opcao = int.Parse(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (telaAmigo.RepoAmigo.VerificarInputID(opcao) == false)
                {
                    notificador.ApresentarMensagem("ID não existe", Notificador.Mensagem.atencao);
                    continue;
                }
                else if (repoEmp.VerificarAmigoRepetido(emprestimo) == true)
                {
                    notificador.ApresentarMensagem("Este amigo já fez um emprestimo", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            emprestimo.Amigo = new();
            Amigo amigoSelecionado = telaAmigo.RepoAmigo.RetornarAmigoSelecionado(opcao);

            emprestimo.Amigo = amigoSelecionado;

            //============ fim amigo

            //Escolhendo Revista
            Console.WriteLine("Escolha a revista: \n");

            if (telaRevista.VisualizarRevistasCadastradas() == false)
            {
                return null;
            }

            while (true)
            {
                Console.Write("\nDigite um número: ");
                try { opcao = int.Parse(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (telaRevista.RepoRevista.VerificarInputNumeroRevista(opcao) == false)
                {
                    notificador.ApresentarMensagem("O número não existe", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            emprestimo.Revista = new();
            Revista revistaSelecionada = TelaRevista.RepoRevista.RetornarRevistaSelecionada(opcao);

            emprestimo.Revista = revistaSelecionada;

            //============ fim revista

            while (true)
            {
                Console.Write("Digite a data que o amigo pegou: ");
                try { DateTime.TryParse(Console.ReadLine(), out emprestimo.dataPegou); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (emprestimo.ValidarDataPegou() == Emprestimo.StatusValidacao.inválido)
                {
                    notificador.ApresentarMensagem("Campo inválido\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            while (true)
            {
                Console.Write("Digite a data que devolveu: ");
                try { DateTime.TryParse(Console.ReadLine(), out emprestimo.dataPegou); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (emprestimo.ValidarDataDevolveu() == Emprestimo.StatusValidacao.inválido)
                {
                    notificador.ApresentarMensagem("Campo inválido\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            Console.WriteLine("Status:\n");
            Console.WriteLine("1- Aberto\n2- Fechado");

            while (true) 
            {
                Console.Write("Digite um número: ");
                try { opcao = int.Parse(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (opcao != 1 && opcao != 2)
                {
                    notificador.ApresentarMensagem("Opção inválida", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            switch (opcao)
            {
                case 1:
                    emprestimo.status = (Emprestimo.StatusEmprestimo)0;
                    break;
                case 2:
                    emprestimo.status = (Emprestimo.StatusEmprestimo)1;
                    break;
            }

            return emprestimo;
        }
        #endregion
    }

}
