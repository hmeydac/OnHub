namespace Hubs.Persistance.Tests
{
    using System.Transactions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public abstract class TransactionalUnitTest
    {
        private TransactionScope transactionScope;
    
    
        [TestInitialize]
        public virtual void Initialize()
        {
            this.transactionScope = new TransactionScope();
            this.SetUp();
        }

        public abstract void SetUp();

        [TestCleanup]
        public virtual void Cleanup()
        {
            this.transactionScope.Dispose();
        }
    }
}
