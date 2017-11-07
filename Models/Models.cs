using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace MnkyTv.Models
{
  // Add profile data for application users by adding properties to the ApplicationUser class
  public class ApplicationUser : IdentityUser
  {
    public bool CanLogin { get; set; }
  }

  public class ApplicationRole : IdentityRole
  {
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public string IPAddress { get; set; }
  }

  public class MediaRequest
  {
    public MediaRequest()
    {
      CreatedOn = DateTime.Now;
      MediaVotes = new List<MediaVote>();
    }

    public int ID { get; set; }
    //public int UserId { get; set; }
    public ApplicationUser User { get; set; }
    public DateTime CreatedOn { get; set; }
    public int MediaType { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public IEnumerable<MediaVote> MediaVotes { get; }
    public bool Complete { get; set; }
    public DateTime? CompletedOn { get; set; }
  }

  public class MediaVote
  {
    public MediaVote() { }

    public int ID { get; set; }

    public int? ApplicationUserID { get; set; }
    public ApplicationUser User { get; set; }

    public int? MediaRequestID { get; set; }
    public MediaRequest MediaRequest { get; set; }
  }
}
