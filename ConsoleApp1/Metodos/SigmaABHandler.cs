using TrabalhoFerramentas.Metodos.Utils;
using static TrabalhoFerramentas.ConsoleHandler;

namespace TrabalhoFerramentas.Metodos;

public static class SigmaABHandler
{
    public static void VerificarSimboloECadeia()
    {
        Limpar();
        Escrever("Σ fixo = {a,b}");
        Escrever("Informe um símbolo:");
        var simbolo = Ler();

        var pertenceSimbolo = SigmaUtils.SimboloEmSigma(simbolo);
        Escrever(pertenceSimbolo ? "símbolo válido em Σ" : "símbolo inválido em Σ");

        Escrever("Informe uma cadeia (palavra) sobre Σ:");
        var cadeia = Ler();

        var pertenceCadeia = SigmaUtils.CadeiaEmSigma(cadeia);
        Escrever(pertenceCadeia ? "cadeia válida em Σ*" : "cadeia inválida (fora de Σ*)");

        TextoFinal();
    }

    private static void TextoFinal()
    {
        Escrever("Conclusão emitida para símbolo e cadeia conforme Σ={a,b}.");
        Pausar();
    }
}
