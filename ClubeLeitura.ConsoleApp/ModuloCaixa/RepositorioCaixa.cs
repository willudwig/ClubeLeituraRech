using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixa
    {
        public Caixa[] caixas = new Caixa[50];
        public int numeroCaixa = 0;

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null)
                    return i;
            }

            return -1;
        }

        public void Inserir(Caixa caixa)
        {
            caixa.Numero = numeroCaixa++;

            int posicaoVazia = ObterPosicaoVazia();

            caixas[posicaoVazia] = caixa;
        }

        public void Editar(Caixa novaCaixa, int numcaixa)
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

        public void Excluir(int numcaixa)
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

        public void Visualizar()
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

        public Caixa RetornarCaixaSelecionada(int numeroCaixa)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null)
                {
                    if(caixas[i].Numero == numeroCaixa)
                    {
                        return caixas[i];
                    }
                }
                else
                    break;
            }
            return null;
        }
    }
}
