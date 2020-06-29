using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class FoodDTO
    {
        public FoodDTO(int iD, string name, int idCategory, float price)
        {
            this.ID = iD;
            this.Name = name;
            this.IdCategory = idCategory;
            this.Price = price;
        }

        public FoodDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.IdCategory = (int)row["idCategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        private int idCategory;

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public int IdCategory { get => idCategory; set => idCategory = value; }
    }
}
