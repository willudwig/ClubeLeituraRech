
using System;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.Superclasse;


namespace ClubeLeitura.ConsoleApp
{
    public class TelaCadastroCaixa : TelaCadastro
    {
        Caixa caixa;
        public RepositorioCaixa repoCaixa = new();

        public override string MostrarOpcoes()
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

        public override void InserirNovoObjeto()
        {
            MostrarTitulo("Inserindo nova Caixa");

            repoCaixa.Inserir( InputarCaixa() );

            Notificador.ApresentarMensagem("Caixa inserida com sucesso!", Notificador.Mensagem.sucesso);
        }

        public override void EditarObjeto()
        {
            MostrarTitulo("Editando Caixa");

            if (VisualizarObjetosCadastrados() == false)
                return;

            int numCaixa;

            while (true)
            {
                Console.Write("Digite o número da caixa que deseja editar: ");
                try { numCaixa = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { Notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (repoCaixa.VerificarInputNumeroCaixa(numCaixa) == true)
                {
                    break;
                }
                else
                {
                    Notificador.ApresentarMensagem("O número digitado não existe\n",Notificador.Mensagem.atencao);
                    continue;
                }
            }
       
            caixa = InputarCaixa();
            caixa.numero = numCaixa;
            repoCaixa.Editar(caixa, caixa.Numero);

            Notificador.ApresentarMensagem("Caixa editada com sucesso", Notificador.Mensagem.sucesso);
        }

        public override void ExcluirObjeto()
        {
            MostrarTitulo("Excluindo Caixa");

            if (VisualizarObjetosCadastrados() == false)
                return;

            int numCaixa;

            while (true)
            {
                Console.Write("Digite o número da caixa que deseja excluir: ");
                try { numCaixa = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { Notificador.ApresentarMensagem("Formato inválido\n", Notificador.Mensagem.erro); continue; }

                if (repoCaixa.VerificarInputNumeroCaixa(numCaixa) == true)
                {
                    break;
                }
                else
                {
                    Notificador.ApresentarMensagem("O número digitado não existe\n", Notificador.Mensagem.atencao);
                    continue;
                }
            }

            repoCaixa.Excluir(numCaixa);

            Notificador.ApresentarMensagem("Caixa excluída com sucesso", Notificador.Mensagem.sucesso);
        }

        public override bool VisualizarObjetosCadastrados()
        {
            MostrarTitulo("Visualização de Caixas");

            if (repoCaixa.VerificarVetorCaixasVazio() == true)
            {
                Notificador.ApresentarMensagem("Registro de caixas vazio", Notificador.Mensagem.atencao);
                return false;
            }
            else
            {
                repoCaixa.Visualizar();
                return true;
            }
        }


        private Caixa InputarCaixa()
        {
            string cor = "";
            string etiqueta = "";
            
            caixa = new Caixa(cor, etiqueta);

            while (true)
            {
                Console.Write("Digite a cor: ");
                cor = Console.ReadLine();

                if (caixa.ValidarCor() == Caixa.Status.inválido)
                {
                    Notificador.ApresentarMensagem("Campo inválido\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            while (true)
            {
                Console.Write("Digite a etiqueta: ");
                etiqueta = Console.ReadLine();

                if (repoCaixa.VerificarMesmaEtiquetasInserir(caixa) == true)
                {
                    Notificador.ApresentarMensagem("A etiqueta digitada já existe\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else if (caixa.ValidarEtiqueta() == Caixa.Status.inválido)
                {
                    Notificador.ApresentarMensagem("Campo inválido\n", Notificador.Mensagem.atencao);
                    continue;
                }
                else
                    break;
            }

            return caixa; 
        }


    }
}