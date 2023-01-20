using DataAccessLibrary.Models;
using System.Reflection;

namespace CinemaRoomEditor.Data
{
    public class SeatPlacer
    {
        public delegate void _Handler(int startRow, int endRow, int startColumn, int endColumn);
        private _Handler? Handler { get; set; }
        public void Handle(SeatManager _seatManager,int startRow, int endRow, int startColumn,int endColumn)
        {
            if(Handler != null && _seatManager!=null)
            {
                seatManager = _seatManager;
                Handler(startRow, endRow, startColumn, endColumn);
            }
            

        }
        Func<int> GetColNum;
        SeatManager? seatManager;
        public SeatPlacer(Func<int> getColNum)
        {
            Handler = null;
            GetColNum = getColNum;
        }
        public bool SetHandler(string handler)
        {
            if (handler == null)
            {
                Handler = null;
                return true;
            }
            MethodInfo? mi = typeof(SeatPlacer).GetMethod(handler, BindingFlags.NonPublic | BindingFlags.Instance);
            if (mi != null)
            {
                Handler = (_Handler)mi.CreateDelegate(typeof(_Handler), this);
                return true;
            }
            return false;
        }
        private void None(int startRow, int endRow, int startColumn, int endColumn)
        {
            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startColumn; j <= endColumn; j++)
                {
                    seatManager.DeleteSeat(j, i);
                    //seatManager.AddSeat(new SeatModel(j, i, SeatType.None));
                }
            }

        }
        private void Single(int startRow, int endRow, int startColumn, int endColumn)
        {
            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startColumn; j <= endColumn; j++)
                {
                    seatManager.DeleteSeat(j, i);
                    seatManager.AddSeat(new SeatModel(j, i));
                }
            }

        }
        private void Double(int startRow, int endRow, int startColumn, int endColumn)
        {
            SeatModel? seat1, seat2;
            if (GetColNum()-1 <= endColumn) endColumn--;
            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startColumn; j <= endColumn; j += 2)
                {
                    seat1 = new SeatModel(j, i, new List<Position>(), SeatType.Double_Left);
                    seatManager.DeleteSeat(j, i);
                    seatManager.DeleteSeat(j + 1, i);
                    seat2 = new SeatModel(j + 1, i, new List<Position> { new Position(seat1.Col, seat1.Row) }, SeatType.Double_Right);
                    seat1.BindedSeats.Add(new Position(seat2.Col, seat2.Row));
                    seatManager.AddSeat(seat1);
                    seatManager.AddSeat(seat2);

                }
            }

        }
        private void Single_Accessible(int startRow, int endRow, int startColumn, int endColumn)
        {
            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startColumn; j <= endColumn; j++)
                {
                    seatManager.DeleteSeat(j, i);
                    seatManager.AddSeat(new SeatModel(j, i, SeatType.Single_Accessible));
                }
            }

        }

    }
}
