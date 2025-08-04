using CyberRiskTracker.Models;
using CyberRiskTracker.Repositories;

namespace CyberRiskTracker.Services
{
    public class RiskService
    {
        private readonly IRiskRepository _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RiskService(IRiskRepository repository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<RiskItem>> GetAllRisksAsync() => await _repository.GetAllAsync();

        public async Task<RiskItem?> GetRiskByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task SaveRiskAsync(RiskItem risk) => await _repository.SaveAsync(risk);

        public async Task DeleteRiskAsync(int id) => await _repository.DeleteAsync(id);

        public async Task UploadRiskImageAsync(RiskItem risk)
        {
            if (risk == null || risk.ImageContent == null) return;
            string url = _httpContextAccessor.HttpContext.Request.Host.Value;
            var imgPath = $@"{_webHostEnvironment.WebRootPath}\images\{risk.ImageName}";
            using var fs = File.Create(imgPath);
            await fs.WriteAsync(risk.ImageContent, 0, risk.ImageContent.Length);
            fs.Close();
            risk.ImageName = $@"https://{url}/images/{risk.ImageName}";
            await _repository.SaveAsync(risk);
        }
    }

}
