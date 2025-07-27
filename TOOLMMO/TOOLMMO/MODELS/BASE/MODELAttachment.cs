namespace MODELS.BASE
{
    public class MODELAttachment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ReferenceId { get; set; }           
        public string FileName { get; set; }             
        public string FileExtension { get; set; }        
        public double? SizeInMB { get; set; }           
        public string Url { get; set; }
        public string FullFileName { get; set; }        

    }
}
