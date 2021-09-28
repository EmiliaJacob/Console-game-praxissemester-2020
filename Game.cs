using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WholeNewWorld
{
    internal class Game
     {

        private static int NumberPlayers { get; set; } = 0;
        private readonly Dictionary<string,int> _totalGoods = new Dictionary<string, int>();

        public Queue Players = new Queue();
        public static IStates CurrentState { get; set; } 
        public Dictionary<int,List<Player>> PlayersRank = new Dictionary<int, List<Player>>();
        public static int TotalLand{ get; set; }

        public Game()
        { 
            CurrentState = States.InitialState;
            ManageMarketPrices.InitMarketPrices(50,25,50,60,75);
        }
       
        private void SetUpGame()
        {
            Prints.QNumberPlayers();

            while (NumberPlayers <= 0)
            {
                NumberPlayers = Inputs.ReadInt();

                if(NumberPlayers <=0 )
                    Prints.TooLessPlayer();
            }

            TotalLand = NumberPlayers * 100;

            for (var i = 1; i <= NumberPlayers; i++) 
            {
                Prints.QPlayerName(i);

                var cache = new Player
                {
                    Settlers = 20,
                    BankAccount = 100,
                    Land = 5,
                    Grain = 25,
                    Oil = 10,
                    Metal = 25,
                    Crystal = 0,
                    GrainMachines = 2,
                    OilMachines = 1,
                    MetalMachines = 0,
                    CrystalMachines = 0,
                    MachinesFree = 0,
                    LandFree = 2,
                    GrainMachineProductionCapacity = 10,
                    OilMachineProductionCapacity = 5,
                    MetalMachineProductionCapacity = 1,
                    CrystalMachineProductionCapacity = 2,
                    Name = Console.ReadLine()
                };

                Prints.QPlayerTerritoryName(cache.Name);
                cache.TerritoryName = Console.ReadLine(); 
                Players.Enqueue(cache);
            }

            Console.WriteLine();
        }
       
        public void RunGame()
        {
            SetUpGame();
            Player currentPlayer;

            while (true)
            {
                
                for (int i = 0; i < NumberPlayers; i++)
                {
                    currentPlayer = (Player)(Players.Dequeue());
                    OneRound(currentPlayer);
                    Players.Enqueue(currentPlayer);
                }

                Players.Enqueue(Players.Dequeue());
                ChangePrices();
                CalculateRanking();
                Prints.PriceChanges();
                Prints.PlayerRanks(this);
            }   
        }

        private static void OneRound(Player player)
        {
            Game.CurrentState = States.InitialState;

            while (Game.CurrentState != States.EndOfRound)
            {
                if (!(CurrentState is StateInitial))
                {
                    Prints.SettlersBankAccountLand(player);
                    Prints.GoodsMachines(player);
                }

                CurrentState.PrintMenu();
                CurrentState.MenuActions(player);
            }
        }
        
        private void SummUpGoods()
        { 
            int totalGrain = 0;
            int totalOil = 0;
            int totalMetal = 0;
            int totalCrystal = 0;

            Player CurrentPlayer;

            for (var i = 0; i < NumberPlayers; i ++)
            {
                CurrentPlayer = (Player)(Players.Dequeue());
                totalGrain += CurrentPlayer.Grain;
                totalOil+= CurrentPlayer.Oil;
                totalMetal += CurrentPlayer.Metal;
                totalCrystal+= CurrentPlayer.Crystal;
                Players.Enqueue(CurrentPlayer);
            }

            _totalGoods["grain"] = totalGrain;
            _totalGoods["oil"] = totalOil;
            _totalGoods["metal"] = totalMetal;
            _totalGoods["crystal"] = totalCrystal;
        }

        private void ChangePrices()
        {
            SummUpGoods();

            var sortedGoods = _totalGoods.OrderByDescending(x => x.Value).Select(totalAmount => totalAmount.Key).ToList();

            ManageMarketPrices.UpdateLastPriceVariables();

            ManageMarketPrices.IncreaseLandPrice(5);

            ManageMarketPrices.DecreasePrices(sortedGoods[0],0.1);
            ManageMarketPrices.DecreasePrices(sortedGoods[1],0.5);
            ManageMarketPrices.IncreasePrices(sortedGoods[3],0.2);

            ManageMarketPrices.CalcBuyDifference();
            
            ManageMarketPrices.CalcSellDifference();
        }

        private void CalculateRanking() 
        {
            int currentRank = 1;

            var sortedGamerList = 
                from Player player in Players 
                orderby player.Land descending  
                select player;

            int currentLandLevel = sortedGamerList.ElementAt(0).Land;  

            foreach (var player in sortedGamerList)
            {
                if (player.Land < currentLandLevel)
                {
                    currentRank += 1;
                    currentLandLevel = player.Land;
                }

                player.Rank = currentRank;
            }
        }
    }
}
