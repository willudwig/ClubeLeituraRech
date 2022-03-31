using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.Superclasse;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    public class RepositorioRevista : Repositorio<Revista>
    {
        Revista[] revistas = new Revista[100];

        public override void Inserir(Revista revista)
        {
            revistas[PosicaoVazia] = revista;
        }

        public override void Editar(Revista novaRevista, int numrevista)
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

        public override void Excluir(int numrevista)
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

        public override void Visualizar()
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null)
                    continue;

                Console.WriteLine("Numero ID: " + revistas[i].numeroRevista);
                Console.WriteLine("Coleção: " + revistas[i].colecao);
                Console.WriteLine("Edição: " + revistas[i].edicao);
                Console.WriteLine("Ano: " + revistas[i].ano);
                Console.WriteLine("Caixa: " + revistas[i].caixa.Cor);
                Console.WriteLine();
            }
        }

        public override Revista RetornarObjetoSelecionado(int opcao)
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

     

    }
}
