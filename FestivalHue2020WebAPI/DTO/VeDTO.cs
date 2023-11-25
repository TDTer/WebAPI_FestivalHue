using FestivalHue2020WebAPI.Models;

namespace FestivalHue2020WebAPI.DTO
{
    public class VeDTO
    {
        public int Id { get; set; }
        public ChuongTrinh ChuongTrinh { get; set; }
        public float Gia { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayBan { get; set; }
        public int QRCode { get; set; }
        public bool HopLe { get; set; }
    }
}
