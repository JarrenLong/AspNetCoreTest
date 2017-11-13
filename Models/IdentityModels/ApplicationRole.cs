using Microsoft.AspNetCore.Identity;
using System;

namespace MnkyTv.Models.IdentityModels
{
  public class ApplicationRole : IdentityRole<string>
  {
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public string IPAddress { get; set; }
  }
}
