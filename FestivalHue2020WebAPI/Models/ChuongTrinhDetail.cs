namespace FestivalHue2020WebAPI.Models
{
    public class ChuongTrinhDetail
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public DateTime FDate { get; set; }
        public DateTime TDate { get; set; }
        public int IdDoan { get; set; }
        public string? DoanName { get; set; }
        public int IdDiaDiem { get; set; }
        public string? DiaDiemName { get; set; }
        public int IdNhom { get; set; }
        public string? NhomName { get; set; }
    }
}