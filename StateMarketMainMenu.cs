namespace WholeNewWorld
{
    class StateMarketMainMenu : IStates
    {
        public void PrintMenu()
        {
            Prints.MarketMainMenu();
        }

        public void MenuActions(Player player)
        {
            var input = Inputs.ReadInt();

            switch(input)
            {
                case 1:
                    Game.CurrentState = States.BuyAtMarket;
                    break;

                case 2:
                    Game.CurrentState = States.SellAtMarket;
                    break;

                case 3:
                    Game.CurrentState = States.MainMenu;
                    break;

                case -1:
                    MenuActions(player); 
                    break;
            }
        }
    }
}
