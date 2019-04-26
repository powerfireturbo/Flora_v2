using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Flora.Models;
using System.Linq;
namespace Flora.Data
{
    public class PlantService : IPlantService
    {
        private static IImageService imageService;
        private static IGeoService geoService;
        private static IFloraDB floraDB;

        public PlantService(IImageService img, IGeoService geo, IFloraDB db)
        {
            imageService = img;
            geoService = geo;
            floraDB = db;
        }

        public async Task<Plant> GetPlantAsync(int plantID)
        {
            return await floraDB.GetPlantAsync(plantID);
        }
        public async Task<List<Plant>> GetPlantsWithinRadiusAsync(int radius)
        {
            List<string> names = await geoService.GetPlantNamesWithinRadius(25);
            return await floraDB.GetPlantsAsync(names);
        }

        public async Task<List<Plant>> GetPlantsByStateAsync(string state)
        {
            List<string> names = await geoService.GetPlantNamesByState(state);
            return await floraDB.GetPlantsAsync(names);
        }

        public async Task<List<Plant>> GetPlantsByCountyAsync(string state, string county)
        {
            List<string> names = await geoService.GetPlantNamesByCounty(state, county);
            return await floraDB.GetPlantsAsync(names);
        }

        public async Task<Plant> GetPlantAsync(string name)
        {
            return await floraDB.GetPlantAsync(name);
        }

        public async Task<string> GetPlantImageUrlAsync(string plantName)
        {
            return await imageService.GetPlantImageURL(plantName);
        }

        public async Task<List<string>> GetFamiliesAsync()
        {
            return await floraDB.GetFamiliesAsync();
        }
        
        public async Task<List<string>> GetGeneraAsync(string family)
        {
            return await floraDB.GetGeneraAsync(family);
        }

        public async Task<List<string>> GetSpeciesAsync(string genus)
        {
            return await floraDB.GetSpeciesAsync(genus);
        }
    }
}
