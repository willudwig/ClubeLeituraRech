using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    public class RepositorioRevista
    {
        Revista[] revistas = new Revista[100];

        public void Inserir(Revista revista)
        {
            revistas[ ObterPosicaoVazia() ] = revista;
        }

        public void Editar(Revista novaRevista, int numrevista)
        {

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null)
                {
                    if (revistas[i].NumeroRevista == numrevista)
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
                    if (revistas[i].NumeroRevista == numrevista)
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

                Console.WriteLine("Numero ID: " + revistas[i].NumeroRevista);
                Console.WriteLine("Coleção: " + revistas[i].Colecao);
                Console.WriteLine("Edição: " + revistas[i].Edicao);
                Console.WriteLine("Ano: " + revistas[i].Ano);
                Console.WriteLine("Caixa: " + revistas[i].Caixa.Cor);
                Console.WriteLine();
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
                else if (revistas[i].NumeroRevista == numeroDigitado)
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
                    if (revistas[i].NumeroRevista == opcao)
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
