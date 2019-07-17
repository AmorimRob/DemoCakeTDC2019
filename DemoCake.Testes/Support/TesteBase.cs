using System;
using Autofac.Extras.FakeItEasy;
using NUnit.Framework;

namespace DemoCake.Testes.Support
{
    public class TesteBase
    {
        protected AutoFake _autoFake;

        [SetUp]
        public void SetUpBase()
        {
            _autoFake = new AutoFake();
        }

        [TearDown]
        public void TearDownBase()
        {
            _autoFake.Dispose();
        }
    }
}
