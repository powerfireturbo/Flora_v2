using System.Collections.Generic;
using System.Threading.Tasks;
using Flora.Models;

namespace Flora.Data
{
    public interface IPlantService
    {
        Task<Plant> GetPlantAsync(string name);
        Task<Plant> GetPlantAsync(int plantID);
        Task<string> GetPlantImageUrlAsync(string plantName);
        Task<List<Plant>> GetPlantsByCountyAsync(string state, string county);
        Task<List<Plant>> GetPlantsByStateAsync(string state);
        Task<List<Plant>> GetPlantsWithinRadiusAsync(int radius);
        Task<List<string>> GetSpeciesAsync(string genus);
        Task<List<string>> GetFamiliesAsync();
        Task<List<string>> GetGeneraAsync(string family);

    }
}