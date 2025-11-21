using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TenantProject.Model.Entity;

[Table("tenant")]
public class Tenant
{
    public Guid Id { get; set; }
    public string TenantName { get; set; }

    public Guid TenantTypeId { get; set; }

    public string TenantPhone { get; set; }
    public string TenantAddress { get; set; }

    [JsonIgnore]
    public TenantType TenantType { get; set; }
    [JsonIgnore]
    public TenantBoothDetail TenantBoothDetail { get; set; }
    [JsonIgnore]
    public TenantSpaceDetail TenantSpaceDetail { get; set; }
}
