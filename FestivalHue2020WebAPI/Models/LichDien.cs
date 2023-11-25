using System.ComponentModel.DataAnnotations.Schema;

namespace FestivalHue2020WebAPI.Models
{
    public class LichDien
    {
        public int Id { get; set; }
        public DateTime fdate { get; set; }
        public string Md5 { get; set; }
        public ICollection<ChuongTrinh>? DetailList { get; set; }
    }
}
