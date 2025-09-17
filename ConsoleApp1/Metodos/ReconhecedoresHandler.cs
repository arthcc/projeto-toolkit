using TrabalhoFerramentas.Metodos.Utils;
using static TrabalhoFerramentas.ConsoleHandler;

namespace TrabalhoFerramentas.Metodos;

public static class ReconhecedoresHandler
{
    public static void Menu()
    {
        bool continua = true;
        while (continua)
        {
            Limpar();
            Escrever("Reconhecedores em Σ={a,b}");
            Escrever(" 1 - L_par_a (quantidade de 'a' par)");
            Escrever(" 2 - L = { w | w = a b* }");
            Escrever("[ENTER] para sair");
            var op = Ler();

            switch (op)
            {
                case "1": TestarParA(); break;
                case "2": TestarABEstrela(); break;
                case "": continua = false; break;
                default: Escrever("Opção inválida."); Pausar(); break;
            }
        }
    }

    private static void TestarParA()
    {
        Escrever("Informe a cadeia:");
        var w = Ler();

        if (!SigmaUtils.CadeiaEmSigma(w))
        {
            Escrever("Entrada inválida: fora de Σ*.");
            Pausar();
            return;
        }

        int qtdA = 0;
        foreach (var ch in w!) if (char.ToLowerInvariant(ch) == 'a') qtdA++;
        Escrever(qtdA % 2 == 0 ? "ACEITA" : "REJEITA");
        Pausar();
    }

    private static void TestarABEstrela()
    {
        Escrever("Informe a cadeia:");
        var w = Ler();

        if (!SigmaUtils.CadeiaEmSigma(w))
        {
            Escrever("Entrada inválida: fora de Σ*.");
            Pausar();
            return;
        }

        if (string.IsNullOrEmpty(w))
        {
            Escrever("REJEITA");
            Pausar();
            return;
        }

        var s = w!.ToLowerInvariant();
        bool ok = s[0] == 'a';
        for (int i = 1; ok && i < s.Length; i++)
            ok = s[i] == 'b';

        Escrever(ok ? "ACEITA" : "REJEITA");
        Pausar();
    }
}