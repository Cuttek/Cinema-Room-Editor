using CinemaCreatorApp.Components;
using CinemaCreatorApp.Pages;
using DataAccessLibrary.Models;
using System.Numerics;
using System.Text.Json;

namespace CinemaCreatorApp.Data
{
    public class CreatorStateService : ICreatorStateService
    {

        public string? SelectedType { get; private set; }
        public Cell? SelectedCell { get; private set; }
        public List<SeatModel> seats = new List<SeatModel>();
        public List<List<Cell>> cells = new List<List<Cell>>();


        public void SetSeatType(string type)
        {
            SelectedType = type;
        }
        public void ClickedSeat(Cell cell)
        {
            if (cell is null) return;
            SelectedCell = cell;
            if(cell.ContainedSeat is not null)
            {
                DeleteSeat(cell.ContainedSeat);
                //cell.hasSeat = false;
            }
            else
            {

                seats.Add(new SeatModel(cell.column,cell.row,null));

                cell.SetContainedSeat(seats.Last());
                //cell.hasSeat = true;
                //cell.ContainedSeat.hostingCell = cell;
            }
            //Console.WriteLine(SelectedCell);
        }
        public void DeleteSeat(SeatModel seat)
        {
            if(seat is null) return;
            if(seat.BindedSeats!=null)
            {
                foreach (SeatModel s in seat.BindedSeats)
                {

                    NullifySeat(s);
                    
                }
            }
            NullifySeat(seat);

        }
        public void NullifySeat(SeatModel seat)
        {
            if (seat != null)
            {
                //foreach (Cell c in cells)
                //    if (c.ContainedSeat == seat)
                //    {
                //        c.ContainedSeat = null;
                //        c.hasSeat = false;
                //        //cells.Remove(c);
                //    }
                if (cells[seat.Y].Count >  seat.X && cells.Count >seat.Y)
                {
                    cells[seat.Y][seat.X].DeleteContainedSeat();
                    //cells[seat.Y][seat.X].hasSeat = false;
                        
                }
                if(seats.Find(e => e==seat)!=null)
                    seats.Remove(seat);
            }
        }
        public void InitializeSeats()
        {
            foreach(List<Cell> cellRows in cells)
            {
                foreach(Cell cell in cellRows)
                {
                    cell.DeleteContainedSeat();
                }  
            }
            seats = new List<SeatModel>();
        }
        public string GetSeatsJson()
        {
            return JsonSerializer.Serialize(seats);
        }
        public void SetSeatsJson(string json)
        {
            if(json!=null)
            {
                seats = (List<SeatModel>)JsonSerializer.Deserialize(json, typeof(List<SeatModel>));
                /*foreach (SeatModel seat in seats)
                {
                    Cell tempCell = cells.Find(c => c.row == seat.Y && c.column == seat.X);
                    if(tempCell!=null)
                    {
                        //cells.Add(tempCell);
                        tempCell.ContainedSeat = seat;
                        
                    }
                }
                */
            }
            //RefreshCellStates();

        }
        public SeatModel FindSeatAtLocation(int x, int y)
        {
            return seats.Find(s => s.X == x && s.Y == y);
        }
        public void SetCells(List<List<Cell>> _cells)
        {
            cells = _cells;
            //foreach (Cell cell in cells)
            //{
            //    if (FindSeatAtLocation(cell.column, cell.row) is not null)
            //    {
            //        cell.hasSeat = true;
            //    }
            //    else
            //    {
            //        cell.hasSeat = false;
            //    }
            //}
        }
        public void RefreshCellStates()
        {
            foreach(List<Cell> cellRows in cells)
            {
                foreach(Cell cell in cellRows)
                {
                    SeatModel seat = FindSeatAtLocation(cell.column, cell.row);
                    if (seat is not null)
                    {
                        cell.SetContainedSeat(seat);
                    }
                    else
                    {
                        cell.DeleteContainedSeat();
                    }
                }
            }
        }
    }
    public interface ICreatorStateService
    {
        public void SetSeatType(string type);
        public void ClickedSeat(Cell cell);
        public string GetSeatsJson();
        public void SetSeatsJson(string json);
        public void SetCells(List<List<Cell>> _cells);
        public void InitializeSeats();

        public void DeleteSeat(SeatModel seat);
        public SeatModel FindSeatAtLocation(int x, int y);
        public void RefreshCellStates();
    }
}
