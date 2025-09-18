namespace TrabalhoFerramentas
{
    using System;
    using TrabalhoFerramentas.Metodos.AV1.Alfabeto;
    using TrabalhoFerramentas.Metodos.AV1.AvaliadorProposicional;
    using TrabalhoFerramentas.Metodos.AV1.Classificador;
    using TrabalhoFerramentas.Metodos.AV1.Reconhecedor;
    using TrabalhoFerramentas.Metodos.AV1.TerminaComB;
    using static TrabalhoFerramentas.Metodos.Utils.ConsoleUtils;
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

                opcao = LerOpcaoMenu("Escolha uma opção", "1", "2", "3", "4", "5", "");


                switch (opcao)
                {
                   
                    case "1": AlfabetoHandler.VerificarAlfabetoECadeia(); break;
                    case "2": ClassificadorHandler.Classificador(); break;
                    case "3": TerminaComBHandler.Decidir(); break;
                    case "4": AvaliadorProposicionalHandler.Menu(); break; 
                    case "5": ReconhecedoresHandler.Menu(); break;
                    case "": Escrever("Obrigada por utilizar nosso sistema :)"); continua = false; break;
                }

            } while (continua);

        }

        static void Menu()
        {
            Escrever("Projeto Toolkit (versao simples)");
            Escrever("---- AV1 ----");
            Escrever("1) Verificar alfabeto e cadeia");
            Escrever("2) Classificador T/I/N por JSON");
            Escrever("3) Decisor: termina com 'b'?");
            Escrever("4) Avaliador proposicional (P,Q,R)");
            Escrever("5) Reconhecedor: L_par_a e a b*");
            TextoOpcaoSair();
        }
    }
}
