using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.Superclasse;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo : Repositorio<Amigo>
    {
        Amigo[] amigos = new Amigo[30];


        public override void Inserir(Amigo amigo)
        {
            amigos[PosicaoVazia] = amigo;
        }

        public override void Editar(Amigo novoAmigo, int id)
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

        public override void Excluir(int id)
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

        public override void Visualizar()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    continue;

                Console.WriteLine("ID: " + amigos[i].Id);
                Console.WriteLine("Nome: " + amigos[i].nome);
                Console.WriteLine("Responsável: " + amigos[i].nomeResp);
                Console.WriteLine("Telefone: " + amigos[i].telefone);
                Console.WriteLine("Endereço: " + amigos[i].endereco);
                Console.WriteLine();
            }
        }

        public override Amigo RetornarObjetoSelecionado(int opcao)
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
                else if (amigos[i].Id == id)
                {
                    return true;
                }
            }
            return false;
        }
        //=================================================================


      
    }
}

