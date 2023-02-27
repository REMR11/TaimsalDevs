using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemTaimsalDevs.DAL;
using SystemTaimsalDevs.EL;

namespace SystemTaimsalDevs.BL
{

    public class ProviderBL
    {
        public async Task<int> CreateAsync(Provider pProvider)
        {
            return await ProvidersDAL.CreateAsync(pProvider);
        }

        public async Task<int> Modify(Provider pProvider)
        {
            return await ProvidersDAL.ModifyAsync(pProvider);
        }

        public async Task<Provider> GetByIdAsync(Provider pProvider)
        {
            return await ProvidersDAL.GetByIdAsync(pProvider);
        }

        public async Task<List<Provider>> GetAllAsync(Provider pProvider)
        {
            return await ProvidersDAL.GetAllAsync();
        }

        public async Task<List<Provider>> SearchAsync(Provider pProvider)
        {
            return await ProvidersDAL.SearchAsync(pProvider);
        }

        public async Task<int> DeleteAsync(Provider pProvider)
        {
            return await ProvidersDAL.DeleteAsync(pProvider);
        }
    }
}
