using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PcController : ControllerBase
{
       private readonly IDbService _dbService;
       
       public PcController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var pcs = await _dbService.GetAll(cancellationToken);
            return Ok(pcs);
        }

        [Route("{id}/components")]
        [HttpGet]
        public async Task<IActionResult> GetPcComponentsById(int id, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _dbService.GetPcComponentsByIdAsync(id, cancellationToken);
                return Ok(res);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> AddPc(PcDto PcDto, CancellationToken cancellationToken)
        {
            await _dbService.AddPc(PcDto, cancellationToken);
            return Created();
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePc(int id, UpdatePcDto UpdatePcDto, CancellationToken cancellationToken)
        {
            try
            {
                await _dbService.UpdatePcAsync(id, UpdatePcDto, cancellationToken);
                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePc(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _dbService.DeletePcByIdAsync(id, cancellationToken);
                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
}