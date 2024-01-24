

using ZeroToHero.Interfaces.Chess.Services.Implementations;
using ZeroToHero.Interfaces.Chess.Services.Interfaces;

namespace ZeroToHero.Interfaces.Chess.Models
{
    public class Board : IBoard
    {
        public List<Tile> Squares { get; set; }

        public Board()
        {
            InitializeBoard();
            //DisabledAllExcept("A8,B8,C8,F8,G8,H8,E8,A1,C1,B1,F1,G1,H1,E1");
            DisabledAllExcept("E8,A1,C1,B1,F1,G1,H1,E1");

        }

        private void InitializeBoard()
        {
            Squares = [];

            // Initialize pieces for the starting position
            AddPiecesToRow(1, ChessPieceColor.White);
            AddPawnsToRow(2, ChessPieceColor.White);
            AddPawnsToRow(7, ChessPieceColor.Black);
            AddPiecesToRow(8, ChessPieceColor.Black);

            AddEmptySquares();
            SetBoardColors();
        }

        private void AddEmptySquares()
        {
            // Generate empty tiles for the rest of the board
            for (char file = 'A'; file <= 'H'; file++)
            {
                for (int rank = 3; rank <= 6; rank++)
                {
                    Squares.Add(new Tile($"{file}{rank}"));
                }
            }
        }

        private void DisabledAllExcept(string position)
        {
            var positions = position.Split(',');
            foreach (var square in Squares)
            {
                if(!positions.Contains(square.Position))
                {
                    square.Piece = null;
                }
            }
        }
        private void AddPiecesToRow(int row, ChessPieceColor color)
        {
            Squares.Add(new Tile($"A{row}", new Rook(color)));
            Squares.Add(new Tile($"B{row}", new Knight(color)));
            Squares.Add(new Tile($"C{row}", new Bishop(color)));
            Squares.Add(new Tile($"D{row}", new Queen(color)));
            Squares.Add(new Tile($"E{row}", new King(color)));
            Squares.Add(new Tile($"F{row}", new Bishop(color)));
            Squares.Add(new Tile($"G{row}", new Knight(color)));
            Squares.Add(new Tile($"H{row}", new Rook(color)));
        }

        private void AddPawnsToRow(int row, ChessPieceColor color)
        {
            for (char file = 'A'; file <= 'H'; file++)
            {
                Squares.Add(new Tile($"{file}{row}", new Pawn(color)));
            }
        }

        private int GetTileIndex(string position)
        {
            return Squares.FindIndex(tile => tile.Position == position);
        }

        public Tile GetTile(string position)
        {
            var tile = Squares.FirstOrDefault(tile => tile.Position == position);
            return tile;    
        }

        public void SetTile(string position, Tile tile)
        {
            var tileIndex = GetTileIndex(position);
            Squares[tileIndex] = tile;
        }

        public void SelectTile(string position)
        {
            foreach (var square in Squares)
            {
                square.IsSelected = square.Position == position;
            }
        }
        public bool IsTileControlledBy(string position, ChessPieceColor color)
        {
            var tile = GetTile(position);
            if (tile == null)
            {
                return false;
            }
            var friendlyPieces = Squares.Where(square => square.IsOccupiedBy(color));
            foreach (var friendlyPiece in friendlyPieces)
            {
                var availableMoves = friendlyPiece.Piece.GetPossibleMoves(this);
                foreach (var move in availableMoves)
                {
                    if (move.DestinationPosition == position)
                    {
                        return true;
                    }
                }
            }
          
            return false;
        }
        public void DeselectAllTiles()
        {
            foreach (var square in Squares)
            {
                square.IsSelected = false;
            }
        }

        public IBoard Copy()
        {
            return new Board
            {
                Squares = Squares.Select(tile => new Tile(tile.Position, tile.Piece, tile.IsDark)
                {
                    IsSelected = tile.IsSelected
                }).ToList()
            };
        }


        private void SetBoardColors()
        {
            // Generate empty tiles for the rest of the board
            for (char file = 'A'; file <= 'H'; file++)
            {
                for (int rank = 1; rank <= 8; rank++)
                {
                    bool isDark = (file - 'A' + rank) % 2 == 0;
                    var position = $"{file}{rank}";
                    var tile = GetTile(position);
                    tile.IsDark = isDark;
                    SetTile(position, tile);
                }
            }
        }

        public IEnumerable<Tile> GetChessPiecesByColor(ChessPieceColor color)
        {
            return Squares.Where(square => square.IsOccupiedBy(color)).ToArray();
        }
    }
}
