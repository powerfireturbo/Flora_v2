using System.Collections.Generic;
using System.Threading.Tasks;
using Flora.Models;

namespace Flora.Data
{
    public interface IFloraDB
    {
        Task<List<string>> GetFamiliesAsync();
        Task<Plant> GetPlantAsync(int plantID);
        Task<List<string>> GetGeneraAsync(string family);
        Task<Plant> GetPlantAsync(string scientificName);
        Task<List<Plant>> GetPlantsAsync(List<string> names);
        Task<List<string>> GetSpeciesAsync(string genus);

    }
}