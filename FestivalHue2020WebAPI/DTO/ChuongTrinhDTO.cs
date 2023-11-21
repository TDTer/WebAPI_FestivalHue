using FestivalHue2020WebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FestivalHue2020WebAPI.DTO
{
    public class ChuongTrinhDTO
    {
        public int Id { get; set; }
        public string ChuongTrinhName { get; set; }
        public string ChuongTrinhContent { get; set; }
        public int TypeInoff { get; set; }
        public float Price { get; set; }
        public int TypeProgram { get; set; }
        public int Arrange { get; set; }
        public ICollection<ChuongTrinhDetail> DetailList { get; set; }
        public string Md5 { get; set; }
        [NotMapped]
        public List<string> PathImageList { get; set; }
    }
}
