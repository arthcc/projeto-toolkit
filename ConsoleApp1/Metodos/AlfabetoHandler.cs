namespace TrabalhoFerramentas.Metodos;

public static class AlfabetoHandler
{
    public static string RecuperarAlfabeto()
    {
        Console.WriteLine("Informe o alfabeto: ");
        return Console.ReadLine();
    }

    static bool AlfabetoValido(string alfabeto)
    {
        if (!string.IsNullOrEmpty(alfabeto)) 
            return true;

        Console.WriteLine("Informe um alfabeto antes");
        return false;
    }

    public static void VerificaPertencimento(string alfabeto)
    {
        if (!AlfabetoValido(alfabeto)) return;

        bool continua = true;

        do
        {
            Console.WriteLine("Informe uma letra ou pressione ENTER para sair:");
            string letra = Console.ReadLine();

            if (string.IsNullOrEmpty(letra))
            {
                continua = false;
                return;
            }

            bool pertence = alfabeto.Contains(letra);

            Console.WriteLine(
                $"A letra '{letra}' {(pertence ? "pertence" : "não pertence")} ao alfabeto."
            );

        } while (continua);
    }

    public static void VerificaLetrasPalavraNaoPertencem(string alfabeto)
    {
        if (!AlfabetoValido(alfabeto)) return;

        bool continua = true;

        do
        {
            Console.WriteLine("Informe uma palavra ou pressione ENTER para sair:");
            string palavra = Console.ReadLine();

            if (string.IsNullOrEmpty(palavra))
            {
                continua = false;
                return;
            }

            List<char> letrasInvalidas = palavra.Where(x => !alfabeto.Contains(x)).ToList();

            if (letrasInvalidas.Any())
                Console.WriteLine($"As seguintes letras não pertencem: {string.Join(", ", letrasInvalidas)}");
            else
                Console.WriteLine("Todas as letras da palavra pertencem ao alfabeto.");

        } while (continua);
    }
}