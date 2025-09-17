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
            Escrever("Reconhecedores em Σ = {a, b}");
            Escrever("Na saída: T=Verdadeiro (ACEITA), F=Falso (REJEITA)");
            Escrever("");
            Escrever("Escolha a linguagem para testar a cadeia w (somente 'a' e 'b'):");
            Escrever(" 1 - L é par?  -> aceita se a quantidade de 'a' em w é PAR");
            Escrever(" 2 - L = { w | w = a b* } -> aceita se w começa com 'a' e o restante é só 'b'");
            Escrever(" [ENTER] para voltar");
            var op = Ler();

            switch (op)
            {
                case "1": TestarAEhPar(); break;
                case "2": TestarComecaATerminaB(); break;
                case "": continua = false; break;
                default: Escrever("Opção inválida."); Pausar(); break;
            }
        }
    }

    private static void TestarAEhPar()
    {
        Limpar();
        Escrever("L é par?");
        Escrever("Critério: a quantidade de 'a' em w é PAR.");
        Escrever("Entrada esperada: cadeia w sobre Σ={a,b} (somente 'a' ou 'b').");
        Escrever("Exemplos válidos: a, b, ab, bbaab, aa, bb");
        Escrever("Exemplos inválidos: '' (vazio), 'c', 'a1b', 'ab ' (espaço)");
        Escrever("");
        Escrever("Digite w:");
        var w = Ler();

        if (!SigmaUtils.CadeiaEmSigma(w))
        {
            Escrever("Entrada inválida: w deve conter apenas 'a' ou 'b' e não pode ser vazia.");
            Pausar();
            return;
        }

        int qtdA = 0;
        foreach (var ch in w!.ToLowerInvariant()) if (ch == 'a') qtdA++;

        bool aceita = (qtdA % 2 == 0);
        Escrever($"Você digitou: w=\"{w}\"  |w|={w.Length}  #a={qtdA}");
        Escrever(aceita
            ? "Resultado: True — número de 'a' é PAR."
            : "Resultado: False — número de 'a' é ÍMPAR.");
        Pausar();
    }

    private static void TestarComecaATerminaB()
    {
        Limpar();
        Escrever("L = { w | w = a b* }");
        Escrever("Critério: w deve começar com 'a' e, após o primeiro caractere, conter apenas 'b'.");
        Escrever("Entrada esperada: cadeia w sobre Σ={a,b} (somente 'a' ou 'b').");
        Escrever("Exemplos ACEITOS: a, ab, abb, abbbb");
        Escrever("Exemplos REJEITADOS: '' (vazio), b, ba, aab, abab");
        Escrever("");
        Escrever("Digite w:");
        var w = Ler();

        if (!SigmaUtils.CadeiaEmSigma(w))
        {
            Escrever("Entrada inválida: w deve conter apenas 'a' ou 'b' e não pode ser vazia.");
            Pausar();
            return;
        }

        var s = w!.ToLowerInvariant();
        bool aceita = s.Length >= 1 && s[0] == 'a';
        for (int i = 1; aceita && i < s.Length; i++)
            aceita = s[i] == 'b';

        Escrever($"Você digitou: w=\"{w}\"");
        Escrever(aceita
            ? "Resultado: True — forma 'a' seguido de zero ou mais 'b'."
            : "Resultado: False — não está na forma 'a b*'.");
        Pausar();
    }
}
