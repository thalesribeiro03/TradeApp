using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TesteGFT.Application;
using TesteGFT.Model;

namespace TesteGFT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Olá!");

            //Lista inicial
            var Trade1 = new Trade(2000000, "Private");
            var Trade2 = new Trade(400000, "Public");
            var Trade3 = new Trade(500000, "Public");
            var Trade4 = new Trade(3000000, "Public");

            List<Trade> portfolio = new List<Trade>();
            portfolio.Add(Trade1);
            portfolio.Add(Trade2);
            portfolio.Add(Trade3);
            portfolio.Add(Trade4);

            TradeApplication _tradeApp = new TradeApplication();

            //Seria uma consulta para trazer as categorias no BD
            var listCategories = _tradeApp.GetAllConfigCategories();
            
            //Output Inicial
            Console.WriteLine("Output" + JsonConvert.SerializeObject(_tradeApp.getListTradeCategories(listCategories, portfolio)));

            _tradeApp.AddNewConfigCategoryQuestion(listCategories);
            _tradeApp.AddNewTradeQuestion(listCategories, portfolio);

            Console.WriteLine("Valeu!");
            Console.ReadKey();
        }

    }
}