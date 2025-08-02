using CyberRiskTracker.Models; 

namespace CyberRiskTracker.Components.Pages
{
    public partial class RiskList
    {
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
    }
}
