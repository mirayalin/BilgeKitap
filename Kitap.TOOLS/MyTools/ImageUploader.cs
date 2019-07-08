using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Kitap.TOOLS.MyTools
{
   public static class ImageUploader
    {
        public static string UploadImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                Guid uniqueName = Guid.NewGuid();

                serverPath = serverPath.Replace("~", string.Empty);//eger gelen serverPath parametresinde ~(tilda) diye bir işaret varsa onu boslukla degiştir.

                string[] fileArray = file.FileName.Split('.');//burada uzaygemisi.jpg  diye bir veri gelirse Split('.') metodu sayesinde ben bunu ["uzaygemisi"]["jpg"] olarak noktalardan kesip iki elemanlı bir string arraye dönüstürdüm. 

                string extension = fileArray[fileArray.Length - 1].ToLower(); //burada dosya uzantısını yakalayarak onu kücük harflere cevirdik.

                string fileName = $"{uniqueName}.{extension}";

                //alt tarafta uzantı kontrolü ile dosyanın bir resim olup olmadıgını anlamaya calısıyoruz.
                if (extension == "jpg" || extension == "gif" || extension == "png" || extension == "jpeg")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        return "Dosya zaten var";
                    }
                    else
                    {
                        string filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);

                        file.SaveAs(filePath);
                        return serverPath + fileName;
                    }
                }
                else
                {
                    return "Lütfen resim seçiniz";
                }
            }
            else
            {
                return "Dosya boş";
            }
            

        }

    }
}
