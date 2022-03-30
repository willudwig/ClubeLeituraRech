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

            telaCadastroRevista.TelaCaixa = telaCadastroCaixa;
            telaCadastroRevista.RepositorioCaixa = telaCadastroCaixa.RepoCaixa;

            telaCadastroEmprestimo.TelaAmigo = telaCadastroAmigo;
            telaCadastroEmprestimo.TelaRevista = telaCadastroRevista;

            while (true)
            {                
                string opcaoMenuPrincipal = menuPrincipal.MostrarOpcoes();

                if (opcaoMenuPrincipal == "1")
                {
                    string opcao = telaCadastroCaixa.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroCaixa.InserirNovoObjeto();
                        Console.ReadKey();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroCaixa.EditarObjeto();
                        Console.ReadKey();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroCaixa.ExcluirObjeto();
                        Console.ReadKey();
                    }
                    else if (opcao == "4")
                    {
                        telaCadastroCaixa.VisualizarObjetosCadastrados();
                        Console.ReadKey();
                    }
                }
                else if (opcaoMenuPrincipal == "2")
                {
                    string opcao = telaCadastroRevista.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroRevista.InserirNovoObjeto();
                        Console.ReadKey();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroRevista.EditarObjeto();
                        Console.ReadKey();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroRevista.ExcluirObjeto();
                        Console.ReadKey();
                    }
                    else if (opcao == "4")
                    {
                        telaCadastroRevista.VisualizarObjetosCadastrados();
                        Console.ReadKey();
                    }
                }
                else if (opcaoMenuPrincipal == "3")
                {
                    string opcao = telaCadastroAmigo.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroAmigo.InserirNovoObjeto();
                        Console.ReadKey();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroAmigo.EditarObjeto();
                        Console.ReadKey();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroAmigo.ExcluirObjeto();
                        Console.ReadKey();
                    }
                    else if (opcao == "4")
                    {
                        telaCadastroAmigo.VisualizarObjetosCadastrados();
                        Console.ReadKey();
                    }
                }
                else if (opcaoMenuPrincipal == "4")
                {
                    string opcao = telaCadastroEmprestimo.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroEmprestimo.InserirNovoObjeto();
                        Console.ReadKey();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroEmprestimo.EditarObjeto();
                        Console.ReadKey();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroEmprestimo.ExcluirObjeto();
                        Console.ReadKey();
                    }
                    else if (opcao == "4")
                    {
                        telaCadastroEmprestimo.VisualizarObjetosCadastrados();
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
