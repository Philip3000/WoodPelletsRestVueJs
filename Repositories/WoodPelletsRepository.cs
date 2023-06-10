using WoodPelletsLib;

namespace RestWoodPellets.Repositories
{
    public class WoodPelletsRepository
    {
        private int _nextId = 1;
        private readonly List<WoodPellet> Data;
        public WoodPelletsRepository()
        {
            Data = new List<WoodPellet>
            {
                new WoodPellet{ Id = _nextId++, Brand = "BioWood", Price = 4995, Quality = 4 },
                new WoodPellet{ Id = _nextId++, Brand = "BioWood", Price = 5195, Quality = 4 },
                new WoodPellet{ Id = _nextId++, Brand = "BilligPille", Price = 4125, Quality = 1 },
                new WoodPellet{ Id = _nextId++, Brand = "GoldenWoodPellet", Price = 5995, Quality = 5 },
                new WoodPellet{ Id = _nextId++, Brand = "GoldenWoodPellet", Price = 5795, Quality = 5 }

            };
        }
        public List<WoodPellet> GetAll()
        {
            if (Data.Count == 0)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return new List<WoodPellet>(Data);
            }
        }
        public WoodPellet? GetById(int id)
        {
            return Data.Find(WoodPellet => WoodPellet.Id == id);
        }
        public WoodPellet Add(WoodPellet newWoodPellet)
        {
            newWoodPellet.Validate(newWoodPellet);
            newWoodPellet.Id = _nextId++;
            Data.Add(newWoodPellet);
            return newWoodPellet;
        }
        public WoodPellet Delete(int id)
        {
            WoodPellet? woodPellet = GetById(id);
            if (woodPellet == null) return null;
            Data.Remove(woodPellet);
            return woodPellet;
        }
        public WoodPellet? Update(int id, WoodPellet updates)
        {
            WoodPellet? woodPellet = GetById(id);
            if (woodPellet == null) return null;
            woodPellet.Brand = updates.Brand;
            woodPellet.Price = updates.Price;
            woodPellet.Quality = updates.Quality;
            return woodPellet;
        }
    }
}
