using WebApplication1.Controllers;
using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IDbService
{
    Task<List<PcDto>> GetAll(CancellationToken cancellationToken);
    //Task<PcComponentDto> GetById(int id, CancellationToken cancellationToken);
    Task AddPc(PcDto pc, CancellationToken cancellationToken);
    Task UpdatePcAsync(int id, UpdatePcDto UpdatePcDto, CancellationToken cancellationToken);
    Task DeletePcByIdAsync(int id, CancellationToken cancellationToken);
    Task<PcWithComponentsDto> GetPcComponentsByIdAsync(int id, CancellationToken cancellationToken);
}