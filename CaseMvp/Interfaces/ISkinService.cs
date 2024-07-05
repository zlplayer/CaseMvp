using CaseMvp.Dtos;

namespace CaseMvp.Interfaces
{
    public interface ISkinService
    {
        Task<IEnumerable<SkinDto>> GetAll();
        Task<SkinDto> GetById(int id);
        Task Create(CreateSkinDto createSkinDto);
        Task Update(int id, UpdateSkinDto updateSkinDto);
        Task Delete(int id);
    }
}
