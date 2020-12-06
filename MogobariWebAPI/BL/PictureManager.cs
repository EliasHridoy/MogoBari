using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Design;
using MogobariWebAPI.BL.Interface;
using MogobariWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MogobariWebAPI.BL
{
    public class PictureManager: IPictureManager
    {
        private readonly Mogobari_dbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PictureManager(IHostingEnvironment hostingEnvironment, Mogobari_dbContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }



        public async Task<List<Picture>> Create(List<IFormFile> images, string folderName)
        {
            List<Picture> pictures = new List<Picture>();

            foreach (var image in images)
            {

                Picture picture = new Picture();
                string path, fileName; 
                
                Save(image, folderName, out path, out fileName);
                picture.Filename = fileName;

                if (path != "")
                {
                    picture.VirtualPath = path;
                    _context.Picture.Add(picture);

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception)
                    {

                        return null;
                    } 
                }

                pictures.Add(picture);
            }

            
            return pictures;        
        }


        public void Save(IFormFile Image, string folderName, out string path, out string fileName )
        {
            fileName = "";
            path = "";
            
            if (Image.Length > 0)
            {
                
                
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "imgs\\" + folderName);

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                Image.CopyTo(new FileStream(filePath, FileMode.Create));

                fileName = uniqueFileName;
                path = "\\imgs\\" + folderName +"\\"+ uniqueFileName;

            }

        }
    }
}
