using AutoMapper;
using LearnProject.Model;
using LearnProject.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LearnProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly Repository.WalkRepo.IWalkRepository _walkRepository;
        public WalkController(IMapper immapper, Repository.WalkRepo.IWalkRepository walkRepository)
        {
            _mapper = immapper;
            _walkRepository = walkRepository;
        }
       

        //post api/walk
        [HttpPost]
        public async Task<IActionResult> AddWalkAsync(Model.DTO.AddWalkRequestDto addWalkRequestDto)
        {
            try
            {
                //convert DTO to Domain model
                var walkDomain = _mapper.Map<Model.Domain.Walk>(addWalkRequestDto);
                //pass Domain model details to repository
                var addedWalk = await _walkRepository.AddWalkAsync(walkDomain);
                //convert back to DTO
                var walkDto = _mapper.Map<Model.DTO.WalkDto>(addedWalk);
                //return response

                //return Ok(Resultmodel(201, "Walk Added success", walkDto));
                return Ok(new BaseModel { Statuscode = 201, Message = "Walk Added success", Result = { Data = walkDto } });

            }
            catch (Exception ex)
            {
                return Ok(new BaseModel { Statuscode = 500, Message = "Walk not Added success" });
            }

        }
        //get api/walk
        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            try
            { 
                var walksDomain = await _walkRepository.GetAllWalksAsync();
                //convert back to DTO
                var walkDTOs = _mapper.Map<List<Model.DTO.WalkDto>>(walksDomain);
                return Ok(new BaseModel { Statuscode = 201, Message = "Walk Added success", Result = { Data = walkDTOs } });
            }
            catch (Exception ex)
            {
                return Ok(new BaseModel { Statuscode = 500, Message = "Walk Added success" });
            }
        }
        //get api/walk
        //GET: api/walk/GetAllWalksWithFilterAsync
        [HttpGet("filter")]
        public async Task<IActionResult> AllWalksWithFilterAsync([FromQuery] string? filteron = null, [FromQuery] string? filterquery = null)
        {
            try
            {
                var walksDomain = await _walkRepository.AllWalksWithFilterAsync(filteron, filterquery);
                //convert back to DTO
                var walkDTOs = _mapper.Map<List<Model.DTO.WalkDto>>(walksDomain);
                return Ok(new BaseModel { Statuscode = 201, Message = "Walk Added success", Result = { Data = walkDTOs } });
            }
            catch (Exception ex)
            {
                return Ok(new BaseModel { Statuscode = 500, Message = "Walk Added success" });
            }
        }
        //get
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByidAsync([FromRoute] Guid id)
        {
            try
            {
                var walkDomain = await _walkRepository.GetWalkAsync(id);
                //convert back to DTO
                var walkDTOs = _mapper.Map<Model.DTO.WalkDto>(walkDomain);
                return Ok(new BaseModel { Statuscode = 201, Message = "Walk Added success" });
            }
            catch (Exception ex)
            {
                return Ok(new BaseModel { Statuscode = 500, Message = "Walk  not Added success" });
            }
        }
    }
}
