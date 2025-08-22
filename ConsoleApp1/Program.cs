namespace TrabalhoFerramentas
{
    using System;
    using TrabalhoFerramentas.Metodos;
    using TrabalhoFerramentas.Metodos.Classificador;

    class Program
    {
        static void Main(string[] args)
        {
            string alfabeto = "";
            bool continua = true;

            string opcao;
            do
            {
                Console.Clear();
                Menu();

                opcao = Console.ReadLine();


                switch (opcao)
                {
                    case "1":
                        alfabeto = AlfabetoHandler.RecuperarAlfabeto();
                        break;
                    case "2":
                        AlfabetoHandler.VerificaPertencimento(alfabeto);
                        break;
                    case "3":
                        AlfabetoHandler.VerificaLetrasPalvraNaoPertencem(alfabeto);
                        break;
                    case "4":
                        ClassificadorHandler.Execute();
                        break;
                    case "":
                        Console.WriteLine("Obrigada por utilizar nosso sistema :)");
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("ERROR");
                        break;
                }

            } while (continua);

        }

        static void Menu()
        {
            Console.WriteLine(" 1 - Informar um alfabeto");
            Console.WriteLine(" 2 - Validar se letra faz parte do alfabeto");
            Console.WriteLine(" 3 - Verificar quais letras da palavra não pertencem ao alfabeto");
            Console.WriteLine(" 4 - Classificador T/I/N por JSON");
            Console.WriteLine("'ENTER' para sair");
        }
    }
}