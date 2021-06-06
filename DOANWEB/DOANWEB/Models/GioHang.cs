using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOANWEB.Models
{
    public class GioHang
    {
        MUABANLAPTOPDataContext db = new MUABANLAPTOPDataContext();
        public string iMaSP { get; set; }
        public string sTenSP { get; set; }
        public string sHinhAnh { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        public GioHang(string MASP)
        {
            iMaSP = MASP;
            SANPHAM sp = db.SANPHAMs.Single(s => s.MASP == iMaSP);
            sTenSP = sp.TENSP;
            sHinhAnh = sp.HINHANH;
            dDonGia = double.Parse(sp.GIABAN.ToString());
            iSoLuong = 1;

        }
    }
}