using System;

namespace BancoSeries
{
    class Program
    {

        static void Main(string[] args)
        {
            BancoDeSeries bancoDeSeries = new BancoDeSeries();

            string input = "";
            while(input != "X")
            {
                MostrarOpcoes();
                input = Console.ReadLine().ToUpper();
                LidarComInput(input, bancoDeSeries);
            }
        }

        static void MostrarOpcoes()
        {
            Console.WriteLine(""); 
            Console.WriteLine("Chill Séries. O que deseja?");
            Console.WriteLine("1 - Inserir série.");
            Console.WriteLine("2 - Deletar série.");
            Console.WriteLine("3 - Listar séries");
            Console.WriteLine("4 - Deletar todas as séries.");
            Console.WriteLine("5 - Ver série.");
            Console.WriteLine("C - Limpar console.");
            Console.WriteLine("X - Sair.");
            Console.WriteLine(""); 
        }

        static void InserirSerie(BancoDeSeries banco)
        {
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Descrição: ");
            string descricao = Console.ReadLine();
            Console.WriteLine("Ano de lançamento:");
            string ano = Console.ReadLine();
            Console.WriteLine("Finalizada? (S/N)");
            bool finalizada = Console.ReadLine().ToUpper() == "S" ?  true : false;
            banco.Adicionar(new Serie(nome, descricao, ano, finalizada));
        }

        static void DeletarSerie(BancoDeSeries banco)
        {
            Console.WriteLine("ID: ");
            int id = int.Parse(Console.ReadLine());
            banco.Excluir(id);
        }

        static void DeletarTodasAsSeries(BancoDeSeries banco)
        {
            banco.Limpar();
        }

        static void ListarSeries(BancoDeSeries banco)
        {
            string[] series = banco.Listar();
            for (int i = 0; i < banco.Count; i++)
            {
                Console.WriteLine(series[i]);
            }
        }

        static void VerSerie(BancoDeSeries banco)
        {
            Console.WriteLine("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(banco.ListarSerie(id));
        }

        static void LidarComInput(string input, BancoDeSeries banco)
        {
            switch(input)
            {
                case "1":
                    InserirSerie(banco);
                break;
                  case "2":
                    DeletarSerie(banco);
                break;
                  case "3":
                    ListarSeries(banco);
                break;
                  case "4":
                    DeletarTodasAsSeries(banco);
                break;
                  case "5":
                    VerSerie(banco);
                break;
                  case "C":
                    Console.Clear();
                break;
                  default:
                break;
            }
        }
    }
}
