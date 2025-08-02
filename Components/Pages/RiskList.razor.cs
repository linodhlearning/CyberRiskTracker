using CyberRiskTracker.Models;

namespace CyberRiskTracker.Components.Pages
{
    public partial class RiskList
    {
        private RiskItem? _highlightedRisk; // Track which risk should be highlighted

        private RiskItem? _selectedRisk;
        private List<RiskItem> risks = [];
        protected override async Task OnInitializedAsync()
        {
            var allRisks = await RiskSvc.GetAllRisksAsync();
            risks = allRisks.Take(6).ToList();
        }

        void GoToDetail(int id) => NavigationManager.NavigateTo($"/risk/{id}");

        private void OpenRiskDialog(RiskItem risk)
        {
            _selectedRisk = risk;
        }
        private void ClearRiskModel()
        {
            _selectedRisk = null;
        }
        private void SpecialRiskEventClicked(RiskItem risk)
        {
            _highlightedRisk = risk; // Set the risk to be highlighted
            //StateHasChanged(); // Trigger UI refresh
        }
        private string GetActiveClass(RiskItem risk)
        {
            return _highlightedRisk?.Id == risk.Id ? "risk-highlighted" : "";
        }
    }
}
