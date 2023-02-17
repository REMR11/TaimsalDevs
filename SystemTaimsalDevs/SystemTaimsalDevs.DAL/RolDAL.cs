using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemTaimsalDevs.EL;
using Microsoft.EntityFrameworkCore;
namespace SystemTaimsalDevs.DAL
{
    internal class RolDAL
    {

        public static async Task<int> CrearteAsync(Rol pRol)
        {
            int result = 0;
            using (var BDContext = new SystemTaimsalDevsContext())
            {
                BDContext.Add(pRol);
                result = await BDContext.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModifyAsync(Rol pRol)
        {
            int result = 0;
            using (var BDContext = new SystemTaimsalDevsContext())
            {
                var rol = await BDContext.Rols.FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
                rol.NameRol = pRol.NameRol;
                BDContext.Update(rol);
                result = await BDContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Rol> GetByIdAsync(Rol pRol)
        {
            var rol = new Rol();
            using (var BDContext = new SystemTaimsalDevsContext())
            {
                rol = await BDContext.Rols.FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
            }
            return rol;
        }

        public static async Task<List<Rol>> GetAllAsync()
        {
            var roles = new List<Rol>();
            using (var BDContext = new SystemTaimsalDevsContext())
            {
                roles = await BDContext.Rols.ToListAsync();
            }
            return roles;
        }
        internal static IQueryable<Rol> QuerySelect(IQueryable<Rol> pQuery, Rol pRol)
        {
            if (pRol.IdRol > 0)
                pQuery = pQuery.Where(s => s.IdRol == pRol.IdRol);
            if (!string.IsNullOrWhiteSpace(pRol.NameRol))
                pQuery = pQuery.Where(s => s.NameRol.Contains(pRol.NameRol));
            pQuery = pQuery.OrderByDescending(s => s.IdRol).AsQueryable();
            if (pRol.Top_Aux > 0)
                pQuery = pQuery.Take(pRol.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Rol>> SearchAsync(Rol pRol)
        {
            var roles = new List<Rol>();
            using (var BDContext = new SystemTaimsalDevsContext())
            {
                var select = BDContext.Rols.AsQueryable();
                select = QuerySelect(select, pRol);
                roles = await select.ToListAsync();
            }
            return roles;
        }
        public static async Task<int> DeleteAsync(Rol pRol)
        {
            int result = 0;
            using (var BDContext = new SystemTaimsalDevsContext())
            {
                var rol = await BDContext.Rols.FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
                BDContext.Rols.Remove(rol);
                result = await BDContext.SaveChangesAsync();
            }
            return result;
        }

    }
}
