using QuanLyNhaHang.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class BillInfoDTO
    {
        public BillInfoDTO(int iD, int iDBill, int iDFood, int count)
        {
            this.ID = iD;
            this.IDBill = iDBill;
            this.IDFood = iDFood;
            this.Count = count;
        }
        public BillInfoDTO(DataRow row)
        {
            this.ID = (int)row["iD"];
            this.IDBill = (int)row["iDBill"];
            this.IDFood = (int)row["iDFood"];
            this.Count = (int)row["count"];
        }
        private int iD;
        private int iDBill;
        private int iDFood;
        private int count;

        public int ID { get => iD; set => iD = value; }
        public int IDBill { get => iDBill; set => iDBill = value; }
        public int IDFood { get => iDFood; set => iDFood = value; }
        public int Count { get => count; set => count = value; }
    }
}
