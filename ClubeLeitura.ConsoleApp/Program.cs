/**
 * O sistema deve permirtir o usuário escolher qual opção ele deseja
 *  -Para acessar o cadastro de caixas, ele deve digitar "1"
 *  -Para acessar o cadastro de revistas, ele deve digitar "2"
 *  -Para acessar o cadastro de amigquinhos, ele deve digitar "3"
 *  
 *  -Para gerenciar emprestimos, ele deve digitar "4"
 *  
 *  -Para sair, usuário deve digitar "s"
 */
using System;
using ClubeLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using ClubeLeitura.ConsoleApp.ModuloAmigo;


namespace ClubeLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaMenuPrincipal menuPrincipal = new();
            TelaCadastroCaixa telaCadastroCaixa = new();
            TelaCadastroAmigo telaCadastroAmigo = new();
            TelaCadastroRevista telaCadastroRevista = new();
            TelaCadastroEmprestimo telaCadastroEmprestimo = new();

            telaCadastroRevista.telaCaixa = telaCadastroCaixa;
            telaCadastroRevista.repositorioCaixa = telaCadastroCaixa.repoCaixa;

            telaCadastroEmprestimo.telaAmigo = telaCadastroAmigo;
            telaCadastroEmprestimo.telaRevista = telaCadastroRevista;

            while (true)
            {                
                string opcaoMenuPrincipal = menuPrincipal.MostrarOpcoes();

                if (opcaoMenuPrincipal == "1")
                {
                    string opcao = telaCadastroCaixa.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroCaixa.InserirNovaCaixa();
                        Console.ReadKey();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroCaixa.EditarCaixa();
                        Console.ReadKey();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroCaixa.ExcluirCaixa();
                        Console.ReadKey();
                    }
                    else if (opcao == "4")
                    {
                        telaCadastroCaixa.VisualizarCaixasCadastradas();
                        Console.ReadKey();
                    }
                }
                else if (opcaoMenuPrincipal == "2")
                {
                    string opcao = telaCadastroRevista.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroRevista.InserirNovaRevista();
                        Console.ReadKey();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroRevista.EditarRevista();
                        Console.ReadKey();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroRevista.ExcluirRevista();
                        Console.ReadKey();
                    }
                    else if (opcao == "4")
                    {
                        telaCadastroRevista.VisualizarRevistasCadastradas();
                        Console.ReadKey();
                    }
                }
                else if (opcaoMenuPrincipal == "3")
                {
                    string opcao = telaCadastroAmigo.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroAmigo.InserirNovoAmigo();
                        Console.ReadKey();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroAmigo.EditarAmigo();
                        Console.ReadKey();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroAmigo.ExcluirAmigo();
                        Console.ReadKey();
                    }
                    else if (opcao == "4")
                    {
                        telaCadastroAmigo.VisualizarAmigosCadastrados();
                        Console.ReadKey();
                    }
                }
                else if (opcaoMenuPrincipal == "4")
                {
                    string opcao = telaCadastroEmprestimo.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroEmprestimo.InserirNovoEmprestimo();
                        Console.ReadKey();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroEmprestimo.EditarEmprestimo();
                        Console.ReadKey();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroEmprestimo.ExcluirEmprestimo();
                        Console.ReadKey();
                    }
                    else if (opcao == "4")
                    {
                        telaCadastroEmprestimo.VisualizarEmprestimosCadastrados();
                        Console.ReadKey();
                    }
                }
                else if (opcaoMenuPrincipal == "s")
                {
                    Console.Clear();
                    Notificador noticiaProgram = new();
                    noticiaProgram.ApresentarMensagem("Programa Finalizado", Notificador.Mensagem.sucesso);
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }
    }
}
