using System;
using System.Collections.Generic;
using System.Text;
using TesteGFT.Interface;

namespace TesteGFT.Model
{
    public class Trade : ITrade
    {
        public double valueClass { get; set; }
        public string clientSectorClass { get; set; }

        public Trade(double _value, string _clientSector)
        {
            valueClass = _value;
            clientSectorClass = _clientSector;
        }

        //Interface Props
        public double Value => valueClass;

        public string ClientSector => clientSectorClass;

    }
}
