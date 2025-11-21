using System.ComponentModel.DataAnnotations.Schema;
using TenantProject.Model.DTO;

namespace TenantProject.Model.Entity;

[Table("tenant_type")]
public class TenantType
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Tenant>? Tenants { get; set; }

    public TenantTypeDto ToResponseDto()
    {
        return new TenantTypeDto()
        {
            Id = Id,    
            Name = Name,
        };
    }
}
