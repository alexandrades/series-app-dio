using System;
using DIO.Series.Classes;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opUsuario = ObterOpcaoUsuario();

            while(opUsuario.ToUpper() != "X"){
                switch(opUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                }

                opUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar este serviço");
            Console.WriteLine("Conte sempre conosco! :D");

        }

        private static void ExcluirSerie(){
            Console.Write("Digite o ID da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(idSerie);
        }

        private static void VisualizarSerie(){
            Console.Write("Digite o ID da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(idSerie);

            Console.WriteLine(serie);
        }

        private static void AtualizarSerie(){
            Console.Write("Digite o ID da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof (Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int generoId = int.Parse(Console.ReadLine());

            Console.Write("Título da serie: ");
            string titulo = Console.ReadLine();

            Console.Write("Ano de inicio da serie: ");
            int anoInicio = int.Parse(Console.ReadLine());

            Console.Write("Descrição da serie: ");
            string descricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: idSerie,
                                        genero: (Genero)generoId,
                                        titulo: titulo,
                                        ano: anoInicio,
                                        descricao: descricao);

            repositorio.Atualiza(idSerie, atualizaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("Nenhum série cadastrada. :(");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("->ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? " --Excluído--": ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int generoId = int.Parse(Console.ReadLine());

            Console.Write("Título da serie: ");
            string titulo = Console.ReadLine();

            Console.Write("Ano de inicio da serie: ");
            int anoInicio = int.Parse(Console.ReadLine());

            Console.Write("Descrição da serie: ");
            string descricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)generoId,
                                        titulo: titulo,
                                        ano: anoInicio,
                                        descricao: descricao);

            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("============  DIO Séries ao seu dispor ============");
            Console.WriteLine("Informa a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opUsuario;
        }
    }
}
