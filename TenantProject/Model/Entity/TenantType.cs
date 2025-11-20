using System.ComponentModel.DataAnnotations.Schema;

namespace TenantProject.Model.Entity;

[Table("tenant_type")]
public class TenantType
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Tenant Tenant { get; set; }
}
