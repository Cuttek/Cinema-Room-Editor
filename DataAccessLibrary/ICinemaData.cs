using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface ICinemaData
    {
        Task<List<RoomModel>> GetRooms();
        Task<int> InsertRoom(RoomModel sr);
        Task<int> UpdateRoom(RoomModel sr);
        Task<int> DeleteRoom(RoomModel sr);
    }
}