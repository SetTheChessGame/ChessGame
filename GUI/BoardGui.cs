﻿using ObjectGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    class BoardGui: TableLayoutPanel
    {
        #region thuoc tinh chung
        public List<CellGui> listCellGui { get; set; }
        public Cell CellSelectedFirst { get; set; }
        public Cell CellSelectedSecond { get; set; }
        public Board boardLogic { get; set; }
        public static MoveHistory moveHistory;
        #endregion

        public ChessPieces workingPiece { get; set; }

        public BoardGui(ChessPieceSide sidePlayFirst) : base()
        {
            this.boardLogic = new Board(sidePlayFirst);
            moveHistory = new MoveHistory();

            this.CellSelectedFirst = this.CellSelectedSecond = null;
            this.ColumnCount = 8;           
            this.RowCount = 8;


            this.Size = new Size(538, 538);
            this.Location = new Point(250, 40);
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            this.listCellGui = new List<CellGui>();
            AddCellGuiAndCell();
        }

        public void AddCellGuiAndCell()
        {
            // if(listCellGui!=null) listCellGui.Clear();
            this.Controls.Clear();
            if(listCellGui!=null)
                this.listCellGui.Clear();

            for (int i = 0; i < 64; i++)
            {
                CellGui cell = new CellGui(this, i);
                this.Controls.Add(cell, i % 8, i / 8);
                this.listCellGui.Add(cell);
            }
            this.Refresh();
        }

        public CellGui GetCellGui(int id)
        {
            return this.listCellGui[id];
        }

        public void Undo()
        {
            

            //set lai icon tren cellGui neu co buoc di truoc do
            //neu chua di cai nao thi bo tay. khong the undo
            if(BoardGui.moveHistory.GetNearestMove()!=null)
            {
                this.boardLogic = BoardGui.moveHistory.Undo(this.boardLogic);
                this.listCellGui[BoardGui.moveHistory.GetNearestMove().actionPiece.chessPiecePosition].SetImageIcon();
                this.listCellGui[BoardGui.moveHistory.GetNearestMove().destination].SetImageIcon();
                BoardGui.moveHistory.RemoveHistoryForThisMove();
                this.boardLogic.SetNextPlayer();
            }

        }
    }
}
