using System.Threading.Tasks;
using Flora.Models;

namespace Flora.Data
{
    public interface IImageService
    {
        Task<string> GetPlantImageURL(string plantName);
    }
}