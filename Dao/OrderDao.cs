using OrderApp.Common;
using OrderApp.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Dao
{
    class OrderDao
    {
        public int countOrderById(String id)
        {
            String strQuery = "SELECT COUNT(*) FROM DON_DAT_HANG WHERE ID like '" + id + "'";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int numOrderInMonth = reader.GetInt32(0);
            reader.Close();
            return numOrderInMonth;
        }

        public static int getMaxIdOrder(DateTime systemTime)
        {
            String strQuery = "SELECT MAX(RIGHT(ID, 4))"
                + " FROM DON_DAT_HANG "
                + " WHERE SUBSTRING(ID, 3, 2) = @mm "
                + " AND SUBSTRING(ID, 5, 2) = @yy ";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@mm", systemTime.ToString("MM"));
            cmd.Parameters.AddWithValue("@yy", systemTime.ToString("yy"));
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int numOrderInMonth = 0;
            if (!reader.IsDBNull(0))
            {
                numOrderInMonth = int.Parse( reader.GetString(0));
            }
            reader.Close();
            return numOrderInMonth;
        }

        public DataTable getListOrder(String idKhachHang, DateTime dateFrom, DateTime dateTo, int searchType,  Boolean status)
        {
            DataTable dt = new DataTable();
            String strQuery = "SELECT"
                + " Row_number() over(order by d.ID) STT"
                + ", d.ID as ID"
                + ", ct.ID as ID_CHI_TIET_DON_HANG"
                + ", k.TEN_KHACH_HANG"
                + ", d.NGAY_DAT"
                + ", d.NGAY_GIAO"
                + ", ct.TEN_SAN_PHAM"
                + ", ct.SO_LUONG"
                + ", ct.KICH_THUOC"
                + ", ct.SO_TRANG"
                + ", ct.LOAI_BIA"
                + ", ct.LOAI_GIAY"
                + ", ct.DON_GIA"
                + ", ct.CHIET_KHAU"
                + ", ct.THANH_TIEN"
                + ", ct.TRANG_THAI_THANH_TOAN"
                + ", ct.TRANG_THAI_XUAT_KHO"
                + " FROM DON_DAT_HANG d"
                + " LEFT JOIN DON_DAT_HANG_SP ct ON d.ID = ct.ID_DON_DAT_HANG "
                + " LEFT JOIN KHACH_HANG k ON d.ID_KHACH_HANG = k.ID_KHACH_HANG "
                + " WHERE NGAY_GIAO >= @dateFrom AND NGAY_GIAO <= @dateTo";
            
            // add dk ma khach hang
            if (StringUtils.isNotBlank(idKhachHang)) {
                strQuery += " AND d.ID_KHACH_HANG = @idKhachHang";
            }

            // add dieu kien trang thai don hang
            switch (searchType)
            {
                case 0:
                    break;
                case 1:
                    // TRANG_THAI_THANH_TOAN
                    strQuery += " AND ct.TRANG_THAI_THANH_TOAN = @status";
                    break;
                case 2:
                    // TRANG_THAI_XUAT_KHO
                    strQuery += " AND ct.TRANG_THAI_XUAT_KHO = @status";
                    break;
            }
            strQuery += " ORDER BY d.NGAY_GIAO, d.ID_KHACH_HANG";

            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@dateFrom", new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day));
            cmd.Parameters.AddWithValue("@dateTo", new DateTime(dateTo.Year, dateTo.Month, dateTo.Day));
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@idKhachHang", idKhachHang);

            cmd.Connection = Connection.getConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            return dt;
        }

        public DataTable searchListOrder(String idKhachHang = "")
        {
            DataTable dt = new DataTable();
            String strQuery = "SELECT"
                + " Row_number() over(order by d.ID) STT"
                + ", d.ID as ID"
                + ", k.TEN_KHACH_HANG"
                + ", d.NGAY_DAT"
                + ", d.NGAY_GIAO"
                + ", d.TONG_TIEN"
                + ", (CASE d.TRANG_THAI_THANH_TOAN WHEN 'TRUE' THEN 'OK' ELSE '-' END) AS TRANG_THAI_THANH_TOAN"
                + ", (CASE d.TRANG_THAI_XUAT_KHO WHEN 'TRUE' THEN 'OK' ELSE '-' END) AS TRANG_THAI_XUAT_KHO"
                + " FROM DON_DAT_HANG d"
                + " LEFT JOIN KHACH_HANG k"
                + " ON d.ID_KHACH_HANG = k.ID_KHACH_HANG";
           if (idKhachHang != "")
           {
                strQuery += " WHERE d.ID_KHACH_HANG LIKE @idKhachHang ";
           }
            strQuery += " ORDER BY d.NGAY_GIAO ASC, d.ID_KHACH_HANG";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            if (idKhachHang != "")
            {
                cmd.Parameters.AddWithValue("@idKhachHang", idKhachHang);
            }
            cmd.Connection = Connection.getConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            return dt;
        }

        public static OrderDto getOderByID(String id)
        {
            OrderDto order = new OrderDto();
            String strQuery = "SELECT dh.*, kh.TEN_KHACH_HANG "
                + " FROM DON_DAT_HANG dh, KHACH_HANG kh "
                + " WHERE dh.ID_KHACH_HANG = kh.ID_KHACH_HANG"
                + " AND dh.ID = '" + id + " '";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            order.id = id;
            order.idKhachHang       = reader["ID_KHACH_HANG"] != DBNull.Value ? (String)reader["ID_KHACH_HANG"] : String.Empty;
            order.tenKhachHang      = reader["TEN_KHACH_HANG"] != DBNull.Value ? (String)reader["TEN_KHACH_HANG"] : String.Empty;
            order.ngayGiao          = reader["NGAY_GIAO"] != DBNull.Value ? (DateTime) reader["NGAY_GIAO"] : DateTime.Now;
            order.ngayDat           = reader["NGAY_DAT"] != DBNull.Value ? (DateTime) reader["NGAY_DAT"] : DateTime.Now;
            order.lienHe            = reader["LIEN_HE"] != DBNull.Value ? (String)reader["LIEN_HE"].ToString() : String.Empty;
            order.dienThoai         = reader["SDT"] != DBNull.Value ? (String)reader["SDT"].ToString() : String.Empty;
            order.diaDiemGiaoHang   = reader["DIA_DIEM_GIAO_HANG"] != DBNull.Value ? (String)reader["DIA_DIEM_GIAO_HANG"] : String.Empty;
            order.tongCong          = reader["TONG_CONG"] != DBNull.Value ? (double)(Decimal)reader["TONG_CONG"] : 0;
            order.vat               = reader["VAT"] != DBNull.Value ? (double)(Decimal)reader["VAT"] : 0;
            order.tongTien          = reader["TONG_TIEN"] != DBNull.Value ? (double)(Decimal)reader["TONG_TIEN"] : 0;
            order.phiVanChuyen      = reader["PHI_VAN_CHUYEN"] != DBNull.Value ? (double)(Decimal)reader["PHI_VAN_CHUYEN"] : 0;
            order.thanhToan         = reader["TRANG_THAI_THANH_TOAN"] != DBNull.Value ? (Boolean)reader["TRANG_THAI_THANH_TOAN"] : false;
            order.xuatKho           = reader["TRANG_THAI_XUAT_KHO"] != DBNull.Value ? (Boolean)reader["TRANG_THAI_XUAT_KHO"] : false;
            order.notes             = reader["NOTES"] != DBNull.Value ? (String)reader["NOTES"] : String.Empty;

            reader.Close();
            return order;
        }

        public static List<DonDatHangSPDto> getOderDetailByOrderID(String orderID)
        {
            String strQuery = "SELECT ID "
                + ", TEN_SAN_PHAM "
                + ", KICH_THUOC "
                + ", DON_VI "
                + ", SO_TRANG "
                + ", LOAI_BIA "
                + ", LOAI_GIAY "
                + ", DON_GIA "
                + ", SO_LUONG "
                + ", CHIET_KHAU "
                + ", THANH_TIEN "
                + ", CD_CR "
                + " FROM DON_DAT_HANG_SP "
                + " WHERE ID_DON_DAT_HANG = @orderID";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@orderID", orderID);
            SqlDataReader reader = cmd.ExecuteReader();
            List<DonDatHangSPDto> listDetail = new List<DonDatHangSPDto>();
            while (reader.Read())
            {
                DonDatHangSPDto donHangDetail = new DonDatHangSPDto();
                if (!reader.IsDBNull(0)) donHangDetail.id = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) donHangDetail.tenSanPham = reader.GetString(1);
                if (!reader.IsDBNull(2)) donHangDetail.kichThuoc = reader.GetString(2);
                if (!reader.IsDBNull(3)) donHangDetail.donVi = reader.GetString(3);
                if (!reader.IsDBNull(4)) donHangDetail.soTrang = reader.GetInt32(4);
                if (!reader.IsDBNull(5)) donHangDetail.loaiBia = reader.GetString(5);
                if (!reader.IsDBNull(6)) donHangDetail.loaiGiay = reader.GetString(6);
                if (!reader.IsDBNull(7)) donHangDetail.donGia = (double)reader.GetDecimal(7);
                if (!reader.IsDBNull(8)) donHangDetail.soluong = reader.GetInt32(8);
                if (!reader.IsDBNull(9)) donHangDetail.chietKhau = (double)reader.GetDecimal(9);
                if (!reader.IsDBNull(10)) donHangDetail.thanhTien = (double)reader.GetDecimal(10);
                if (!reader.IsDBNull(11)) donHangDetail.cdcr = reader.GetString(11);
                donHangDetail.idOrder = orderID;

                listDetail.Add(donHangDetail);
            }
            reader.Close();
            return listDetail;
        }

        public static void capNhatThanhToan(string idOrder, Boolean thanhToan)
        {
            String strQuery = ""
                + " UPDATE DON_DAT_HANG SET"
                + " TRANG_THAI_THANH_TOAN = @thanhToan"
                + " WHERE ID = @idOrder";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@idOrder", idOrder);
            cmd.Parameters.AddWithValue("@thanhToan", thanhToan);
            cmd.ExecuteNonQuery();
        }
        public static void capNhatXuatKho(string idOrder, Boolean giaoHang)
        {
            String strQuery = ""
                + " UPDATE DON_DAT_HANG SET"
                + " TRANG_THAI_XUAT_KHO = @giaoHang"
                + " WHERE ID = @idOrder";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@idOrder", idOrder);
            cmd.Parameters.AddWithValue("@giaoHang", giaoHang);
            cmd.ExecuteNonQuery();
        }
        //Details
        public static void capNhatChiTietThanhToan(string idOrderDetail, Boolean thanhToan)
        {
            String strQuery = ""
                + " UPDATE DON_DAT_HANG_SP SET"
                + " TRANG_THAI_THANH_TOAN = @thanhToan"
                + " WHERE ID = @id";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@id", idOrderDetail);
            cmd.Parameters.AddWithValue("@thanhToan", thanhToan);
            cmd.ExecuteNonQuery();
        }

        public static void capNhatChiTietXuatKho(string idOrderDetail, Boolean giaoHang)
        {
            String strQuery = ""
                + " UPDATE DON_DAT_HANG_SP SET"
                + " TRANG_THAI_XUAT_KHO = @giaoHang"
                + " WHERE ID = @id";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@id", idOrderDetail);
            cmd.Parameters.AddWithValue("@giaoHang", giaoHang);
            cmd.ExecuteNonQuery();
        }

        public void insertId(String id)
        {
            String strQuery = "INSERT INTO DON_DAT_HANG (ID)"
                + " VALUES ("
                + " @id )";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public void deleteId(String idDonHang)
        {
            String strQuery = " DELETE DON_DAT_HANG_SP WHERE ID_DON_DAT_HANG = @orderID ;"
                + " DELETE DON_DAT_HANG WHERE ID = @id";
            SqlCommand cmd = new SqlCommand(strQuery); 
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@orderID", idDonHang);
            cmd.Parameters.AddWithValue("@id", idDonHang);
            cmd.ExecuteNonQuery();
        }

        public void creatOrder(OrderDto orderDto)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                String strQuery = ""
                    + " UPDATE DON_DAT_HANG SET"
                    + " ID_KHACH_HANG = @idKhachHang"
                    + ", NGAY_DAT = @ngayDat"
                    + ", NGAY_GIAO = @ngayGiao"
                    + ", TONG_CONG = @tongCong"
                    + ", VAT = @vat"
                    + ", TONG_TIEN = @tongTien"
                    + ", PHI_VAN_CHUYEN = @phiVanChuyen"
                    + ", NOTES = @notes"
                    + ", LIEN_HE = @lienHe"
                    + ", SDT = @sdt"
                    + ", DIA_DIEM_GIAO_HANG = @diaDiemGiaoHang"
                    + " WHERE id = @id";
                SqlCommand cmd = new SqlCommand(strQuery);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                cmd.Transaction = sqlTransaction;
                cmd.Parameters.AddWithValue("@id", orderDto.id);
                cmd.Parameters.AddWithValue("@idKhachHang", orderDto.idKhachHang);
                cmd.Parameters.AddWithValue("@ngayDat", new DateTime(orderDto.ngayDat.Year, orderDto.ngayDat.Month, orderDto.ngayDat.Day));
                cmd.Parameters.AddWithValue("@ngayGiao", new DateTime(orderDto.ngayGiao.Year, orderDto.ngayGiao.Month, orderDto.ngayGiao.Day));
                cmd.Parameters.AddWithValue("@tongCong", orderDto.tongCong);
                cmd.Parameters.AddWithValue("@vat", orderDto.vat);
                cmd.Parameters.AddWithValue("@tongTien", orderDto.tongTien);
                cmd.Parameters.AddWithValue("@phiVanChuyen", orderDto.phiVanChuyen);
                cmd.Parameters.AddWithValue("@notes", orderDto.notes);
                cmd.Parameters.AddWithValue("@lienHe", orderDto.lienHe);
                cmd.Parameters.AddWithValue("@sdt", orderDto.dienThoai);
                cmd.Parameters.AddWithValue("@diaDiemGiaoHang", orderDto.diaDiemGiaoHang);
                cmd.ExecuteNonQuery();

                // update Số Tiền Nợ
                cmd = new SqlCommand(
                    "UPDATE KHACH_HANG "
                     + " SET SO_TIEN_NO = SO_TIEN_NO + @soTienNo"
                     + " WHERE ID_KHACH_HANG = @idKhachHang"
                );
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                cmd.Transaction = sqlTransaction;

                cmd.Parameters.AddWithValue("@soTienNo" , orderDto.tongTien);
                cmd.Parameters.AddWithValue("@idKhachHang" , orderDto.idKhachHang);

                cmd.ExecuteNonQuery();

                // save Detail
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                cmd.Transaction = sqlTransaction;

                String sql = "INSERT INTO DON_DAT_HANG_SP ("
                    + " ID_DON_DAT_HANG"
                    + ", TEN_SAN_PHAM"
                    + ", SO_LUONG"
                    + ", KICH_THUOC"
                    + ", DON_VI"
                    + ", SO_TRANG"
                    + ", LOAI_BIA"
                    + ", LOAI_GIAY"
                    + ", DON_GIA"
                    + ", CHIET_KHAU"
                    + ", THANH_TIEN"
                    + ", CD_CR"
                    + ", CREATE_BY"
                    + ", CREATE_TIME"
                    + " )"
                    + " VALUES ";
                for (int i = 0; i < orderDto.listSanPham.Count; i++)
                {
                    sql += "("
                    + " @idDonDatHang" + i
                    + " , @tenSanPham" + i
                    + " , @soLuong" + i
                    + " , @kichThuoc" + i
                    + " , @donVi" + i
                    + " , @soTrang" + i
                    + " , @loaiBia" + i
                    + " , @loaiGiay" + i
                    + " , @donGia" + i
                    + " , @chietKhau" + i
                    + " , @thanhTien" + i
                    + " , @cdcr" + i
                    + " , @createBy" + i
                    + " , @createTime" + i
                    + " ) ";
                    if (i < orderDto.listSanPham.Count - 1)
                    {
                        sql += ", ";
                    }

                    DonDatHangSPDto dto = orderDto.listSanPham[i];

                    cmd.Parameters.AddWithValue("@idDonDatHang" + i, dto.idOrder);
                    cmd.Parameters.AddWithValue("@tenSanPham" + i, dto.tenSanPham);
                    cmd.Parameters.AddWithValue("@soLuong" + i, dto.soluong);
                    cmd.Parameters.AddWithValue("@kichThuoc" + i, dto.kichThuoc);
                    cmd.Parameters.AddWithValue("@donVi" + i, dto.donVi);
                    cmd.Parameters.AddWithValue("@soTrang" + i, dto.soTrang);
                    cmd.Parameters.AddWithValue("@loaiBia" + i, dto.loaiBia);
                    cmd.Parameters.AddWithValue("@loaiGiay" + i, dto.loaiGiay);
                    cmd.Parameters.AddWithValue("@donGia" + i, dto.donGia);
                    cmd.Parameters.AddWithValue("@chietKhau" + i, dto.chietKhau);
                    cmd.Parameters.AddWithValue("@thanhTien" + i, dto.thanhTien);
                    cmd.Parameters.AddWithValue("@cdcr" + i, dto.cdcr);
                    cmd.Parameters.AddWithValue("@createBy" + i, dto.createBy);
                    cmd.Parameters.AddWithValue("@createTime" + i, dto.createTime);
                }
                cmd.CommandText = sql;
                int numRowExcute = cmd.ExecuteNonQuery();
                if (numRowExcute != orderDto.listSanPham.Count)
                {
                    throw new Exception("Insert ĐƠN ĐẶT HÀNG fail!");
                }

                sqlTransaction.Commit();
            }
            catch (Exception ex) {
                sqlTransaction.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public void updateOrder(OrderDto orderDto)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                String strQuery = ""
                    + " UPDATE DON_DAT_HANG SET"
                    + " ID_KHACH_HANG = @idKhachHang"
                    + ", NGAY_DAT = @ngayDat"
                    + ", NGAY_GIAO = @ngayGiao"
                    + ", TONG_CONG = @tongCong"
                    + ", VAT = @vat"
                    + ", TONG_TIEN = @tongTien"
                    + ", PHI_VAN_CHUYEN = @phiVanChuyen"
                    + ", NOTES = @notes"
                    + ", LIEN_HE = @lienHe"
                    + ", SDT = @sdt"
                    + ", DIA_DIEM_GIAO_HANG = @diaDiemGiaoHang"
                    + " WHERE id = @id";
                SqlCommand cmd = new SqlCommand(strQuery);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                cmd.Transaction = sqlTransaction;
                cmd.Parameters.AddWithValue("@id", orderDto.id);
                cmd.Parameters.AddWithValue("@idKhachHang", orderDto.idKhachHang);
                cmd.Parameters.AddWithValue("@ngayDat", new DateTime(orderDto.ngayDat.Year, orderDto.ngayDat.Month, orderDto.ngayDat.Day));
                cmd.Parameters.AddWithValue("@ngayGiao", new DateTime(orderDto.ngayGiao.Year, orderDto.ngayGiao.Month, orderDto.ngayGiao.Day));
                cmd.Parameters.AddWithValue("@tongCong", orderDto.tongCong);
                cmd.Parameters.AddWithValue("@vat", orderDto.vat);
                cmd.Parameters.AddWithValue("@tongTien", orderDto.tongTien);
                cmd.Parameters.AddWithValue("@phiVanChuyen", orderDto.phiVanChuyen);
                cmd.Parameters.AddWithValue("@notes", orderDto.notes);
                cmd.Parameters.AddWithValue("@lienHe", orderDto.lienHe);
                cmd.Parameters.AddWithValue("@sdt", orderDto.dienThoai);
                cmd.Parameters.AddWithValue("@diaDiemGiaoHang", orderDto.diaDiemGiaoHang);
                cmd.ExecuteNonQuery();

                // delete Detail
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                cmd.Transaction = sqlTransaction;

                String sqlDelete = "DELETE DON_DAT_HANG_SP WHERE ID_DON_DAT_HANG = @idDonHang";
                cmd.CommandText = sqlDelete;
                cmd.Parameters.AddWithValue("@idDonHang", orderDto.id);
                cmd.ExecuteNonQuery();

                // save Detail
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                cmd.Transaction = sqlTransaction;

                String sql = "INSERT INTO DON_DAT_HANG_SP ("
                    + " ID_DON_DAT_HANG"
                    + ", TEN_SAN_PHAM"
                    + ", SO_LUONG"
                    + ", KICH_THUOC"
                    + ", DON_VI"
                    + ", SO_TRANG"
                    + ", LOAI_BIA"
                    + ", LOAI_GIAY"
                    + ", DON_GIA"
                    + ", CHIET_KHAU"
                    + ", THANH_TIEN"
                    + ", CD_CR"
                    + ", CREATE_BY"
                    + ", CREATE_TIME"
                    + " )"
                    + " VALUES ";
                for (int i = 0; i < orderDto.listSanPham.Count; i++)
                {
                    sql += "("
                    + " @idDonDatHang" + i
                    + " , @tenSanPham" + i
                    + " , @soLuong" + i
                    + " , @kichThuoc" + i
                    + " , @donVi" + i
                    + " , @soTrang" + i
                    + " , @loaiBia" + i
                    + " , @loaiGiay" + i
                    + " , @donGia" + i
                    + " , @chietKhau" + i
                    + " , @thanhTien" + i
                    + " , @cdcr" + i
                    + " , @createBy" + i
                    + " , @createTime" + i
                    + " ) ";
                    if (i < orderDto.listSanPham.Count - 1)
                    {
                        sql += ", ";
                    }

                    DonDatHangSPDto dto = orderDto.listSanPham[i];

                    cmd.Parameters.AddWithValue("@idDonDatHang" + i, dto.idOrder);
                    cmd.Parameters.AddWithValue("@tenSanPham" + i, dto.tenSanPham);
                    cmd.Parameters.AddWithValue("@soLuong" + i, dto.soluong);
                    cmd.Parameters.AddWithValue("@kichThuoc" + i, dto.kichThuoc);
                    cmd.Parameters.AddWithValue("@donVi" + i, dto.donVi);
                    cmd.Parameters.AddWithValue("@soTrang" + i, dto.soTrang);
                    cmd.Parameters.AddWithValue("@loaiBia" + i, dto.loaiBia);
                    cmd.Parameters.AddWithValue("@loaiGiay" + i, dto.loaiGiay);
                    cmd.Parameters.AddWithValue("@donGia" + i, dto.donGia);
                    cmd.Parameters.AddWithValue("@chietKhau" + i, dto.chietKhau);
                    cmd.Parameters.AddWithValue("@thanhTien" + i, dto.thanhTien);
                    cmd.Parameters.AddWithValue("@cdcr" + i, dto.cdcr);
                    cmd.Parameters.AddWithValue("@createBy" + i, dto.createBy);
                    cmd.Parameters.AddWithValue("@createTime" + i, dto.createTime);
                }
                cmd.CommandText = sql;
                int numRowExcute = cmd.ExecuteNonQuery();
                if (numRowExcute != orderDto.listSanPham.Count)
                {
                    throw new Exception("update ĐƠN ĐẶT HÀNG fail!");
                }

                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public void insert(OrderDto dto)
        {
            String strQuery = "INSERT INTO DON_DAT_HANG "
                + "( "
                + " ID"
                + ", ID_KHACH_HANG"
                + ", NGAY_GIAO"
                + ", TRANG_THAI_THANH_TOAN"
                + ", TONG_CONG"
                + ", VAT"
                + ", TONG_TIEN"
                + ", PHI_VAN_CHUYEN"
                + ", NOTES"
                + ", LIEN_HE"
                + ", SDT"
                + ", DIA_DIEM_GIAO_HANG"
                + ", CREATE_BY"
                + ", CREATE_TIME"
                + ") VALUES ("
                + "@id"
                + ", @idKhachHang"
                + ", @ngayGiao"
                + ", @trangThaiThanhToan"
                + ", @tongCong"
                + ", @vat"
                + ", @tongTien"
                + ", @phiVanChuyen"
                + ", @notes"
                + ", @sdt"
                + ", @user"
                + ", @createTime"
                + ")";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@id", dto.id);
            cmd.Parameters.AddWithValue("@idKhachHang", dto.idKhachHang);
            cmd.Parameters.AddWithValue("@ngayGiao", dto.ngayGiao);
            cmd.Parameters.AddWithValue("@trangThaiThanhToan", dto.thanhToan ? 1 : 0);
            cmd.Parameters.AddWithValue("@tongCong", dto.tongCong);
            cmd.Parameters.AddWithValue("@vat", dto.vat);
            cmd.Parameters.AddWithValue("@tongTien", dto.tongTien);
            cmd.Parameters.AddWithValue("@phiVanChuyen", dto.phiVanChuyen);
            cmd.Parameters.AddWithValue("@notes", dto.notes);
            cmd.Parameters.AddWithValue("@lienHe", dto.dienThoai);
            cmd.Parameters.AddWithValue("@sdt", dto.dienThoai);
            cmd.Parameters.AddWithValue("@diaDiemGiaoHang", dto.dienThoai);
            cmd.Parameters.AddWithValue("@user", dto.user);
            cmd.Parameters.AddWithValue("@createTime", dto.createTime);
            cmd.ExecuteNonQuery();
        }
        
        public SqlDataReader getDebtByCustomer(String dateFrom, String dateTo, String idKhachHang = "")
        {
            String strQuery = "SELECT a.ID"
                                + ", a.NGAY_GIAO"
                                + ", sp.TEN_SAN_PHAM"
                                + ", ISNULL(sp.CD_CR, '') AS CD_CR"
                                + ", ISNULL(sp.KICH_THUOC, '') AS KICH_THUOC"
                                + ", ISNULL(sp.SO_TRANG, 0) AS SO_TRANG"
                                + ", ISNULL(sp.LOAI_BIA, '') AS LOAI_BIA"
                                + ", ISNULL(sp.LOAI_GIAY, '') AS LOAI_GIAY"
                                + ", ISNULL(sp.SO_LUONG, 0) AS SO_LUONG"
                                + ", ISNULL(sp.DON_GIA, 0) AS DON_GIA"
                                + ", ISNULL(sp.CHIET_KHAU, 1) AS CHIET_KHAU"
                                + ", ISNULL(sp.THANH_TIEN, 0) AS THANH_TIEN"
                                + ", ISNULL(a.VAT, 0) AS VAT"
                                + ", sp.THANH_TIEN + sp.THANH_TIEN * ISNULL(a.VAT, 0)/100 AS TONG_TIEN"
                                + " FROM DON_DAT_HANG a"
                                + " LEFT JOIN DON_DAT_HANG_SP sp"
                                + " ON a.ID = sp.ID_DON_DAT_HANG"
                                + " WHERE a.NGAY_DAT >= '" + dateFrom + "' AND a.NGAY_DAT <= '" + dateTo + "'";
            if (StringUtils.isNotBlank(idKhachHang))
            {
                strQuery += " AND a.ID_KHACH_HANG = '" + idKhachHang + "'";
                //+ "     AND a.TRANG_THAI_THANH_TOAN = 'false'"
            }

            strQuery += " ORDER BY NGAY_GIAO DESC";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public SqlDataReader getDebtByCustomerWithPay(String dateFrom, String dateTo, String idKhachHang = "")
        {
            String strQuery = "SELECT a.ID AS ID"
                    + ", a.NGAY_GIAO AS NGAY_GIAO"
                    + ", sp.TEN_SAN_PHAM AS TEN_SAN_PHAM"
                    + ", ISNULL(sp.CD_CR, '') AS CD_CR"
                    + ", ISNULL(sp.KICH_THUOC, '') AS KICH_THUOC"
                    + ", ISNULL(sp.SO_TRANG, 0) AS SO_TRANG"
                    + ", ISNULL(sp.LOAI_BIA, '') AS LOAI_BIA"
                    + ", ISNULL(sp.LOAI_GIAY, '') AS LOAI_GIAY"
                    + ", ISNULL(sp.SO_LUONG, 0) AS SO_LUONG"
                    + ", ISNULL(sp.DON_GIA, 0) AS DON_GIA"
                    + ", ISNULL(sp.CHIET_KHAU, 1) AS CHIET_KHAU"
                    + ", ISNULL(sp.THANH_TIEN, 0) AS THANH_TIEN"
                    + ", ISNULL(a.VAT, 0) AS VAT"
                    + ", sp.THANH_TIEN + sp.THANH_TIEN * ISNULL(a.VAT, 0)/100 AS TONG_TIEN"
                    + " FROM DON_DAT_HANG a"
                    + " LEFT JOIN DON_DAT_HANG_SP sp ON a.ID = sp.ID_DON_DAT_HANG"
                    + " WHERE a.NGAY_DAT >= '" + dateFrom + "' AND a.NGAY_DAT <= '" + dateTo + "'";
            if (StringUtils.isNotBlank(idKhachHang))
            {
                strQuery += " AND a.ID_KHACH_HANG = '" + idKhachHang + "'";
            }
            strQuery += " UNION"
                    + " SELECT '' AS ID"
                    + ", NGAY_TRA AS NGAY_GIAO"
                    + ", 'THANH TOÁN' AS TEN_SAN_PHAM"
                    + ", '' AS CD_CR"
                    + ", '' AS KICH_THUOC"
                    + ", NULL AS SO_TRANG"
                    + ", '' AS LOAI_BIA"
                    + ", '' AS LOAI_GIAY"
                    + ", NULL AS SO_LUONG"
                    + ", NULL AS DON_GIA"
                    + ", NULL AS CHIET_KHAU"
                    + ", NULL AS THANH_TIEN"
                    + ", NULL AS VAT"
                    + ", SO_TIEN AS TONG_TIEN"
                    + " FROM LICH_SU_TRA_TRUOC"
                    + " WHERE NGAY_TRA >= '" + dateFrom + "' AND NGAY_TRA <= '" + dateTo + "'";
            if (StringUtils.isNotBlank(idKhachHang))
            {
                strQuery += " AND ID_KHACH_HANG = '" + idKhachHang + "'";
            }
            strQuery += " ORDER BY NGAY_GIAO";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
