namespace WholeNewWorld
{
    class StateInitial : IStates
    {
        public void PrintMenu() 
        {

        }
        
        public void MenuActions(Player player)
        {
            ManageAccount.EmigrateSettlers(player);
            ManageAccount.ServeFood(player); 
            ManageAccount.GiveBirth(player);
            ManageAccount.ProduceNewGoods(player);
            Game.CurrentState = States.MainMenu;
            
            Prints.RoundResume(player);
            Prints.QforEnter();
            Inputs.WaitForEnterInput();
            Game.CurrentState = States.MainMenu;
        }
    }
}
