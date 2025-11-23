using System.ComponentModel.DataAnnotations;

namespace TenantProject.Model.DTO;

public class TenantRequestDto
{
    [Required(ErrorMessage = "Tenant name cannot be empty")]
    [StringLength(50, MinimumLength = 4, ErrorMessage = "Name at least has to be 4 chars")]
    public string TenantName { get; set; }
    [Required(ErrorMessage = "Tenant type cannot be empty")]
    public string TenantTypeId { get; set; }
    [Required(ErrorMessage = "Tenant phone cannot be empty")]
    [StringLength(50, MinimumLength = 8, ErrorMessage = "Phone at least has to be 8 chars")]
    public string TenantPhone { get; set; }
    [Required(ErrorMessage = "Tenant address cannot be empty")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Address cannot be single char")]
    public string TenantAddress { get; set; }
    public string? BoothNum { get; set; }
    public int? AreaSm { get; set; }
}
