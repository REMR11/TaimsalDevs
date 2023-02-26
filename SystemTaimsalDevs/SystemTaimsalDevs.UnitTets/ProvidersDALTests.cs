using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemTaimsalDevs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemTaimsalDevs.EL;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace SystemTaimsalDevs.DAL.Tests
{
    [TestClass()]
    public class ProvidersDALTests
    {
        public static Provider providerInitial = new Provider { IdProvider = 1, NameProvider = "Proveedor Bonito" };
        [TestMethod()]
        public async Task T1CreateAsyncTest()
        {
            var pProvider = new Provider();
            pProvider.NameProvider = providerInitial.NameProvider;
            var result = await ProvidersDAL.CreateAsync(pProvider);
            Assert.AreNotEqual(0, result);
            providerInitial.IdProvider = pProvider.IdProvider; 
        }


        [TestMethod()]
        public async Task T2ModifyAsyncTest()
        {
            var provider = new Provider();
            provider.IdProvider = providerInitial.IdProvider;
            provider.NameProvider = "A";
            int result = await ProvidersDAL.ModifyAsync(provider);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3GetByIdAsyncTest()
        {
            var provider = new Provider();
            provider.IdProvider = providerInitial.IdProvider;
            var result = await ProvidersDAL.GetByIdAsync(provider);
            Assert.AreEqual(provider.IdProvider, result.IdProvider);
        }

        [TestMethod()]
        public async Task T4GetAllAsyncTest()
        {
            var result = await ProvidersDAL.GetAllAsync();
            Assert.AreNotEqual(0, result.Count);
        }

       
        [TestMethod()]
        public async Task T5SearchAsyncTest()
        {
            var pProvider = new Provider();
            pProvider.NameProvider = "A";
            var result = await  ProvidersDAL.SearchAsync(pProvider);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T6DeleteAsyncTest()
        {
            var pProvider = new Provider();
            pProvider.IdProvider = providerInitial.IdProvider;
            var result = await ProvidersDAL.DeleteAsync(pProvider);
            Assert.AreNotEqual(0, result);
        }
    }
}