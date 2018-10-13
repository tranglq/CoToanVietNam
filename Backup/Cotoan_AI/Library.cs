using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace MChess
{
    /// <summary>
    /// Lop Library phuc vu cac thao tac tim kiem the co va nuoc di trong thu vien nuoc di
    /// Cac the co duoc luu tru ngoai (file), thong tin luu lai gom co:
    ///     Vi tri cac quan tren ban co, tuc la luu Board
    ///     Nuoc di tiep theo Move next_move
    ///     Ben di tiep theo color
    ///     Khoa (theLock)
    ///     ...
    ///     
    /// Dung cau truc Hash Table de luu tru va tim kiem
    /// Su dung cac phuong thuc HashKey() va HashLock() (class Board) de tim kiem the co va 
    /// tranh dung do
    /// 
    /// Cac thao tac voi thu vien
    ///     Load thu vien tu file
    ///     Tim kiem va doc thong tin trong thu vien
    ///     Luu mot the co vao thu vien
    /// </summary>

    class LibraryEntry
    {
        
    }
    class Library
    {
        //kich thuoc thu vien
        private static int SIZE = 4096;
        private LibraryEntry[] Table;

    }
}
