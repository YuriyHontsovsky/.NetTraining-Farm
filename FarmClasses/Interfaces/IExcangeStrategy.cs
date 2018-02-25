using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmClasses.Interfaces
{
    public interface IExcangeStrategy
    {
        IExcangeAction Excange(IHousehold MyHousehold, IExchangeRules ExchangeRules);
    }
}
