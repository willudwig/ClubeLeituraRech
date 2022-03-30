using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeLeitura.ConsoleApp.Superclasse;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    public class RepositorioEmprestimo : Repositorio<Emprestimo>
    {
        Emprestimo[] emprestimos = new Emprestimo[50];
        
        public override void Inserir(Emprestimo emprestimo)
        {
           emprestimos[posicaoVazia] = emprestimo;
        }

        public override void Editar(Emprestimo novoEmp, int numEmp)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    if (emprestimos[i].NumeroEmp == numEmp)
                    {
                        emprestimos[i] = novoEmp;
                        break;
                    }
                }
                else
                    continue;
            }
        }

        public override void Excluir(int numEmp)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    if (emprestimos[i].NumeroEmp == numEmp)
                    {
                        emprestimos[i] = null;
                        break;
                    }
                }
                else
                    continue;
            }
        }

        public override void Visualizar()
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] == null)
                    continue;

                Console.WriteLine("Número: " + emprestimos[i].NumeroEmp);
                Console.WriteLine("Amigo: " + emprestimos[i].Amigo.Nome);
                Console.WriteLine("Revista: " + emprestimos[i].Revista.Colecao);
                Console.WriteLine("Edição da revista: " + emprestimos[i].Revista.Edicao);
                Console.WriteLine();
            }
        }

        public override Emprestimo RetornarObjetoSelecionado(int numeroEmp)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    if (emprestimos[i].NumeroEmp == numeroEmp)
                    {
                        return emprestimos[i];
                    }
                }
                else
                    break;
            }
            return null;
        }


        //Validações
        public bool VerificarVetorEmprestimosVazio()
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] == null)
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

        public bool VerificarInputNumeroEmprestimo(int numeroDigitado)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] == null)
                {
                    continue;
                }
                else if (emprestimos[i].NumeroEmp == numeroDigitado)
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerificarAmigoRepetido(Emprestimo emp)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    if(emprestimos[i].Amigo.Nome == emp.Amigo.Nome)
                    {
                        return true;
                    }
                }
                else
                    continue;
            }
            return false;
        }
        //=================================================================

    }
}
        
