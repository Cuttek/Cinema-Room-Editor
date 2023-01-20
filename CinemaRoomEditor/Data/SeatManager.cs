using DataAccessLibrary.Models;
using System.Text.Json;

namespace CinemaRoomEditor.Data
{
    public class SeatManager
    {
        private List<SeatModel>? seats;
        public SeatManager()
        {
            seats = new List<SeatModel>();
        }
        public SeatManager(string json)
        {
            SetSeatsJson(json);
        }
        public void DeleteSeat(int column, int row)
        {
            DeleteSeat(FindSeatAtLocation(column, row));
        }
        public void DeleteSeat(SeatModel? seat)
        {
            if (seat is null) return;
            if (seat.BindedSeats != null)
            {
                foreach (Position location in seat.BindedSeats)
                {
                    SeatModel? s = FindSeatAtLocation(location.x, location.y);
                    NullifySeat(s);
                }
            }
            NullifySeat(seat);
        }
        void NullifySeat(SeatModel? seat)
        {
            if (seat == null || seats == null) return;
            seats.Remove(seat);
        }
        public void AddSeat(SeatModel seat)
        {
            if (seat == null || seats == null) return;
            seats.Add(seat);
        }


        public SeatModel? FindSeatAtLocation(int column, int row)
        {
            if (seats == null) return null;
            return seats.Find(s => s.Col == column && s.Row == row);
        }

        //JSON
        public string GetSeatsJson() => JsonSerializer.Serialize(seats);
        public void SetSeatsJson(string json)
        {
            if (json != null)
            {
                seats = (List<SeatModel>?)JsonSerializer.Deserialize(json, typeof(List<SeatModel>));
            }
        }
        public void InitSeats() => seats = new List<SeatModel>();
        public List<SeatModel>? GetSeats() => seats;
    }

}
