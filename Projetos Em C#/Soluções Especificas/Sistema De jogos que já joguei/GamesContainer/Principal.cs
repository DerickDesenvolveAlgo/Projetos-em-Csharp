using System;
using System.IO;

namespace Sistema_De_jogos_que_já_joguei.GamesContainer
{
    internal class Principal
    {
        static void Main(string[] args)
        {

            GamesOrganizer gamesOrganizer = new GamesOrganizer();
            Principal principal = new Principal();

            gamesOrganizer.LoadGames();

            Console.WriteLine("Bem vindo ao seu organizador de Games, aqui estão os seu jogos atualmente zerados:");
            foreach (var Game in gamesOrganizer.Games)
            {
                Console.WriteLine(Game);
            }
            if (gamesOrganizer.Games.Count <= 0)
            {
                Console.WriteLine("zerou nada dog");
            }
            Console.WriteLine("\nGostaria de adicionar mais algum ou remover?\nEscreva 'adicionar' ou 'remover'\ncaso " +
                "queria somente ver os games denovo escreva 'Mostrar' ");
            var resposta = Console.ReadLine();
            bool isInvalid;
            switch (resposta.ToLower())
            {
                case "adicionar": gamesOrganizer.AddGame(); break;
                case "remover": gamesOrganizer.RemoveGame(); break;
                case "mostrar": gamesOrganizer.displaygames(); break;


            }
        }    
    }



}
