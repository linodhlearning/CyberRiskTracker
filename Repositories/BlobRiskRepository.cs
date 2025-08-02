using Azure.Storage.Blobs;
using CyberRiskTracker.Models;
using System;
using System.Text.Json;

namespace CyberRiskTracker.Repositories
{
    public class BlobRiskRepository : IRiskRepository
    {
        private readonly BlobContainerClient _container;
        private const string ListBlob = "risks-list.json";

        public BlobRiskRepository(BlobServiceClient client)
        {
            _container = client.GetBlobContainerClient("cyberrisks");
            _container.CreateIfNotExists();
        }

        public async Task<List<RiskItem>> GetAllAsync()
        {
            var blob = _container.GetBlobClient(ListBlob);
            if (await blob.ExistsAsync())
            {
                var response = await blob.DownloadContentAsync();
                return JsonSerializer.Deserialize<List<RiskItem>>(response.Value.Content.ToString())!;
            }
            return new List<RiskItem>();
        }

        public async Task<RiskItem?> GetByIdAsync(int id)
        {
            var risks = await GetAllAsync();
            return risks.FirstOrDefault(r => r.Id == id);
        }

        public async Task SaveAsync(RiskItem risk)
        {
            var risks = await GetAllAsync();
            var existing = risks.FirstOrDefault(r => r.Id == risk.Id);
            if (existing != null) risks.Remove(existing);
            risks.Add(risk);

            var blob = _container.GetBlobClient(ListBlob);
            await blob.UploadAsync(BinaryData.FromString(JsonSerializer.Serialize(risks)), overwrite: true);
        }

        public async Task DeleteAsync(int id)
        {
            var risks = await GetAllAsync();
            var toRemove = risks.FirstOrDefault(r => r.Id == id);
            if (toRemove != null)
            {
                risks.Remove(toRemove);
                var blob = _container.GetBlobClient(ListBlob);
                await blob.UploadAsync(BinaryData.FromString(JsonSerializer.Serialize(risks)), overwrite: true);
            }
        }
    }
}
