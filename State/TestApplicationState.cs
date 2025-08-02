namespace CyberRiskTracker.State
{
    public class TestApplicationState
    {
        public string TestString { get; set; } = "Hello from TestApplicationState";
        public int TestInt { get; set; } = 42;
        public DateTime TestDateTime { get; set; } = DateTime.Now;
        public List<string> TestList { get; set; } = new List<string> { "Item1", "Item2", "Item3" };
    }
}
