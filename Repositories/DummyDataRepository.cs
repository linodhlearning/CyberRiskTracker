using CyberRiskTracker.Data.Entities; 
namespace CyberRiskTracker.Repositories
{
    public interface ILoginAttemptRepository
    {
        Task<List<LoginAttemptEntity>> GetLoginAttemptsAsync(int count = 1000);
    }

    public class MockLoginAttemptRepository : ILoginAttemptRepository
    {
        private static readonly string[] usernames = { "admin", "user1", "alice", "bob", "eve", "serviceacct" };
        private static readonly string[] locations = { "USA", "India", "Australia", "UK", "Germany", "China" };
        private static readonly string[] methods = { "Web", "Mobile", "API", "SSO" };
        private readonly Random _rand = new();

        public Task<List<LoginAttemptEntity>> GetLoginAttemptsAsync(int count = 1000)
        {
            var list = Enumerable.Range(1, count).Select(i =>
            {
                return new LoginAttemptEntity
                {
                    Id = i,
                    Username = usernames[_rand.Next(usernames.Length)],
                    AttemptTime = DateTime.UtcNow.AddMinutes(-_rand.Next(0, 100000)),
                    IPAddress = $"{_rand.Next(1, 255)}.{_rand.Next(1, 255)}.{_rand.Next(1, 255)}.{_rand.Next(1, 255)}",
                    IsSuccessful = _rand.NextDouble() > 0.3,
                    Location = locations[_rand.Next(locations.Length)],
                    Method = methods[_rand.Next(methods.Length)]
                };
            }).ToList();

            return Task.FromResult(list);
        }
    }

}
