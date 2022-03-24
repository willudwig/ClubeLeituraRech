using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo
    {
        public Amigo[] amigos = new Amigo[30];
        int idAmigo = 0;

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
            amigo.id = idAmigo++;
            int posicaoVazia = ObterPosicaoVazia();
            amigos[posicaoVazia] = amigo;
        }

        public void Editar(Amigo novoAmigo, int id)
        {

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                {
                    if (amigos[i].id == id)
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
                    if (amigos[i].id == id)
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

                Console.WriteLine("ID: " + amigos[i].id);
                Console.WriteLine("Nome: " + amigos[i].nome);
                Console.WriteLine("Responsável: " + amigos[i].nomeResp);
                Console.WriteLine("Telefone: " + amigos[i].telefone);
                Console.WriteLine("Endereço: " + amigos[i].endereco);
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
                else if (amigos[i].nome == amigoInserido.nome)
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
                else if (amigos[i].id == id)
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
                    if (amigos[i].id == opcao)
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

