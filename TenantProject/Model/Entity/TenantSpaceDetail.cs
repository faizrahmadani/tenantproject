using System.ComponentModel.DataAnnotations.Schema;

namespace TenantProject.Model.Entity;

[Table("tenant_space_detail")]
public class TenantSpaceDetail
{
    public Guid Id { get; set; }

    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; }

    public string AreaSm { get; set; }
}
