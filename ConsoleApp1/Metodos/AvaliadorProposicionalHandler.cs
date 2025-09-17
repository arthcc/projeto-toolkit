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
            Escrever("Avaliador proposicional (variáveis: P, Q, R)");
            Escrever("Símbolos (teclado): AND=&&, OR=||, NOT=!, IMPLICA=->");
            Escrever("Na saída: T=Verdadeiro, F=Falso");
            Escrever("");
            Escrever(" 1 - Avaliar F1: (P && Q) || !R");
            Escrever(" 2 - Avaliar F2: (P -> Q) && (Q -> R)");
            Escrever(" 3 - Tabela-verdade de F1");
            Escrever(" 4 - Tabela-verdade de F2");
            Escrever(" [ENTER] para sair");

            var op = Ler();
            switch (op)
            {
                case "1": AvaliarFormula(Formula1, "F1", "(P && Q) || !R"); break;
                case "2": AvaliarFormula(Formula2, "F2", "(P -> Q) && (Q -> R)"); break;
                case "3": TabelaVerdade(Formula1, "F1", "(P && Q) || !R"); break;
                case "4": TabelaVerdade(Formula2, "F2", "(P -> Q) && (Q -> R)"); break;
                case "": continua = false; break;
                default: Escrever("Opção inválida."); Pausar(); break;
            }
        }
    }

    private static bool Formula1(bool P, bool Q, bool R) => (P && Q) || !R;

    private static bool Formula2(bool P, bool Q, bool R) => Implica(P, Q) && Implica(Q, R);
    private static bool Implica(bool a, bool b) => !a || b;

    private static void AvaliarFormula(Func<bool, bool, bool, bool> f, string nome, string texto)
    {
        Limpar();
        Escrever($"{nome} selecionada");
        Escrever($"Fórmula: {texto}");
        Escrever("Como responder: digite T (Verdadeiro) ou F (Falso). Ex.: T");
        Escrever("");

        var P = LerBoolComPrompt("Informe P (T/F): ");
        var Q = LerBoolComPrompt("Informe Q (T/F): ");
        var R = LerBoolComPrompt("Informe R (T/F): ");

        Escrever($"Você informou: P={BoolToTF(P)}, Q={BoolToTF(Q)}, R={BoolToTF(R)}");
        var v = f(P, Q, R);
        Escrever($"Resultado: {nome} = {(v ? "T (Verdadeiro)" : "F (Falso)")}");
        Escrever("");
        Escrever("Dica: A -> B é falso APENAS quando A=T e B=F; caso contrário é verdadeiro.");
        Escrever("Equivalência útil: (A -> B) == (!A || B)");
        Pausar();
    }

    private static void TabelaVerdade(Func<bool, bool, bool, bool> f, string nome, string texto)
    {
        Limpar();
        Escrever($"Tabela-verdade de {nome}");
        Escrever($"Fórmula: {texto}");
        Escrever("Ordem: P Q R | valor   (T=Verdadeiro, F=Falso)");
        Escrever("");

        var bits = new[] { false, true };

        var linhas = bits
            .SelectMany(P => bits, (P, Q) => new { P, Q })
            .SelectMany(t => bits, (t, R) => new { t.P, t.Q, R, V = f(t.P, t.Q, R) });

        foreach (var l in linhas)
            Escrever($"{BoolToTF(l.P)} {BoolToTF(l.Q)} {BoolToTF(l.R)} | {BoolToTF(l.V)}");


        Pausar();
    }

    private static bool LerBoolComPrompt(string msg)
    {
        while (true)
        {
            Escrever(msg);
            Escrever("Exemplos válidos: T, F");
            var s = Ler()?.Trim().ToUpperInvariant();
            if (s == "T") return true;
            if (s == "F") return false;
            Escrever("Entrada inválida. Use apenas T ou F.");
        }
    }

    private static string BoolToTF(bool v) => v ? "T" : "F";
}
