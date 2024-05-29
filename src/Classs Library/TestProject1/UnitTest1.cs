namespace TestProject1;
using SF2022User17Lib;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        int x = 10;
        int y = 20;
        int rezPlan = 20;
        int rezFact = Calculations.Summ(x, y);
        Assert.AreEqual(rezPlan,rezFact);
    }

    [Test]
    public void Test2()
    {
        int x = 10;
        int y = 20;
        int rezPlan = 30;
        int rezFact = Calculations.Summ(x, y);
        Assert.AreEqual(rezPlan,rezFact);
    }
}