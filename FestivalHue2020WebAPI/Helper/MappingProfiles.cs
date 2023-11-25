using AutoMapper;
using FestivalHue2020WebAPI.DTO;
using FestivalHue2020WebAPI.Models;

namespace FestivalHue2020WebAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ChuongTrinh, ChuongTrinhDTO>().ReverseMap();
            CreateMap<DiaDiem, DiaDiemDTO>().ReverseMap();
            CreateMap<LichDien, LichDienDTO>().ReverseMap();
            CreateMap<TinTuc, TinTucDTO>().ReverseMap();
            CreateMap<Ve, VeDTO>().ReverseMap();
        }
    }
}
