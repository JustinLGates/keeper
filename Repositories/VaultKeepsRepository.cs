using System.Data;
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
  }
}