using Sipaz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sipaz.Core.Interfaces
{
    public interface IPropertyRent
    {
        public PropertyRentModel GetMasterData();

        public Result SaveBasicDetails(PropertyRentModel model);
        public Result SavePropertyFeatures(PropertyRentModel model);
        public Result SavePriceDetails(PropertyRentModel model);

    }
}
