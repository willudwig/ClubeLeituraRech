using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    public class RepositorioRevista
    {
        public Revista[] revistas = new Revista[100];
        public int numeroRevista = 0;

        public void Inserir(Revista revista)
        {
            revista.numeroRevista = numeroRevista++;

            int posicaoVazia = ObterPosicaoVazia();

            revistas[posicaoVazia] = revista;
        }

        public void Editar(Revista novaRevista, int numrevista)
        {

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null)
                {
                    if (revistas[i].numeroRevista == numrevista)
                    {
                        revistas[i] = novaRevista;
                        break;
                    }
                }
                else
                    continue;
            }
        }

        public void Excluir(int numrevista)
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null)
                {
                    if (revistas[i].numeroRevista == numrevista)
                    {
                        revistas[i] = null;
                        break;
                    }
                }
                else
                    continue;
            }
        }

        public void Visualizar()
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null)
                    continue;

                Console.WriteLine("Numero ID: " + revistas[i].numeroRevista);
                Console.WriteLine("Coleção: " + revistas[i].colecao);
                Console.WriteLine("Edição: " + revistas[i].edicao);
                Console.WriteLine("Ano: " + revistas[i].ano);
                Console.WriteLine("Caixa: " + revistas[i].caixa.cor);
            }
        }

        private int ObterPosicaoVazia()
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null)
                    return i;
            }

            return -1;
        }

       //Validações
        public bool VerificarVetorRevistasVazio()
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null)
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
        public bool VerificarInputNumeroRevista(int numeroDigitado)
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null)
                {
                    continue;
                }
                else if (revistas[i].numeroRevista == numeroDigitado)
                {
                    return true;
                }
            }
            return false;
        }
        //=============================================================


        public Revista RetornarRevistaSelecionada(int opcao)
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null)
                {
                    if (revistas[i].numeroRevista == opcao)
                    {
                        return revistas[i];
                    }
                }
                else
                    break;
            }
            return null;
        }

    }
}
