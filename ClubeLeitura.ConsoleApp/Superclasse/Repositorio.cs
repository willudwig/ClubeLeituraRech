using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClubeLeitura.ConsoleApp.Superclasse
{
    abstract public class Repositorio <T>
    {
        T[] _registro;
       
        int _posicaoVazia;

        public int PosicaoVazia { get { return _posicaoVazia;} }

        private void ObterPosicaoVazia()
        {
            for (int i = 0; i < _registro.Length; i++)
            {
                if (_registro[i] == null)
                {
                    _posicaoVazia = i;
                    break;
                }
            }
        }

        public virtual void Inserir(T objeto)
        {
            _registro[_posicaoVazia] = objeto;
        }

        public abstract void Editar(T objeto, int id);

        public abstract void Excluir(int id);

        public abstract void Visualizar();

        public abstract T RetornarObjetoSelecionado(int opcao);

    }
}
