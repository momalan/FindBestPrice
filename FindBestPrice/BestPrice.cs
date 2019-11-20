using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindBestPrice
{
    public class BestPrice
    {
        public int FindBestPrice(int[] prices, int[] costs)
        {

            var pricesCosts = new List<Tuple<int, int>>();
            for (int i = 0; i <= prices.Count() - 1; i++)
            {
                pricesCosts.Add(new Tuple<int, int>(prices[i], costs[i]));
            }
            pricesCosts = pricesCosts.OrderBy(i => i.Item1).ThenBy(t => t.Item2).ToList();
            var pricesProfits = new List<Tuple<int, int>>();
            for (int i = 0; i <= prices.Count() - 1; i++)
            {
                int profitOfThisPrice = pricesCosts[i].Item1 - pricesCosts[i].Item2;
                int profitOfNextPrice = 0;
                for (int j = i + 1; j < prices.Count(); j++)
                {
                    if (pricesCosts[i].Item1 > pricesCosts[j].Item2)
                    {
                        profitOfNextPrice = pricesCosts[i].Item1 - pricesCosts[j].Item2;
                        profitOfThisPrice = profitOfThisPrice + profitOfNextPrice;
                    }
                }

                pricesProfits.Add(new Tuple<int, int>(pricesCosts[i].Item1, profitOfThisPrice));

            }


            List<int> sameProfitPrices = new List<int>();
            pricesProfits = pricesProfits.OrderBy(i => i.Item2).ToList();
            int sameProfitPrice = pricesProfits[prices.Count() - 1].Item2;
            for (int i = 0; i <= prices.Count() - 2; i++)
            {
                if (pricesProfits[i].Item2 == sameProfitPrice)
                {
                    sameProfitPrices.Add(pricesProfits[i].Item1);
                }
            }
            if (pricesProfits[prices.Count() - 1].Item2 < 0)
            {
                return 0;
            }
            else
            {
                if (sameProfitPrices == null)
                {
                    int bestPrice = pricesProfits[pricesProfits.Count() - 1].Item1;
                    return bestPrice;
                }
                else
                {
                    sameProfitPrices.Add(pricesProfits[prices.Count() - 1].Item1);
                    sameProfitPrices.Sort();
                    return sameProfitPrices[0];
                }

            }
        }
    }
}

