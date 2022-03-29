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
        Emprestimo[] emprestimos = new Emprestimo[50];
        int numeroEmp = 0;

        public int NumeroEmp
        {
            get { return numeroEmp; }
            set { numeroEmp = value; }
        }

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
            emprestimo.NumeroEmp = numeroEmp++;

            int posicaoVazia = ObterPosicaoVazia();
            
            emprestimo.NumeroEmp = numeroEmp;
            emprestimos[posicaoVazia] = emprestimo;
        }

        public void Editar(Emprestimo novoEmp, int numEmp)
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

        public void Excluir(int numEmp)
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

        public void Visualizar()
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

        public Emprestimo RetornarEmprestimoSelecionado(int numeroEmp)
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
    }
}
        
