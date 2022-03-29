using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo
    {
        Amigo[] amigos = new Amigo[30];

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    return i;
            }

            return -1;
        }

        public void Inserir(Amigo amigo)
        {
            amigos[ObterPosicaoVazia()] = amigo;
        }

        public void Editar(Amigo novoAmigo, int id)
        {

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                {
                    if (amigos[i].Id == id)
                    {
                        amigos[i] = novoAmigo;
                        break;
                    }
                }
                else
                    continue;
            }
        }

        public void Excluir(int id)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                {
                    if (amigos[i].Id == id)
                    {
                        amigos[i] = null;
                        break;
                    }
                }
                else
                    continue;
            }
        }

        public void Visualizar()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    continue;

                Console.WriteLine("ID: " + amigos[i].Id);
                Console.WriteLine("Nome: " + amigos[i].Nome);
                Console.WriteLine("Responsável: " + amigos[i].NomeResp);
                Console.WriteLine("Telefone: " + amigos[i].Telefone);
                Console.WriteLine("Endereço: " + amigos[i].Endereco);
                Console.WriteLine();
            }
        }

    
        //Validações
        public bool VerificarVetorCaixasVazio()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
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

        public bool VerificarMesmoNomeAmigoInserir(Amigo amigoInserido)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                {
                    continue;
                }
                else if (amigos[i].Nome == amigoInserido.Nome)
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerificarInputID(int id)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                {
                    continue;
                }
                else if (amigos[i].Id == id)
                {
                    return true;
                }
            }
            return false;
        }
        //=================================================================


        public Amigo RetornarAmigoSelecionado(int opcao)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                {
                    if (amigos[i].Id == opcao)
                    {
                        return amigos[i];
                    }
                }
                else
                    break;
            }
            return null;
        }
    }
}

