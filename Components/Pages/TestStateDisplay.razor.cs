using CyberRiskTracker.State;
using Microsoft.AspNetCore.Components;

namespace CyberRiskTracker.Components.Pages
{
    public partial class TestStateDisplay
    {
        [Inject]
        public required TestApplicationState AppState { get; set; }
        private void UpdateTestString()
        {
            AppState.TestInt += 10;
            AppState.TestString = "Updated at " + DateTime.Now.ToLongTimeString();
        }

        protected override void OnInitialized()
        {
            AppState.TestInt += 1;
        }
    }
}
