using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarbyApp.Core.Entities;

namespace WarbyApp.Service.Helpers
{
    public static class FileManager
    {
        public static List<EyeglassesImage> Save(List<IFormFile> files, string rootPath, string folder)
        {
            List<EyeglassesImage> savedFileNames = new List<EyeglassesImage>();
            foreach (var file in files)
            {
                string newFileName = Guid.NewGuid().ToString() + (file.FileName.Length > 64 ? (file.FileName.Substring(file.FileName.Length - 64)) : file.FileName);
                string path = Path.Combine(rootPath, folder, newFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                savedFileNames.Add(new EyeglassesImage { ImageName = newFileName });
            }
            return savedFileNames;
        }
        public static void Delete(string rootPath, string folder, string fileName)
        {
            string path = Path.Combine(rootPath, folder, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
