namespace WholeNewWorld
{
    static class ManageMarketPrices
    {

        public static void InitMarketPrices(int initLand,int initGrain, int initOil, int initMetal, int initCrystal)
        {
            MarketPrices.Land = initLand;
            MarketPrices.Grain = initGrain;
            MarketPrices.Oil = initOil;
            MarketPrices.Metal = initMetal;
            MarketPrices.Crystal = initCrystal;

            MarketPrices.StartGrain = initGrain;
            MarketPrices.StartOil = initOil;
            MarketPrices.StartMetal = initMetal;
            MarketPrices.StartCrystal = initCrystal;
        }

        public  static void DecreasePrices(string nameOfGood, double amount)
        {
            int newVal;

            switch (nameOfGood)
            {
                case "grain":
                    newVal = MarketPrices.Grain - (int)(MarketPrices.Grain * amount);
                    MarketPrices.Grain = newVal > MarketPrices.StartGrain ? newVal : MarketPrices.StartGrain;
                    break;

                case "oil":
                    newVal = MarketPrices.Oil - (int)(MarketPrices.Oil * amount);
                    MarketPrices.Oil = newVal > MarketPrices.StartOil ? newVal : MarketPrices.StartOil;
                    break;

                case "metal":
                    newVal = MarketPrices.Metal - (int)(MarketPrices.Metal * amount);
                    MarketPrices.Metal = newVal > MarketPrices.StartMetal ? newVal : MarketPrices.StartMetal;
                    break;

                case "crystal":
                    newVal = MarketPrices.Crystal - (int)(MarketPrices.Crystal * amount);
                    MarketPrices.Crystal = newVal > MarketPrices.StartCrystal ? newVal : MarketPrices.StartCrystal;
                    break;
            }
        }

        public static void IncreaseLandPrice(int amount)
        {
            MarketPrices.Land += amount;
        }
        
        public static void IncreasePrices(string nameOfGood, double amount) 
        {
            switch (nameOfGood)
            {
                case "grain":
                    MarketPrices.Grain = MarketPrices.Grain + (int)(MarketPrices.Grain * amount);
                    break;

                case "oil":
                    MarketPrices.Oil = MarketPrices.Oil + (int)(MarketPrices.Oil * amount);
                    break;

                case "metal":
                    MarketPrices.Metal = MarketPrices.Metal + (int)(MarketPrices.Metal * amount);
                    break;

                case "crystal":
                    MarketPrices.Crystal = MarketPrices.Crystal + (int)(MarketPrices.Crystal * amount);
                    break;
            }
        }

        public static void CalcBuyDifference()
        {
            MarketPrices.DiffBuyGrain = MarketPrices.Grain - MarketPrices.LastGrain; 
            MarketPrices.DiffBuyOil = MarketPrices.Oil - MarketPrices.LastOil;
            MarketPrices.DiffBuyMetal = MarketPrices.Metal - MarketPrices.LastMetal;
            MarketPrices.DiffBuyCrystal = MarketPrices.Crystal - MarketPrices.LastCrystal;
        }

        public static void CalcSellDifference()
        {
            MarketPrices.DiffSellGrain = (int)(MarketPrices.Grain * 0.9) - (int)(MarketPrices.LastGrain * 0.9);
            MarketPrices.DiffSellOil = (int)(MarketPrices.Oil * 0.9) - (int)(MarketPrices.LastOil * 0.9);
            MarketPrices.DiffSellMetal = (int)(MarketPrices.Metal * 0.9) - (int)(MarketPrices.LastMetal * 0.9);
            MarketPrices.DiffSellCrystal = (int)(MarketPrices.Crystal * 0.9) - (int)(MarketPrices.LastCrystal * 0.9);
        }

        public static void UpdateLastPriceVariables()
        {
            MarketPrices.LastGrain = MarketPrices.Grain;
            MarketPrices.LastOil = MarketPrices.Oil;
            MarketPrices.LastMetal = MarketPrices.Metal;
            MarketPrices.LastCrystal = MarketPrices.Crystal;
        }
    }
}
