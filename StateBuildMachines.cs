using System;
using System.Collections.Generic;
using System.Text;

namespace WholeNewWorld
{
    internal class StateBuildMachines : IStates
    {
        public void PrintMenu()
        {
            // Had to be moved into MenuActions, because the Print required a player Object --> does that mean this whole Interface Method is unnecessary? TODO: inspect this
        }

        public void MenuActions(Player player)
        {
            Prints.QAmountToBuild(player);
            var input = Inputs.ReadInt();
            ManageAccount.BuildMachines(player, input == -1 ? ManageAccount.MaxBuildMachines(player) : input);
            Game.CurrentState = States.MachinesMainMenu;
        }
    }
}
