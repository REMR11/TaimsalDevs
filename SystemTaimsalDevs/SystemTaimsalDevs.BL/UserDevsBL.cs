﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemTaimsalDevs.DAL;
using SystemTaimsalDevs.EL;


namespace SystemTaimsalDevs.BL
{
    internal class UserDevsBL
    {

        public async Task<int> CreateAsync(UserDev pUser)
        {
            return await UserDevDAL.CreateAsync(pUser);
        }

        public async Task<int> ModifyAsync(UserDev pUser)
        {
            return await UserDevDAL.ModifyAsync(pUser);
        }

        public async Task<UserDev> GetByIdAsync(UserDev pUser)
        {
            return await UserDevDAL.GetByIdAsync(pUser);
        }

        public async Task<List<UserDev>> GetAllAsync()
        {
            return await UserDevDAL.GetAllAsync();
        }

        public async Task<List<UserDev>> SarchAsync(UserDev pUser)
        {
            return await UserDevDAL.SearchIncludeRolesAsync(pUser);
        }

        public async Task<int> DeleteAsync(UserDev pUser)
        {
            return await UserDevDAL.DeleteAsync(pUser);
        }


        public async Task<UserDev> LoginAsync(UserDev pUser)
        {
            return await UserDevDAL.LoginAsync(pUser);
        }

        public async Task<int> ChangePasswordAsync(UserDev pUser, string pPasswordAnt)
        {
            return await UserDevDAL.ChangePasswordAsync(pUser, pPasswordAnt);
        }
        public async Task<List<UserDev>> BuscarIncluirRolesAsync(UserDev pUser)
        {
            return await UserDevDAL.SearchIncludeRolesAsync(pUser);
        }
    }
}