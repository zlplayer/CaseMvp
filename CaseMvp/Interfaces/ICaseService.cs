using CaseMvp.Dtos;

namespace CaseMvp.Interfaces
{
    public interface ICaseService
    {
        Task<IEnumerable<CaseDto>> GetAll();
        Task Create(CreateCaseDto createCaseDto);
        Task Update(int id, UpdateCaseDto updateCaseDto);
        Task Delete(int id);
        Task<CaseDto> GetById(int id);
        Task<IEnumerable<SkinDto>> GetSkinsByCaseIdAsync(int caseId);
        Task AddSkinsToCaseAsync(int caseId, int skinIds);
        Task<SkinDto> DrawSkinAsync(int caseId);
        Task<SkinDto> GetSkinByIdAsync(int skinId);
    }
}
