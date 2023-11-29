using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        dbNhanVienDataContext db = new dbNhanVienDataContext();
        public Form1()
        {
            InitializeComponent();
        }
        private void showData()
        {
            dtgvNV.Rows.Clear();
            dtgvNV.Refresh();
            foreach (var nv in db.NHANVIENs.ToList())
            {
                dtgvNV.Rows.Add(nv.MANV, nv.HOTENNV, nv.NGAYSINH, nv.GIOITINH);
            }
            dtgvNV.Visible = true;
        }
        private bool FormValidation()
        {
            if (txtId.Text == string.Empty)
            {
                MessageBox.Show("Nhập mã nhân viên!");
                return false;
            }
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Nhập tên nhân viên!");
                return false;
            }
            if (dtpDOB.Value == null)
            {
                MessageBox.Show("Nhập ngày sinh!");
                return false;
            }
            if (cbbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Nhập giới tính!");
                return false;
            }
            return true;
        }
        private void clearForm()
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            dtpDOB.Text = null;
            cbbGender.SelectedIndex = -1;
        }
        private void storeNhanVien(NHANVIEN nv)
        {
            nv.MANV = txtId.Text;
            nv.HOTENNV = txtName.Text;
            nv.NGAYSINH = dtpDOB.Value;
            nv.GIOITINH = cbbGender.Text;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dtgvNV.Visible = false;
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(FormValidation())
            {
                NHANVIEN nv = new NHANVIEN();
                nv.MANV = txtId.Text;
                nv.HOTENNV = txtName.Text;
                nv.NGAYSINH = dtpDOB.Value;
                nv.GIOITINH = cbbGender.Text;
                db.NHANVIENs.InsertOnSubmit(nv);
                db.SubmitChanges();
                MessageBox.Show("Thêm thành công nhân viên " + nv.HOTENNV);
                showData();
                clearForm();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(db.NHANVIENs.Where(s => s.MANV == txtId.Text).Count() == 1)
            {
                NHANVIEN nv = db.NHANVIENs.First(s => s.MANV == txtId.Text);
                if (txtName.Text != string.Empty)
                {
                    nv.HOTENNV = txtName.Text;
                }
                if (dtpDOB.Value != DateTime.MinValue)
                {
                    nv.NGAYSINH = dtpDOB.Value;
                }
                if (cbbGender.SelectedIndex != -1)
                {
                    nv.GIOITINH = cbbGender.Text;
                }
                db.SubmitChanges();
                showData();
                clearForm();
            }
        }

        private void dtgvNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = dtgvNV.Rows[e.RowIndex].Cells[0].Value;
            NHANVIEN nv = db.NHANVIENs.First(s => s.MANV == id);
            txtId.Text = nv.MANV;
            txtName.Text = nv.HOTENNV;
            dtpDOB.Value = nv.NGAYSINH.Value;
            cbbGender.Text = nv.GIOITINH;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (db.NHANVIENs.Where(s => s.MANV == txtId.Text).Count() == 1)
            {
                NHANVIEN nv = db.NHANVIENs.First(s => s.MANV == txtId.Text);
                db.NHANVIENs.DeleteOnSubmit(nv);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công nhân viên " + txtName.Text);
                showData();
                clearForm();
            }
        }
    }
}
