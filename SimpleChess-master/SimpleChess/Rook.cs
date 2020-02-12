namespace SimpleChess
{
    internal class Rook : Piece
    {
        public Rook() : base("TRN")
        {
        }

        public override bool Move(string fromPosition, string toPosition)
        {
            return fromPosition[0] == toPosition[0] || fromPosition[1] == toPosition[1];
        }
    }
}