using Sipaz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sipaz.Core.Interfaces
{
    public interface IGeoRepository
    {
        public IEnumerable<Districts> GetDistricts();

        public void SaveLocation(Locations model);
    }
}
