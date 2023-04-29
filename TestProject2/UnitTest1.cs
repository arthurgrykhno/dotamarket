namespace TestProject2
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var a = 2; var b = 3;
            var result = a + b;
            Assert.Equal(result,5);
        }
    }
}