using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    [Serializable]
    public class SeatModel
    {
        [JsonConstructor]
        public SeatModel(int col, int row, List<Position> bindedSeats,SeatType seatType)
        {
            //Id = IdCounter++;
            Col = col;
            Row = row;
            BindedSeats = bindedSeats;
            SeatType = seatType;
        }
        public SeatModel(int col,int row, SeatType seatType)
        {
            Col = col;
            Row = row;
            BindedSeats = new List<Position>();
            SeatType = seatType;
        }
        public SeatModel(int x, int y)
        {
            //Id = IdCounter++;
            Col = x;
            Row = y;
            BindedSeats = new List<Position>();
            SeatType = SeatType.Single;
        }
        //public int Id { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }
        //static private int IdCounter=0;
        public List<Position> BindedSeats { get; private set; }
        public SeatType SeatType { get; set; }



    }
    [Serializable]
    public struct Position
    {
        public int x { get; set; }
        public int y { get; set; }
        public Position(int _x,int _y)
        {
            x = _x;
            y = _y;
        }
    }
    public enum SeatType
    {
        None,
        Single,
        Double_Left,
        Double_Right,
        Single_Accessible
    }
}
