using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodPelletsLib
{
    public class WoodPellet
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public int Price { get; set; }

        public int Quality { get; set; }
        public void ValidateID(int id)
        {
            if (id.GetType() != typeof(int))
            {
                throw new ArgumentException("Id must be a number");
            }
        }
        public void ValidateBrand(string? brand) 
        {
            if (brand?.Length <= 1)
            {
                throw new ArgumentException("Brand Must be a string and have atleast TWO letters");
            }
        }
        public void ValidatePrice(int price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price must be a number greater than 0");
            }
        }
        public void ValidateQuality(int quality)
        {
            if (quality < 1 || quality > 5)
            {
                throw new ArgumentException("Quality must be between 1 and 5");
            }
        }
        public void Validate(WoodPellet wood)
        {
            ValidateID(wood.Id);
            ValidateBrand(wood.Brand);
            ValidatePrice(wood.Price);
            ValidateQuality(wood.Quality);
        }
        public override string ToString()
        {
            return $"ID: {Id} - Brand: {Brand} - Price: {Price} - Quality: {Quality}";
        }
    }

}
