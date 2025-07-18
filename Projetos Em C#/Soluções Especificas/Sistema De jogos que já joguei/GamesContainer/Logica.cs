
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_De_jogos_que_já_joguei.GamesContainer
{
    public class GamesOrganizer()
    {
        public List<string> Games = new List<string>();
        private const string FilePath = "Games.txt";
        DateTime datafinalizacao;
        bool canremovegame = false;


        public void SaveGames()
        {
            File.WriteAllLines(FilePath, Games);
        }

        public void LoadGames()
        {
            if (File.Exists(FilePath))
            {
                var lines = File.ReadAllLines(FilePath);
                Games.AddRange(lines);
            }
        }
        public virtual void AddGame()
        {
            Console.WriteLine("Escreva o nome do jogo que gostaria de adicionar");
            string Nome = Console.ReadLine();
            Console.WriteLine("Gostaria de adicionar a data que terminou tambem?");
            var resposta = Console.ReadLine();
            switch (resposta.ToLower())
            {
                case "sim": AddData(Nome); break;
                case "não": Finalizacao(Nome); break;
            }
        }
        public virtual void AddData(string NomeGame)
        {


            Console.WriteLine("Qual foi a data que voce terminou seu jogo?\n (digite no formato: dd/mm/yy)");
            bool Datavalida = false;
            while (!Datavalida)
            {
                var resposta = Console.ReadLine();

                if (DateTime.TryParseExact(resposta, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out datafinalizacao))
                {
                    Datavalida = true;
                }
                else
                {
                    Console.WriteLine("Você escreveu errado patrão, tenta denovo!");
                }

            }

            string var = " terminado em:";

            Games.Add(NomeGame + var + datafinalizacao.ToShortDateString());
            Console.WriteLine("Então sua lista atual está assim:");
            SaveGames();
            displaygames();

        }
        public virtual void RemoveGame()
        {
            if (Games.Count > 0)
            {
                canremovegame = true;
            }
            else
            {
                canremovegame = false;
            }

            if (canremovegame == false)
            {
                Console.WriteLine("Como você quer remover algo que não existe?\nQuer adicionar algo? Sim ou não?");
                var respostaAlt = Console.ReadLine();
                switch (respostaAlt.ToLower())
                {
                    case "sim":
                        AddGame();
                        break;
                    case "nao":
                        Console.WriteLine("Ok! te vejo na proxima");
                        break;
                    default:
                        Console.WriteLine("Resposta não encontrada, está ai???");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Fale o nome do jogo que você gostaria de remover:");
                displaygames();

                var resposta = Console.ReadLine().ToLower();


                var jogopratirar = Games.FirstOrDefault(game => game.ToLower().Contains(resposta));

                if (jogopratirar != null)
                {
                    Games.Remove(jogopratirar);
                    Console.WriteLine($"O jogo '{jogopratirar}' foi removido da sua lista.");
                }
                else
                {
                    Console.WriteLine("Não achei esse jogo");
                }

                Console.WriteLine("Sua lista final está assim:");
                SaveGames();
                displaygames();
            }
        }

        public void Finalizacao(string NomeGame)
        {
            Games.Add(NomeGame);
            SaveGames();
            Console.WriteLine("Sua lista final está Assim:");
            displaygames();
            Console.WriteLine("Gostaria que eu salve isso em um arquivo?");
        }

        public void displaygames()
        {
            foreach (var Game in Games)
            {
                Console.WriteLine(Game);
            }
        }

    }
}
