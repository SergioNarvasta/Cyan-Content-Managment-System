using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;


namespace CyanCMS.Application.Services
{
    public class PartnerAppService : IPartnerAppService
    {
        public readonly IPartnerService _partnerService;
        public PartnerAppService(IPartnerService partnerService) {
            _partnerService = partnerService;
        }
        public async Task Delete(string id)
        {
            await _partnerService.Delete(id);
        }

        public async Task<IEnumerable<Partner>> GetAll()
        {
          return await _partnerService.GetAll();
        }

        public Task<Partner> GetById(string id)
        {
            return _partnerService.GetById(id);
        }

        public async Task Insert(Partner model)
        {
            await _partnerService.Insert(model);
        }

        public async Task Update(Partner model)
        {
            await _partnerService.Update(model);
        }
    }
}
