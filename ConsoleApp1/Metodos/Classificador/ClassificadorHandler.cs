using System.Text.Json;
using static TrabalhoFerramentas.ConsoleHandler;

namespace TrabalhoFerramentas.Metodos.Classificador
{
    public static class ClassificadorHandler
    {
        static ConsoleHandler console = new();

        public static void Classificador()
        {
            bool continua = true;
            do
            {
                Limpar();
                Menu();

                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        QuestionarioClassificacao();
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

        private static void QuestionarioClassificacao()
        {
            List<Problema>? problemas;
            problemas = ObterListaQuestoes();

            if (!ListaProblemasValida(problemas)) return;

            IniciarQuestionario(problemas);
        }

        private static void Menu()
        {
            Console.WriteLine("Bem vindo ao menu de classificação!");
            Console.WriteLine(" 1 -  Classificador T/I/N por JSON.");
            console.TextoOpcaoSair();

        }


        private static void IniciarQuestionario(List<Problema> problemas)
        {
            Pontuacao pontuacao = new Pontuacao();

            problemas.ForEach(p =>
            {
                Limpar();
                ExibirQuestao(p);
                string resposta = ValidarResposta(pontuacao);
                CorrigirResposta(resposta, p, pontuacao);
                console.TextoOpcaoContinuar();
                Pausar();
            });

            ExibirPontuacao(pontuacao);
            console.TextoOpcaoSair();
            Pausar();
        }

        private static void ExibirPontuacao(Pontuacao pontuacao)
        {
            Console.WriteLine("Pontuacao alcançada: ");
            Console.WriteLine($"Acertos: {pontuacao.Acertos} \n Erros: {pontuacao.Erros}");
        }

        private static void ExibirQuestao(Problema problema)
        {
            Console.WriteLine($"[{problema.Identificador}] {problema.Enunciado}");
        }

        private static string? PegarResposta()
        {
            Console.WriteLine("Informe sua resposta (T/I/N): ");
            return Console.ReadLine();
        }

        private static string ValidarResposta(Pontuacao pontuacao)
        {

            while (true)
            {
                string? entrada = PegarResposta();
                string? resposta = ConverterResposta(entrada);

                if (resposta is null)
                {
                    Console.WriteLine("Dê uma resposta valida!");
                    continue;
                }

                return resposta;

            }
        }

        private static void CorrigirResposta(string resposta, Problema problema, Pontuacao pontuacao)
        {
            if (resposta.Equals(problema.CategoriaCorreta))
            {
                Console.WriteLine("Resposta Correta!");
                pontuacao.Acertos++;
                return;
            }

            Console.WriteLine("Resposta Incorreta!");
            pontuacao.Erros++;
        }

        private static string? ConverterResposta(string? sigla)
        {

            switch (sigla)
            {
                case "T":
                    return "tratavel";
                case "I":
                    return "intratavel";
                case "N":
                    return "nao_computavel";
                default:
                    return null;
            }
        }


        private static List<Problema>? ObterListaQuestoes()
        {
            string jsonProblemas = ObterJson();
            return JsonSerializer.Deserialize<List<Problema>>(jsonProblemas);
        }

        private static bool ListaProblemasValida(List<Problema>? problemas)
        {
            if (problemas is null || problemas.Count == 0 )
            {
                Console.WriteLine("Erro ao obter lista de problemas!");
                return false;
            }
            return true;
        }

        private static string ObterJson()
        {
            string json = @"
            [
                {
                ""Identificador"": ""P1"",
                ""Enunciado"": ""Ordenar n numeros"",
                ""CategoriaCorreta"": ""tratavel""
                },
                {
                ""Identificador"": ""P2"",
                ""Enunciado"": ""Verificar se cadeia contem 'a'"",
                ""CategoriaCorreta"": ""tratavel""
                },
                {
                ""Identificador"": ""P3"",
                ""Enunciado"": ""Satisfatibilidade booleana (SAT)"",
                ""CategoriaCorreta"": ""intratavel""
                },
                {
                ""Identificador"": ""P4"",
                ""Enunciado"": ""Caixeiro viajante exato"",
                ""CategoriaCorreta"": ""intratavel""
                },
                {
                ""Identificador"": ""P5"",
                ""Enunciado"": ""Problema da parada"",
                ""CategoriaCorreta"": ""nao_computavel""
                },
                {
                ""Identificador"": ""P6"",
                ""Enunciado"": ""Testar se numero eh primo"",
                ""CategoriaCorreta"": ""tratavel""
                },
                {
                ""Identificador"": ""P7"",
                ""Enunciado"": ""Cobertura por vertices minima"",
                ""CategoriaCorreta"": ""intratavel""
                },
                {
                ""Identificador"": ""P8"",
                ""Enunciado"": ""Decidir se dois programas sempre\nproduzem a mesma saida"",
                ""CategoriaCorreta"": ""nao_computavel""
                }
            ]";
            return json;
        }
    
        
    }
}