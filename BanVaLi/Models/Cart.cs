using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVaLi.Models
{
    public class Cart
    {
        public string Hinh { get; set; }
        public string SanPhamID { get; set; }
        public string TenSanPham { get; set; }
        public Nullable<double> DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien
        {
            get
            {
                return (double) (SoLuong * DonGia);
            }
        }
    }
}