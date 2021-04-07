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
                        //AtualizarSerie();
                        break;
                    case "4":
                        //ExcluirSerie();
                        break;
                    case "5":
                        //VisualizarSeries();
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
                Console.WriteLine("# ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            
            Console.WriteLine();
            // esse forEach vai percorrer a lista de Enums criadas para que caso haja alguma alteração seja facil a manutenção
            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();

            Console.WriteLine("Escolha o Gênero que deseja inserir entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite o Descrição da Série ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            repositorio.Insere(novaSerie);

            Console.WriteLine("Deseja inserir mais uma serie? (Y - Sim ou N - Não)");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            if (opcaoUsuario.ToUpper() == "Y")
            {
                InserirSerie();
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
