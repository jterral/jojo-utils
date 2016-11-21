using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jojo.Common.Helpers.Switch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jojo.Common.UnitTest.Helpers
{
    [TestClass]
    public class UnitTestSwitch
    {
        [TestMethod]
        public void SwitchOnType_NoException()
        {
            string myString = "MyString";
            var myStringObj = (object)myString;

            TypeSwitch.On(myStringObj)
                .Case<UnitTestSwitch>(x =>
                {
                    Assert.Fail();
                })
                .Case<string>(x =>
                {
                    Assert.IsNotNull(x);
                    Assert.AreEqual(myString, x);
                })
                .Default(x =>
                {
                    Assert.Fail();
                });
        }
    }
}
