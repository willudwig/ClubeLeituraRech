using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    public class RepositorioEmprestimo
    {
        public Emprestimo[] emprestimos = new Emprestimo[50];
        public int numeroEmp = 0;

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] == null)
                    return i;
            }

            return -1;
        }

        public void Inserir(Emprestimo emprestimo)
        {
            emprestimo.numeroEmp = numeroEmp++;

            int posicaoVazia = ObterPosicaoVazia();

            emprestimos[posicaoVazia] = emprestimo;
        }

        public void Editar(Emprestimo novoEmp, int numEmp)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    if (emprestimos[i].numeroEmp == numEmp)
                    {
                        emprestimos[i] = novoEmp;
                        break;
                    }
                }
                else
                    continue;
            }
        }

        public void Excluir(int numEmp)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    if (emprestimos[i].numeroEmp == numEmp)
                    {
                        emprestimos[i] = null;
                        break;
                    }
                }
                else
                    continue;
            }
        }

        public void Visualizar()
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] == null)
                    continue;

                Console.WriteLine("Número: " + emprestimos[i].numeroEmp);
                Console.WriteLine("Amigo: " + emprestimos[i].amigo.nome);
                Console.WriteLine("Revista: " + emprestimos[i].revista.colecao);
                Console.WriteLine("Edição da revista: " + emprestimos[i].revista.edicao);
                Console.WriteLine();
            }
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
                else if (emprestimos[i].numeroEmp == numeroDigitado)
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
                    if(emprestimos[i].amigo.nome == emp.amigo.nome)
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

        public Emprestimo RetornarEmprestimoSelecionado(int numeroEmp)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    if (emprestimos[i].numeroEmp == numeroEmp)
                    {
                        return emprestimos[i];
                    }
                }
                else
                    break;
            }
            return null;
        }
    }
}
        
