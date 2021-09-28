namespace WholeNewWorld
{
    static class States
    {
        public static StateManageLand LandMenu { get; } = new StateManageLand();
        public static StateMainMenu MainMenu { get; } = new StateMainMenu();
        public static StateMarketMainMenu MarketMainMenu{ get;  } = new StateMarketMainMenu();
        public static StateBuyAtMarket BuyAtMarket { get; } = new StateBuyAtMarket();
        public static StateSellAtMarket SellAtMarket { get; } = new StateSellAtMarket();
        public static StateMachinesMainMenu MachinesMainMenu { get; } = new StateMachinesMainMenu();
        public static StateExemptMachines ExemptMachines { get; } = new StateExemptMachines();
        public static StateBuildMachines BuildMachines { get; } = new StateBuildMachines();
        public static StateSetMachines SetMachines { get; } = new StateSetMachines();
        public static StateInitial InitialState { get; } = new StateInitial();
        public static StateEndOfRound EndOfRound { get; set; }
    }
}
