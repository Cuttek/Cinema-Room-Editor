using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class CinemaData : ICinemaData
    {
        private readonly ISqlDataAccess _db;
        private string database = "dbo.ScreeningRooms";
        public CinemaData(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<RoomModel>> GetRooms()
        {
            string sql = $"select * from {database}";

            return _db.LoadData<RoomModel, dynamic>(sql, new { });
        }
        public Task<int> InsertRoom(RoomModel sr)
        {
            string sql = @$"insert into {database} (Name, Width,Height,SeatsJson)
                        values (@Name, @Width,@Height,@SeatsJson)";
            return _db.SaveData(sql, sr);
        }
        
        public Task<int> UpdateRoom(RoomModel sr)
        {
            string sql = @$"UPDATE {database} SET Name=@Name, Width=@Width,Height=@Height,SeatsJson=@SeatsJson WHERE Id=@Id";
            return _db.SaveData(sql, sr);
        }
        public Task<int> DeleteRoom(RoomModel sr)
        {
            string sql = @$"DELETE FROM {database} WHERE Id=@Id";
            return _db.SaveData(sql, sr);
        }

    }
}
