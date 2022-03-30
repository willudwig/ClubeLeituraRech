using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.Superclasse;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixa : Repositorio<Caixa>
    {
        Caixa[] caixas = new Caixa[50];


        public override void Inserir(Caixa caixa)
        {
            caixas[posicaoVazia] = caixa;
        }

        public override void Editar(Caixa novaCaixa, int numcaixa)
        {
            
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null)
                {
                    if (caixas[i].Numero == numcaixa)
                    {
                        caixas[i] = novaCaixa;
                        break;
                    }
                }
                else
                    continue;
            }
        }

        public override void Excluir(int numcaixa)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null)
                {
                    if (caixas[i].Numero == numcaixa)
                    {
                        caixas[i] = null;
                        break;
                    }
                }
                else
                    continue;
            }
        }

        public override void Visualizar()
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null)
                    continue;

                Console.WriteLine("Número: " + caixas[i].Numero);
                Console.WriteLine("Cor: " + caixas[i].Cor);
                Console.WriteLine("Etiqueta: " + caixas[i].Etiqueta);
                Console.WriteLine();
            }
        }

        public override Caixa RetornarObjetoSelecionado(int numeroCaixa)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null)
                {
                    if (caixas[i].Numero == numeroCaixa)
                    {
                        return caixas[i];
                    }
                }
                else
                    break;
            }
            return null;
        }


        //Validações
        public bool VerificarVetorCaixasVazio()
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool VerificarMesmaEtiquetasInserir(Caixa caixaInserida)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null)
                {
                    continue;
                }
                else if (caixas[i].Etiqueta == caixaInserida.Etiqueta)
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerificarInputNumeroCaixa(int numeroDigitado)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null)
                {
                    continue;
                }
                else if (caixas[i].Numero == numeroDigitado)
                {
                    return true;
                }
            }
            return false;
        }
        //=================================================================

       
    }
}
