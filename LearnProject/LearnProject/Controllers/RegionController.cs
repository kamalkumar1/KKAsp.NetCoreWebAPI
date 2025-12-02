using LearnProject.CustomActionFilters;
using LearnProject.Data;
using LearnProject.Model;
using LearnProject.Model.Domain;
using LearnProject.Model.DTO;
using LearnProject.Repository.Region;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LearnProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;

        public RegionController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }
        
        //Get:https://localhost:7271/Region
        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAllRegions()
        {
            //Get data from database -domain model
            var regions = await _regionRepository.GetAllRegions();

          // var basemodel = new Model.BaseModel();
            var regionList = new List<RegionDto>();
            if (regions != null)
            {
                //map domain model to dto
                foreach (var region in regions)
                {
                    regionList.Add(new RegionDto
                    {
                        Id = region.Id,
                        Name = region.Name,
                        Code = region.Code,
                        RegionImageUrl = region.RegionImageUrl
                    });
                }
              
                return Ok(new BaseModel
                {
                    Statuscode = 200,
                    Message = "Regions retrieved successfully",
                    Result = new Result
                    {
                        Data = regionList
                    }
                });
            }
            else
            {
               
                return Ok(new BaseModel
                {
                    Statuscode = 200,
                    Message = "No regions found",
                    Result = new Result
                    {
                        Data = regionList
                    }
                });
               
            }
        }
      
        //Get:https://localhost:7271/Region/id
        //Route id and parameter id should be equal
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await _regionRepository.GetById(id);
            var regionDto = new RegionDto();
            if (region != null)
            {
                regionDto.Id = region.Id;
                regionDto.Name = region.Name;
                regionDto.Code = region.Code;
                regionDto.RegionImageUrl = region.RegionImageUrl;

                return Ok(new BaseModel
                {
                    Statuscode = 200,
                    Message = "Region retrieved successfully",
                    Result = new Result
                    {
                        Data = regionDto
                    }
                });
            }
            else
            {
                return Ok(new BaseModel
                {
                    Statuscode = 404,
                    Message = "Region not found",
                    Result = new Result
                    {
                        Data = regionDto
                    }
                });
            }
          
        }
       
        //POST:https://localhost:7271/Region
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> AddRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            try
            {
                if (addRegionRequestDto == null)
                {
                    return BadRequest(new BaseModel { Statuscode = 400, Message = "Request boday is null" });

                }
                else if (addRegionRequestDto.Name == null || addRegionRequestDto.Code == null)
                {
                    return BadRequest(new BaseModel { Statuscode = 400, Message = "Name and Code are required." });
                }
                var region = await _regionRepository.AddRegion(addRegionRequestDto);
                var regionDto = new RegionDto
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl
                };

                return BadRequest(new BaseModel
                {
                    Statuscode = 201,
                    Message = "Region added successfully.",
                    Result = new Result
                    {
                        Data = regionDto
                    }
                });


            }
            catch (Exception ex)
            {
                return Ok(new BaseModel { Statuscode = 500, Message = "An error occurred while adding the region." });
            }
        }
     
      
        //PUT:https://localhost:7271/Region
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDtos updateRegionRequestDto)
        {
            try
            {
                /* if (string.IsNullOrEmpty(id.ToString()))
                 {
                     return Ok(Resultmodel(400, "id is missing"));
                 }
                 else if (updateRegionRequestDto.Name == null)
                 {
                     return Ok(Resultmodel(400, "At least one field (Name) must be provided for update."));

                 }
                 else if (updateRegionRequestDto.Code == null)
                 {
                     return Ok(Resultmodel(400, "At least one field (Code) must be provided for update."));

                 }
                 else if (updateRegionRequestDto.RegionImageUrl == null)
                 {
                     return Ok(Resultmodel(400, "At least one field (RegionImageUrl) must be provided for update."));
                 }*/
                if (ModelState.IsValid)
                {
                    var existingRegion = await _regionRepository.GetById(id);

                    if (existingRegion == null)
                    {
                        return Ok(new BaseModel { Statuscode = 404, Message = "Region Not Found." });
                    }

                    existingRegion = await _regionRepository.UpdateRegion(existingRegion, updateRegionRequestDto);

                    if (existingRegion == null)
                    {
                        return Ok(new BaseModel { Statuscode = 404, Message = "R\"An error occurred while updating the region." });
                    }
                    var regionDto = new RegionDto
                    {
                        Id = existingRegion.Id,
                        Name = existingRegion.Name,
                        Code = existingRegion.Code,
                        RegionImageUrl = existingRegion.RegionImageUrl
                    };

                    return Ok(new BaseModel { Statuscode = 200, Message = "Region updated successfully", Result = { Data = regionDto } });
                }
                else                
                {
                    return Ok(new BaseModel { Statuscode = 404, Message = "R\"An error occurred while updating the region." });
                }
               

            }
            catch(Exception ex)
            {
                return Ok(new BaseModel { Statuscode = 404, Message = "R\"An error occurred while updating the region." });
            }
            
        }

        //Delete:https://localhost:7271/Region/id
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            try
            {
                var existingRegion = await _regionRepository.GetById(id);
                if (existingRegion == null)
                {
                    return Ok(new BaseModel { Statuscode = 404, Message = "R\"An error occurred while updating the region." });
                }
                else
                {
                    await _regionRepository.DeleteRegion(existingRegion);
                    return Ok(new BaseModel { Statuscode = 200, Message = "\"Region deleted successfully." });
                }
            }
            catch(Exception ex)
            {
                return Ok(new BaseModel { Statuscode = 404, Message = "R\"An error occurred while updating the region." });

            }
           
        }
    }
}
