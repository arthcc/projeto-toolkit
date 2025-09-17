using static TrabalhoFerramentas.ConsoleHandler;

namespace TrabalhoFerramentas.Metodos;

public static class AvaliadorProposicionalHandler
{
    public static void Menu()
    {
        bool continua = true;
        while (continua)
        {
            Limpar();
            Escrever("Avaliador proposicional (P, Q, R)");
            Escrever(" 1 - Avaliar F1: (P ∧ Q) ∨ ¬R");
            Escrever(" 2 - Avaliar F2: (P → Q) ∧ (Q → R)");
            Escrever(" 3 - Tabela-verdade de F1");
            Escrever(" 4 - Tabela-verdade de F2");
            Escrever("[ENTER] para sair");
            var op = Ler();
            switch (op)
            {
                case "1": AvaliarFormula(Formula1, "F1"); break;
                case "2": AvaliarFormula(Formula2, "F2"); break;
                case "3": TabelaVerdade(Formula1, "F1"); break;
                case "4": TabelaVerdade(Formula2, "F2"); break;
                case "": continua = false; break;
                default: Escrever("Opção inválida."); Pausar(); break;
            }
        }
    }

    private static bool Formula1(bool P, bool Q, bool R) => (P && Q) || !R;
    private static bool Formula2(bool P, bool Q, bool R) => Implica(P, Q) && Implica(Q, R);
    private static bool Implica(bool a, bool b) => !a || b;

    private static void AvaliarFormula(Func<bool, bool, bool, bool> f, string nome)
    {
        Limpar();
        Escrever($"{nome} selecionada.");
        var P = LerBool("Informe P (T/F): ");
        var Q = LerBool("Informe Q (T/F): ");
        var R = LerBool("Informe R (T/F): ");

        var v = f(P, Q, R);
        Escrever($"Valor de {nome} = {(v ? "V" : "F")}");
        Pausar();
    }

    private static void TabelaVerdade(Func<bool, bool, bool, bool> f, string nome)
    {
        Limpar();
        Escrever($"Tabela-verdade {nome} (ordem P Q R | {nome})");
        for (int p = 0; p < 2; p++)
            for (int q = 0; q < 2; q++)
                for (int r = 0; r < 2; r++)
                {
                    bool P = p == 1, Q = q == 1, R = r == 1;
                    bool v = f(P, Q, R);
                    Escrever($"{(P ? 'T' : 'F')} {(Q ? 'T' : 'F')} {(R ? 'T' : 'F')} | {(v ? 'T' : 'F')}");
                }
        Pausar();
    }

    private static bool LerBool(string msg)
    {
        while (true)
        {
            Escrever(msg);
            var s = Ler()?.Trim().ToUpperInvariant();
            if (s == "T") return true;
            if (s == "F") return false;
            Escrever("Valor inválido. Use T ou F.");
        }
    }
}