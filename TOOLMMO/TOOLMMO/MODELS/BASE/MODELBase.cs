namespace MODELS.BASE
{
    public class MODELBase
    {
        public DateTime? CreateDate { get; set; }
        public string? CreateAt { get; set; }
        public DateTime? EditDate { get; set; }
        public string? EditAt { get; set; }
        public bool IsActived { get; set; } = true;
        public bool IsEdit { get; set; } = false;
        public int? Sort { get; set; }
    }
}
