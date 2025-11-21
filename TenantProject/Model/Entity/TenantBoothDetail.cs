using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TenantProject.Model.Entity;

[Table("tenant_booth_detail")]
public class TenantBoothDetail
{
    public Guid Id { get; set; }

    public Guid TenantId { get;set; }
    [JsonIgnore]
    public Tenant Tenant { get; set; }

    public string BoothNum { get; set; }
}
