namespace WholeNewWorld
{
     class StateManageLand : IStates
    {
        
        public void PrintMenu()
        {
            Prints.LandMenu(); 
        }
        
        public void MenuActions( Player player) 
        {
            var input = Inputs.ReadInt();

            switch(input)
            {
                case 1: // TODO: In eigene Klasse nach Vorbild von Markt 
                    Prints.QAmountToBuy(player, "Land", NamesOfGoods.Land);
                    input = Inputs.ReadInt();
                    BuyLand(player, input == -1 ? ManageAccount.MaxBuyGoods(player, NamesOfGoods.Land) : input);
                    break;
                    
                case 2:
                    Prints.QAmountToSell(player, "Land", player.Land);
                    input = Inputs.ReadInt();
                    SellLand(player, input == -1 ? player.Land : input);
                    break;

                case 3:
                    Game.CurrentState = States.MainMenu;
                    break;

                case -1:
                    MenuActions(player);
                    break;
            }
        }

        private static void BuyLand(Player player, int desiredAmount)
        {
            if (desiredAmount > Game.TotalLand) return;
            var newValue = ManageAccount.Purchase(player, desiredAmount, player.Land, MarketPrices.Land);
            var difference = newValue - player.Land;
            player.Land = newValue;
            player.LandFree += difference;
            Game.TotalLand -= difference;
        }

        private static void SellLand(Player player, int desiredAmount)
        {
            if (desiredAmount <= 0) return;
            ManageAccount.ExemptExcessMachines(player,desiredAmount);
            var newValue = ManageAccount.Sell(player, desiredAmount, player.Land, (int)(MarketPrices.Land * 0.9));
            var difference = player.Land - newValue;
            player.Land = newValue;
            player.LandFree -= difference;
            Game.TotalLand += difference;
        }

        
    }
}
