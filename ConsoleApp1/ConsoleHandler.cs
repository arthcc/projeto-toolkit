using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFerramentas
{
    public class ConsoleHandler
    {
        public string TeclaDeContinuacao { get; set; } = "ENTER";  
        public string TeclaDeSaida { get; set; } = "ENTER";

        public ConsoleHandler() {}

        public ConsoleHandler(string teclaDeContinuacao, string teclaDeSaida)
        {
            TeclaDeContinuacao = teclaDeContinuacao;
            TeclaDeSaida = teclaDeSaida;
        }

        public static void Pausar()
        {
            Console.ReadLine();
        }

        public static void Limpar()
        {
            Console.Clear();
        }
        public static void Escrever(string texto)
        {
            Console.WriteLine(texto);
        }

        public static string? Ler()
        {
            return Console.ReadLine();
        }

        public void TextoOpcaoContinuar()
        {
            Escrever($"[{TeclaDeContinuacao}] para continuar.");
        }

        public void TextoOpcaoSair()
        {
            Escrever($"[{TeclaDeContinuacao}] para sair.");
        }
    }
}
