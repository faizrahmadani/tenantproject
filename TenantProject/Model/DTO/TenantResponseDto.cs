using Microsoft.OpenApi.Any;
using TenantProject.Model.Entity;

namespace TenantProject.Model.DTO;

public class TenantResponseDto
{
    public Guid Id { get; set; }
    public string TenantName { get; set; }
    public string TenantType { get; set; }
    public string TenantPhone { get; set; }
    public string TenantAddress { get; set; }
    public string? TenantDetail {  get; set; } = null;
}
