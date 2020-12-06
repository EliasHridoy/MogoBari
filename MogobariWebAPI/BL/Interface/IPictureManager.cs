using Microsoft.AspNetCore.Http;
using MogobariWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MogobariWebAPI.BL.Interface
{
    public interface IPictureManager
    {
       Task<List<Picture>> Create(List<IFormFile> images, string folderName);

        void Save(IFormFile Image, string folderName, out string path, out string fileName);

    }
}
