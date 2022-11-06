using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    [Serializable]
    public class SeatModel
    {
        public SeatModel(int x,int y, List<SeatModel>? bindedSeats)
        {
            Id = IdCounter++;
            X = x;
            Y = y;
            BindedSeats = bindedSeats;
        }

        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        static private int IdCounter=0;
        public List<SeatModel>? BindedSeats { get; private set; }
        

        
    }
}
