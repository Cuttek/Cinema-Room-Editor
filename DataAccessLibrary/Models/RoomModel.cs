using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    [Serializable]
    public class RoomModel
    {
        public int Id { get; set; }
        public int NumColumns { get; set; }
        public int NumRows { get; set; }
        public string Name { get; set; }
        //public List<SeatModel>? Seats { get; set; }
        public string? SeatsJson { get; set; }
    }
}
