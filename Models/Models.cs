using MnkyTv.Models.IdentityModels;
using System;
using System.Collections.Generic;

namespace MnkyTv.Models
{
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
