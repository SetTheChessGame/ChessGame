﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGame
{
    public enum ChessPieceSide
    {
        BLACK,
        WHITE
    }

    public class Board
    {

        public Player Blacklayer;
        public Player Whitelayer;
        public Player Curentlayer;
        public Dictionary<int, ChessPieces> ListChessPiece;
        public ChessPieceSide nextMoveChessPieceSide;
        public List<Cell> listCell;


        public Board(ChessPieceSide sidePlayFirst)
        {
            ListChessPiece = new Dictionary<int, ChessPieces>();
            CreateDefaultListPieceBoard();
            CreateCellBoard(sidePlayFirst);
        } 

        public Board SetPiece(ChessPieces piece)
        {
            this.ListChessPiece[piece.chessPiecePosition] = piece;
            return this;
        }

        public Board RemovePiece(ChessPieces piece)
        {
           // this.ListChessPiece[piece.chessPiecePosition] = null;
            this.ListChessPiece.Remove(piece.chessPiecePosition);
            return this;
        }

        public ChessPieces GetPiece(int position)
        {
            ChessPieces piece = null;
            return this.ListChessPiece.TryGetValue(position, out piece) ? piece : null;
        }

        public void SetNextPlayer()
        {
            this.Curentlayer = (this.Curentlayer.sideplayer == ChessPieceSide.BLACK) ? this.Whitelayer : this.Blacklayer;
        }

        public Cell GetCell(int position)
        {
            return listCell[position];
        }

        public Board CreateDefaultListPieceBoard()
        {
            //Black ChessPieceSide
            this.SetPiece(new Rook(0,ChessPieceType.ROOK, ChessPieceSide.BLACK));
            this.SetPiece(new Knight(1, ChessPieceType.KNIGHT, ChessPieceSide.BLACK));
            this.SetPiece(new Bishop(2, ChessPieceType.BISHOP, ChessPieceSide.BLACK));
            this.SetPiece(new Queen(3, ChessPieceType.QUEEN, ChessPieceSide.BLACK));
            this.SetPiece(new King(4, ChessPieceType.KING,ChessPieceSide.BLACK));
            this.SetPiece(new Bishop(5, ChessPieceType.BISHOP, ChessPieceSide.BLACK));
            this.SetPiece(new Knight(6, ChessPieceType.KNIGHT,ChessPieceSide.BLACK));
            this.SetPiece(new Rook(7, ChessPieceType.ROOK,ChessPieceSide.BLACK));
            this.SetPiece(new Pawn(8, ChessPieceType.PAW,ChessPieceSide.BLACK));
            this.SetPiece(new Pawn(9, ChessPieceType.PAW, ChessPieceSide.BLACK));
            this.SetPiece(new Pawn(10, ChessPieceType.PAW, ChessPieceSide.BLACK));
            this.SetPiece(new Pawn(11, ChessPieceType.PAW, ChessPieceSide.BLACK));
            this.SetPiece(new Pawn(12, ChessPieceType.PAW, ChessPieceSide.BLACK));
            this.SetPiece(new Pawn(13, ChessPieceType.PAW, ChessPieceSide.BLACK));
            this.SetPiece(new Pawn(14, ChessPieceType.PAW, ChessPieceSide.BLACK));
            this.SetPiece(new Pawn(15, ChessPieceType.PAW, ChessPieceSide.BLACK));
            //White ChessPieceSide

            this.SetPiece(new Pawn(48, ChessPieceType.PAW, ChessPieceSide.WHITE));
            this.SetPiece(new Pawn(49, ChessPieceType.PAW, ChessPieceSide.WHITE));
            this.SetPiece(new Pawn(50, ChessPieceType.PAW, ChessPieceSide.WHITE));
            this.SetPiece(new Pawn(51, ChessPieceType.PAW, ChessPieceSide.WHITE));
            this.SetPiece(new Pawn(52, ChessPieceType.PAW, ChessPieceSide.WHITE));
            this.SetPiece(new Pawn(53, ChessPieceType.PAW, ChessPieceSide.WHITE));
            this.SetPiece(new Pawn(54, ChessPieceType.PAW, ChessPieceSide.WHITE));
            this.SetPiece(new Pawn(55, ChessPieceType.PAW, ChessPieceSide.WHITE));
            this.SetPiece(new Rook(56, ChessPieceType.ROOK, ChessPieceSide.WHITE));
            this.SetPiece(new Knight(57, ChessPieceType.KNIGHT, ChessPieceSide.WHITE));
            this.SetPiece(new Bishop(58, ChessPieceType.BISHOP,ChessPieceSide.WHITE));
            this.SetPiece(new Queen(59, ChessPieceType.QUEEN, ChessPieceSide.WHITE));
            this.SetPiece(new King(60, ChessPieceType.KING,ChessPieceSide.WHITE));
            this.SetPiece(new Bishop(61, ChessPieceType.BISHOP, ChessPieceSide.WHITE));
            this.SetPiece(new Knight(62, ChessPieceType.KNIGHT,ChessPieceSide.WHITE));
            this.SetPiece(new Rook(63, ChessPieceType.ROOK, ChessPieceSide.WHITE));
            return this;
        }

        public Board CreateCellBoard(ChessPieceSide sidePlayFirst)
        {
            Cell[] cells = new Cell[64];
            for(int i=0;i<64;i++)
            {
                cells[i] = Cell.CreateCell(i, this.GetPiece(i));
            }
            this.listCell = cells.ToList();

            this.Blacklayer = new Player((King) cells[4].GetChessPieces(),ChessPieceSide.BLACK);
            this.Whitelayer = new Player((King) cells[60].GetChessPieces(), ChessPieceSide.WHITE);
            this.Curentlayer = (sidePlayFirst == ChessPieceSide.BLACK) ? this.Blacklayer : this.Whitelayer;
            return this;
        }

        public bool checkedForLegalPosition(int position)
        {
            return (position > -1 && position < 64);
        }
    }
}