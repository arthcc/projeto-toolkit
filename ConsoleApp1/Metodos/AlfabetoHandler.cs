using static TrabalhoFerramentas.ConsoleHandler;

namespace TrabalhoFerramentas.Metodos;

public static class AlfabetoHandler
{
    static ConsoleHandler Console = new();
    public static string? RecuperarAlfabeto()
    {
        string? alfabeto;
        do
        {
            Limpar();
            Escrever("Informe o alfabeto:");
            alfabeto = Ler()?.Trim();


        }
        while (!AlfabetoValido(alfabeto));
        Escrever("Alfabeto cadastrado com sucesso!");
        Console.TextoOpcaoContinuar();
        Pausar();
        return alfabeto;

    }

    static bool AlfabetoValido(string? alfabeto)
    {
        if (!string.IsNullOrWhiteSpace(alfabeto)) return true;

        Escrever("Informe um alfabeto valido!");
        Console.TextoOpcaoContinuar();
        Pausar();
        return false;
    }
    public static void VerificaPertencimento(string alfabeto)
    {
        if (!AlfabetoValido(alfabeto)) return;

        HashSet<char> set = new HashSet<char>(
            alfabeto.Trim().ToUpperInvariant()
        );

        Escrever("Informe uma letra:");
        Console.TextoOpcaoSair();

        while (true)
        {
            string? entrada = Ler();

            if (string.IsNullOrWhiteSpace(entrada))
                break; 

            char ch = entrada.Trim()[0];
            bool pertence = set.Contains(char.ToUpperInvariant(ch));

            Escrever($"A letra '{ch}' {(pertence ? "" : "não ")}pertence ao alfabeto.");
            Escrever("Outra letra: (vazio para sair):");
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
            Console.TextoOpcaoSair();
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