using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using shoestore.Models;

namespace shoestore.Repositories
{
  public class ShoeRepository
  {

    private readonly IDbConnection _db;

    public ShoeRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Shoe> GetAll()
    {
      return _db.Query<Shoe>("SELECT * FROM Shoes");
    }

    public Shoe GetById(int id)
    {
      return _db.QueryFirstOrDefault<Shoe>($"SELECT * FROM Shoes WHERE id = @id", new { id });
    }

    public Shoe EditShoe(int id, Shoe newshoe)
    {
      try
      {
        return _db.QueryFirstOrDefault<Shoe>($@"
          UPDATE Shoes SET
            Price = @Price,
            Brand = @Brand,
            Size = @Size,
            Style = @Style
          WHERE Id = @Id;
          SELECT * FROM Shoes WHERE id = @Id;
        ", newshoe);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }


    // public Shoe AddShoe(Shoe newshoe)
    // {
    //   FakeDB.Shoes.Add(newshoe);
    //   return newshoe;
    // }


    // public bool DeleteShoe(int id)
    // {
    //   try
    //   {
    //     FakeDB.Shoes.Remove(FakeDB.Shoes[id]);
    //     return true;
    //   }
    //   catch (Exception ex)
    //   {
    //     Console.WriteLine(ex);
    //     return false;
    //   }
    // }








  }
}