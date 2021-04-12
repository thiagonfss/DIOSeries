using DIOSeries.Classes;
using DIOSeries.Enum;
using System;
using System.Collections.Generic;

namespace DIOSeries
{
    class Program
    {
        static SerieRepository repositorio = new SerieRepository();
        static void Main(string[] args)
        {
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
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void VisualizarSeries()
        {
            List<Serie> lista = repositorio.Lista();
            if (lista.Count != 0)
            {
                Console.WriteLine("Digite o ID da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                Serie serie = repositorio.RetornaPorId(indiceSerie);

                if (serie != null)
                    Console.WriteLine(serie);
            }
            Console.Write("Não existem series cadastradas!!!");
            Console.WriteLine();
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            ListarOpcoes(indiceSerie);


        }

        private static void ExcluirSerie()
        {
            List<Serie> lista = repositorio.Lista();
            if (lista.Count != 0)
            {
                Console.Write("Digite o id da série");
                int indiceSerie = int.Parse(Console.ReadLine());

                Console.Write("Deseja realmente excluir a série com Id {0}", indiceSerie);

                string opcaoUsuario = Console.ReadLine().ToUpper();
                if (opcaoUsuario.ToUpper() == "Y")
                {
                    repositorio.Exclui(indiceSerie);
                }

                return;
            }

            Console.Write("Não existem series cadastradas!!!");
            Console.WriteLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Lista de series");

            List<Serie> lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie cadastrada. Deseja inserir uma nova serie? (Y - Sim ou N - Não)");

                string opcaoUsuario = Console.ReadLine().ToUpper();
                if (opcaoUsuario.ToUpper() == "Y")
                {
                    InserirSerie();
                }

                return;
            }

            foreach (Serie serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if (!excluido)
                    Console.WriteLine("# ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            ListarOpcoes(-1);

            Console.WriteLine("Deseja inserir mais uma serie? (Y - Sim ou N - Não)");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            if (opcaoUsuario.ToUpper() == "Y")
            {
                InserirSerie();
            }

        }

        private static void ListarOpcoes(int controleId)
        {

            Console.WriteLine();
            // esse forEach vai percorrer a lista de Enums criadas para que caso haja alguma alteração seja facil a manutenção
            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();

            Console.WriteLine("Escolha o Gênero que deseja inserir entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Digite o Título da Série ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Digite o Ano de Início da Série ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Digite o Descrição da Série ");
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine();

            if (controleId == -1)
            {
                Serie serie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
                repositorio.Insere(serie);
            }
            else
            {
                Serie serie = new Serie(id: controleId,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
                repositorio.Atualiza(controleId, serie);
            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série ");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
