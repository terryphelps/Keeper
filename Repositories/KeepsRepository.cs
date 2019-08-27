using System.Data;
using System.Collections.Generic;
using keepr.Models;
using Dapper;
using System;
using System.Linq;

namespace keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Keep Create(Keep keep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO keeps (name, description, userid, img, isprivate) VALUES (@Name, @Description, @UserId, @Img, @IsPrivate);
      SELECT LAST_INSERT_ID()", keep);
      keep.Id = id;
      return keep;
    }
    public Keep Update(Keep keep)
    {
      int id = _db.ExecuteScalar<int>(@"
     UPDATE keeps (name, description, img, isprivate) VALUES (@Name, @Description, @Img, @IsPrivate);
      SELECT LAST_INSERT_ID()", keep);
      keep.Id = id;
      return keep;
    }

    public bool Delete(int id)
    {
      int success = _db.Execute(@"
        DELETE FROM keeps WHERE id = @id
      ", new { id });
      return success > 0;
    }

    public List<Keep> FindByUserId(string id)
    {
      return _db.Query<Keep>(@"
      SELECT * FROM keeps WHERE userid = @UserId
      ", new { id }).ToList();
    }
    public Keep FindKeepById(int id)
    {
      return _db.Query<Keep>(@"
      SELECT * FROM keeps WHERE id = @id
      ", new { id }).FirstOrDefault();
    }
    public List<Keep> Find()
    {
      return _db.Query<Keep>(@"
      SELECT * FROM keeps
      ").ToList();
    }
  }
}

// -- -- USE THIS LINE FOR GET KEEPS BY VAULTID
// -- SELECT* FROM vaultkeeps vk
// -- INNER JOIN keeps k ON k.id = vk.keepId
// -- WHERE (vaultId = @vaultId AND vk.userId = @userId)
