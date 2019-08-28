using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public Keep Create(Keep keep)
    {
      return _repo.Create(keep);
    }
    // public Keep Update(Keep keep)
    // {
    //   return _repo.Update(keep);
    // }

    public bool Delete(int id)
    {
      return _repo.Delete(id);
    }
    public List<Keep> FindByUserId(string userId)
    {
      return _repo.FindByUserId(userId);
    }
    public Keep FindKeepById(int id)
    {
      return _repo.FindKeepById(id);
    }
    public List<Keep> Find()
    {
      return _repo.Find();
    }
  }
}