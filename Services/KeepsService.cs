using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }

    internal Keep Get(int id)
    {
      return _repo.Get(id);
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }
    public IEnumerable<Keep> GetByVaultId(int id, string userId)
    {
      return _repo.GetByVaultId(id, userId);
    }

    public Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }

    internal object Delete(int id, string userId)
    {
      return _repo.Delete(id, userId);
    }



    internal Keep Edit(Keep editKeep)
    {
      Keep original = Get(editKeep.Id);
      original.Name = editKeep.Name == null ? original.Name : editKeep.Name;
      original.Description = editKeep.Description == null ? original.Description : editKeep.Description;
      original.Img = editKeep.Img;
      original.IsPrivate = editKeep.IsPrivate != original.IsPrivate ? editKeep.IsPrivate : original.IsPrivate;
      original.Views = editKeep.Views > original.Views ? editKeep.Views : original.Views;
      original.Shares = editKeep.Shares > original.Shares ? editKeep.Shares : original.Shares;
      original.Keeps = editKeep.Keeps > original.Keeps ? editKeep.Keeps : original.Keeps;
      return _repo.Edit(original);
    }
  }
}
