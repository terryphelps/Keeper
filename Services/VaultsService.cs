

using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    public Vault Create(Vault vault)
    {
      return _repo.Create(vault);
    }
    public Vault Update(Vault vault)
    {
      return _repo.Update(vault);
    }
    public bool Delete(int id)
    {
      return _repo.Delete(id);
    }
    public List<Vault> FindByUserId(string id)
    {
      return _repo.FindByUserId(id);
    }
    public Vault FindVaultById(int id)
    {
      return _repo.FindVaultById(id);
    }
    public List<Vault> Find()
    {
      return _repo.Find();
    }
  }
}