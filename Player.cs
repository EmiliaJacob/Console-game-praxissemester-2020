namespace WholeNewWorld
{
     class Player
    {
        public string Name { get; set; }
        public string TerritoryName{ get; set; }
        public int Rank { get; set; }


        public  int Settlers{ get; set; }
        public int BankAccount { get; set; }   
        public int Land { get; set; }
        public int LandFree { get; set; }

        public int Grain { get; set; }
        public int Oil { get; set; }
        public int Metal { get; set; }
        public int Crystal { get; set; } 

        public int GrainMachines { get; set; }
        public int OilMachines { get; set; }
        public int MetalMachines { get; set; }
        public int CrystalMachines { get; set; }

        public int MachinesFree { get; set; }

        public int GrainProduced { get; set; }
        public int OilProduced { get; set; }
        public int MetalProduced { get; set; }
        public int CrystalProduced{ get; set; }

        public int DeadSettlers { get; set; }
        public int OilUsed { get; set; }
        public int EmigratedSettlers{ get; set; }
        public int NewbornSettlers { get; set; }


        public int GrainMachineProductionCapacity { get; set; }
        public int OilMachineProductionCapacity{ get; set; }
        public int MetalMachineProductionCapacity { get; set; }
        public int CrystalMachineProductionCapacity { get; set; }

        public Player()
        {
            GrainProduced = 0;
            OilProduced = 0;
            MetalProduced = 0;
            CrystalProduced = 0;

            Rank = -1;

            OilUsed = 0;

            DeadSettlers = 0;
        }
   }
}
