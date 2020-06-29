using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class BillDTO
    {
        public BillDTO(int iD,DateTime? dateCheckIn,DateTime? dateCheckOut, int status)
        {
            this.ID = iD;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
        }
        public BillDTO(DataRow row)
        {
            this.ID = (int)row["iD"];
            this.DateCheckIn = (DateTime?)row["dateCheckIn"];
            var dateCheckInTemp = row["dateCheckOut"];
            if(dateCheckInTemp.ToString() != "")
            {
                this.Status = (int)row["status"];
            }
            this.Status = (int)row["status"];
        }
        private int iD;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int status;

        public int ID { get => iD; set => iD = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
    }
}
