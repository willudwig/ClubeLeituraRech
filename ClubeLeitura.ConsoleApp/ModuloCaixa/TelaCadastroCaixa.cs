﻿
using System;
using ClubeLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeLeitura.ConsoleApp
{
    public class TelaCadastroCaixa
    {
        Caixa caixa;
        RepositorioCaixa repoCaixa = new();

        public Notificador notificador = new();


        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Caixas");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovaCaixa()
        {
            MostrarTitulo("Inserindo nova Caixa");

            caixa = InputarCaixa();

            repoCaixa.Inserir(caixa);

            notificador.ApresentarMensagem("Caixa inserida com sucesso!", "Sucesso");
        }

        public void EditarCaixa()
        {
            MostrarTitulo("Editando Caixa");

            if (VisualizarCaixasCadastradas() == false)
                return;

            int numCaixa;

            while (true)
            {
                Console.Write("Digite o número da caixa que deseja editar: ");
                try { numCaixa = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", "Erro"); continue; }

                if (repoCaixa.VerificarInputNumeroCaixa(numCaixa) == true)
                {
                    break;
                }
                else
                {
                    notificador.ApresentarMensagem("O número digitado não existe\n","Atencao");
                    continue;
                }
            }
       
            caixa = InputarCaixa();
            caixa.numero = numCaixa;
            repoCaixa.Editar(caixa, caixa.numero);

            notificador.ApresentarMensagem("Caixa editada com sucesso", "Sucesso");
        }

        public void ExcluirCaixa()
        {
            MostrarTitulo("Excluindo Caixa");

            if (VisualizarCaixasCadastradas() == false)
                return;

            int numCaixa;

            while (true)
            {
                Console.Write("Digite o número da caixa que deseja excluir: ");
                try { numCaixa = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { notificador.ApresentarMensagem("Formato inválido\n", "Erro"); continue; }

                if (repoCaixa.VerificarInputNumeroCaixa(numCaixa) == true)
                {
                    break;
                }
                else
                {
                    notificador.ApresentarMensagem("O número digitado não existe\n", "Atencao");
                    continue;
                }
            }

            repoCaixa.Excluir(numCaixa);

            notificador.ApresentarMensagem("Caixa excluída com sucesso", "Sucesso");
        }

        public bool VisualizarCaixasCadastradas()
        {
            MostrarTitulo("Visualização de Caixas");

            if (repoCaixa.VerificarVetorCaixasVazio() == true)
            {
                notificador.ApresentarMensagem("Registro de caixas vazio", "Atencao");
                return false;
            }
            else
            {
                repoCaixa.Visualizar();
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

        private Caixa InputarCaixa()
        {
            Caixa caixa = new();

            Console.Write("Digite a cor: ");
            caixa.cor = Console.ReadLine();

            while (true)
            {
                Console.Write("Digite a etiqueta: ");
                caixa.etiqueta = Console.ReadLine();

                if (repoCaixa.VerificarMesmaEtiquetasInserir(caixa) == true)
                {
                    notificador.ApresentarMensagem("A etiqueta digitada já existe\n", "Atencao");
                    continue;
                }
                else
                    break;
            }

            return caixa;
        }

    }
}