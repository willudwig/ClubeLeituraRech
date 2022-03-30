using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.Superclasse;


namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    public class TelaCadastroEmprestimo : TelaCadastro
    {
        Emprestimo emprestimo;
        RepositorioEmprestimo repoEmp = new();
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

 
        public override string MostrarOpcoes()
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

        public override void InserirNovoObjeto()
        {
            MostrarTitulo("Inserindo novo Emprestimo");

            emprestimo = InputarEmprestimo();

            if (emprestimo == null)
                return;

            repoEmp.Inserir(emprestimo);

            Notificador.ApresentarMensagem("Emprestimo inserido com sucesso!", Notificador.Mensagem.sucesso);
        }

        public override void EditarObjeto()
        {
            MostrarTitulo("Editando Emprestimo");

            if (VisualizarObjetosCadastrados() == false)
                return;

            int numEmprestimo;

            while (true)
            {
                Console.Write("Digite o número do empréstimo que deseja editar: ");
                try { numEmprestimo = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { Notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (repoEmp.VerificarInputNumeroEmprestimo(numEmprestimo) == true)
                {
                    break;
                }
                else
                {
                    Notificador.ApresentarMensagem("O número digitado não existe\n", Notificador.Mensagem.atencao);
                    continue;
                }
            }

            emprestimo = InputarEmprestimo();
            emprestimo.NumeroEmp = numEmprestimo;
            repoEmp.Editar(emprestimo, emprestimo.NumeroEmp);

            Notificador.ApresentarMensagem("Emprestimo editado com sucesso", Notificador.Mensagem.sucesso);
        }

        public override void ExcluirObjeto()
        {
            MostrarTitulo("Excluindo Emprestimo");

            if (VisualizarObjetosCadastrados() == false)
                return;

            int numEmp;

            while (true)
            {
                Console.Write("Digite o número do empréstimo que deseja excluir: ");
                try { numEmp = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { Notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (repoEmp.VerificarInputNumeroEmprestimo(numEmp) == true)
                {
                    break;
                }
                else
                {
                    Notificador.ApresentarMensagem("O número digitado não existe\n", Notificador.Mensagem.atencao);
                    continue;
                }
            }

            repoEmp.Excluir(numEmp);

            Notificador.ApresentarMensagem("Empréstimo excluído com sucesso", Notificador.Mensagem.sucesso);
        }

        public override bool VisualizarObjetosCadastrados()
        {
            MostrarTitulo("Visualização de Caixas");

            if (repoEmp.VerificarVetorEmprestimosVazio() == true)
            {
                Notificador.ApresentarMensagem("Registro de emprestimos vazio",Notificador.Mensagem.atencao);
                return false;
            }
            else
            {
                repoEmp.Visualizar();
                Console.WriteLine();
                return true;
            }
        }

        private Emprestimo InputarEmprestimo()
        {
            Emprestimo emprestimo = new();

            //Escolhendo Amigo
            Console.WriteLine("Escolha o amigo: \n");

             if (telaAmigo.VisualizarObjetosCadastrados() == false)
            {
                return null;
            }

            int opcao;

            while (true)
            {
                Console.Write("\nDigite um número: ");
                try { opcao = int.Parse(Console.ReadLine()); } catch (Exception) { Notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (telaAmigo.RepoAmigo.VerificarInputID(opcao) == false)
                {
                    Notificador.ApresentarMensagem("ID não existe", Notificador.Mensagem.atencao);
                    continue;
                }
                else if (repoEmp.VerificarAmigoRepetido(emprestimo) == true)
                {
                    Notificador.ApresentarMensagem("Este amigo já fez um emprestimo", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            emprestimo.Amigo = new();
            Amigo amigoSelecionado = telaAmigo.RepoAmigo.RetornarObjetoSelecionado(opcao);

            emprestimo.Amigo = amigoSelecionado;

            //============ fim amigo

            //Escolhendo Revista
            Console.WriteLine("Escolha a revista: \n");

            if (telaRevista.VisualizarObjetosCadastrados() == false)
            {
                return null;
            }

            while (true)
            {
                Console.Write("\nDigite um número: ");
                try { opcao = int.Parse(Console.ReadLine()); } catch (Exception) { Notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (telaRevista.RepoRevista.VerificarInputNumeroRevista(opcao) == false)
                {
                    Notificador.ApresentarMensagem("O número não existe", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            emprestimo.Revista = new();
            Revista revistaSelecionada = TelaRevista.RepoRevista.RetornarObjetoSelecionado(opcao);

            emprestimo.Revista = revistaSelecionada;

            //============ fim revista

            while (true)
            {
                Console.Write("Digite a data que o amigo pegou: ");
                try { DateTime.TryParse(Console.ReadLine(), out emprestimo.dataPegou); } catch (Exception) { Notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (emprestimo.ValidarDataPegou() == Emprestimo.StatusValidacao.inválido)
                {
                    Notificador.ApresentarMensagem("Campo inválido\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            while (true)
            {
                Console.Write("Digite a data que devolveu: ");
                try { DateTime.TryParse(Console.ReadLine(), out emprestimo.dataPegou); } catch (Exception) { Notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (emprestimo.ValidarDataDevolveu() == Emprestimo.StatusValidacao.inválido)
                {
                    Notificador.ApresentarMensagem("Campo inválido\n", Notificador.Mensagem.atencao);
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
                try { opcao = int.Parse(Console.ReadLine()); } catch (Exception) { Notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (opcao != 1 && opcao != 2)
                {
                    Notificador.ApresentarMensagem("Opção inválida", Notificador.Mensagem.atencao);
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

    }

}
