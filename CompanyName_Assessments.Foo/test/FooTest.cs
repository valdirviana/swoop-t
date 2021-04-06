using NUnit.Framework;
 
namespace CompanyName_Assessments.Foo.Tests
{
    [TestFixture]
    public class FooTest
    {
        [TestCase]
        public void TestBar1()
        {
            Assert.AreEqual(Foo.Bar(), );
        }

	 [TestCase]
        public void TestBar2()
        {
            Assert.AreEqual(Foo.Bar(), );
        }

        
        [TestCase]
        public void TestBaz1()
        {
            Assert.AreEqual(Foo.Baz(), );
        }

        [TestCase]
        public void TestBaz2()
        {
            Assert.AreEqual(Foo.Baz(), );
        }
    }
}
