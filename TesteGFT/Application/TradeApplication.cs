using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteGFT.Model;
using TesteGFT.Repository;

namespace TesteGFT.Application
{
    public class TradeApplication
    {
        TradeRepository tradeRepository = new TradeRepository();

        public List<string> getListTradeCategories(List<ConfigCategories> ListCategories, List<Trade> trades)
        {
            return tradeRepository.getListTradeCategories(ListCategories, trades);
        }

        public void AddNewTrade(List<ConfigCategories> ListCategories, List<Trade> lstPortifolio)
        {
            Console.WriteLine("Valor:");
            var val = Console.ReadLine();
            Console.WriteLine("Setor (Public/Private...): ");
            var setor = Console.ReadLine();

            var Trade = new Trade(Convert.ToDouble(val), setor);
            lstPortifolio.Add(Trade);

            Console.WriteLine("Output" + JsonConvert.SerializeObject(getListTradeCategories(ListCategories, lstPortifolio)));
        }

        public void AddNewConfigCategoryQuestion(List<ConfigCategories> listCategories)
        {
            Console.WriteLine("Deseja incluir/Alterar/Excluir alguma categoria? S/N");
            var resp = Console.ReadLine();
            if (resp.ToUpper() == "S")
            {
                Console.WriteLine("incluir[1]/Alterar[2]/Excluir[3]?");
                var opt = Console.ReadLine();

                if (opt == "1")
                {
                    ConfigCategories cfg = new ConfigCategories();

                    Console.WriteLine("Nome:");
                    cfg.name = Console.ReadLine();

                    Console.WriteLine("Operation: (>,<,>=,<=)");
                    cfg.Operation = Console.ReadLine();

                    Console.WriteLine("Section:");
                    cfg.Section = Console.ReadLine();

                    Console.WriteLine("value:");
                    cfg.value = Convert.ToDouble(Console.ReadLine());

                    tradeRepository.AddNewConfigCategories(listCategories, cfg);
                    Console.WriteLine("Categorias" + JsonConvert.SerializeObject(listCategories, Formatting.Indented));

                }
                else if (opt == "2")
                {
                    Console.WriteLine(JsonConvert.SerializeObject(listCategories, Formatting.Indented));
                    Console.WriteLine("Digite o Id da Categoria?");
                    var IdCategory = Console.ReadLine();

                    ConfigCategories cfg = new ConfigCategories();
                    cfg.idCategory = Convert.ToInt32(IdCategory);

                    Console.WriteLine("Nome:");
                    cfg.name = Console.ReadLine();

                    Console.WriteLine("Operation: (>,<,>=,<=,=)");
                    cfg.Operation = Console.ReadLine();

                    Console.WriteLine("Section:");
                    cfg.Section = Console.ReadLine();

                    Console.WriteLine("value:");
                    cfg.value = Convert.ToDouble(Console.ReadLine());
                    tradeRepository.UpdateConfigCategories(listCategories, cfg);
                    Console.WriteLine("Categorias" + JsonConvert.SerializeObject(listCategories, Formatting.Indented));

                }
                else if (opt == "3")
                {
                    Console.WriteLine(JsonConvert.SerializeObject(listCategories, Formatting.Indented));
                    Console.WriteLine("Digite o Id da Categoria?");
                    var IdCategory = Console.ReadLine();

                    tradeRepository.RemoveConfigCategories(listCategories, Convert.ToInt32(IdCategory));
                    Console.WriteLine("Categorias" + JsonConvert.SerializeObject(listCategories, Formatting.Indented));

                }
                else
                {
                    Console.WriteLine("Resposta Inválida");
                }

                AddNewConfigCategoryQuestion(listCategories);
            }
        }

        public void AddNewTradeQuestion(List<ConfigCategories> ListCategories, List<Trade> lstPortifolio)
        {
            Console.WriteLine("Deseja incluir mais algum trade? S/N");
            var resp = Console.ReadLine();

            if (resp.ToUpper() != "S" && resp.ToUpper() != "N")
                Console.WriteLine("Resposta Inválida");

            if (resp.ToUpper() == "S")
            {
                AddNewTrade(ListCategories, lstPortifolio);
                AddNewTradeQuestion(ListCategories, lstPortifolio);
            }
        }

        public List<ConfigCategories> GetAllConfigCategories()
        {
            return tradeRepository.GetAllConfigCategories();
        }
    }
}
