using System;
using System.Linq;

namespace WholeNewWorld
{
    class Prints
    {
        private static void PrintNumberPlusSign(int diff)
        {
            if (diff > 0)
                Console.Write($"+{diff}");

            if (diff < 0)
                Console.Write(diff);

            if (diff == 0)
                Console.Write(0);
        }


        //Account Information
        public static void SettlersBankAccountLand(Player player)
        {
            Console.WriteLine($"{player.Name} aus {player.TerritoryName}");
            Console.WriteLine(
                $"Siedler: {player.Settlers} | Geld: {player.BankAccount} | Land: {player.Land} (Verfügbar: {Game.TotalLand}, Preis: {MarketPrices.Land}/{(int) (MarketPrices.Land * 0.9)})");
            Console.WriteLine();
        }

        public static void ListOfGoods()
        {
            Console.WriteLine("1. Getreide\n" +
                              "2. Öl\n" +
                              "3. Metall\n" +
                              "4. Kristall\n" +
                              "5. Abbrechen");
        }

        public static void GoodsMachines(Player player)
        {
            Console.WriteLine("Maschinen   Anzahl  Vorrat  Preis");
            Console.WriteLine(
                $"Getreide         {player.GrainMachines}      {player.Grain}  {MarketPrices.Grain}/{(int) (MarketPrices.Grain * 0.9)}");
            Console.WriteLine(
                $"Öl               {player.OilMachines}      {player.Oil}  {MarketPrices.Oil}/{(int) (MarketPrices.Oil * 0.9)}");
            Console.WriteLine(
                $"Metall           {player.MetalMachines}       {player.Metal}  {MarketPrices.Metal}/{(int) (MarketPrices.Metal * 0.9)}");
            Console.WriteLine(
                $"Kristall         {player.CrystalMachines}       {player.Crystal}  {MarketPrices.Crystal}/{(int) (MarketPrices.Crystal * 0.9)}");
            Console.WriteLine($"Frei             {player.MachinesFree}");
            Console.WriteLine("---");
        }


        //Alerts
        public static void TooLessPlayer()
        {
            Console.Write("Bitte eine Zahl > 0 eingeben: ");
        }


        //Option Listings
        public static void LandMenu()
        {
            Console.WriteLine(
                "1. Land kaufen\n" +
                "2. Land verkaufen\n" +
                "3. Zurück"
            );
        }

        public static void MainMenu()
        {
            Console.WriteLine(
                "1. Land verwalten\n" +
                "2. Maschinen verwalten\n" +
                "3. Markt besuchen\n" +
                //"4. Unterwelt besuchen\n" +
                "4. Runde beenden"
            );
        }

        public static void UnderWoldMenu()
        {
            Console.WriteLine($"" +
                              $"1. Kredithai\n" +
                              $"2. Zurück\n");
        }
        public static void MachineMenu()
        {
            Console.WriteLine(
                "1. Maschine(n) herstellen\n" +
                "2. Maschine(n) zuordnen\n" +
                "3. Maschine(n) freistellen\n" +
                "4. Zurück"
            );
        }

        public static void MarketMainMenu()
        {
            Console.WriteLine(
                "1. Vorräte kaufen\n" +
                "2. Vorräte verkaufen\n" +
                "3. Zurück"
            );
        }


        //Questions
        public static void QNumberPlayers()
        {
            Console.WriteLine(
                $"Willkommen in der Neuen Welt\n" +
                $"============================"
            );

            Console.Write($"Wie viele Spieler? ");
        }

        public static void QWhatToBuy()
        {
            Console.WriteLine("Welche Vorräte sollen gekauft werden");
        }

        public static void QPlayerName(int number)
        {
            Console.Write($"Name für Spieler {number}? ");
        }

        public static void QPlayerTerritoryName(string name)
        {
            Console.Write($"Name des Gebiets für Spieler {name}? ");
        }

        public static void QAmountToBuy(Player player, string printName, string goodName)
        {
            Console.Write($"Wie viel {printName} soll gekauft werden [{ManageAccount.MaxBuyGoods(player,goodName)}]? ");
        }

        public static void QAmountToSell(Player player ,string name, int maxValue)
        {
            Console.Write($"Wie viel {name} soll verkauft werden [{maxValue}]? ");
        }

        public static void QWhatToSell()
        {
            Console.WriteLine("Welche Vorräte sollen verkauft werden");
        }

