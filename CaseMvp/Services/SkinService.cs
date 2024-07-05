using AutoMapper;
using CaseMvp.Dtos;
using CaseMvp.Entity;
using CaseMvp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CaseMvp.Services
{
    public class SkinService:ISkinService
    {
        private readonly CaseMvpDbContext _dbContext;
        private readonly IMapper _mapper;
        public SkinService(CaseMvpDbContext dbContext, IMapper mapper)
        {
            _dbContext=dbContext;
            _mapper=mapper;
        }

        public async Task<IEnumerable<SkinDto>> GetAll()
        {
            var skins=await _dbContext.Skins.ToListAsync();

            return _mapper.Map<IEnumerable<SkinDto>>(skins);
        }

        public async Task<SkinDto> GetById(int id)
        {
            var skin=await _dbContext.Skins.FirstOrDefaultAsync(c=>c.Id==id);
            if(skin == null)
            {
                throw new Exception("Skin not found");
            }
            return _mapper.Map<SkinDto>(skin);
        }

        public async Task Create(CreateSkinDto createSkinDto)
        {
            var newSkin=_mapper.Map<Skin>(createSkinDto);
            await _dbContext.Skins.AddAsync(newSkin);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, UpdateSkinDto updateSkinDto)
        {
            var skinToUpdate=await _dbContext.Skins.FirstOrDefaultAsync(c=>c.Id==id);
            if(skinToUpdate==null)
            {
                throw new Exception("Skin not found");
            }
            _mapper.Map(updateSkinDto, skinToUpdate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var skinToDelete=await _dbContext.Skins.FirstOrDefaultAsync(c=>c.Id==id);
            if(skinToDelete==null)
            {
                throw new Exception("Skin not found");
            }
            _dbContext.Skins.Remove(skinToDelete);
            await _dbContext.SaveChangesAsync();
        }

    }
}
