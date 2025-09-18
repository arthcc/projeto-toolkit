using static TrabalhoFerramentas.Metodos.Utils.ConsoleUtils;

namespace TrabalhoFerramentas.Metodos.AV1.AvaliadorProposicional;


/// <summary>
/// Item 4 (AV1): Avalia fórmulas sobre P,Q,R e, opcionalmente, mostra tabela-verdade.
/// </summary>
public static class AvaliadorProposicionalHandler
{
    private readonly record struct Linha(bool P, bool Q, bool R, bool V);

    /// <summary>
    /// Submenu do avaliador: escolher fórmula ou imprimir tabela. Enter vazio sai.
    /// </summary>
    public static void Menu()
    {
        bool continua = true;

        while (continua)
        {
            Limpar();
            Escrever("Avaliador proposicional (variáveis: P, Q, R)");
            Escrever("Símbolos: AND=&&, OR=||, NOT=!");
            Escrever("Na entrada/saída: V=Verdadeiro, F=Falso");
            Escrever("");
            Escrever(" 1 - Avaliar F1: (P && Q) || !R");
            Escrever(" 2 - Avaliar F2: (P -> Q) && (Q -> R)");
            Escrever(" 3 - Tabela-verdade de F1");
            Escrever(" 4 - Tabela-verdade de F2");
            TextoOpcaoSair();

            string opcao = LerOpcaoMenu("Escolha uma opção", "1", "2", "3", "4", "");
            switch (opcao)
            {
                case "1":
                    AvaliarFormula(Formula1, "F1", "(P && Q) || !R");
                    break;
                case "2":
                    AvaliarFormula(Formula2, "F2", "(P -> Q) && (Q -> R)");
                    break;
                case "3":
                    TabelaVerdade(Formula1, "F1", "(P && Q) || !R");
                    break;
                case "4":
                    TabelaVerdade(Formula2, "F2", "(P -> Q) && (Q -> R)");
                    break;
                case "":
                    continua = false;
                    break;
            }
        }
    }

    // F1: (P && Q) || !R
    private static bool Formula1(bool P, bool Q, bool R) => P && Q || !R;

    // F2: (P -> Q) && (Q -> R)
    private static bool Formula2(bool P, bool Q, bool R) => Implica(P, Q) && Implica(Q, R);

    // Implicação: (a -> b) == (!a || b)
    private static bool Implica(bool a, bool b) => !a || b;

    /// <summary>
    /// Lê P,Q,R em V/F, avalia a fórmula escolhida e mostra o resultado.
    /// </summary>
    private static void AvaliarFormula(Func<bool, bool, bool, bool> f, string nome, string texto)
    {
        Limpar();
        Escrever($"{nome} selecionada");
        Escrever($"Fórmula: {texto}");
        Escrever("");

        bool P = LerBoolVF("Informe P");
        bool Q = LerBoolVF("Informe Q");
        bool R = LerBoolVF("Informe R");

        Escrever($"Você informou: P={BoolToVF(P)}, Q={BoolToVF(Q)}, R={BoolToVF(R)}");

        bool valor = f(P, Q, R);
        Escrever($"Resultado: {nome} = {BoolToVF(valor)}");
        Escrever("");
        Escrever("Dica: A -> B é falso apenas quando A=V e B=F. Equivalência: (A -> B) == (!A || B).");
        Pausar();
    }

    /// <summary>
    /// Gera e imprime a tabela-verdade completa da fórmula escolhida.
    /// </summary>
    private static void TabelaVerdade(Func<bool, bool, bool, bool> f, string nome, string texto)
    {
        Limpar();
        Escrever($"Tabela-verdade de {nome}");
        Escrever($"Fórmula: {texto}");
        Escrever("Ordem: P Q R | F");
        Escrever("");

        List<Linha> linhas = new List<Linha>(8);
        bool[] bits = new bool[] { false, true };

        for (int i = 0; i < bits.Length; i++)
        {
            bool P = bits[i];
            for (int j = 0; j < bits.Length; j++)
            {
                bool Q = bits[j];
                for (int k = 0; k < bits.Length; k++)
                {
                    bool R = bits[k];
                    bool V = f(P, Q, R);
                    linhas.Add(new Linha(P, Q, R, V));
                }
            }
        }

        foreach (Linha l in linhas)
        {
            Escrever($" {BoolToVF(l.P)} {BoolToVF(l.Q)} {BoolToVF(l.R)} | {BoolToVF(l.V)}");
        }

        Pausar();
    }

    private static char BoolToVF(bool v) => v ? 'V' : 'F';
}

