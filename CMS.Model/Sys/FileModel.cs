using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CMS.Model.Sys
{
    public class FileModel
    {
        
            [Display ( Name = "Category" )]
            [Required ( ErrorMessage = "Please input the category!" )]
            public string Category { get; set; }

            [Display ( Name = "Description" )]
            [Required ( ErrorMessage = "Please input the description!" )]
            public string Description { get; set; }

            [Display ( Name = "File:" )]
            [Required ( ErrorMessage = "Please upload a file!" )]
            [ValidateFile]
            public HttpPostedFileBase Files { get; set; }
        
    }
}
