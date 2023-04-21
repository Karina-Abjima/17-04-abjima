using System.Security.Cryptography.X509Certificates;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        private PointOfInterestDto finalPointOfInterest;
        private readonly ILogger<PointOfInterestController> _logger;
        private readonly IMailService _mailService;
        private readonly CitiesDataStore _citiesDataStore;

        public PointOfInterestController(ILogger<PointOfInterestController> logger,
            IMailService mailService,CitiesDataStore citiesDataStore)
        {
            _logger=logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService=mailService?? throw new ArgumentNullException(nameof(mailService));
            _citiesDataStore=citiesDataStore ?? throw new ArgumentNullException(nameof(citiesDataStore));
        }
        public object? PointOfInterest { get; private set; } 

        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {   
            try
            {
                //throw new Exception("Exception Sample.");
                var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
                if (city == null) 
                {
                    _logger.LogInformation($"City with id{cityId} wasn't found when accessing");
                    return NotFound();
                }
                return Ok(city.PointOfInterests);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception while getting points of interest for city with Id{cityId}",ex);
                return StatusCode(500, "A problem is happened while handling your request.");
             
            }
        }

        [HttpGet("{pointsofinterestid}", Name = "GetPointsOfInterest")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
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
            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = _citiesDataStore.Cities.SelectMany
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
        public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId,
            PointOfInterestForUpdateDto pointOfInterest)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }
            pointOfInterestFromStore.Name = pointOfInterest.Name;
            pointOfInterestFromStore.Description = pointOfInterest.Description;

            return NoContent();
        }
        [HttpPatch("{pointofinterestid}")]

            public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfIntrestId,
              JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
            {
                var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
                if (city == null)
                {
                    return NotFound();
                }

                var pointOfInterestFromStore = city.PointsOfInterest.
                   FirstOrDefault(c => c.Id == cityId);
                if (pointOfInterestFromStore == null)
                {
                    return NotFound();
                }
                var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
                {
                    Name = pointOfInterestFromStore.Name,
                    Description = pointOfInterestFromStore.Description
                };

                patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                pointOfInterestFromStore.Name = pointOfInterestFromStore.Name;
                pointOfInterestFromStore.Description = pointOfInterestFromStore.Description;

                return NoContent();
            }
            [HttpDelete ("{pointOfInterestId}")]

            public ActionResult DeletePointOfInterest(int cityId,int pointOfIntrestId)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault
                (c => c.Id == cityId);
            if (pointOfInterestFromStore == null)
            {
                return BadRequest(ModelState);
            }

            city.PointsOfInterest.Remove(pointOfInterestFromStore);
            NewMethod(pointOfInterestFromStore);
            return NoContent();

        }

        private void NewMethod(PointOfInterestDto? pointOfInterestFromStore)
        {
            _mailService.Send( "Point of interest deleted.",
            $"Point of interest{pointOfInterestFromStore.Name} with id{pointOfInterestFromStore.Id}was deleted.");
        }


    }
}
