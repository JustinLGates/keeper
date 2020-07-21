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
    internal Keep FindById(int id)
    {
      return _repo.findKeep(id);
    }

    internal Keep Get(int id, string userId)
    {
      Keep found = FindById(id);
      if (found == null)
      {
        throw new Exception("could not find keep");
      }
      if (found.UserId != userId && found.IsPrivate == true)
      {
        throw new Exception("this is not yours...");
      }
      return found;


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
      Keep found = Get(id, userId);
      if (found == null)
      {
        throw new NullReferenceException("keep id is no good..");
      }
      if (found.UserId == userId)
      {
        return _repo.Delete(id, userId);
      }
      throw new Exception("hmmm something dosnt add up..");
    }



    internal Keep Edit(Keep editKeep)
    {
      Keep original = FindById(editKeep.Id);
      if (original.UserId == editKeep.UserId)
      {
        original.Name = editKeep.Name == null ? original.Name : editKeep.Name;
        original.Description = editKeep.Description == null ? original.Description : editKeep.Description;
        original.Img = editKeep.Img;
        original.IsPrivate = editKeep.IsPrivate != original.IsPrivate ? editKeep.IsPrivate : original.IsPrivate;
        original.Views = editKeep.Views > original.Views ? editKeep.Views : original.Views;
        original.Shares = editKeep.Shares > original.Shares ? editKeep.Shares : original.Shares;
        original.Keeps = editKeep.Keeps > original.Keeps ? editKeep.Keeps : original.Keeps;

        return _repo.Edit(original);
      }
      throw new Exception("something went wrong");
    }

    internal IEnumerable<Keep> GetByUserId(string userId)
    {

      return _repo.GetAllUserKeeps(userId);
    }
  }
}
