using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
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
    internal VaultKeep Create(VaultKeep vaultKeep)
    {
      string sql = @"
        INSERT INTO vaultkeeps
            (vaultId, keepId, userId)
            VALUES
            (@VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID();
            ";

      vaultKeep.Id = _db.ExecuteScalar<int>(sql, vaultKeep);
      return vaultKeep;
    }

    internal bool Delete(int id, string UserId)
    {
      string sql = @"
      DELETE FROM vaultkeeps WHERE (id = @id AND userId = @userId);";
      _db.Execute(sql, new { id, UserId });
      return true;
    }

    internal VaultKeep getvaultkeep(int Id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @Id;";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { Id });
    }

    internal IEnumerable<VaultKeepViewModel> getKeepByVaultId(int id, string userId)
    {
      string sql = @"
       SELECT 
         k.*,
         vk.id as vaultKeepId
       FROM vaultkeeps vk
       INNER JOIN keeps k ON k.id = vk.keepId 
       WHERE (vaultId = @id AND vk.userId = @userId); ";

      return _db.Query<VaultKeepViewModel>(sql, new { id, userId });
    }
  }
}