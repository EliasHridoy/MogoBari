using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MogobariWebAPI.Models.ViewModels
{
    public class ProductWithImageFile
    {
        public string product { get; set; }
        /// <summary>
        /// Here product wil be a json data. As a result we will catch it as string than convert it from 
        /// json to product type
        /// </summary>
        public List<IFormFile> Images { get; set; }
    }
}
