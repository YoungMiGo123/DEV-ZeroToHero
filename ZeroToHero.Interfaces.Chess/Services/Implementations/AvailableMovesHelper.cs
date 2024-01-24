using System.Globalization;
using ZeroToHero.Interfaces.Chess.Models;
using ZeroToHero.Interfaces.Chess.Services.Interfaces;

namespace ZeroToHero.Interfaces.Chess.Services.Implementations
{
    public class AvailableMovesHelper
    {
        public static bool IsMoveValid(IBoard board, int file, int rank, ChessPieceColor color)
        {
            // Check if the target square is within the board bounds
            char fileChar = (char)file;
            if (fileChar < 'A' || fileChar > 'H' || rank < 1 || rank > 8)
            {
                return false;
            }

            var targetTile = board.GetTile($"{(char)file}{rank}");

            return !targetTile.IsOccupied || targetTile.IsOccupiedBy(color);
        }
        public static void CheckDiagonalMoves(
           IBoard board,
           Tile currentTile,
           Direction direction,
           List<AvailableMove> availableMoves,
           ChessPieceColor color
        )
        {
            int fileChange = direction.FileChange;
            int rankChange = direction.RankChange;

            int newFile = currentTile.Position[0] + fileChange;
            int newRank = int.Parse($"{currentTile.Position[1]}", CultureInfo.InvariantCulture) + rankChange;
            var opponentColor = color == ChessPieceColor.White ? ChessPieceColor.Black : ChessPieceColor.White;

            while (IsMoveValid(board, newFile, newRank, opponentColor))
            {
                string newPosition = $"{(char)newFile}{newRank}";

                if (board.GetTile(newPosition).IsOccupiedBy(opponentColor))
                {
                    // Stop further movement in this direction if there is a piece in the way
                    availableMoves.Add(new AvailableMove(newPosition, MoveType.Capture));
                    break;
                }

                availableMoves.Add(new AvailableMove(newPosition, MoveType.Regular));

                // Move further in the specified direction
                newFile += fileChange;
                newRank += rankChange;
            }
        }

        public static void CheckStraightMoves(
            IBoard board, 
            Tile currentTile, 
            Direction direction, 
            List<AvailableMove> availableMoves, 
            ChessPieceColor color
        )
        {
            int fileChange = direction.FileChange;
            int rankChange = direction.RankChange;

            int newFile = currentTile.Position[0] + fileChange;
            int newRank = int.Parse($"{currentTile.Position[1]}", CultureInfo.InvariantCulture) + rankChange;

            var opponentColor = color == ChessPieceColor.White ? ChessPieceColor.Black : ChessPieceColor.White;

            while (IsMoveValid(board, newFile, newRank, opponentColor))
            {
                string newPosition = $"{(char)newFile}{newRank}";

                if (board.GetTile(newPosition).IsOccupiedBy(opponentColor))
                {
                    availableMoves.Add(new AvailableMove(newPosition, MoveType.Capture));
                    break;
                }

                availableMoves.Add(new AvailableMove(newPosition, MoveType.Regular));

                // Move further in the specified direction
                newFile += fileChange;
                newRank += rankChange;
            }
        }

    }
}
