using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flora.Data
{
    public interface IGeoService
    {
        Task<List<string>> GetPlantNamesByCounty(string state, string county);
        Task<List<string>> GetPlantNamesWithinRadius(int radius);
        Task<List<string>> GetPlantNamesByState(string state);
    }
}