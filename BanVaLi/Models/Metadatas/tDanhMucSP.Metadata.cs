using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  System.ComponentModel;
using  System.ComponentModel.DataAnnotations;

namespace BanVaLi.Models
{
    [MetadataType(typeof(tDanhMucSPMetadata))]
    public partial class tDanhMucSP : IEnumerable
    {
        internal sealed class tDanhMucSPMetadata
        {
            [Display(Name = "Mã sản phẩm")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string MaSP { get; set; }

            [Display(Name = "Tên sản phẩm")]
            public string TenSP { get; set; }

            [Display(Name = "Mã Chất Liệu")]
            public string MaChatLieu { get; set; }

            [Display(Name = "Ngăn LapTop")]
            public string NganLapTop { get; set; }
            public string Model { get; set; }

            [Display(Name = "Màu Sắc")]
            public string MauSac { get; set; }

            [Display(Name = "Mã Kích Thước")]
            public string MaKichThuoc { get; set; }

            [Display(Name = "Cân Nặng")]
            public Nullable<double> CanNang { get; set; }

            [Display(Name = "Độ Nới")]
            public Nullable<double> DoNoi { get; set; }

            [Display(Name = "Mã Hàng SX")]
            public string MaHangSX { get; set; }

            [Display(Name = "Mã nước Sản Xuất")]
            public string MaNuocSX { get; set; }

            [Display(Name = "Mã Đặc Tính")]
            public string MaDacTinh { get; set; }

            [Display(Name = "Website")]
            public string Website { get; set; }

            [Display(Name = "Thời Gian Bảo Hành")]
            public Nullable<double> ThoiGianBaoHanh { get; set; }

            [Display(Name = "Giới Thiệu Sản Phẩm")]
            public string GioiThieuSP { get; set; }

            [Display(Name = "Giá")]
            public Nullable<double> Gia { get; set; }

            [Display(Name = "Chiết Khấu")]
            public Nullable<double> ChietKhau { get; set; }

            [Display(Name = "Mã Loại")]
            public string MaLoai { get; set; }

            [Display(Name = "Mã Đối tượng")]
            public string MaDT { get; set; }
            [Display(Name = "Ảnh")]
            public string Anh { get; set; }

            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]


            //public  ICollection<tAnhSP> tAnhSP { get; set; }
            //public  tChatLieu tChatLieu { get; set; }
            //public  tHangSX tHangSX { get; set; }
            //public  tKichThuoc tKichThuoc { get; set; }
            //public  tLoaiDT tLoaiDT { get; set; }
            //public  tLoaiSP tLoaiSP { get; set; }
            //public  tQuocGia tQuocGia { get; set; }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}