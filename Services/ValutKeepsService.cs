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
    public bool Delete(int id)
    {
      return _repo.Delete(id);
    }
    public List<VaultKeep> FindKeepsById(int id)
    {
      return _repo.FindKeepsById(id);
    }
  }
}