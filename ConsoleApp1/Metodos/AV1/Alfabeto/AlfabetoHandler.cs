using static TrabalhoFerramentas.Metodos.Utils.ConsoleUtils;

namespace TrabalhoFerramentas.Metodos.AV1.Alfabeto;

public static class AlfabetoHandler
{
    /// <summary>
    /// Menu: 1) informar alfabeto, 2) verificar símbolo, 3) verificar cadeia.
    /// Enter vazio para sair deste módulo.
    /// </summary>
    public static void VerificarAlfabetoECadeia()
    {
        string? alfabeto = null;
        bool continua = true;

        while (continua)
        {
            Limpar();
            Menu(alfabeto);
           
            string opcao = LerOpcaoMenu("Escolha uma opção", "1", "2", "3", "");

            switch (opcao)
            {
                case "1":
                    alfabeto = RecuperarAlfabeto();
                    break;

                case "2":
                    if (!GarantirAlfabetoDefinido(alfabeto)) break;
                    VerificaPertencimento(alfabeto!);
                    break;

                case "3":
                    if (!GarantirAlfabetoDefinido(alfabeto)) break;
                    VerificaLetrasPalvraNaoPertencem(alfabeto!);
                    break;

                case "":
                    continua = false; 
                    break;
            }
        }
    }

    /// <summary>
    /// Lê do usuário um alfabeto (string não vazia), confirma e retorna.
    /// </summary>
    public static string? RecuperarAlfabeto()
    {
        string? alfabeto;

        do
        {
            Limpar();
            Escrever("Informe o alfabeto:");
            alfabeto = Console.ReadLine()?.Trim();
        }
        while (!AlfabetoValido(alfabeto));

        Escrever("Alfabeto cadastrado com sucesso!");
        Pausar();
        return alfabeto;
    }

    /// <summary>
    /// Valida se o alfabeto não é nulo/vazio (pode expandir regras aqui).
    /// </summary>
    static bool AlfabetoValido(string? alfabeto)
    {
        if (!string.IsNullOrWhiteSpace(alfabeto)) return true;

        Escrever("Informe um alfabeto valido!");
        Pausar();
        return false;
    }

    /// <summary>
    /// Laço que verifica se letras digitadas pertencem ao alfabeto.
    /// Enter vazio encerra.
    /// </summary>
    public static void VerificaPertencimento(string alfabeto)
    {
        if (!AlfabetoValido(alfabeto)) return;

        HashSet<char> set = new HashSet<char>(alfabeto.Trim().ToUpperInvariant());

        TextoOpcaoSair();
        Escrever("Informe uma letra:");

        while (true)
        {
            string? entrada = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entrada))
                break;

            char ch = entrada.Trim()[0];
            bool pertence = set.Contains(char.ToUpperInvariant(ch));

            Escrever($"A letra '{ch}' {(pertence ? "" : "não ")}pertence ao alfabeto.");
            TextoOpcaoSair();
            Escrever("Outra letra:");
        }
    }

    /// <summary>
    /// Lê palavras e mostra quais letras NÃO pertencem ao alfabeto. Enter vazio encerra.
    /// </summary>
    public static void VerificaLetrasPalvraNaoPertencem(string alfabeto)
    {
        if (!AlfabetoValido(alfabeto)) return;

        HashSet<char> set = new HashSet<char>(alfabeto.Trim().ToUpperInvariant());

        while (true)
        {
            TextoOpcaoSair();
            Escrever("Informe uma palavra:");

            string? palavra = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(palavra))
                break;

            List<char> letrasInvalidas = new List<char>();
            foreach (char c in palavra)
            {
                char up = char.ToUpperInvariant(c);
                if (!set.Contains(up))
                    letrasInvalidas.Add(c);
            }

            if (letrasInvalidas.Count == 0)
            {
                Escrever("Todas as letras pertencem ao alfabeto.");
            }
            else
            {
                string lista = string.Join(", ", letrasInvalidas.Distinct());
                Escrever($"As seguintes letras não pertencem: {lista}");
            }
        }
    }

    /// <summary>
    /// Garante que o submenu só avance se o alfabeto estiver definido.
    /// </summary>
    private static bool GarantirAlfabetoDefinido(string? alfabeto)
    {
        if (!string.IsNullOrWhiteSpace(alfabeto)) return true;

        Escrever("Defina o alfabeto primeiro (opção 1).");
        Pausar();
        return false;
    }

    private static void Menu(string? alfabeto)
    {
        Escrever("=== Verificar alfabeto e cadeia ===");
        Escrever($"Alfabeto atual: {(string.IsNullOrWhiteSpace(alfabeto) ? "(não definido)" : alfabeto)}\n");
        Escrever(" 1 - Informar alfabeto");
        Escrever(" 2 - Verificar se símbolo pertence");
        Escrever(" 3 - Verificar se cadeia pertence");
        TextoOpcaoSair();
       
    }
}