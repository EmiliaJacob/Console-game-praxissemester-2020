using System;

namespace WholeNewWorld
{
    static class ManageAccount
    {
        //Methods to calc & return Max Values available for transactions
        public static int MaxBuyGoods(Player player, string Good)
        {
            int max = 0;

            switch (Good)
            {
                case NamesOfGoods.Land:
                    max = player.BankAccount / MarketPrices.Land;
                    break;

                case NamesOfGoods.Grain:
                    max = player.BankAccount / MarketPrices.Grain;
                    break;

                case NamesOfGoods.Oil:
                    max = player.BankAccount / MarketPrices.Oil;
                    break;

                case NamesOfGoods.Metal:
                    max = player.BankAccount / MarketPrices.Metal;
                    break;

                case NamesOfGoods.Crystal:
                    max = player.BankAccount / MarketPrices.Crystal;
                    break;
            }

            return max;
        }

        /* public static int MaxSellGoods (Player player, string Good) // Vllt überflüssig
         {
             int max = 0;
 
             switch (Good)
             {
                 case NamesOfGoods.Land:
                     max = player.Land;
                     break;           
                 
                 case NamesOfGoods.Grain:
                     max = player.Grain;
                     break;           
                 
                 case NamesOfGoods.Oil:
                     max = player.Oil;
                     break;              
                 
                 case NamesOfGoods.Metal:
                     max = player.Metal;
                     break;
 
                 case NamesOfGoods.Crystal:
                     max = player.Crystal;
                     break;
             }
             return max;
         }*/

        public static int MaxBuildMachines(Player player) 
        {
            return player.Metal / 5; 
        }

        public static int MaxAssignMachines (Player player)
        {
            return player.LandFree > player.MachinesFree ? player.MachinesFree : player.LandFree;
        }

        public static int MaxExemptMachines (Player player) // TODO: Vllt entfernen
        {
            var max = 0;
            return max;
        }


        public static void ChangeValueGrains(Player player, int newValue)
        {
            player.Grain = newValue;
        }

        public static void ChangeValueOil(Player player, int newValue)
        {
            player.Oil = newValue;
        }

        public static void ChangeValueMetal(Player player, int newValue)
        {
            player.Metal = newValue;
        }

        public static void ChangeValueCrystal(Player player, int newValue)
        {
            player.Crystal = newValue;
        }

        public static int Purchase(Player player, int desiredAmount, int inAccount, int price)
        {
            if (player.BankAccount < desiredAmount * price || desiredAmount <= 0) return inAccount;
            inAccount += desiredAmount;
            player.BankAccount -= desiredAmount * price;
            return inAccount;
        }

        public static int Sell(Player player, int quantity, int inAccount, int price)
        {
            if (inAccount < quantity || quantity <= 0) return inAccount;
            player.BankAccount += quantity * price;
            inAccount -= quantity;
            return inAccount;
        }

        public static int AssignMachines(Player player, int machine, int quantity)
        {
            if (quantity > player.MachinesFree || quantity > player.LandFree || quantity <= 0) return 0;
            player.MachinesFree -= quantity;
            player.LandFree -= quantity;
            return quantity;
        }

        public static int ExemptMachines(Player player,  int numberMachines, int quantity)
        {
            if (quantity <= 0 || quantity > numberMachines) return 0;
            player.MachinesFree += quantity;
            player.LandFree += quantity;
            return quantity;
        }

        public static void ExemptExcessMachines(Player player, int soldLand)
        {
            if (soldLand <= player.LandFree) return;
            var difference = soldLand - player.LandFree;
            var i = difference;

            while (i > 0 && player.CrystalMachines > 0)
            {
                player.CrystalMachines -= ManageAccount.ExemptMachines(player, player.CrystalMachines, 1);
                i--;
            }

            while (i > 0 && player.MetalMachines > 0)
            {
                player.MetalMachines -= ManageAccount.ExemptMachines(player, player.MetalMachines, 1);
                i--;
            }

            while (i > 0 && player.OilMachines > 0)
            {
                player.OilMachines -= ManageAccount.ExemptMachines(player, player.OilMachines, 1);
                i--;
            }

            while (i > 0 && player.GrainMachines > 0)
            {
                player.GrainMachines -= ManageAccount.ExemptMachines(player, player.GrainMachines, 1);
                i--;
            }
        }

        public static void BuildMachines(Player player, int quantity) 
        {
            if (ManageAccount.MaxBuildMachines(player) < quantity || quantity <= 0) return;
            player.MachinesFree += quantity;
            player.Metal -= quantity*5;
        }

        public static void ServeFood(Player player)
        {
            player.DeadSettlers = 0;

            if (player.Grain >= player.Settlers)
                player.Grain -= player.Settlers;

            else
            {
                player.DeadSettlers = player.Settlers - player.Grain;
                player.Settlers -= player.DeadSettlers;
                player.Grain = 0;
            }
        }

        private static int CalculateNewProduction(Player player, int amountMachines, int amountProduction)
        {
            var grownUpSettlers = player.Settlers-player.NewbornSettlers;
            var minimum = Math.Min(grownUpSettlers, player.Oil);
            var newProducedGoods = 0;
            if (minimum <= 0) return newProducedGoods;
            if (minimum >= amountMachines)
            {
                newProducedGoods = amountMachines * amountProduction;
                player.OilUsed += amountMachines;
                player.Oil -= amountMachines;
            }
            else
            {
                newProducedGoods = minimum * amountProduction;
                player.OilUsed += minimum;
                player.Oil -= minimum;
            }
            return newProducedGoods;
        }

        public static void ProduceNewGoods(Player player)
        {
            player.GrainProduced = 0;
            player.OilProduced = 0;
            player.MetalProduced = 0;
            player.CrystalProduced = 0;
            player.OilUsed = 0;

            player.GrainProduced = CalculateNewProduction(player, player.GrainMachines, player.GrainMachineProductionCapacity); 
            player.Grain += player.GrainProduced; 
            
            player.OilProduced = CalculateNewProduction(player, player.OilMachines, player.OilMachineProductionCapacity);  
            player.Oil += player.OilProduced;   
            
            player.MetalProduced = CalculateNewProduction(player, player.MetalMachines, player.MetalMachineProductionCapacity); 
            player.Metal+= player.MetalProduced;

            player.CrystalProduced = CalculateNewProduction(player, player.CrystalMachines, player.CrystalMachineProductionCapacity);
            player.Crystal = player.CrystalProduced;
        }

        public static void GiveBirth(Player player)
        {
            player.NewbornSettlers = 0;

            if (player.Grain < 5 || player.LandFree <= 0) return;
            int maximum = player.Grain / 5;
            int freeSlots = (player.LandFree * 5) - player.Settlers;

            player.NewbornSettlers = freeSlots < maximum ? freeSlots : maximum;

            player.Settlers += player.NewbornSettlers;
        }

        public static void EmigrateSettlers(Player player)//seems to Work
        {
            player.EmigratedSettlers = 0;

            if (player.LandFree >= player.Settlers / 5) return;
            player.EmigratedSettlers = player.Settlers - (player.LandFree * 5);
            player.Settlers -= player.EmigratedSettlers;
        }
    }
}
