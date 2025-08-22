namespace TrabalhoFerramentas.Metodos;

using System;
using static TrabalhoFerramentas.ConsoleHandler;
public static class AlfabetoHandler
{
    static ConsoleHandler console = new();
    public static string? RecuperarAlfabeto()
    {
        string? alfabeto;
        do
        {
            Limpar();
            Escrever("Informe o alfabeto: ");
            alfabeto = Ler()?.Trim();


        }
        while (!AlfabetoValido(alfabeto));
        Escrever("Alfabeto cadastrado com sucesso!");
        console.TextoOpcaoContinuar();
        Pausar();
        return alfabeto;

    }

    static bool AlfabetoValido(string? alfabeto)
    {
        if (!string.IsNullOrWhiteSpace(alfabeto)) return true;

        Escrever("Informe um alfabeto valido!");
        console.TextoOpcaoContinuar();
        Pausar();
        return false;
    }
    public static void VerificaPertencimento(string alfabeto)
    {
        if (!AlfabetoValido(alfabeto)) return;

        var set = new HashSet<char>(
            alfabeto.Trim().ToUpperInvariant()
        );

        Escrever("Informe uma letra:");
        console.TextoOpcaoSair();

        while (true)
        {
            var entrada = Ler();

            if (string.IsNullOrWhiteSpace(entrada))
                break; 

            var ch = entrada.Trim()[0];
            var pertence = set.Contains(char.ToUpperInvariant(ch));

            Escrever($"A letra '{ch}' {(pertence ? "" : "não ")}pertence ao alfabeto.");
            Escrever("Outra letra (vazio para sair):");
        }
    }

    public static void VerificaLetrasPalvraNaoPertencem(string alfabeto)
    {
        if (!AlfabetoValido(alfabeto))
        {
            return;
        }

        while (true)
        {
            Escrever("Informe uma palavra");
            console.TextoOpcaoSair();
            string palavra = Ler();

            if (string.IsNullOrEmpty(palavra))
            {
                break;
            }

            List<char> letrasInvalidas = palavra.Where(x => !alfabeto.Contains(x)).ToList();

            Escrever($"As seguintes letras não pertencem: {string.Join(", ", letrasInvalidas)} ");

        }

    }
}