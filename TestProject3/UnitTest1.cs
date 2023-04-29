namespace TestProject3
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var a = 1 ; var b = 2;
            var result = a + b;
            Assert.Equal(result, 3);
        }
    }
}