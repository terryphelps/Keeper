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
      INSERT INTO keeps (name, description, userId, img, isPrivate) VALUES (@Name, @Description, @UserId, @Img, @IsPrivate);
      SELECT LAST_INSERT_ID()", keep);
      keep.Id = id;
      return keep;
    }

    public bool Delete(int id, string userId)
    {
      int success = _db.Execute(@"
        DELETE FROM keeps WHERE id = @id
      ", new { id });
      return success > 0;
    }

    public List<Keep> FindByUserId(string userId)
    {
      return _db.Query<Keep>(@"
      SELECT * FROM keeps WHERE userId = @UserId
      ", new { userId }).ToList();
    }
    public Keep FindKeepById(int id)
    {

      return _db.Query<Keep>(@"
      SELECT * FROM keeps WHERE id = @id AND isPrivate = 0
      ", new { id }).FirstOrDefault();
    }
    public List<Keep> Find()
    {
      return _db.Query<Keep>(@"
      SELECT * FROM keeps WHERE isPrivate = 0
      ").ToList();
    }

    //TODO ADD A METHOD FOR UPDATING A KEEP

  }
}

// -- -- USE THIS LINE FOR GET KEEPS BY VAULTID
// -- SELECT* FROM vaultkeeps vk
// -- INNER JOIN keeps k ON k.id = vk.keepId
// -- WHERE (vaultId = @vaultId AND vk.userId = @userId)