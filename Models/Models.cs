using MnkyTv.Models.IdentityModels;
using System;
using System.Collections.Generic;

namespace MnkyTv.Models
{
  public abstract class DbTable
  {
    public int ID { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }

    public DbTable()
    {
      ID = 0;
      CreatedOn = DateTime.Now;
      DeletedOn = null;
    }

    public bool IsDeleted { get { return DeletedOn != null; } }

    public void Delete()
    {
      DeletedOn = DateTime.Now;
    }
    public void Undelete()
    {
      DeletedOn = null;
    }
  }

  public class MediaRequest : DbTable
  {
    public MediaRequest() : base()
    {
      MediaVotes = new List<MediaVote>();
    }

    //public int UserId { get; set; }
    public ApplicationUser User { get; set; }
    public int MediaType { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public IEnumerable<MediaVote> MediaVotes { get; }
    public bool IsComplete { get { return CompletedOn != null; } }
    public DateTime? CompletedOn { get; set; }
  }

  public class MediaVote : DbTable
  {
    public MediaVote() : base() { }

    public ApplicationUser User { get; set; }
    public MediaRequest MediaRequest { get; set; }
  }
}
