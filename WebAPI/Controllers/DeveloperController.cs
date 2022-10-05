using Core.Interfaces;
using Core.Models;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperService _developerService;
        private readonly IGenericRepository<Developer> _repository;

        public DeveloperController(IDeveloperService developerService,IGenericRepository<Developer> repository)
        {
            _developerService = developerService;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDevs()
        {
            try
            {
                return Ok(await _repository.GetAllAsync()); 

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevById(int id)
        {
            try
            {
                return Ok(await _repository.GetByIdAsync(id));  

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Specify()
        {
            try
            {
               // var specification = new DeveloperWithAddressSpecification(3);
                var specification = new DeveloperByIncomeSpecification(1);
                return Ok( _repository.FindWWithSpecificationPattern(specification));
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeveloper(Developer developer)
        {
            try
            {

                await _developerService.AddDeveloper(developer);
                return Ok(developer + " created!");
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
