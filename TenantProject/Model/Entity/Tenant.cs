using System.ComponentModel.DataAnnotations.Schema;

namespace TenantProject.Model.Entity;

[Table("tenant")]
public class Tenant
{
    public Guid Id { get; set; }
    public string TenantName { get; set; }

    public Guid TenantTypeId { get; set; }
    public TenantType TenantType { get; set; }

    public string TenantPhone { get; set; }
    public string TenantAddress { get; set; }
}
