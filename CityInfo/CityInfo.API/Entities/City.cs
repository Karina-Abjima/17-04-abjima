using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;
using CityInfo.API.Controllers;

namespace CityInfo.API.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }    
        public string? Description { get; set; }

        public ICollection<PointOfInterest> PointOfInterests { get; set; }
                         = new List<PointOfInterest>();

        public City(string name) 
        { 
             Name= name;
        }
    }
}
