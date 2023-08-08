using AccountStorage.Clients.WebClients.Flux.Interfaces;
using AccountStorage.Clients.WebClients.Flux.Stores.AccountStore.Actions;
using AccountStorage.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountStorage.Test.ServiceTests
{
    public class ClassRelationshipTests
    {

        [Fact]
        public void Test()
        {
            var a = new Account();
            var b = new AddAccountAction(a);
            var c = new DbEntity();
            Assert.True(b is AddAccountAction);
            //Assert.True(b is IAction);
            //Assert.True(b is IAction);
            Assert.True(a is DbEntity);
            //Assert.True((Account)c is Account);
            //Assert.True(a is IAction<DbEntity>);
            //Assert.True(a is IAction<DbEntity>);
            //Assert.True(a is IAction<DbEntity>);
            //Assert.True(b is DbEntity);
        }
    }
}
