using CyberRiskTracker.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace CyberRiskTracker.Components.Pages.Risk
{
    public partial class RiskDetail
    {
        [Parameter] public int Id { get; set; }

        private RiskItem? risk;
        private bool imageUploaded;
        private IBrowserFile selectedFile;

        public string ErrorMessage { get; set; }= string.Empty;
        protected override async Task OnInitializedAsync()
        {
            risk = await RiskSvc.GetRiskByIdAsync(Id);
        }

      private  async Task Save()
        {
            try { 
            if (risk != null)
            { 
                await RiskSvc.SaveRiskAsync(risk);
                NavigationManager.NavigateTo("/risks");
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"An error occurred while saving: {ex.Message}";
        }
}

        private void Cancel(MouseEventArgs e)
        {
            NavigationManager.NavigateTo("/risks");
        }
        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
            StateHasChanged();
        }

        private async Task UploadImageAsync()
        {
            if (risk == null) return;
            if (selectedFile != null)
            {
                var file = selectedFile;
                Stream stream = file.OpenReadStream();
                MemoryStream ms = new();
                await stream.CopyToAsync(ms);
                stream.Close();
                risk.ImageName = file.Name;
                risk.ImageContent = ms.ToArray();
                await RiskSvc.UploadRiskImageAsync(risk);
                imageUploaded = true;
            }
        }
    }
}
