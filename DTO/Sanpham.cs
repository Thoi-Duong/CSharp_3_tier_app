using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Sanpham
    {
        public string Masanpham { get; set; }
        public string Tensanpham { get; set; }
        public int Soluong { get; set; }
        public int DonGia { get; set; }
        public string XuatXu { get; set; }
        public string MaDanhMuc { get; set; }
        public Sanpham(string masp,string tensp,int soluong,int dongia,string xuatxu,string madm)
        {
            Masanpham = masp;
            Tensanpham = tensp;
            Soluong = soluong;
            DonGia = dongia;
            XuatXu = xuatxu;
            MaDanhMuc = madm;
        }

        public Sanpham()
        {

        }
    }
}
