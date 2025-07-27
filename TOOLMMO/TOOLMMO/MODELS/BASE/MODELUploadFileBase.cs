using MODELS.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.BASE
{
    public class MODELUploadFileBase
    {
        public double FileSizeLimitMB { get; set; }           
        public bool AllowMultipleFiles { get; set; }          
        public string FileValidationMessage { get; set; }     
        public string[] AllowedFileExtensions { get; set; }
        public List<MODELAttachment> ExistingAttachments { get; set; } 
        public int ReferenceType { get; set; }                
        public Guid? TempKey { get; set; }                    
        public string? UploadFolder { get; set; }             

    }
}
