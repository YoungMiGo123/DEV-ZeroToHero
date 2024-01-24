
using System.Diagnostics;

namespace ZeroToHero.Interfaces.Chess.Models
{
    [DebuggerDisplay("FileChange: {FileChange}, RankChange: {RankChange}, Direction: {DirectionName}")]
    public class Direction
    {
        public int FileChange { get; }
        public int RankChange { get; }
        public string DirectionName => GetDirectionName();

        private string GetDirectionName()
        {
            return (FileChange, RankChange) switch
            {
                (-1, -1) => "Diagonal to the top-left",
                (-1, 1) => "Diagonal to the top-right",
                (1, -1) => "Diagonal to the bottom-left",
                (1, 1) => "Diagonal to the bottom-right",
                (-1, 0) => "Horizontal to the left",
                (1, 0) => "Horizontal to the right",
                (0, -1) => "Vertical to the top",
                (0, 1) => "Vertical to the bottom",
                _ => "Unknown direction"
            };
        }

        public Direction()
        {

        }
        public Direction(int fileChange, int rankChange)
        {
            FileChange = fileChange;
            RankChange = rankChange;
        }
    }
}
