namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        public void Main(string[] args)
        {
            string opUser = ObterOpcaoUser();

            while(opUser.ToUpper() != "A")
            {
                switch(opUser)
                {
                    case "1":
                        Listar();
                        break;
                    case "2":
                        Inserir();
                        break;
                    case "3":
                        Atualizar();
                        break;
                    case "4":
                        Excluir();
                        break;
                    case "5":
                        Visualizar();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static void Listar()
        {
            Console.WriteLine("Obrigado por está aqui");
            Console.ReadLine();

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {                
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornoExcluir();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornoId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));
                
            }
        }

        private static void Inserir()
        {
            System.Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}",i, Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGen = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ANO da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescri = Console.ReadLine();

            Serie newSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGen, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescri);

            repositorio.Insere(newSerie);
        }

        private static void Atualizar()
        {
            System.Console.WriteLine("Digite o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}",i, Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGen = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ANO da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescri = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGen, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescri);

            repositorio.Atualizar(indiceSerie,atualizaSerie);
        }

        private static void Excluir()
        {
            System.Console.WriteLine("Digite o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        private static void Visualizar()
        {
            System.Console.WriteLine("Digite o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.retornoId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUser()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series pra você!");
            Console.WriteLine("Informe a sua opção: ");

            Console.WriteLine("1. Listar");
            Console.WriteLine("2. Inserir");
            Console.WriteLine("3. Atualizar");
            Console.WriteLine("4. Excluir");
            Console.WriteLine("5. Visualizar");
            Console.WriteLine("6. Limpar a tela");
            Console.WriteLine("A. Sair");
            Console.WriteLine();

            string opUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opUser;
        }
    }
}

