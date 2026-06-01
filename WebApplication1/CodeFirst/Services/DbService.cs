using System.Globalization;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _dbContext;

    public DbService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<PcDto>> GetAll(CancellationToken cancellationToken)
    {
        return await _dbContext.Pc
            .Select(p => new PcDto
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock

            }).ToListAsync(cancellationToken);
    }

    public async Task AddPc(PcDto PcDto, CancellationToken cancellationToken)
    {
        var res = new Pc()
        {
            Name = PcDto.Name,
            Weight = PcDto.Weight,
            Warranty = PcDto.Warranty,
            CreatedAt = PcDto.CreatedAt,
            Stock = PcDto.Stock
        };
        
        await _dbContext.Pc.AddAsync(res, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdatePcAsync(int id, UpdatePcDto UpdatePcDto, CancellationToken cancellationToken)
    {
        var Pc = await _dbContext.Pc.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        if (Pc == null)
        {
            throw new NotFoundException();
        }
        
        Pc.Name = UpdatePcDto.Name;
        Pc.Weight = UpdatePcDto.Weight;
        Pc.Warranty = UpdatePcDto.Warranty;
        Pc.CreatedAt = UpdatePcDto.CreatedAt;
        Pc.Stock = UpdatePcDto.Stock;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeletePcByIdAsync(int id, CancellationToken cancellationToken)
    {
        var pc = await _dbContext.Pc.Where(p => p.Id == id).ExecuteDeleteAsync(cancellationToken);
        if (pc == 0)
        {
            throw new NotFoundException();
        }
        
    }

    public async Task<PcWithComponentsDto> GetPcComponentsByIdAsync(int id, CancellationToken cancellationToken)
    {
        var res = await _dbContext.Pc.Where(u => u.Id == id).Select(u => new PcWithComponentsDto
        {
            Id = u.Id,
            Name = u.Name,
            Weight = u.Weight,
            Warranty = u.Warranty,
            CreatedAt = u.CreatedAt,
            Stock = u.Stock,
            pcComponents = u.PcComponents.Select(up => new PcComponentsDto
            {
                Amount = up.Amount,
                Component = new ComponentDto
                {
                    Code = up.Component.Code,
                    Name = up.Component.Name,
                    Description = up.Component.Description,
                    Manufacturer = new ComponentManufacturerDto
                    {
                        Id = up.Component.ComponentManufacturer.Id,
                        Abbreviation = up.Component.ComponentManufacturer.Abbreviation,
                        FullName = up.Component.ComponentManufacturer.FullName,
                        FoundationDate =  up.Component.ComponentManufacturer.FoundationDate,
                    },
                    Type = new ComponentTypeDto
                    {
                        Id = up.Component.ComponentType.Id,
                        Abbreviation = up.Component.ComponentType.Abbreviation,
                        Name = up.Component.ComponentType.Abbreviation,
                    } 
                }
            })
        }).FirstOrDefaultAsync(cancellationToken);

        if (res == null)
        {
            throw new  NotFoundException();
        }

        return res;
    }
   
}