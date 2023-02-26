using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemTaimsalDevs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemTaimsalDevs.EL;
using static SystemTaimsalDevs.EL.UserDev;

namespace SystemTaimsalDevs.DAL.Tests
{
    [TestClass()]
    public class UserDevDALTests
    {
        private static UserDev UserDevInicial = new UserDev { IdUser = 2, IdRol = 1, Login = "JuanUser", Password = "123456" };

        [TestMethod()]
        public async Task  T0EncryotMD5Test()
        {
            UserDev user = new UserDev();
            user.Password = "password";
            UserDevDAL.EncryotMD5(user);
            Assert.AreEqual("5f4dcc3b5aa765d61d8327deb882cf99", user.Password);
        }

        [TestMethod()]
        public async Task T1CreateAsyncTest()
        {
            var UserDev = new UserDev();
            UserDev.IdRol = UserDevInicial.IdRol;
            UserDev.NameUser = "juan";
            UserDev.LastNameUser = "lopez";
            UserDev.Login = "juanUser";
            string password = "123456";
            UserDev.Password = password;
            UserDev.StatusUser = (byte)Status_Users.INACTIVO;
            int result = await UserDevDAL.CreateAsync(UserDev);
            Assert.AreNotEqual(0, result);
            UserDevInicial.IdUser = UserDev.IdUser;
            UserDevInicial.Login = UserDev.Login;
            UserDevInicial.Password = UserDev.Password;
        }

        [TestMethod()]
        public async Task T2ModifyAsyncTest()
        {
            var UserDev = new UserDev();
            UserDev.IdUser = UserDevInicial.IdUser;
            UserDev.IdRol = UserDevInicial.IdRol;
            UserDev.NameUser = "Juana";
            UserDev.LastNameUser = "Lopeza";
            UserDev.Login = "JuanUser01";
            UserDev.StatusUser = (byte)Status_Users.ACTIVO;
            int result = await UserDevDAL.ModifyAsync(UserDev);
            Assert.AreNotEqual(0, result);
            UserDevInicial.Login = UserDev.Login;
        }

        [TestMethod()]
        public async Task T3GetByIdAsyncTest()
        {
            var userdev = new UserDev();
            userdev.IdUser= 1;
            var result = await UserDevDAL.GetByIdAsync(userdev);
            Assert.AreEqual(userdev.IdUser, result.IdUser);
        }

        [TestMethod()]
        public async Task T4GetAllAsyncTest()
        {
            var result = await UserDevDAL.GetAllAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        //[TestMethod()]
        //public async Task T5BuscarAsyncTest()
        //{
        //    var UserDev = new UserDev();
        //    UserDev.IdRol = UserDevInicial.IdRol;
        //    UserDev.NameUser = "Juan";
        //    UserDev.LastNameUser = "u";
        //    UserDev.Login = "juanUser";
        //    UserDev.StatusUser = (byte)Status_Users.ACTIVO;
        //    UserDev.Top_Aux = 10;
        //    var resultUserDevs = await UserDevDAL.BuscarAsync(UserDev);
        //    Assert.AreNotEqual(0, resultUserDevs.Count);
        //}

        //[TestMethod()]
        //public async Task T6SearchIncludeRolesAsyncTest()
        //{
        //    var userDev = new UserDev();
        //    userDev.IdRol = userDev.IdRol;
        //    userDev.NameUser = "U";
        //    userDev.LastNameUser = "u";
        //    userDev.Login = "A";
        //    userDev.StatusUser = (byte)Status_Users.ACTIVO;
        //    userDev.Top_Aux = 10;
        //    var result = await UserDevDAL.SearchIncludeRolesAsync(userDev);
        //    Assert.AreNotEqual(0, result.Count);
        //    var lasUser = result.FirstOrDefault();
        //    Assert.IsTrue(lasUser.IdRol != null && userDev.IdRol == lasUser.IdRolNavigation.IdRol);
        //}

        [TestMethod()]
        public async Task T7LoginAsyncTest()
        {
            var userDev = new UserDev();
            userDev.Login = "juanUser";
            userDev.Password = UserDevInicial.Password;
            var result = await UserDevDAL.LoginAsync(userDev);
            Assert.AreEqual(userDev.Login, result.Login);  
        }

        //[TestMethod()]
        //public async Task T8ChangePasswordAsyncTest()
        //{

        //    var usuario = new UserDev();
        //    usuario.IdUser = UserDevInicial.IdUser;
        //    string passwordNuevo = "Admin";
        //    usuario.Password = passwordNuevo;
        //    var result = await UserDevDAL.ChangePasswordAsync(usuario, UserDevInicial.Password);
        //    Assert.AreNotEqual(0, result);
        //    UserDevInicial.Password = passwordNuevo;
        //}

        [TestMethod()]
        public async Task  T9DeleteAsyncTest()
        {
            var userDev = new UserDev();
            userDev.IdUser = UserDevInicial.IdUser;
            var resutl = await UserDevDAL.DeleteAsync(userDev);
            Assert.AreNotEqual(0, resutl);
        }
    }
}