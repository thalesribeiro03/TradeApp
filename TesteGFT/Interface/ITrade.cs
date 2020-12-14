using System;
using System.Collections.Generic;
using System.Text;

namespace TesteGFT.Interface
{
    interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
    }
}
