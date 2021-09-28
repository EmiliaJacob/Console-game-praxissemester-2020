namespace WholeNewWorld
{
    internal class StateExemptMachines : IStates
    {
        public void PrintMenu()
        {
            Prints.QWhereToExempt();
        }

        public void MenuActions(Player player)
        {

            var input = Inputs.ReadInt();

            switch (input)
            {
                case 1:
                    Prints.QHowManyToExempt("Getreide", player.GrainMachines);
                    input = Inputs.ReadInt();

                    player.GrainMachines -= input == -1
                        ? ManageAccount.ExemptMachines(player, player.GrainMachines, player.GrainMachines)
                        : ManageAccount.ExemptMachines(player, player.GrainMachines, input);

                    Game.CurrentState = States.MachinesMainMenu;
                    break;

                case 2:
                    Prints.QHowManyToExempt("Öl", player.OilMachines);
                    input = Inputs.ReadInt();

                    player.OilMachines -= input == -1
                        ? ManageAccount.ExemptMachines(player, player.OilMachines, player.OilMachines)
                        : ManageAccount.ExemptMachines(player, player.OilMachines, input);

                    Game.CurrentState = States.MachinesMainMenu;
                    break;

                case 3:
                    Prints.QHowManyToExempt("Metall", player.MetalMachines);
                    input = Inputs.ReadInt();

                    player.MetalMachines -= input == -1
                        ? ManageAccount.ExemptMachines(player, player.MetalMachines, player.MetalMachines)
                        : ManageAccount.ExemptMachines(player, player.MetalMachines, input);

                    Game.CurrentState = States.MachinesMainMenu;
                    break;

                case 4:
                    Prints.QHowManyToExempt("Kristall", player.CrystalMachines);
                    input = Inputs.ReadInt();

                    player.CrystalMachines -= input == -1
                        ? ManageAccount.ExemptMachines(player, player.CrystalMachines, player.CrystalMachines)
                        : ManageAccount.ExemptMachines(player, player.CrystalMachines, input);

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
