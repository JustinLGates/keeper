using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
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
    internal IEnumerable<Vault> Get(string userId)
    {
      string sql = "SELECT * FROM vaults WHERE userId = @userId;";
      return _db.Query<Vault>(sql, new { userId });
    }
    internal Vault Create(Vault vaultData)
    {
      string sql = @"
        INSERT INTO vaults
            (name, description, userId)
            VALUES
            (@Name, @Description, @UserId);
            SELECT LAST_INSERT_ID();
            ";
      vaultData.Id = _db.ExecuteScalar<int>(sql, vaultData);
      return vaultData;
    }

    internal Vault GetById(int id, string userId)
    {
      string sql = "SELECT * FROM vaults WHERE id = @id && userId = @userId;";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id, userId });
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM Vaults WHERE  id = @id";
      int changed = _db.Execute(sql, new { id });
      return changed == 1;
    }
  }
}
