using System.ComponentModel.DataAnnotations;

namespace TenantProject.Model.DTO;

public class TenantRequestDto
{
    [Required]
    public string TenantName { get; set; }
    [Required]
    public Guid TenantTypeId { get; set; }
    [Required]
    public string TenantPhone { get; set; }
    [Required]
    public string TenantAddress { get; set; }
    public string? BoothNum { get; set; }
    public int? AreaSm { get; set; }
}
