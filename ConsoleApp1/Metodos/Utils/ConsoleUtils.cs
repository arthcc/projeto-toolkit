using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFerramentas.Metodos.Utils
{
 
    /// <summary>
    /// Utilitários centralizados para interação via console:
    /// limpar tela, escrever mensagens e ler entradas validadas.
    /// </summary>
    public static class ConsoleUtils
    {
        // ===== Saída =====

        public static void Limpar() => Console.Clear();

        public static void Escrever(string mensagem) => Console.WriteLine(mensagem);

        public static void Pausar()
        {
            Console.WriteLine("\nPressione [ENTER] para continuar...");
            Console.ReadLine();
        }

        // ===== Entrada genérica =====

        /// <summary>Lê uma string não vazia do console.</summary>
        public static string LerNaoVazio(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt}: ");
                string? entrada = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(entrada))
                    return entrada.Trim();

                Escrever("Entrada inválida. Digite novamente.");
            }
        }

        public static string Ler(string? prompt = "")
        {
            while (true)
            {
                Console.Write($"{prompt}: ");
                string entrada = Console.ReadLine();
                return entrada.Trim();
            }
        }

        /// <summary>
        /// Lê uma opção de menu garantindo que esteja entre as válidas
        /// (ex.: LerOpcaoMenu("Escolha", "1","2")).
        /// </summary>
        public static string LerOpcaoMenu(string prompt, params string[] opcoesValidas)
        {
            while (true)
            {
                string opcao = Ler(prompt);
                foreach (string o in opcoesValidas)
                    if (opcao == o) return opcao;

                Escrever($"Opção inválida. Escolha entre: {string.Join(", ", opcoesValidas)}");
            }
        }

        // ===== Entrada booleana (V/F) =====

        /// <summary>
        /// Lê um booleano no formato V/F (V = Verdadeiro, F = Falso).
        /// </summary>
        public static bool LerBoolVF(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt} (V/F): ");
                string? s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s)) continue;

                s = s.Trim().ToUpperInvariant();
                if (s == "V") return true;
                if (s == "F") return false;

                Escrever("Entrada inválida. Use V para Verdadeiro ou F para Falso.");
            }
        }

        /// <summary>
        /// Converte bool em caractere 'V' (true) ou 'F' (false).
        /// </summary>
        public static char BoolToVF(bool valor) => valor ? 'V' : 'F';

        // ===== Σ = {a,b} =====

        /// <summary>
        /// Lê um caractere pertencente a Σ={a,b}.
        /// </summary>
        public static string LerSimboloSigma(string prompt)
        {
            while (true)
            {
                string texto = LerNaoVazio(prompt);
                if (SigmaUtils.SimboloEmSigma(texto))
                    return texto;

                Escrever("Símbolo inválido. Digite apenas 'a' ou 'b'.");
            }
        }

        /// <summary>
        /// Lê uma cadeia pertencente a Σ={a,b}.
        /// </summary>
        public static string LerCadeiaSigma(string prompt)
        {
            while (true)
            {
                string cadeia = LerNaoVazio(prompt);
                if (SigmaUtils.CadeiaEmSigma(cadeia))
                    return cadeia;

                Escrever("Cadeia inválida. Use apenas 'a' e 'b'.");
            }
        }

        public static void TextoOpcaoSair()
        {
            Console.WriteLine("\nPressione [ENTER] para sair.");
        }

    }
}
