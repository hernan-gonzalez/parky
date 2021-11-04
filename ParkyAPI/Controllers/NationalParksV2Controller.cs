using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyAPI.Models;
using ParkyAPI.Models.Dtos;
using ParkyAPI.Repository.IRepository;

namespace ParkyAPI.Controllers
{

    [Route("api/v{version:apiVersion}/nationalparks")]
    [ApiVersion("2.0")]
    //[Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "ParkyOpenAPISpecNP")]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class NationalParksV2Controller : ControllerBase
    {
        private INationalParkRepository _npRepo;

        private readonly IMapper _mapper;

        public NationalParksV2Controller(INationalParkRepository nprepo,IMapper mapper)
        {
            _npRepo = nprepo;
            _mapper = mapper;

        }

        /// <summary>
        /// Get List of national parks.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(List<NationalParkDto>))]
      
        public IActionResult GetNationalParks()
        {
            var obj= _npRepo.GetNationalParks().FirstOrDefault();

            var objDto = new List<NationalParkDto>();

            //foreach (var obj in objList)
            //{
            //    objDto.Add(_mapper.Map<NationalParkDto>(obj));
            //}
            return Ok(_mapper.Map<NationalParkDto>(obj));
        }

        
    }
}