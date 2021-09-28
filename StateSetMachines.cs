namespace WholeNewWorld
{
    internal class StateSetMachines : IStates
    {
        public void PrintMenu()
        {
            Prints.QWhereToSet();
        }

        public void MenuActions(Player player) 
        {
            var input = Inputs.ReadInt();

            switch (input)
            {
                case 1:
                    Prints.QHowManySetTo("Getreide", ManageAccount.MaxAssignMachines(player));
                    input = Inputs.ReadInt();

                    player.GrainMachines += input == -1
                        ? ManageAccount.AssignMachines(player, player.GrainMachines, ManageAccount.MaxAssignMachines(player))
                        : ManageAccount.AssignMachines(player, player.GrainMachines, input);

                    Game.CurrentState = States.MachinesMainMenu;
                    break;

                case 2:
                    Prints.QHowManySetTo("Öl", ManageAccount.MaxAssignMachines(player));
                    input = Inputs.ReadInt();

                    player.OilMachines += input == -1
                        ? ManageAccount.AssignMachines(player, player.OilMachines, ManageAccount.MaxAssignMachines(player))
                        : ManageAccount.AssignMachines(player, player.OilMachines, input);

                    Game.CurrentState = States.MachinesMainMenu;
                    break;

                case 3:
                    Prints.QHowManySetTo("Metall", ManageAccount.MaxAssignMachines(player));
                    input = Inputs.ReadInt();

                    player.MetalMachines += input == -1
                        ? ManageAccount.AssignMachines(player, player.MetalMachines, ManageAccount.MaxAssignMachines(player))
                        : ManageAccount.AssignMachines(player, player.MetalMachines, input);

                    Game.CurrentState = States.MachinesMainMenu;
                    break;

                case 4:
                    Prints.QHowManySetTo("Kristall", ManageAccount.MaxAssignMachines(player));
                    input = Inputs.ReadInt();

                    player.CrystalMachines += input == -1
                        ? ManageAccount.AssignMachines(player, player.CrystalMachines, ManageAccount.MaxAssignMachines(player))
                        : ManageAccount.AssignMachines(player, player.CrystalMachines, input);

                    Game.CurrentState = States.MachinesMainMenu;
                    break;

                case 5:
                    Game.CurrentState = States.MachinesMainMenu;
                    break;

                case -1: 
                    MenuActions(player);
                    break;
            }
        }
    }
}
