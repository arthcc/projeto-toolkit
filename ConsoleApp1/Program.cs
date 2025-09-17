namespace TrabalhoFerramentas
{
    using System;
    using TrabalhoFerramentas.Metodos;
    using TrabalhoFerramentas.Metodos.Classificador;
    using static TrabalhoFerramentas.ConsoleHandler;
    class Program
    {
        static void Main(string[] args)
        {
            string alfabeto = "";
            bool continua = true;

            string opcao;
            do
            {
                Limpar();
                Menu();

                opcao = Ler();


                switch (opcao)
                {
                    case "1": alfabeto = AlfabetoHandler.RecuperarAlfabeto(); break;
                    case "2": AlfabetoHandler.VerificaPertencimento(alfabeto); break;
                    case "3": AlfabetoHandler.VerificaLetrasPalvraNaoPertencem(alfabeto); break;
                    case "4": ClassificadorHandler.Classificador(); break;
                    case "5": SigmaABHandler.VerificarSimboloECadeia(); break;
                    case "6": TerminaComBHandler.Decidir(); break;
                    case "7": AvaliadorProposicionalHandler.Menu(); break; 
                    case "8": ReconhecedoresHandler.Menu(); break;
                    case "": Escrever("Obrigada por utilizar nosso sistema :)"); continua = false; break;
                    default: Escrever("ERROR"); break;
                }

            } while (continua);

        }

        static void Menu()
        {
            Escrever(" 1 - Informar um alfabeto");
            Escrever(" 2 - Validar se letra faz parte do alfabeto");
            Escrever(" 3 - Verificar quais letras da palavra não pertencem ao alfabeto");
            Escrever(" 4 - Classificador T/I/N por JSON");
            Escrever(" 5 - Σ={a,b}: verificador de símbolo e cadeia (Σ e Σ*)");
            Escrever(" 6 - Decisor: termina com 'b'?");
            Escrever(" 7 - Avaliador proposicional (P,Q,R) + tabela-verdade");
            Escrever(" 8 - Reconhecedores Σ={a,b}: L_par_a e a b*");
            Escrever("[ENTER] para sair");
        }
    }
}
