using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteGFT.Model;

namespace TesteGFT.Repository
{
    public class TradeRepository
    {
        //Aqui teria toda a conexao com alguma base de dados.

        public List<ConfigCategories> AddNewConfigCategories(List<ConfigCategories> ListCategories, ConfigCategories config)
        {
            //Seria ser criado no banco de dados, com Id incremental
            ConfigCategories cfg = new ConfigCategories
            {
                idCategory = ListCategories.LastOrDefault().idCategory + 1,
                name = config.name,
                Operation = config.Operation,
                Section = config.Section,
                value = config.value
            };

            ListCategories.Add(cfg);
            return ListCategories;
        }

        public List<ConfigCategories> RemoveConfigCategories(List<ConfigCategories> ListCategories, int idCategory)
        {
            var category = ListCategories.Where(x => x.idCategory == idCategory).FirstOrDefault();
            ListCategories.Remove(category);

            return ListCategories;
        }

        public List<ConfigCategories> UpdateConfigCategories(List<ConfigCategories> ListCategories, ConfigCategories Category)
        {
            var category = ListCategories.Where(x => x.idCategory == Category.idCategory).FirstOrDefault();
            category.name = Category.name;
            category.Operation = Category.Operation;
            category.Section = Category.Section;
            category.value = Category.value;
            
            return ListCategories;
        }

        public List<string> getListTradeCategories(List<ConfigCategories> ListCategories, List<Trade> trades)
        {
            List<string> tradeCategories = new List<string>();
            ConfigCategories config = new ConfigCategories();

            foreach (var trade in trades)
            {
                var category = string.Empty;

                //Verificando qual classe e regra de valor se encaixa
                var queryFull = ListCategories.Where(x =>
                        (x.Section.ToUpper() == trade.clientSectorClass.ToUpper() && trade.valueClass >= x.value && x.Operation == ">=")
                        ||
                        (x.Section.ToUpper() == trade.clientSectorClass.ToUpper() && trade.valueClass <= x.value && x.Operation == "<=")
                        ||
                        (x.Section.ToUpper() == trade.clientSectorClass.ToUpper() && trade.valueClass == x.value && x.Operation == "=")
                        ||
                        (x.Section.ToUpper() == trade.clientSectorClass.ToUpper() && trade.valueClass > x.value && x.Operation == ">")
                        ||
                        (x.Section.ToUpper() == trade.clientSectorClass.ToUpper() && trade.valueClass < x.value && x.Operation == "<"))
                    .ToList();

                if (queryFull.Any())
                    tradeCategories.Add(queryFull.FirstOrDefault().name);
                else
                    tradeCategories.Add("UNDEFINED");
            }

            return tradeCategories;
        }

        //Configs Iniciais
        public List<ConfigCategories> GetAllConfigCategories()
        {
            List<ConfigCategories> lstConfigCategories = new List<ConfigCategories>();
            ConfigCategories config1 = new ConfigCategories
            {
                idCategory = 1,
                name = "LOWRISK",
                Operation = "<",
                Section = "Public",
                value = 1000000
            };
            lstConfigCategories.Add(config1);

            ConfigCategories config2 = new ConfigCategories
            {
                idCategory = 2,
                name = "MEDIUMRISK",
                Operation = ">",
                Section = "Public",
                value = 1000000
            };
            lstConfigCategories.Add(config2);

            ConfigCategories config3 = new ConfigCategories
            {
                idCategory = 3,
                name = "HIGHRISK",
                Operation = ">",
                Section = "Private",
                value = 1000000
            };
            lstConfigCategories.Add(config3);

            return lstConfigCategories;
        }
    }
}
