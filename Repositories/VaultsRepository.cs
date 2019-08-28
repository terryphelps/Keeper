using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Vault Create(Vault vault)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaults (name, description, userId) VALUES (@Name, @Description, @UserId);
      SELECT LAST_INSERT_ID()", vault);
      vault.Id = id;
      return vault;
    }

    // public Vault Update(Vault vault)
    // {
    //   int id = _db.ExecuteScalar<int>(@"
    //   UPDATE vaults (name, description, userid) VALUES (@Name, @Description, @UserId);
    //   SELECT LAST_INSERT_ID()", vault);
    //   vault.Id = id;
    //   return vault;
    // }
    public bool Delete(int id)
    {
      int success = _db.Execute(@"
      DELETE FROM vaults WHERE id = @id
      ", new { id });
      return success > 0;
    }

    public List<Vault> FindByUserId(string userId)
    {
      return _db.Query<Vault>(@"
      SELECT * FROM vaults WHERE userid = @UserId
      ", new { userId }).ToList();
    }

    public Vault FindVaultById(int id)
    {
      return _db.Query<Vault>(@"
      SELECT * FROM vaults WHERE id = @id
      ", new { id }).FirstOrDefault();
    }

    public List<Vault> Find()
    {
      return _db.Query<Vault>(@"
      SELECT * FROM vaults
      ").ToList();
    }
  }
}