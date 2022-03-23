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

namespace ClubeLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaMenuPrincipal menuPrincipal = new();
            TelaCadastroCaixa telaCadastroCaixa = new();
            TelaCadastroAmigo telaCadastroAmigo = new();

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
                    //string opcao = telaCadastroRevistas.MostrarOpcoes();

                    //if (opcao == "1")
                    //{
                    //    telaCadastroCaixa.InserirNovaRevista();
                    //}
                    //else if (opcao == "2")
                    //{
                    //    telaCadastroRevista.EditarRevista();
                    //}
                    //else if (opcao == "3")
                    //{
                    //    telaCadastroRevista.ExcluirRevista();
                    //}
                    //else if (opcao == "4")
                    //{
                    //    telaCadastroRevista.VisualizarRevista("Tela");
                    //    Console.ReadLine();
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
                else if (opcaoMenuPrincipal == "s")
                {
                    Console.Clear();
                    Notificador noticiaProgram = new();
                    noticiaProgram.ApresentarMensagem("Programa Finalizado", "Sucesso");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }       
    }
}
