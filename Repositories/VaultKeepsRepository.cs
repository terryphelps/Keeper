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
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaultKeep (vaultId, keepId, userId) VALUES(@VaultId, @KeepId, @UserId)
      SELECT LAST_INSERT_ID()", vaultKeep);
      vaultKeep.Id = id;
      return vaultKeep;
    }
    public bool Delete(int id)
    {
      int success = _db.Execute(@"
       DELETE FROM vaultKeep WHERE id = @id
       ", new { id });
      return success > 0;
    }

    public List<VaultKeep> FindKeepsById(int id)
    {
      return _db.Query<VaultKeep>(@"
        SELECT * FROM vaultkeeps vk
        INNER JOIN keeps k ON k.id = vk.keepId
        WHERE (vaultId = @vaultId AND vk.userId = @userId)
        ").ToList();
    }
  }
}