using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TenantProject.Model.Entity;

[Table("tenant_space_detail")]
public class TenantSpaceDetail
{
    public Guid Id { get; set; }

    public Guid TenantId { get; set; }
    public int AreaSm { get; set; }

    [JsonIgnore]
    public Tenant Tenant { get; set; }
}
