using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Keep> GetByVaultId(int VaultId, string UserId)
    {
      string sql = @"
      SELECT 
        k.*,
        vk.id as vaultKeepId
      FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId 
      WHERE (vaultId = @VaultId AND vk.userId = @UserId); ";

      return _db.Query<Keep>(sql, new { VaultId, UserId });
    }

    internal IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
      return _db.Query<Keep>(sql);
    }

    internal Keep Edit(Keep editKeep)
    {
      string sql = @"
        UPDATE keeps
        SET
            name = @Name,
            description = @Description,
            img = @Img,
            isPrivate = @IsPrivate,
            views = @Views,
            shares = @Shares,
            keeps = @Keeps
        WHERE id = @Id;
        SELECT * FROM keeps WHERE id = @Id && userId = @UserId;";
      return _db.QueryFirstOrDefault<Keep>(sql, editKeep);
    }

    internal Keep Get(int id, string userId)
    {
      string sql = "SELECT * FROM Keeps WHERE id = @id;";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }

    internal Keep Create(Keep KeepData)
    {
      string sql = @"
        INSERT INTO keeps
            (name, description, userId, img, isPrivate)
            VALUES
            (@Name, @Description, @UserId, @Img, @IsPrivate);
            SELECT LAST_INSERT_ID();
            ";
      KeepData.Id = _db.ExecuteScalar<int>(sql, KeepData);
      return KeepData;
    }
    internal bool Delete(int Id, string UserId)
    {
      string sql = "DELETE FROM Keeps WHERE  id = @Id && userId = @UserId";
      int changed = _db.Execute(sql, new { Id, UserId });
      return changed == 1;
    }
  }
}