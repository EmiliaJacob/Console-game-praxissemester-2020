namespace WholeNewWorld
{
    internal class StateBuyAtMarket : IStates
    {
        public void PrintMenu()
        {
            Prints.QWhatToBuy();
            Prints.ListOfGoods();
        }

        public void MenuActions(Player player)
        {
            var chosenGood = Inputs.ReadInt();
            var newValue=0;
            int input;

            switch (chosenGood)
            {
                case 1:
                    Prints.QAmountToBuy(player,"Getreide", NamesOfGoods.Grain);
                    input = Inputs.ReadInt();
                    newValue = ManageAccount.Purchase(player, input==-1 ? ManageAccount.MaxBuyGoods(player,NamesOfGoods.Grain) : input, player.Grain, MarketPrices.Grain);
                    ManageAccount.ChangeValueGrains(player,newValue);
                    Game.CurrentState = States.MarketMainMenu;
                    break;

                case 2:
                    Prints.QAmountToBuy(player, "Öl", NamesOfGoods.Oil);
                    input = Inputs.ReadInt();
                    newValue = ManageAccount.Purchase(player, input == -1 ? ManageAccount.MaxBuyGoods(player, NamesOfGoods.Oil) : input, player.Oil, MarketPrices.Oil);
                    ManageAccount.ChangeValueOil(player,newValue);
                    Game.CurrentState = States.MarketMainMenu; 
                    break;

                case 3:
                    Prints.QAmountToBuy(player, "Metall", NamesOfGoods.Metal);
                    input = Inputs.ReadInt();
                    newValue = ManageAccount.Purchase(player, input == -1 ? ManageAccount.MaxBuyGoods(player, NamesOfGoods.Metal) : input, player.Metal, MarketPrices.Metal);
                    ManageAccount.ChangeValueMetal(player, newValue);
                    Game.CurrentState = States.MarketMainMenu;
                    break;

                case 4:
                    Prints.QAmountToBuy(player, "Kristall", NamesOfGoods.Crystal);
                    input = Inputs.ReadInt();
                    newValue = ManageAccount.Purchase(player, input == -1 ? ManageAccount.MaxBuyGoods(player, NamesOfGoods.Crystal) : input, player.Crystal, MarketPrices.Crystal);
                    ManageAccount.ChangeValueCrystal(player, newValue);
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
