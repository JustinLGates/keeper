using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using Keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal VaultKeeps Create(VaultKeeps newVaultKeeps)
    {
      string sql = @"
        INSERT INTO vaultkeeps
            (vaultId, keepId, userId)
            VALUES
            (@VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID();
            ";
      newVaultKeeps.Id = _db.ExecuteScalar<int>(sql, newVaultKeeps);
      return newVaultKeeps;
    }



    internal IEnumerable<Keep> getKeepByVaultId(Vault vault)
    {
      string sql = @"
      SELECT 
        k.*,
        vk.id as vaultKeepId
      FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId 
      WHERE (vaultId = @VaultId AND vk.userId = @UserId); ";

      return _db.Query<Keep>(sql, vault);
    }


  }
}