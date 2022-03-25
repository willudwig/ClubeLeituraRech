using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp
{
    public class Notificador
    {
        public void ApresentarMensagem(string mensagem, Mensagem tipoMensagem)
        {
            switch (tipoMensagem)
            {
                case Mensagem.sucesso:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case Mensagem.atencao:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                case Mensagem.erro:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        public enum Mensagem { sucesso, atencao, erro}
    }
}
