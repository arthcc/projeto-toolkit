using static TrabalhoFerramentas.Metodos.Utils.ConsoleUtils;

namespace TrabalhoFerramentas.Metodos.AV1.TerminaComB;

/// <summary>
/// Item 3 (AV1): Decide se uma cadeia (Σ={a,b}) termina com 'b'.
/// Pré-condição: cadeia sobre Σ. Saída: "SIM" ou "NAO".
/// </summary>
public static class TerminaComBHandler
{
    /// <summary>
    /// Lê a cadeia (validada em Σ) e imprime "SIM" se termina com 'b', senão "NAO".
    /// </summary>
    public static void Decidir()
    {
        Limpar();
        Escrever("Decisor: termina com 'b'?");
        Escrever("Σ fixo = {a,b}");

        string w = LerCadeiaSigma("Informe a cadeia");

        bool terminaComB = w.Length > 0 && char.ToLowerInvariant(w[^1]) == 'b';
        Escrever(terminaComB ? "SIM" : "NAO");
        Pausar();
    }
}