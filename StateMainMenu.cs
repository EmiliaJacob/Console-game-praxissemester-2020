namespace WholeNewWorld
{
    internal class StateMainMenu : IStates
    {
        public void PrintMenu() 
        {
            Prints.MainMenu();
        }

        public void MenuActions(Player player)
        {
            var input = Inputs.ReadInt(); ;

            switch(input)
            {
                case 1:
                    Game.CurrentState = States.LandMenu;
                    break;

                case 2:
                    Game.CurrentState = States.MachinesMainMenu;
                    break;

                case 3:
                    Game.CurrentState = States.MarketMainMenu;
                    break;

                case 4:
                    Game.CurrentState = States.EndOfRound;
                    break;

                case -1:
                    MenuActions(player);
                    break;
            }
        }
    }
}
