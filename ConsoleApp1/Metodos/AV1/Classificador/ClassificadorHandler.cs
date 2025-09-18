using System.Text.Json;
using static TrabalhoFerramentas.Metodos.Utils.ConsoleUtils;

namespace TrabalhoFerramentas.Metodos.AV1.Classificador
{
    /// <summary>
    /// Item AV1: Classificador T/I/N por JSON embutido.
    /// Lê a lista de problemas, pergunta (T/I/N), corrige e exibe pontuação final.
    /// </summary>
    public static class ClassificadorHandler
    {

        /// <summary>
        /// Loop do menu do classificador. Enter vazio sai.
        /// </summary>
        public static void Classificador()
        {
            bool continua = true;
            do
            {
                Limpar();
                Menu();

                string? opcao = LerOpcaoMenu("Escolha uma opção", "1", "");
                switch (opcao)
                {
                    case "1":
                        QuestionarioClassificacao();
                        break;
                    case "":
                        continua = false;
                        break;
                }

            } while (continua);
        }

        /// <summary>
        /// Orquestra a obtenção da lista e inicia o questionário.
        /// </summary>
        private static void QuestionarioClassificacao()
        {
            List<Problema>? problemas = ObterListaQuestoes();

            if (!ListaProblemasValida(problemas))
                return;

            IniciarQuestionario(problemas!);
        }

        /// <summary>
        /// Exibe o menu do módulo.
        /// </summary>
        private static void Menu()
        {
            Escrever("Bem vindo ao menu de classificação!");
            Escrever(" 1 -  Classificador T/I/N por JSON.");
            TextoOpcaoSair();
        }

        /// <summary>
        /// Loop principal do questionário: pergunta, valida, corrige e pontua.
        /// </summary>
        private static void IniciarQuestionario(List<Problema> problemas)
        {
            Pontuacao pontuacao = new Pontuacao();

            problemas.ForEach(p =>
            {
                Limpar();
                ExibirQuestao(p);

                string resposta = ValidarResposta();

                CorrigirResposta(resposta, p, pontuacao);
                Pausar();
            });
            Limpar();
            ExibirPontuacao(pontuacao);
            Pausar();
        }

        /// <summary>
        /// Mostra o resumo de acertos/erros.
        /// </summary>
        private static void ExibirPontuacao(Pontuacao pontuacao)
        {
            Escrever("Pontuacao alcançada: ");
            Escrever($"Acertos: {pontuacao.Acertos} \nErros: {pontuacao.Erros}");
        }

        /// <summary>
        /// Imprime a questão atual.
        /// </summary>
        private static void ExibirQuestao(Problema problema)
        {
            Escrever($"[{problema.Identificador}] {problema.Enunciado}");
        }

        /// <summary>
        /// Lê e valida a resposta do usuário como T/I/N.
        /// Usa ConsoleHandler para garantir entrada válida.
        /// </summary>
        private static string ValidarResposta()
        {
            string respostaSigla = LerOpcaoMenu("Informe sua resposta (T/I/N)", "T", "I", "N");
         
            string? respostaNormalizada = ConverterResposta(respostaSigla);
           
            if (respostaNormalizada is null)
                return "tratavel"; 
            return respostaNormalizada;
        }

        /// <summary>
        /// Corrige uma resposta e atualiza a pontuação.
        /// </summary>
        private static void CorrigirResposta(string resposta, Problema problema, Pontuacao pontuacao)
        {
            if (resposta.Equals(problema.CategoriaCorreta, StringComparison.OrdinalIgnoreCase))
            {
                Escrever("Resposta Correta!");
                pontuacao.Acertos++;
                return;
            }

            Escrever("Resposta Incorreta!");
            pontuacao.Erros++;
        }

        /// <summary>
        /// Converte T/I/N para as categorias do seu modelo.
        /// </summary>
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

        /// <summary>
        /// Carrega a lista de problemas a partir do JSON embutido.
        /// </summary>
        private static List<Problema>? ObterListaQuestoes()
        {
            string jsonProblemas = ObterJson();
            return JsonSerializer.Deserialize<List<Problema>>(jsonProblemas);
        }

        /// <summary>
        /// Verifica se a lista desserializada é válida.
        /// </summary>
        private static bool ListaProblemasValida(List<Problema>? problemas)
        {
            if (problemas is null || problemas.Count == 0)
            {
                Escrever("Erro ao obter lista de problemas!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// JSON embutido com os problemas T/I/N.
        /// </summary>
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
                ""Enunciado"": ""Decidir se dois programas sempre produzem a mesma saida"",
                ""CategoriaCorreta"": ""nao_computavel""
                }
            ]";
            return json;
        }
    }
}