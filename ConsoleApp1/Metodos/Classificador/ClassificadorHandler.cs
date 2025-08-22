using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TrabalhoFerramentas.Metodos.Classificador
{
    public static class ClassificadorHandler
    {
        public static void Execute()
        {
            List<Problema>? problemas;

            MenuClassificador();
            problemas = ObterListaQuestoes();

            if (!ListaProblemasValida(problemas)) return;

            IniciarQuestionario(problemas);

        }
        private static void MenuClassificador()
        {
            Console.WriteLine("Bem vindo ao teste de classificação!");
            Console.WriteLine("Classificações possiveis: T = Tratável, I = intratável, N = Não computável");
            Console.WriteLine("Aperte [ENTER] para iniciar uma tentativa!");

        }

        private static void IniciarQuestionario(List<Problema> problemas)
        {
            Pontuacao pontuacao = new Pontuacao();

            problemas.ForEach(p =>
            {
                Console.Clear();
                ExibirQuestao(p);
                string resposta = ValidarResposta(pontuacao);
                CorrigirResposta(resposta, p, pontuacao);
            });

            ExibirPontuacao(pontuacao);
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
                string resposta = PegarResposta();
                resposta = ConverterResposta(resposta);
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

            Console.WriteLine("Resposta Inorreta!");
            pontuacao.Erros++;
        }

        private static string ConverterResposta(string? sigla)
        {

            switch (sigla)
            {
                case "T":
                    return "tratavel";
                case "I":
                    return "intratável";
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
            if (problemas is null)
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
                ""Enunciado"": ""Decidir se dois programas sempre
                produzem a mesma saida"",
                ""CategoriaCorreta"": ""nao_computavel""
                }
            ]";
            return json;
        }
    }
}