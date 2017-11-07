using Microsoft.AspNetCore.Identity;

namespace MnkyTv.Models.IdentityModels
{
  public class ApplicationUser : IdentityUser
  {
    public bool CanLogin { get; set; }
  }
}
