namespace TrabalhoFerramentas
{
    using System;
    using TrabalhoFerramentas.Metodos;

    class Program
    {
        static void Main(string[] args)
        {
            string alfabeto = "";
            bool continua = true;

            string opcao;
            do
            {
                Menu();

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        alfabeto = AlfabetoHandler.RecuperarAlfabeto();
                        break;

                    case "2":
                        if (string.IsNullOrEmpty(alfabeto))
                            Console.WriteLine("Informe um alfabeto primeiro (opção 1).");
                        else
                            AlfabetoHandler.VerificaPertencimento(alfabeto);
                        break;

                    case "3":
                        if (string.IsNullOrEmpty(alfabeto))
                            Console.WriteLine("Informe um alfabeto primeiro (opção 1).");
                        else
                            AlfabetoHandler.VerificaLetrasPalavraNaoPertencem(alfabeto); 
                        break;

                    case "": 
                        Console.WriteLine("Obrigada por utilizar nosso sistema :)");
                        continua = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

            } while (continua);

        }

        static void Menu()
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine(" 1 - Informar um alfabeto");
            Console.WriteLine(" 2 - Validar se letra faz parte do alfabeto");
            Console.WriteLine(" 3 - Verificar quais letras da palavra não pertencem ao alfabeto");
            Console.WriteLine(" Pressione apenas ENTER para sair");
            Console.Write("Escolha uma opção: ");
        }
    }
}
