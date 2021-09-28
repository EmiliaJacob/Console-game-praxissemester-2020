namespace WholeNewWorld
{
    class StateMachinesMainMenu : IStates
    {
        public void PrintMenu()
        {
            Prints.MachineMenu();
        }

        public void MenuActions(Player player)
        {
            switch(Inputs.ReadInt())
            {
                case 1:
                    Game.CurrentState = States.BuildMachines;
                    break;

                case 2:
                    Game.CurrentState = States.SetMachines;
                    break;

                case 3:
                    Game.CurrentState = States.ExemptMachines;
                    break;

                case 4:
                    Game.CurrentState = States.MainMenu;
                    break;

                case -1: 
                    MenuActions(player);
                    break;
            }
        }
    }
}
