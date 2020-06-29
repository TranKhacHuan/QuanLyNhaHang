using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class CategoryDTO
    {
        public CategoryDTO(int iD, string name)
        {
            this.ID = iD;
            this.Name = name;
        }
        public CategoryDTO(DataRow row)
        {
            this.ID = (int)row["iD"];
            this.Name = row["name"].ToString();
        }
        private int iD;
        private string name;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
    }
}
