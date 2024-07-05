using AutoMapper;
using CaseMvp.Dtos;
using CaseMvp.Entity;
using CaseMvp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CaseMvp.Services
{
    public class CaseService: ICaseService
    {
        private readonly CaseMvpDbContext _dbContext;
        private readonly IMapper _mapper;
        public CaseService(CaseMvpDbContext dbContext, IMapper mapper)
        {
            _dbContext=dbContext;
            _mapper=mapper;
        }

        public async Task<IEnumerable<CaseDto>> GetAll()
        {
            var cases=await _dbContext.Cases.ToListAsync();

            return _mapper.Map<IEnumerable<CaseDto>>(cases);
        }
        
        public async Task<CaseDto> GetById(int id)
        {
            var box=await _dbContext.Cases.FirstOrDefaultAsync(c=>c.Id==id);
            if(box == null)
            {
                throw new Exception("Case not found");
            }
            return _mapper.Map<CaseDto>(box);
        }

        public async Task<IEnumerable<SkinDto>> GetSkinsByCaseIdAsync(int caseId)
        {
            var caseAndSkins = await _dbContext.CaseAndSkins.Where(c => c.CaseId == caseId).Include(c=>c.Skin).Select(c => c.Skin).ToListAsync();
            return _mapper.Map<IEnumerable<SkinDto>>(caseAndSkins);
        }

        public async Task Create(CreateCaseDto createCaseDto)
        {
            var newCase=_mapper.Map<Case>(createCaseDto);
            await _dbContext.Cases.AddAsync(newCase);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, UpdateCaseDto updateCaseDto)
        {
            var caseToUpdate=await _dbContext.Cases.FirstOrDefaultAsync(c=>c.Id==id);
            if(caseToUpdate==null)
            {
                throw new Exception("Case not found");
            }
            _mapper.Map(updateCaseDto, caseToUpdate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var caseToDelete=await _dbContext.Cases.FirstOrDefaultAsync(c=>c.Id==id);
            if(caseToDelete==null)
            {
                throw new Exception("Case not found");
            }
            _dbContext.Cases.Remove(caseToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddSkinsToCaseAsync(int caseId, int skinId)
        {
           var skin = await _dbContext.Skins.FirstOrDefaultAsync(c => c.Id == skinId);

            if (skin == null)
            {
                throw new Exception("Skin not found");
            }

            var caseAndSkin = new CaseAndSkin
            {
                CaseId = caseId,
                SkinId = skinId
            };

            await _dbContext.CaseAndSkins.AddAsync(caseAndSkin);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<SkinDto> DrawSkinAsync(int caseId)
        {
            var caseAndSkins = await _dbContext.CaseAndSkins.Where(c => c.CaseId == caseId).Include(c => c.Skin).ToListAsync();
            if (caseAndSkins.Count == 0)
            {
                // Rzuć wyjątek lub zwróć null/odpowiednią wartość w przypadku braku skinów
                throw new InvalidOperationException("No skins available in the case.");
            }
            var random = new Random();
            var randomSkin = caseAndSkins[random.Next(0, caseAndSkins.Count)];
            
            return _mapper.Map<SkinDto>(randomSkin.Skin);
        }

        public async Task<SkinDto> GetSkinByIdAsync(int skinId)
        {
            var skin = await _dbContext.Skins.FindAsync(skinId);
            if (skin == null)
            {
                return null;
            }

            return _mapper.Map<SkinDto>(skin);
        }
    }
}
