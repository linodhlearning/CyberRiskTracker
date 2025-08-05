
using AutoMapper; 
using CyberRiskTracker.Models;
using CyberRiskTracker.Repositories;
using CyberRiskTracker.Data.Entities;
namespace CyberRiskTracker.Services
{
    public class RiskService
    {
        private readonly IRiskRepository _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public RiskService(IRiskRepository repository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<List<RiskItem>> GetAllRisksAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<RiskItem>>(entities);
        }

        public async Task<RiskItem?> GetRiskByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<RiskItem?>(entity);
        }

        public async Task SaveRiskAsync(RiskItem risk)
        {
            var entity = _mapper.Map<RiskItemEntity>(risk);
            await _repository.SaveAsync(entity);
        }

        public async Task DeleteRiskAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task UploadRiskImageAsync(RiskItem risk)
        {
            if (risk == null || risk.ImageContent == null) return;
            string url = _httpContextAccessor.HttpContext.Request.Host.Value;
            var imgPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", risk.ImageName);
            using var fs = File.Create(imgPath);
            await fs.WriteAsync(risk.ImageContent, 0, risk.ImageContent.Length);
            fs.Close();
            risk.ImageName = $@"https://{url}/images/{risk.ImageName}";
            await SaveRiskAsync(risk);
        }
    }
}
