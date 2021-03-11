using System;
using System.Collections.Generic;
using System.Collections;
using DIO.Docs;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
		static DocumentariosRepositorio docRepositorio = new DocumentariosRepositorio();
        static void Main(string[] args)
        {
			int escolha = Escolha();
            
			if (escolha == 1)
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
							VisualizarSerie();
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
			else if (escolha == 2) 
			{
				string opcaoDocs = ObterOpcaoDocs();
				while (opcaoDocs.ToUpper() != "X")
				{
					switch (opcaoDocs)
					{
						case "1":
							ListarDocs();
							break;
						case "2":
							InserirDoc();
							break;
						case "3":
							AtualizarDoc();
							break;
						case "4":
							ExcluirDoc();
							break;
						case "5":
							VisualizarDoc();
							break;
						case "C":
							Console.Clear();
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}

					opcaoDocs = ObterOpcaoDocs();
				}
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			Console.Write("Confirmar exclusão? (1 - para Sim, 0 para não) ");
			int confirmar = int.Parse(Console.ReadLine());
			if (confirmar == 1)
				repositorio.Exclui(indiceSerie);
			else
				return;
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

		// documentários
		private static void ExcluirDoc()
		{
			Console.Write("Digite o id do documentário: ");
			int indiceDoc = int.Parse(Console.ReadLine());

			Console.Write("Confirmar exclusão? (1 - para Sim, 0 para não) ");
			int confirmar = int.Parse(Console.ReadLine());
			if (confirmar == 1)
				docRepositorio.Exclui(indiceDoc);
			else
				return;
		}

        private static void VisualizarDoc()
		{
			Console.Write("Digite o id do documentário: ");
			int indiceDoc = int.Parse(Console.ReadLine());

			var doc = docRepositorio.RetornaPorId(indiceDoc);

			Console.WriteLine(doc);
		}

        private static void AtualizarDoc()
		{
			Console.Write("Digite o id do documentário: ");
			int indiceDoc = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(GeneroDoc)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(GeneroDoc), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do documentário: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de publicação do documentário: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a duração do documentário em minutos: ");
			int duracaoDoc = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do documentário: ");
			string entradaDescricao = Console.ReadLine();

			Documentarios atualizaDoc = new Documentarios(id: indiceDoc,
										genero: (GeneroDoc)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
										duracao: duracaoDoc);

			docRepositorio.Atualiza(indiceDoc, atualizaDoc);
		}
        private static void ListarDocs()
		{
			Console.WriteLine("Listar documentários");

			var lista = docRepositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum documentário cadastrado.");
				return;
			}

			foreach (var doc in lista)
			{
                var excluido = doc.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", doc.retornaId(), doc.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirDoc()
		{
			Console.WriteLine("Inserir novo documentário");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(GeneroDoc)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(GeneroDoc), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do documentário: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de publicação do documentário: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a duração do documentário em minutos: ");
			int duracaoDoc = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do documentário: ");
			string entradaDescricao = Console.ReadLine();

			Documentarios novoDoc = new Documentarios(id: docRepositorio.ProximoId(),
										genero: (GeneroDoc)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
										duracao: duracaoDoc);

			docRepositorio.Insere(novoDoc);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Estamos a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		private static string ObterOpcaoDocs()
		{
			Console.WriteLine();
			Console.WriteLine("Estamos a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar documentário");
			Console.WriteLine("2- Inserir novo documentário");
			Console.WriteLine("3- Atualizar documentário");
			Console.WriteLine("4- Excluir documentário");
			Console.WriteLine("5- Visualizar documentário");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		public static int Escolha ()
		{
			Console.WriteLine();
			Console.WriteLine("Estamos a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada: (1 para Séries, 2 para Documentários) ");

			int opcaoEscolha = int.Parse(Console.ReadLine());
			return opcaoEscolha;
		}
    }
}
