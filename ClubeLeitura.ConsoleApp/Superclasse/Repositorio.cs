using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Superclasse
{
    abstract public class Repositorio <T>
    {
        T[] registro;
       
        public int posicaoVazia;

        private void ObterPosicaoVazia()
        {
            for (int i = 0; i < registro.Length; i++)
            {
                if (registro[i] == null)
                {
                    posicaoVazia = i;
                    break;
                }
            }
        }

        public virtual void Inserir(T objeto)
        {
            registro[posicaoVazia] = objeto;
        }

        public abstract void Editar(T objeto, int id);

        public abstract void Excluir(int id);

        public abstract void Visualizar();

        public abstract T RetornarObjetoSelecionado(int opcao);

    }
}
