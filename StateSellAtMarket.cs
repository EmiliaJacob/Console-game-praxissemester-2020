namespace WholeNewWorld
{
    internal class StateSellAtMarket : IStates
    {
        public void PrintMenu()
        {
            Prints.QWhatToSell();
            Prints.ListOfGoods();
        }

        public void MenuActions(Player player)
        {
            var chosenGood = Inputs.ReadInt();
            var newValue = 0;
            int input;

            switch (chosenGood)
            {
                case 1:
                    Prints.QAmountToSell(player, "Getreide", player.Grain);
                    input = Inputs.ReadInt();
                    newValue = ManageAccount.Sell(player, input==-1 ? player.Grain : input, player.Grain, (int)(MarketPrices.Grain * 0.9));
                    player.Grain = newValue;
                    Game.CurrentState = States.MarketMainMenu;
                    break;

                case 2:
                    Prints.QAmountToSell(player, "Öl", player.Oil);
                    input = Inputs.ReadInt();
                    newValue = ManageAccount.Sell(player, input == -1 ? player.Oil : input, player.Oil, (int)(MarketPrices.Oil * 0.9));
                    player.Oil = newValue;
                    Game.CurrentState = States.MarketMainMenu;
                    break;

                case 3:
                    Prints.QAmountToSell(player, "Metall", player.Metal);
                    input = Inputs.ReadInt();
                    newValue = ManageAccount.Sell(player, input == -1 ? player.Metal : input, player.Metal, (int)(MarketPrices.Metal * 0.9));
                    player.Metal = newValue;
                    Game.CurrentState = States.MarketMainMenu;
                    break;

                case 4:
                    Prints.QAmountToSell(player, "Kristall", player.Crystal);
                    input = Inputs.ReadInt();
                    newValue = ManageAccount.Sell(player, input == -1 ? player.Crystal : input, player.Crystal, (int)(MarketPrices.Crystal * 0.9));
                    player.Crystal = newValue;
                    Game.CurrentState = States.MarketMainMenu;
                    break;

                case 5:
                    Game.CurrentState = States.MarketMainMenu;
                    break;

                case -1: 
                    MenuActions(player);
                    break;
            }
        }
    }
}
