using System;
using CadastroSeries_API;

namespace CadastroSeries_API.Console
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            #region Opção do Usuário
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
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
                        System.Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            System.Console.WriteLine("Obrigado por utilizar nosso cadastro de séries");
            System.Console.WriteLine();

            #endregion
        }
        #region Obter a Opção Usuário
        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Olá! Seja Bem Vindo!!!");
            System.Console.WriteLine("Digite a opção desejada:");

            System.Console.WriteLine("1- Listar as séries cadastradas");
            System.Console.WriteLine("2- Inserir uma nova série");
            System.Console.WriteLine("3- Atualizar série as cadastradas");
            System.Console.WriteLine("4- Excluir uma série");
            System.Console.WriteLine("5- Visualizar uma série");
            System.Console.WriteLine("C- Limpar Tela");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string opcaoUsuario = System.Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
        #endregion

        #region Listar Séries
        public static void ListarSeries()
        {
            System.Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada. ");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                System.Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }
        #endregion 

        #region Inserir Serie
        //Exception e return para C ou tela inicial no genero
        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir uma nova série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entGenero = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Digite a Título da Série: ");
            string entTitulo = System.Console.ReadLine();

            System.Console.WriteLine("Digite o Ano da Produção da Série: ");
            int entAno = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Digite a Sinopse da Série: ");
            string entSinopse = System.Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entGenero, titulo: entTitulo, ano: entAno, sinopse: entSinopse);

            repositorio.Insere(novaSerie);

        }


        #endregion

        #region Atualizar Serie
        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(System.Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entGenero = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Digite a Título da Série: ");
            string entTitulo = System.Console.ReadLine();

            System.Console.WriteLine("Digite o Ano da Produção da Série: ");
            int entAno = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Digite a Sinopse da Série: ");
            string entSinopse = System.Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entGenero, titulo: entTitulo, ano: entAno, sinopse: entSinopse);

            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }
        #endregion

        #region Excluir Série
        private static void ExcluirSerie()
        {
            System.Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(System.Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }
        #endregion

        #region Visualiar Série
        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série que deseja consultar: ");
            int indiceSerie = int.Parse(System.Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            System.Console.WriteLine(serie);
        }
        #endregion





    }
}
