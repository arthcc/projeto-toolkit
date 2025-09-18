using static TrabalhoFerramentas.Metodos.Utils.ConsoleUtils;

namespace TrabalhoFerramentas.Metodos.AV1.Reconhecedor;
/// <summary>
/// Item 5 (AV1): Reconhecedores em Σ={a,b}.
/// Opções: L_par_a (quantidade de 'a' par) e L = { w | w = a b* }.
/// Saída: ACEITA / REJEITA.
/// </summary>
public static class ReconhecedoresHandler
{
    /// <summary>
    /// Submenu do reconhecedor. Enter vazio volta ao menu principal.
    /// </summary>
    public static void Menu()
    {
        bool continua = true;
        while (continua)
        {
            Limpar();
            Escrever("Reconhecedores em Σ = {a, b}");
            Escrever(" 1 - L_par_a: aceita se a quantidade de 'a' em w é PAR");
            Escrever(" 2 - L = { w | w = a b* }");
            TextoOpcaoSair();

            string opcao = LerOpcaoMenu("Escolha uma opção", "1", "2", "");
            switch (opcao)
            {
                case "1": TestarAEhPar(); break;
                case "2": TestarComecaATerminaB(); break;
                case "": continua = false; break;
            }
        }
    }

    /// <summary>
    /// L_par_a: aceita se #a(w) é par. Valida Σ e imprime ACEITA/REJEITA.
    /// </summary>
    private static void TestarAEhPar()
    {
        Limpar();
        Escrever("L_par_a  (Σ = {a,b})");

        string w = LerCadeiaSigma("Digite w");

        int qtdA = 0;
        string s = w.ToLowerInvariant();
        for (int i = 0; i < s.Length; i++)
            if (s[i] == 'a') qtdA++;

        bool aceita = (qtdA % 2) == 0;

        Escrever(aceita ? "ACEITA" : "REJEITA");
        Pausar();
    }

    /// <summary>
    /// L = { w | w = a b* }: aceita se w começa com 'a' e o restante é só 'b'. Imprime ACEITA/REJEITA.
    /// </summary>
    private static void TestarComecaATerminaB()
    {
        Limpar();
        Escrever("L = { w | w = a b* }  (Σ = {a,b})");

        string w = LerCadeiaSigma("Digite w");

        string s = w.ToLowerInvariant();
        bool aceita = s.Length >= 1 && s[0] == 'a';
        for (int i = 1; aceita && i < s.Length; i++)
            aceita = s[i] == 'b';

        Escrever(aceita ? "ACEITA" : "REJEITA");
        Pausar();
    }
}