﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class MachineDALTests
    {
        private static Machine MachineInitial = new Machine { IdMachine = 18, NameMachine = "MachineMachine", ImageMachine = "../wwwroot/img/Product/" };
        [TestMethod()]
        public async Task T1CreateAsyncTest()
        {
            var machine = new Machine();
            machine.NameMachine = "Machine123";
            machine.ImageMachine = "C/Taimsal/FrontEnd/WWWROOT/IMG/IMAGEN-BONITA.PNG";
            int result = await MachineDAL.CreateAsync(machine);
            Assert.AreNotEqual(0, result);
            MachineInitial.IdMachine = machine.IdMachine;
        }

        [TestMethod()]
        public async Task T2ModifyAsyncTest()
        {
            var machine = new Machine();
            machine.IdMachine = MachineInitial.IdMachine;
            machine.NameMachine = MachineInitial.NameMachine;
            int result = await MachineDAL.ModifyAsync(machine);
            Assert.AreNotEqual(result, 0);
        }

        [TestMethod()]
        public async Task T3GetByIdAsyncTest()
        {
            var machine = new Machine();
            machine.IdMachine = MachineInitial.IdMachine;
            var result = await MachineDAL.GetByIdAsync(machine);
            Assert.AreEqual(machine.IdMachine, result.IdMachine);
        }

        [TestMethod()]
        public async Task T4GetAllAsyncTest()
        {
            var result = await MachineDAL.GetAllAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T5SearchAsyncTest()
        {
            var machine = new Machine();
            machine.IdMachine = MachineInitial.IdMachine;
            var result = await MachineDAL.SearchAsync(machine);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T6DeleteAsyncTest()
        {
            var machine = new Machine();
            machine.IdMachine = MachineInitial.IdMachine;
            int result = await MachineDAL.DeleteAsync(machine);
            Assert.AreNotEqual(0, result);
        }
    }
}