using System;

namespace DIO_Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
        string opcaoUsuario = ObterOpcaoUsuario();
             
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
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

                    case "C":
                    Console.Clear();
                    Console.WriteLine(opcaoUsuario);
                    break;

                    default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por usar nossos serviços");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
              Console.WriteLine("Nenhuma serie cadastrada!");  
              return;
            }
            foreach(var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie: ");

            foreach (int  i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i , Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genero entre as opçoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo= Console.ReadLine();

            Console.Write("Digite o ano de início da série  ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série ");
            string entradaDescricao = Console.ReadLine();

           Serie novaSerie = new Serie
           (
               id : repositorio.ProximoId(),
               genero: (Genero)entradaGenero,
               titulo: entradaTitulo,
               ano: entradaAno, 
               descricao: entradaDescricao
           );
           repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int  i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i , Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genero entre as opçoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo= Console.ReadLine();

            Console.Write("Digite o ano de início da série:  ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

           Serie atualizaSerie = new Serie
           (
               id : indiceSerie,
               genero: (Genero)entradaGenero,
               titulo: entradaTitulo,
               ano: entradaAno, 
               descricao: entradaDescricao
           );
           repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            
            Console.WriteLine(serie);
        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor!!!");
            Console.WriteLine("Informe opção desejada:");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualilzar");
            Console.WriteLine("4 - Excluir");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            Console.WriteLine();
            string opcaoUsuario =  Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
