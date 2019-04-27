using Flora.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flora.Data
{
    public class FloraDB : IFloraDB
    {
        readonly SQLiteAsyncConnection db;

        public FloraDB(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
        }

        public Task<Plant> GetPlantAsync(int plantID)
        {
            return db.GetAsync<Plant>(plantID);
        }

        public Task<Plant> GetPlantAsync(string scientificName)
        {
            return db.Table<Plant>().Where(p => p.ScientificName == scientificName).FirstOrDefaultAsync();
        }

        public async Task<List<string>> GetFamiliesAsync()
        {
            List<Plant> plants = await db.QueryAsync<Plant>("SELECT DISTINCT Family FROM Plants");
            return plants.Select(p => p.Family).ToList();
        }

        public async Task<List<string>> GetGeneraAsync(string family)
        {
            List<Plant> plants = await db.QueryAsync<Plant>("SELECT DISTINCT Genus FROM Plants WHERE Family = ?", family);
            return plants.Select(p => p.Genus).ToList();
        }

        public async Task<List<string>> GetSpeciesAsync(string genus)
        {
            List<Plant> plants = await db.QueryAsync<Plant>("SELECT DISTINCT ScientificName FROM Plants WHERE Genus = ?", genus);
            return plants.Select(p => p.ScientificName).ToList();
        }

        public async Task<List<Plant>> GetPlantsAsync(List<string> names)
        {
            List<string> namesSubList;
            List<Plant> plants = new List<Plant>();
            for(int i = 0; (names.Count - i) > 500; i+=500)
            {
                namesSubList = names.GetRange(i, 500);
                plants.AddRange(await db.Table<Plant>().Where(p => namesSubList.Contains(p.ScientificName.ToLower())).ToListAsync());
            }
            int numLeft = (names.Count % 500) - 1;
            namesSubList = names.GetRange((names.Count - numLeft), numLeft);
            plants.AddRange(await db.Table<Plant>().Where(p => namesSubList.Contains(p.ScientificName.ToLower())).ToListAsync());

            await db.RunInTransactionAsync(conn =>
            {
                foreach (Plant p in plants)
                {
                    p.Attributes = conn.Query<Models.Attribute>(
                        "SELECT Attributes.Name, Attributes.Description, Attributes.FirstHeading, Attributes.SecondHeading " +
                        "FROM PlantAttribute INNER JOIN Attributes ON PlantAttribute.AttributeID = Attributes.AttributeID " +
                        "WHERE PlantID = ?", p.PlantID
                        );
                }
            });

            return plants;
        }
    }
}