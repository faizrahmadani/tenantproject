using Microsoft.EntityFrameworkCore;
using TenantProject.Data;
using TenantProject.Helper;
using TenantProject.Model.DTO;
using TenantProject.Model.Entity;

namespace TenantProject.Services;

public class TenantService
{
    private readonly MainDatabaseContext _context;
    public TenantService(MainDatabaseContext context)
    {
        _context = context;
    }

    public async Task<TenantRequestDto> AddTenant(TenantRequestDto requestDto)
    {
        var currentTenantType = await CheckTenantTypeExist(requestDto.TenantTypeId);
        if (currentTenantType == null)
        {
            throw new Exception(ErrorMessageHelper.TenantTypeNotInvalid);
        }
        var tenantId = Guid.NewGuid();
        var newTenant = new Tenant()
        {
            Id = tenantId,
            TenantName = requestDto.TenantName,
            TenantTypeId = requestDto.TenantTypeId,
            TenantAddress = requestDto.TenantAddress,
            TenantPhone = requestDto.TenantPhone,
        };

        await _context.Tenants.AddAsync(newTenant);

        if (currentTenantType.Name == TenantTypeEnum.Booth)
        {
            var newTenantBooth = new TenantBoothDetail()
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                BoothNum = requestDto.BoothNum,
            };
            await _context.TenantBoothDetails.AddAsync(newTenantBooth);

        }
        if (currentTenantType.Name == TenantTypeEnum.SpaceOnly)
        {
            var newTenantBooth = new TenantSpaceDetail()
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                AreaSm = requestDto.AreaSm ?? 0,
            };
            await _context.TenantSpaceDetails.AddAsync(newTenantBooth);
        }

        await _context.SaveChangesAsync();

        return requestDto;
    }

    public async Task<List<TenantResponseDto>> GetTenants(string search)
    {
        var listOfTenantResponseDto = new List<TenantResponseDto>();
        var query = _context.Tenants
            .Include(e => e.TenantType)
            .Include(e => e.TenantBoothDetail)
            .Include(e => e.TenantSpaceDetail)
            .AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(e => e.TenantName.ToLower().Contains(search.ToLower()));
        }

        var currentListOfTenants = await query.ToListAsync();

        foreach (var tenant in currentListOfTenants)
        {
            var newSingleTenant = new TenantResponseDto()
            {
                Id = tenant.Id,
                TenantName = tenant.TenantName,
                TenantType = tenant.TenantType.Name,
                TenantPhone = tenant.TenantPhone,
                TenantAddress = tenant.TenantAddress,
            };

            if (newSingleTenant.TenantType == TenantTypeEnum.Booth)
                newSingleTenant.TenantDetail = tenant.TenantBoothDetail.BoothNum;

            if (newSingleTenant.TenantType == TenantTypeEnum.SpaceOnly)
                newSingleTenant.TenantDetail = tenant.TenantSpaceDetail.AreaSm.ToString();

            listOfTenantResponseDto.Add(newSingleTenant);
        }

        return listOfTenantResponseDto;
    }

    public async Task<List<TenantTypeDto>> GetTenantTypes()
    {
        return await _context.TenantTypes
            .Select(e => e.ToResponseDto())
            .ToListAsync();
    }

    private async Task<TenantType?> CheckTenantTypeExist(Guid requestedTenantId)
    {
        var listOfTenantTypeId = await _context.TenantTypes.ToListAsync();
        if (listOfTenantTypeId.Select(e => e.Id).Contains(requestedTenantId))
        {
            var requestedTenant = listOfTenantTypeId.FirstOrDefault(e => e.Id == requestedTenantId);
            return requestedTenant;
        }
        return null;
    }
}

public static class TenantTypeEnum
{
    public static string FoodTruck => "Food Truck";
    public static string Booth => "Booth";
    public static string SpaceOnly => "Space Only";
}
