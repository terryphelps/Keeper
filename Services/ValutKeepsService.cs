using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    public VaultKeep Create(VaultKeep vaultKeep)
    {
      return _repo.Create(vaultKeep);
    }
    public IEnumerable<Keep> FindVaultKeepsById(int id, string userId)
    {
      return _repo.FindVaultKeepsById(id, userId);
    }
    public VaultKeep Delete(VaultKeep vaultKeep)
    {
      return _repo.Delete(vaultKeep);
    }
  }
}