using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindBestPrice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPrice(string price, string cost, string PriceList, string CostList)
        {
            if (price == "" && cost == "")
            {
                List<int> pricess = System.Web.Helpers.Json.Decode<List<int>>(PriceList);
                List<int> costss = System.Web.Helpers.Json.Decode<List<int>>(CostList);
                int[] prices = pricess.ToArray();
                int[] costs = costss.ToArray();
                BestPrice bp = new BestPrice();
                int bestPrice = bp.FindBestPrice(prices, costs);
                string stringPricesx = string.Join(", ", prices);
                string stringPrices = "{" + stringPricesx + "}";
                string stringCostsx = string.Join(", ", costs);
                string stringCosts = "{" + stringCostsx + "}";
                ViewBag.stringPricesx = stringPrices;
                ViewBag.stringCostsx = stringCosts;
                ViewBag.BestPrice = bestPrice;
                return View("BestPrice");
            }
            else
            {
                List<int> pricesCount = System.Web.Helpers.Json.Decode<List<int>>(PriceList);
                int priceCounter;
                if (pricesCount == null)
                {
                    priceCounter = 0;
                }
                else
                {
                    priceCounter = pricesCount.Count();
                }

                if (Int32.Parse(price) < 1 || Int32.Parse(cost) < 0 || priceCounter > 49)
                {
                    if (priceCounter != 0)
                    {
                        List<int> pricess = System.Web.Helpers.Json.Decode<List<int>>(PriceList);
                        List<int> costss = System.Web.Helpers.Json.Decode<List<int>>(CostList);
                        int[] prices = pricess.ToArray();
                        int[] costs = costss.ToArray();
                        ViewBag.PriceList = pricess;
                        ViewBag.CostList = costss;
                        string stringPricesx = string.Join(", ", prices);
                        string stringPrices = "{" + stringPricesx + "}";
                        string stringCostsx = string.Join(", ", costs);
                        string stringCosts = "{" + stringCostsx + "}";
                        ViewBag.stringPrices = stringPrices;
                        ViewBag.stringCosts = stringCosts;
                        ViewBag.errorMessage = "Error: Price should be more than 1, cost should not be < 0 OR there is no space for more comparison (max 50)!";
                        return View("Index");
                    }
                    else
                    {
                        ViewBag.errorMessage = "Error: Price should be more than 1, cost should not be < 0 OR there is no space for more Prices!";
                        return View("Index");
                    }
                }
                else
                {
                    int priceX = Int32.Parse(price);
                    int costX = Int32.Parse(cost);
                    List<int> prices = System.Web.Helpers.Json.Decode<List<int>>(PriceList);
                    List<int> costs = System.Web.Helpers.Json.Decode<List<int>>(CostList);
                    if (prices != null && costs != null)
                    {
                        prices.Add(priceX);
                        costs.Add(costX);
                        ViewBag.PriceList = prices;
                        ViewBag.CostList = costs;
                        string stringPricesx = string.Join(", ", prices);
                        string stringPrices = "{" + stringPricesx + "}";
                        string stringCostsx = string.Join(", ", costs);
                        string stringCosts = "{" + stringCostsx + "}";
                        ViewBag.stringPrices = stringPrices;
                        ViewBag.stringCosts = stringCosts;
                    }
                    else
                    {
                        List<int> pricess = new List<int>();
                        List<int> costss = new List<int>();
                        pricess.Add(priceX);
                        costss.Add(costX);
                        ViewBag.PriceList = pricess;
                        ViewBag.CostList = costss;
                        string stringPricesx = string.Join(", ", pricess);
                        string stringPrices = "{" + stringPricesx + "}";
                        string stringCostsx = string.Join(", ", costss);
                        string stringCosts = "{" + stringCostsx + "}";
                        ViewBag.stringPrices = stringPrices;
                        ViewBag.stringCosts = stringCosts;
                    }
                    return View("Index");
                }
            }
        }
    }
}