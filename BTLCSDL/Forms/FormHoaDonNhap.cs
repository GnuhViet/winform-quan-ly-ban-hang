using BTLCSDL.DAO;
using BTLCSDL.DAO.impl;
using BTLCSDL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BTLCSDL.Forms
{
    public partial class FormHoaDonNhap : Form
    {
        private int MaHDN;
        private ReflectionDAO hdn;
        private ReflectionDAO cthdn;
        private ReflectionDAO ncc;
        private ReflectionDAO nv;
        private CommonDAO sql;
        private string queryGetAll = "select MaHDN, NgayNhap, MaSoThue, TongTien, TenNCC, HoTenNV from HoaDonNhap h join NhanVien n on h.MaNV = n.MaNV join NhaCungCap n2 on n2.MaNCC = h.MaNCC";
        private List<SanPhamHDN> listSPHD;
        private bool isThem;
        public FormHoaDonNhap(ReflectionDAO hdn2, ReflectionDAO cthdn2, ReflectionDAO ncc2, ReflectionDAO nv2)
        {
            InitializeComponent();
            hdn = hdn2;
            cthdn = cthdn2;
            sql = new CommonDAO();
            ncc = ncc2;
            nv = nv2;
            isThem = false;

			ControlExtension.Draggable(formThemHDN, true);
			ControlExtension.Draggable(formSuaSP, true);
		}
        
        public void thayCotTableHDN()
        {
            tableHDN.Columns["MaHDN"].HeaderText = "Mã HDN";
            tableHDN.Columns["NgayNhap"].HeaderText = "Ngày nhập";
            tableHDN.Columns["MaSoThue"].HeaderText = "Mã số thuế";
            tableHDN.Columns["TongTien"].HeaderText = "Tổng tiền";
            tableHDN.Columns["TenNCC"].HeaderText = "Tên NCC";
            tableHDN.Columns["HoTenNV"].HeaderText = "Họ tên NV";
        }

        public void thayCotTableSP()
        {
            tableSP.Columns["TenSP"].HeaderText = "Tên SP";
            tableSP.Columns["TenS"].HeaderText = "Size";
            tableSP.Columns["TenMS"].HeaderText = "Màu sắc";
            tableSP.Columns["SoLuong"].HeaderText = "Số lượng";
            tableSP.Columns["DonGiaNhap"].HeaderText = "Đơn giá";
            tableSP.Columns["ThanhTien"].HeaderText = "Thành tiền";
        }
        public void thayCotTableTatCaSP()
        {
            tableTatCaSP.Columns["TenSP"].HeaderText = "Tên SP";
            tableTatCaSP.Columns["TenS"].HeaderText = "Size";
            tableTatCaSP.Columns["TenMS"].HeaderText = "Màu sắc";
        }
        private SanPhamHDN getCTHDN(int i)
        {
            SanPhamHDN sp = new SanPhamHDN();
            sp.MaCTHDN = 0;
            sp.SoLuong = Convert.ToInt32(tableTatCaSP.Rows[i].Cells[1].Value);
            sp.DonGiaNhap = Convert.ToDouble(tableTatCaSP.Rows[i].Cells[2].Value);
            sp.ThanhTien = sp.SoLuong * sp.DonGiaNhap;
            sp.MaHDN = MaHDN;
            sp.MaCTSP = getMaCTSP(i);
            sp.TenSP = tableTatCaSP.Rows[i].Cells[3].Value.ToString();
            sp.TenSize = tableTatCaSP.Rows[i].Cells[4].Value.ToString();
            sp.TenMau = tableTatCaSP.Rows[i].Cells[5].Value.ToString();
            return sp;
        }
        #region formMain
        private void FormHoaDonNhap_Load(object sender, EventArgs e)
        {
            cmbSearchBy.SelectedIndex = 0;
            DataTable dt =  new DataTable();
            tableHDN.DataSource = sql.table(queryGetAll);
            thayCotTableHDN();
            cmbNCC.DataSource = sql.table("select Convert(nvarchar(25),MaNCC) + ' - ' + TenNCC [MaTen], MaNCC from NhaCungCap");
            cmbNCC.DisplayMember = "MaTen";
            cmbNCC.ValueMember = "MaNCC";
            cmbNV.DataSource = sql.table("select Convert(nvarchar(25),MaNV) + ' - ' + HoTenNV [MaTen], MaNV from NhanVien");
            cmbNV.DisplayMember = "MaTen";
            cmbNV.ValueMember = "MaNV";
            formSuaSP.Visible = false;
        }

        private void txtTK_TextChange(object sender, EventArgs e)
        {
            string query = "";
            if (cmbSearchBy.SelectedItem.ToString().Equals("Mã hóa đơn nhập"))
                query = queryGetAll + $" where Convert(nvarchar(50), MaHDN) like N'{txtTK.Text}%'";
            if (cmbSearchBy.SelectedItem.ToString().Equals("Họ tên nhân viên"))
                query = queryGetAll + $" where HoTenNV like N'%{txtTK.Text}%'";
            if (cmbSearchBy.SelectedItem.ToString().Equals("Tên nhà cung cấp"))
                query = queryGetAll + $" where TenNCC like N'%{txtTK.Text}%'";
            if (txtTK.Text == "")
                query = queryGetAll;
            tableHDN.DataSource = sql.table(query);

        }
        #endregion


        #region formThemHDN

        private void btnThemHDN_Click(object sender, EventArgs e)
        {
            dtpNgayNhap.Value = DateTime.Today;
            txtMST.Text = "";
            cmbNCC.Text = "";
            cmbNV.Text = "";
            formThemHDN.Visible = true;
            lbThemHDN.Text = "Thêm hóa đơn";
            btnThemHDNSubmit.Text = "Thêm hóa đơn";
            isThem = true;
            listSPHD = new List<SanPhamHDN>();
            MaHDN = 0;
            txtTongTien.Text = "0";
            BindingListSPHD();
        }

        private void btnDongFormThemHDN_Click(object sender, EventArgs e)
        {
            formSuaSP.Visible = false;
            formThemHDN.Visible = false;
            tableHDN.DataSource = sql.table(queryGetAll);
            txtTK_TextChange(sender, e);
        }
        private bool ValidateFormThemHDN()
        {
            if(dtpNgayNhap.Value > DateTime.Today)
            {
                MessageBox.Show("Ngày tạo hóa đơn không được lớn hơn thời điểm hiện tại");
                return false;
            }
            if (txtMST.Text == "")
            {
                MessageBox.Show("Mã số thuế không được để trống");
                return false;
            }
            if (cmbNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn nhà cung cấp");
                return false;
            }
            if (cmbNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn nhân viên");
                return false;
            }
            return true;
        }
        private void btnThemHDNSubmit_Click(object sender, EventArgs e)
        {
            if(ValidateFormThemHDN() && isThem == true)
            {
                if(MessageBox.Show("Bạn có muốn thêm hóa đơn không?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    HoaDonNhap hoaDonNhap = new HoaDonNhap();
                    hoaDonNhap.NgayNhap = Convert.ToDateTime(dtpNgayNhap.Value);
                    hoaDonNhap.MaSoThue = txtMST.Text;
                    hoaDonNhap.MaNCC = Convert.ToInt32(cmbNCC.SelectedValue);
                    hoaDonNhap.MaNV = Convert.ToInt32(cmbNV.SelectedValue);
                    hoaDonNhap.TongTien = 0;
                    hdn.create(hoaDonNhap);
                    DataTable dt = sql.table("select max(MaHDN) max from HoaDonNhap");
                    MaHDN = Convert.ToInt32(dt.Rows[0]["max"]);
                    foreach (ChiTietHDN item in listSPHD)
                    {
                        item.MaHDN = MaHDN;
                        cthdn.create(item);
                    }
                    MessageBox.Show("Thêm hóa đơn thành công");
                    formThemHDN.Visible = false;
                    tableHDN.DataSource = sql.table(queryGetAll);
                    txtTK_TextChange(sender, e);
                }
            }
            if(ValidateFormThemHDN() && isThem == false)
            {
                if(MessageBox.Show("Bạn có muốn sửa hóa đơn không?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    HoaDonNhap item = new HoaDonNhap();
                    item.MaHDN = MaHDN;
                    item.NgayNhap = Convert.ToDateTime(dtpNgayNhap.Value);
                    item.MaSoThue = txtMST.Text;
                    item.TongTien = Convert.ToDouble(txtTongTien.Text);
                    item.MaNCC = Convert.ToInt32(cmbNCC.SelectedValue);
                    item.MaNV = Convert.ToInt32(cmbNV.SelectedValue);
                    hdn.update(item);
                    FormHoaDonNhap_Load(sender, e);
                    formThemHDN.Visible = false;
                }
            }
        }
		#endregion


        #region formSuaSP
        private int getMaCTSP(int rowindex)
        {
            string size = tableTatCaSP.Rows[rowindex].Cells[4].Value.ToString();
            string mauSac = tableTatCaSP.Rows[rowindex].Cells[5].Value.ToString();
            string tenSP = tableTatCaSP.Rows[rowindex].Cells[3].Value.ToString();
            DataTable dt = sql.table("select MaCTSP from ChiTietSP c " +
                "join Size on Size.MaS = c.MaS " +
                "join SanPham s on c.MaSP = s.MaSP " +
                "join MauSac m on c.MaMS = m.MaMS " +
                $"where TenS = N'{size}' and TenMS = N'{mauSac}' and TenSP = N'{tenSP}'");
            return Convert.ToInt32(dt.Rows[0]["MaCTSP"]);
        }
        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            formSuaSP.Visible = true;
            formSuaSP.BringToFront();
            txtTKSP.Text = "";
            tableTatCaSP.DataSource = sql.table("select TenSP, TenS, TenMS from ChiTietSP c " +
                "join Size on Size.MaS = c.MaS " +
                "join SanPham s on s.MaSP = c.MaSP " +
                "join MauSac m on m.MaMs = c.MaMS");
            for (int i = 3; i < tableTatCaSP.ColumnCount; ++i)
                tableTatCaSP.Columns[i].ReadOnly = true;
            thayCotTableTatCaSP();
            TichSPDaChon();
        }

        private void btnDongFormSuaSP_Click(object sender, EventArgs e)
        {
            formSuaSP.Visible = false;
            
        }
        private void TichSPDaChon()
        {
            for(int i = 0;i < tableTatCaSP.RowCount;++i)
            {
                int MaCTSP = getMaCTSP(i);
                foreach(SanPhamHDN item in listSPHD)
                    if(item.MaCTSP == MaCTSP)
                    {
                        tableTatCaSP.Rows[i].Cells[0].Value = true;
                        tableTatCaSP.Rows[i].Cells[1].Value = item.SoLuong;
                        tableTatCaSP.Rows[i].Cells[2].Value = item.DonGiaNhap;
                    }
            }
        }
        

        private void tableTatCaSP_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(tableTatCaSP.CurrentRow.Cells[0].Value) == true && tableTatCaSP.CurrentRow.Cells[1].Value != null && tableTatCaSP.CurrentRow.Cells[2].Value != null)
            {
                int MaCTSP = getMaCTSP(tableTatCaSP.CurrentCell.RowIndex);
                foreach(SanPhamHDN item in listSPHD)
                {
                    if(item.MaCTSP == MaCTSP) {
                        item.SoLuong = Convert.ToInt32(tableTatCaSP.CurrentRow.Cells[1].Value);
                        item.DonGiaNhap = Convert.ToDouble(tableTatCaSP.CurrentRow.Cells[2].Value);
                        item.ThanhTien = item.SoLuong * item.DonGiaNhap;
                        return;
                    }
                }
                listSPHD.Add(getCTHDN(tableTatCaSP.CurrentCell.RowIndex));
            }
        }
        private void ColumnTableTatCaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tableTatCaSP_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnTableTatCaSP_KeyPress);
            if (tableTatCaSP.CurrentCell.ColumnIndex == 1 || tableTatCaSP.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnTableTatCaSP_KeyPress);
                }
            }
        }
        private bool ValidateTableTatCaSP()
        {
            foreach (DataGridViewRow row in tableTatCaSP.Rows)
                if (Convert.ToBoolean(row.Cells[0].Value) == true && ((row.Cells[1].Value == null) || (row.Cells[2].Value == null))) {
                    MessageBox.Show("Bạn chưa điền đầy đủ thông tin");
                    row.Selected = true;
                    return false;
                }
            return true;


        }
        private void BindingListSPHD()
        {
            var list = new BindingList<SanPhamHDN>(listSPHD);
            tableSP.DataSource = list;
            tableSP.Columns["MaCTHDN"].Visible = false;
            tableSP.Columns["MaHDN"].Visible = false;
            tableSP.Columns["MaCTSP"].Visible = false;
            tableSP.Columns["TenSP"].DisplayIndex = 0;
            tableSP.Columns["TenSize"].HeaderText = "Size";
            tableSP.Columns["TenMau"].HeaderText = "Màu sắc";
            tableSP.Columns["SoLuong"].HeaderText = "Số lượng";
            tableSP.Columns["DonGiaNhap"].HeaderText = "Đơn giá";
            tableSP.Columns["ThanhTien"].HeaderText = "Thành tiền";
        }

        private void btnSuaSPSubmit_Click(object sender, EventArgs e)
        {
            double tongTien = 0;
            if (ValidateTableTatCaSP() == true && isThem == true) {
                formSuaSP.Visible = false;
                foreach (SanPhamHDN sp in listSPHD)
                {
                    tongTien += sp.ThanhTien;
                }
                BindingListSPHD();
            }
            if (ValidateTableTatCaSP() == true && isThem == false)
            {
                if(MessageBox.Show("Bạn có muốn sửa sản phẩm hóa đơn không? ", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

					sql.Execute($"delete from ChiTietHDN where MaHDN = {MaHDN}");

					foreach (SanPhamHDN sp in listSPHD)
                    {
                        tongTien += sp.ThanhTien;
                        cthdn.create(sp);
                    }
                        
                    formSuaSP.Visible = false;
                    BindingListSPHD();
                    MessageBox.Show("Sửa sản phẩm trong hóa đơn thành công");
                }
            }
            txtTongTien.Text = tongTien.ToString(); 
        }

            #endregion

        private void tableTatCaSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && Convert.ToBoolean(tableTatCaSP.CurrentCell.Value) == false && tableTatCaSP.CurrentRow.Cells[1].Value != null && tableTatCaSP.CurrentRow.Cells[2].Value != null)
            {
                listSPHD.Add(getCTHDN(e.RowIndex));
                return;
            }
            if (e.ColumnIndex == 0 && Convert.ToBoolean(tableTatCaSP.CurrentCell.Value) == true)
            {
                int MaCTSP = getMaCTSP(tableTatCaSP.CurrentCell.RowIndex);
                foreach (SanPhamHDN item in listSPHD)
                    if (item.MaCTSP == MaCTSP)
                    {
                        listSPHD.Remove(item);
                        break;
                    }

                tableTatCaSP.CurrentRow.Cells[1].Value = "";
                tableTatCaSP.CurrentRow.Cells[2].Value = "";
            }
        }

        private void txtTKSP_TextChange(object sender, EventArgs e)
        {
            string query = "select TenSP, TenS, TenMS from ChiTietSP c " +
                "join Size on Size.MaS = c.MaS " +
                "join SanPham s on s.MaSP = c.MaSP " +
                "join MauSac m on m.MaMs = c.MaMS";
            if (txtTKSP.Text == "")
                tableTatCaSP.DataSource = sql.table(query);
            else
                tableTatCaSP.DataSource = sql.table(query + $" where TenSP like N'%{txtTKSP.Text}%'");
            TichSPDaChon();
        }

        private void setFormSuaHDN(int i)
        {
            DataTable dt = hdn.getDataTableByField("MaHDN", $"{MaHDN}");
            string maNV = dt.Rows[0]["MaNV"].ToString();
            string maNCC = dt.Rows[0]["MaNCC"].ToString();
            listSPHD = new List<SanPhamHDN>();
            List<Object> listCTHDN = cthdn.getListByField("MaHDN", $"{MaHDN}");
            foreach(ChiTietHDN item in listCTHDN)
            {
                SanPhamHDN sp = new SanPhamHDN();
                sp.MaCTHDN = item.MaCTHDN;
                sp.SoLuong = item.SoLuong;
                sp.ThanhTien = item.ThanhTien;
                sp.DonGiaNhap = item.DonGiaNhap;
                sp.MaHDN = item.MaHDN;
                sp.MaCTSP = item.MaCTSP;
                string query = "select TenSP, TenS, TenMS from ChiTietSP c " +
                "join Size on Size.MaS = c.MaS " +
                "join SanPham s on s.MaSP = c.MaSP " +
                "join MauSac m on m.MaMs = c.MaMS " +
                $"where MaCTSP = {sp.MaCTSP}";
                DataTable dt2 = sql.table(query);
                sp.TenMau = dt2.Rows[0]["TenMS"].ToString();
                sp.TenSize = dt2.Rows[0]["TenS"].ToString();
                sp.TenSP = dt2.Rows[0]["TenSP"].ToString();
                listSPHD.Add(sp);
            }
            lbThemHDN.Text = "Sửa hóa đơn";
            btnThemHDNSubmit.Text = "Sửa hóa đơn";
            
            dtpNgayNhap.Value = Convert.ToDateTime(tableHDN.Rows[i].Cells[3].Value);
            txtMST.Text = tableHDN.Rows[i].Cells[4].Value.ToString();
            cmbNCC.SelectedIndex = cmbNCC.FindStringExact(maNCC + " - " + tableHDN.Rows[i].Cells[6].Value.ToString());
            cmbNV.SelectedIndex = cmbNV.FindString(maNV + " - " + tableHDN.Rows[i].Cells[7].Value.ToString());
            txtTK.Text = "";
            txtTongTien.Text = tableHDN.Rows[i].Cells[5].Value.ToString();
            BindingListSPHD();
            formThemHDN.Visible = true;
        }
        private void getListSPHD()
        {
            listSPHD = new List<SanPhamHDN>();

        }
        private void tableHDN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MaHDN = Convert.ToInt32(tableHDN.CurrentRow.Cells[2].Value);
            if (e.ColumnIndex == 0)
            {
                if(MessageBox.Show("Bạn có muốn xóa hóa đơn không?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    HoaDonNhap item = new HoaDonNhap();
                    item.MaHDN = MaHDN;
                    hdn.delelte(item);
                    FormHoaDonNhap_Load(sender, e);
                }
            }
            if(e.ColumnIndex == 1)
            {
                isThem = false;
                setFormSuaHDN(tableHDN.CurrentCell.RowIndex);
            }
        }
    }
}
            
