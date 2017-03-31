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

        public DataTable getListOrder(DateTime dateFrom, DateTime dateTo, int searchType,  Boolean status)
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
                + " ON d.ID_KHACH_HANG = k.ID_KHACH_HANG"
                + " WHERE NGAY_GIAO > @dateFrom AND NGAY_GIAO < @dateTo";
            
            // add dieu kien trang thai don hang
            switch (searchType)
            {
                case 0:
                    break;
                case 1:
                    // TRANG_THAI_THANH_TOAN
                    strQuery += " AND TRANG_THAI_THANH_TOAN = @status";
                    break;
                case 2:
                    // TRANG_THAI_XUAT_KHO
                    strQuery += " AND TRANG_THAI_XUAT_KHO = @status";
                    break;
            }
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
            cmd.Parameters.AddWithValue("@dateTo", dateTo);
            cmd.Parameters.AddWithValue("@status", status);

            cmd.Connection = Connection.getConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            return dt;
        }

        public static OrderDto getOderByID(String id)
        {
            DataTable dt = new DataTable();
            String strQuery = "SELECT * FROM DON_DAT_HANG WHERE ID = '" + id + " '";
            SqlDataAdapter adapter = new SqlDataAdapter(strQuery, Connection.getConnection());
            adapter.Fill(dt);
            return null;
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

        public void deleteId(String id)
        {
            String strQuery = "DELETE FROM DON_DAT_HANG WHERE ID = @id";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            cmd.Parameters.AddWithValue("@id", id);
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
                    + ", NGAY_GIAO = @ngayGiao"
                    + ", TONG_CONG = @tongCong"
                    + ", VAT = @vat"
                    + ", TONG_TIEN = @tongTien"
                    + ", PHI_VAN_CHUYEN = @phiVanChuyen"
                    + ", NOTES = @notes"
                    + ", SDT = @sdt"
                    + " WHERE id = @id";
                SqlCommand cmd = new SqlCommand(strQuery);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                cmd.Transaction = sqlTransaction;
                cmd.Parameters.AddWithValue("@id", orderDto.id);
                cmd.Parameters.AddWithValue("@idKhachHang", orderDto.idKhachHang);
                cmd.Parameters.AddWithValue("@ngayGiao", orderDto.ngayGiao);
                cmd.Parameters.AddWithValue("@tongCong", orderDto.tongCong);
                cmd.Parameters.AddWithValue("@vat", orderDto.vat);
                cmd.Parameters.AddWithValue("@tongTien", orderDto.tongTien);
                cmd.Parameters.AddWithValue("@phiVanChuyen", orderDto.phiVanChuyen);
                cmd.Parameters.AddWithValue("@notes", orderDto.notes);
                cmd.Parameters.AddWithValue("@sdt", orderDto.phone);
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
                + ", SDT"
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
            cmd.Parameters.AddWithValue("@sdt", dto.phone);
            cmd.Parameters.AddWithValue("@user", dto.user);
            cmd.Parameters.AddWithValue("@createTime", dto.createTime);
            cmd.ExecuteNonQuery();
        }
        
        public SqlDataReader getDebtByCustomer(String idKhachHang)
        {
            String strQuery = "SELECT a.ID"
                                + ", a.NGAY_GIAO"
                                + ", sp.TEN_SAN_PHAM"
                                + ", sp.CD_CR"
                                + ", sp.KICH_THUOC"
                                + ", sp.SO_TRANG"
                                + ", sp.LOAI_BIA"
                                + ", sp.LOAI_GIAY"
                                + ", sp.SO_LUONG"
                                + ", sp.DON_GIA"
                                + ", ISNULL(sp.CHIET_KHAU, 1) AS CHIET_KHAU"
                                + ", sp.THANH_TIEN"
                                + " FROM DON_DAT_HANG a"
                                + " LEFT JOIN DON_DAT_HANG_SP sp"
                                + " ON a.ID = sp.ID_DON_DAT_HANG"
                                + " WHERE a.ID_KHACH_HANG = '" + idKhachHang + "'"
                                + " ORDER BY NGAY_GIAO DESC";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection.getConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