        public static void QAmountToBuild(Player player)
        { 
            Console.Write($"Wie viele Maschinen sollen hergestellt werden [{ManageAccount.MaxBuildMachines(player)}]? ");
        }

        public static void QWhereToSet()
        {
            Console.WriteLine("Wo sollen Maschinen zugeordnet werden?");
            ListOfGoods();
        }

        public static void QforEnter()
        {
            Console.WriteLine($"Zum Fortfahren Enter drücken.");
        }

        public static void QWhereToExempt()
        {
            Console.WriteLine("Von wo sollen Maschinen freigegeben werden?");
            ListOfGoods();
        }

        public static void QHowManyToExempt(String name, int maxVal)
        {
            Console.Write($"Wie viele Maschinen sollen von {name} freigegeben werden [{maxVal}]? ");
        }

        public static void QHowManySetTo( String name, int maxValue)
        {
            Console.Write($"Wie viele Maschinen sollen zu {name} zugewiesen werden [{maxValue}]? ");
        }


        //Round-End Information
        public static void RoundResume(Player player)
        {
            Console.WriteLine($"Statusbericht für {player.Name} aus {player.TerritoryName}");
            Console.WriteLine("=============");

            if (player.NewbornSettlers != 0)
                Console.WriteLine($"- Es wurden {player.NewbornSettlers} Siedler geboren");

            if (player.EmigratedSettlers != 0)
                Console.WriteLine($"- Es sind {player.EmigratedSettlers} Siedler ausgewandert");

            if (player.DeadSettlers != 0)
                Console.WriteLine($"- Es sind {player.DeadSettlers} Siedler gestorben");

            Console.WriteLine($"- Die Siedler haben {player.Settlers - player.NewbornSettlers} Getreide verbraucht");
            Console.WriteLine($"- Die Maschinen haben {player.OilUsed} Öl verbraucht");
            Console.WriteLine($"- Es wurde produziert:\n" +
                              $"  Getreide: {player.GrainProduced}\n" +
                              $"  Öl: {player.OilProduced}\n" +
                              $"  Metall: {player.MetalProduced}\n" +
                              $"  Kristall: {player.Crystal}\n");
        }

        public static void PlayerRanks(Game game)
        {
            Console.WriteLine($"Rangfolge:");

            var players = game.Players.Cast<Player>().ToList();

            var orderedByRank = players.OrderBy(x => x.Rank).ThenBy(x => x.Name).ToList();

            foreach (var player in orderedByRank) //TODO: foreach überall für queues verwenden
            {
                Console.WriteLine($"{player.Rank}. {player.Name} aus {player.TerritoryName} ({player.Land} Land)");
            }

            Console.WriteLine();
        }

        public static void PriceChanges()
        {
            Console.WriteLine($"" +
                              "Rundenbericht\n" +
                              "=============\n" +
                              "Folgende Preisänderungen haben sich ergeben: ");

            Console.WriteLine($"- Land:     +5/+4   ({MarketPrices.Land}/{(int) (MarketPrices.Land * 0.9)})");

            Console.Write($"- Getreide: ");
            PrintNumberPlusSign(MarketPrices.DiffBuyGrain);
            Console.Write($"/");
            PrintNumberPlusSign(MarketPrices.DiffSellGrain);
            Console.WriteLine($"     ({MarketPrices.Grain}/{(int) (MarketPrices.Grain * 0.9)})");

            Console.Write($"- Öl:       ");
            PrintNumberPlusSign(MarketPrices.DiffBuyOil);
            Console.Write($"/");
            PrintNumberPlusSign(MarketPrices.DiffSellOil);
            Console.WriteLine($"     ({MarketPrices.Oil}/{(int) (MarketPrices.Oil * 0.9)})");

            Console.Write($"- Metall:   ");
            PrintNumberPlusSign(MarketPrices.DiffBuyMetal);
            Console.Write($"/");
            PrintNumberPlusSign(MarketPrices.DiffSellMetal);
            Console.WriteLine($"     ({MarketPrices.Metal}/{(int) (MarketPrices.Metal * 0.9)})");

            Console.Write($"- Kristall: ");
            PrintNumberPlusSign(MarketPrices.DiffBuyCrystal);
            Console.Write($"/");
            PrintNumberPlusSign(MarketPrices.DiffSellCrystal);
            Console.WriteLine($" ({MarketPrices.Crystal}/{(int) (MarketPrices.Crystal * 0.9)})");

            Console.WriteLine();
        }
    }
}