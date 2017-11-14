using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CMS.Model.Sys
{
    public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid ( object value )
        {
            int MaxContentLength = 1024 * 1024 * 4;
            string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".pdf","txt" };

            var file = value as HttpPostedFileBase;

            if(file == null)
                return false;
            else if(!AllowedFileExtensions.Contains ( file.FileName.Substring ( file.FileName.LastIndexOf ( '.' ) ) ))
            {
                ErrorMessage = "请上传你的博客图片类型: " + string.Join ( ", ", AllowedFileExtensions );
                return false;
            }
            else if(file.ContentLength > MaxContentLength)
            {
                ErrorMessage = "上传图片过大，不能超过4兆 : " + ( MaxContentLength / 1024 ).ToString ( ) + "MB";
                return false;
            }
            else
                return true;
        }
    }
}
