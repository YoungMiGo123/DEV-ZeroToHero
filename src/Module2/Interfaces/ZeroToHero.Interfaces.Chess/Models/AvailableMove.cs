using ZeroToHero.Interfaces.Chess.Services.Interfaces;

namespace ZeroToHero.Interfaces.Chess.Models
{
    public enum MoveType
    {
        Regular,
        Capture,
        None
    }

    public class AvailableMove
    {
        public string DestinationPosition { get; set; }
        public MoveType MoveType { get; set; }

        public AvailableMove()
        {
            
        }
        public AvailableMove(string destinationPosition, MoveType moveType)
        {
            DestinationPosition = destinationPosition;
            MoveType = moveType;
        }
    }
}
