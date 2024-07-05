using AutoMapper;
using CaseMvp.Dtos;
using CaseMvp.Entity;

namespace CaseMvp
{
    public class CaseMvpMappinProfile:Profile
    {
        public CaseMvpMappinProfile()
        {
            CreateMap<Case, CaseDto>();
            CreateMap<CaseDto, Case>();
            CreateMap<CreateCaseDto, Case>();
            CreateMap<UpdateCaseDto, Case>();
            CreateMap<CaseDto,UpdateCaseDto>();


            CreateMap<Skin, SkinDto>();
            CreateMap<SkinDto, Skin>();
            CreateMap<CreateSkinDto, Skin>();
            CreateMap<UpdateSkinDto, Skin>();
            CreateMap<SkinDto, UpdateSkinDto>();
        }
    }
}
