using TrabalhoFerramentas.Metodos.Utils;
using static TrabalhoFerramentas.ConsoleHandler;

namespace TrabalhoFerramentas.Metodos;

public static class TerminaComBHandler
{
    public static void Decidir()
    {
        Limpar();
        Escrever("Σ fixo = {a,b}. Informe a cadeia:");
        string? w = Ler();

        if (!SigmaUtils.CadeiaEmSigma(w))
        {
            Escrever("Entrada inválida: fora de Σ*.");
            Pausar();
            return;
        }

        string? resposta = (!string.IsNullOrEmpty(w) && char.ToLowerInvariant(w[^1]) == 'b') ? "SIM" : "NAO";
        Escrever(resposta);
        Pausar();
    }
}