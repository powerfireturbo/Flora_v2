using Flora.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flora.Data
{
    public class ImageService : IImageService
    {
        public Task<string> GetPlantImageURL(string plantName)
        {
            return Task<string>.Run(() => { return "https://www.anImageUrl.com"; });
        }
    }
}
