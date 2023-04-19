using System.Security.Cryptography.X509Certificates;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        private PointOfInterestDto finalPointOfInterest;

        public object PointOfInterest { get; private set; }

        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{pointsofinterestid}",Name= "GetPointsOfInterest")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId, int pointOfInterestId) 
        {
           var city = CitiesDataStore.Current.Cities.FirstOrDefault(c  => c.Id == cityId);
           if(city == null) 
            {
               return NotFound();
            }

            //find point of interest

            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
            if (pointOfInterest == null)
            {
                return NotFound();
            }
            return Ok(pointOfInterest);
        }
        [HttpPost]

        public ActionResult<PointOfInterestDto> CreatePointOfInterest(
            int cityId,
            PointOfInterestForCreationDto pointOfInterest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany
                (c => c.PointOfInterests).Max(p => p.Id);
            var finalPointsOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    cityId = cityId,
                    pointOfInterestID = finalPointOfInterest.Id
                },
                finalPointOfInterest);
        }
            [HttpPut("{pointofinterestid}")]
            public ActionResult UpdatePointOfInterest(int cityId,int pointOfInterestId,
                PointOfInterestForUpdateDto pointOfInterest)
            {
                    var city=CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
                    if(city == null)
                    {
                      return NotFound();
                    }
            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
            if(pointOfInterestFromStore == null) 
            {
                return NotFound(); 
            }
            pointOfInterestFromStore.Name = pointOfInterest.Name;
            pointOfInterestFromStore.Description = pointOfInterest.Description;

            return NoContent();

        }
        
    }
}
