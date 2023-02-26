using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemTaimsalDevs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemTaimsalDevs.EL;

namespace SystemTaimsalDevs.DAL.Tests
{
    [TestClass()]
    public class RolDALTests
    {
        private static Rol rolInitial = new Rol { IdRol = 1, NameRol = "Admin" };
        [TestMethod()]
        public async Task CrearteAsyncTest()
        {
            var pRol = new Rol();
            pRol.NameRol = rolInitial.NameRol;
            var result = await RolDAL.CrearteAsync(pRol);
            Assert.AreNotEqual(0, result);
            rolInitial.IdRol = pRol.IdRol;
        }

        [TestMethod()]
        public void ModifyAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByIdAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SearchAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async void DeleteAsyncTest()
        {
            var pRol = new Rol();
            pRol.NameRol = rolInitial.NameRol;
            var result = await RolDAL.DeleteAsync(pRol);
            Assert.AreNotEqual (0, pRol.IdRol);
        }
    }
}