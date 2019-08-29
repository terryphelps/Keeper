using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public VaultKeep Create(VaultKeep vaultKeep)
    {
      // var vaultId = vaultKeep.VaultId;
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaultKeeps (vaultId, keepId, userId) VALUES(@VaultId, @KeepId, @UserId);
      SELECT LAST_INSERT_ID()", vaultKeep);
      vaultKeep.Id = id;
      return vaultKeep;
    }
    public VaultKeep Delete(VaultKeep vaultKeep)
    {
      var id = _db.Execute(@"
       DELETE FROM vaultKeeps WHERE vaultId = @VaultId AND keepId = @KeepId AND userId = @UserId
       ", vaultKeep);
      vaultKeep.Id = id;
      return vaultKeep;
    }

    public IEnumerable<VaultKeep> FindVaultKeepsById(int vaultId, string userId)
    {
      string query = @"
        SELECT * FROM vaultkeeps vk
        INNER JOIN keeps k ON k.id = vk.keepId
        WHERE (vaultId = @vaultId AND vk.userId = @userId);
        ";
      return _db.Query<VaultKeep>(query, new { vaultId, userId });
    }
  }
}