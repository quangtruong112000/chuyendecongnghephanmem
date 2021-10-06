﻿using GUI.BUS;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyCafe.Gul
{
    public partial class QuanLy : Form
    {
        int MA = 100;
        int MamON =1000;
      public int MaBan =1;
        int Check = -1;
        private BLLBan BLLBan;
        private BLLNhomMon nhomMon;
        private BLLThucDon ThucDon;
        private GUI.BUS.NhanVien nhanVien;
        private BLLNhanvien BLLNhanvien;

        GUI.BUS.Service1Client BLL = new GUI.BUS.Service1Client();

        public QuanLy(TrangChu trangChu)
        {
            InitializeComponent();
            LoadDatabase();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            LoadDatabase();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            LoadDatabase();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            LoadDatabase();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }

        internal void AddNhom(NhomMon nhomMon)
        {
            this.BLL.InsertNhomMon(nhomMon);
            LoadDatabase();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
       
            NhomMau nhomMau = new NhomMau((MA + 1), this);
            nhomMau.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                NhomMon nhomMon1 = new NhomMon();
                nhomMon1.Maloai = Convert.ToInt32(dataGridView3.Rows[Check].Cells[0].Value.ToString());
                nhomMon1.Tenloai = dataGridView3.Rows[Check].Cells[1].Value.ToString();
                nhomMon1.MAU = dataGridView3.Rows[Check].Cells[2].Value.ToString();
                BLL.DeleteNhomMon(nhomMon1); LoadDatabase();
            }
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
        
            LoadDatabase();
        }

        internal void Update(NhomMon nhomMon)
        {
            this.BLL.UpdateNhomMon(nhomMon);
            LoadDatabase();

        }

        public void LoadDatabase()
        {
            this.BLLNhanvien = new BLLNhanvien();
            nhanVien = new GUI.BUS.NhanVien();
            nhanVien.MaNV1 = "5951071110";
            nhomMon = new BLLNhomMon();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MaLoai");
            dataTable.Columns.Add("TenLoai");
            dataTable.Columns.Add("MauSac");

            foreach (var i in BLL.SelectNhomMon())
            {
                dataTable.Rows.Add(i.Maloai, i.Tenloai, i.MAU);
            }
            dataGridView3.DataSource =dataTable;
            dataGridView3.Show();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            foreach (var item in BLL.SelectNhomMon())
            {
                MA = (Convert.ToInt32(item.Maloai.ToString()));
                comboBox1.Items.Add(item.Tenloai.ToString());
                comboBox2.Items.Add(item.Tenloai.ToString());
                comboBox2.Tag = item.Maloai.ToString();
            }
            ThucDon = new BLLThucDon();
            DataTable dataTablethucdon = new DataTable();
            dataTablethucdon.Columns.Add("Mamon");
            dataTablethucdon.Columns.Add("tenmon");
            dataTablethucdon.Columns.Add("maloai");
            dataTablethucdon.Columns.Add("dongia");
            dataTablethucdon.Columns.Add("DVT");
            foreach (var i in BLL.SelectThucDon())
            {
                dataTablethucdon.Rows.Add(i.MAMON, i.tenmon, i.NhomMon.Maloai,i.DONGIA,i.DVT);
            }
            dataGridView1.DataSource = dataTablethucdon;
            dataGridView1.Show();
            foreach (var item in BLL.SelectThucDon())
            {
                MamON = (Convert.ToInt32(item.MAMON.ToString()));
            }
            BLLBan = new BLLBan();

            DataTable dataTableban = new DataTable();
            dataTableban.Columns.Add("Maban");
            dataTableban.Columns.Add("tenban");
            dataTableban.Columns.Add("Trangthai");
            foreach (var i in BLL.SelectBan())
            {
                dataTableban.Rows.Add(i.MaBan, i.TenBan, i.TrangThai);
            }


            dataGridView2.DataSource = dataTableban;
            dataGridView2.Show();
            foreach (var item in BLL.SelectBan())
            {
                MaBan= (Convert.ToInt32(item.MaBan.ToString()) +1);
            }
            Check = -1;

                label10.Text ="Tổng Số Bàn :" + BLL.SelectBan().Length + " Bàn";
          
            foreach (var item in BLL.TongSoMon())
            {
                label11.Text = "Tổng Số Món :" + item.Soluong.ToString()+" Món";
            }
            foreach (var item in BLL.TongNhomMon())
            {
                label12.Text = "Tổng Số Nhóm Món :" + item.Soluong.ToString()+" Nhóm ";
            }


            DataTable dataTablenv = new DataTable();
            dataTablenv.Columns.Add("manv");
            dataTablenv.Columns.Add("ten");
            dataTablenv.Columns.Add("gioitinh");
            dataTablenv.Columns.Add("sdt");
            dataTablenv.Columns.Add("chucvu");
            dataTablenv.Columns.Add("matkhau");
            foreach (var i in BLL.SelectNV())
            {
                dataTablenv.Rows.Add(i.MaNV1, i.Ten1, i.GioiTinh1,i.SDT1,i.Chucvu1,i.MaKhau1);
            }

            dataGridView4.DataSource = dataTablenv;



            /*foreach (DataRow item in this.BLL.SelectNV().Rows)
            {
                nhanVien.MaNV1= item["MaNV"].ToString();
            }
*/
            foreach (var i in BLL.SelectNV())
            {
                nhanVien.MaNV1 = i.MaNV1.ToString();
            }

            int n = Convert.ToInt32(nhanVien.MaNV1.Substring(6));
            n++;
            
            label17.Text = "595107"+n;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                NhomMon nhomMon1 = new NhomMon();
                nhomMon1.Maloai = Convert.ToInt32(dataGridView3.Rows[Check].Cells[0].Value.ToString());
                nhomMon1.Tenloai = dataGridView3.Rows[Check].Cells[1].Value.ToString();
                nhomMon1.MAU = dataGridView3.Rows[Check].Cells[2].Value.ToString();
                NhomMau nhomMau = new NhomMau(nhomMon1, this);
                nhomMau.Show();

            }

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Check = e.RowIndex;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex > -1)
            {
                if (MamON == 1)
                {
                    MamON = 10000;
                }

                GUI.BUS.ThucDon thucDon = new ThucDon();
                thucDon.MAMON = (MamON + 1);
                thucDon.tenmon = textBox4.Text;
                thucDon.NhomMon = new NhomMon();
                thucDon.NhomMon.Maloai = Convert.ToInt32(dataGridView3.Rows[(comboBox2.SelectedIndex)].Cells[0].Value.ToString());
                thucDon.DONGIA = Convert.ToInt32(textBox5.Text);
                thucDon.DVT = textBox6.Text;
                this.BLL.InsetThucDon(thucDon);
                LoadDatabase();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {

                GUI.BUS.ThucDon thucDon = new ThucDon();
                thucDon.MAMON = Convert.ToInt32(dataGridView1.Rows[Check].Cells[0].Value.ToString());
                this.BLL.DeleteThucDon(thucDon);
                LoadDatabase();


            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TimKiemNhomMon(string n)
        {
            if (n.Length > 0)
            {
                nhomMon = new BLLNhomMon();
                /*DataTable dataTable = BLL.TimKiemNhomMon(n);*/
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("MaLoai");
                dataTable.Columns.Add("TenLoai");
                dataTable.Columns.Add("MauSac");

                foreach (var i in BLL.SelectNhomMon())
                {
                    dataTable.Rows.Add(i.Maloai, i.Tenloai, i.MAU);
                }
                dataGridView3.DataSource = dataTable;
                dataGridView3.Show();
                foreach (var item in BLL.TimKiemNhomMon(n))
                {
                    comboBox2.SelectedItem = item.Tenloai.ToString();
                }
               
            }
            else { LoadDatabase(); }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            int n  = comboBox2.SelectedIndex;
            GUI.BUS.ThucDon thucDon = new ThucDon();
                thucDon.MAMON = MamON;
               LoadDatabase();
                thucDon.tenmon = textBox4.Text;
                thucDon.NhomMon = new NhomMon();
                thucDon.NhomMon.Maloai = Convert.ToInt32(dataGridView3.Rows[n].Cells[0].Value.ToString());
                thucDon.DONGIA = Convert.ToInt32(textBox5.Text);
                thucDon.DVT = textBox6.Text;
                this.BLL.UpdateThucDon(thucDon);
                LoadDatabase();
 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Check = e.RowIndex;
            MamON = Convert.ToInt32(dataGridView1.Rows[Check].Cells[0].Value.ToString());
            MessageBox.Show(Check.ToString());
            textBox4.Text = dataGridView1.Rows[Check].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.Rows[Check].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[Check].Cells[4].Value.ToString();
            string ma =dataGridView1.Rows[Check].Cells[2].Value.ToString();
            TimKiemNhomMon(ma);

        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                string Ten = comboBox1.SelectedItem.ToString();
                ThucDon = new BLLThucDon();
                
                DataTable dataTablethucdon = new DataTable();
                dataTablethucdon.Columns.Add("Mamon");
                dataTablethucdon.Columns.Add("tenmon");
                dataTablethucdon.Columns.Add("maloai");
                dataTablethucdon.Columns.Add("dongia");
                dataTablethucdon.Columns.Add("DVT");
                foreach (var i in BLL.TimKiemThucDon(Ten))
                {
                    dataTablethucdon.Rows.Add(i.MAMON, i.tenmon, i.NhomMon.Maloai, i.DONGIA, i.DVT);
                }
                dataGridView1.DataSource = dataTablethucdon;
                dataGridView1.Show();
            }
        }

     

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string TimKiem = textbox1.Text;
            if (TimKiem.Length > 0)
            {
                ThucDon = new BLLThucDon();
               

                DataTable dataTablethucdon = new DataTable();
                dataTablethucdon.Columns.Add("Mamon");
                dataTablethucdon.Columns.Add("tenmon");
                dataTablethucdon.Columns.Add("maloai");
                dataTablethucdon.Columns.Add("dongia");
                dataTablethucdon.Columns.Add("DVT");
                foreach (var i in BLL.TimKiemThucDon1(TimKiem))
                {
                    dataTablethucdon.Rows.Add(i.MAMON, i.tenmon, i.NhomMon.Maloai, i.DONGIA, i.DVT);
                }

                dataGridView1.DataSource = dataTablethucdon;
                dataGridView1.Show();

            }
            else LoadDatabase();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Check = e.RowIndex;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                GUI.BUS.Ban ban = new GUI.BUS.Ban();
                ban.MaBan = Convert.ToInt32(dataGridView2.Rows[Check].Cells[0].Value.ToString());
                ban.TenBan = dataGridView2.Rows[Check].Cells[1].Value.ToString();
                ban.TrangThai = dataGridView2.Rows[Check].Cells[2].Value.ToString();
                if (BLL.DeleteBan(ban) == 0)
                {
                    MessageBox.Show("Bàn này không thể xóa vui lòng kiểm tra lại tình trạng bàn");
                }
                LoadDatabase();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Ban ban = new Ban(this);
            ban.Show();

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (Check >-1)
            {
                GUI.BUS.Ban ban = new GUI.BUS.Ban();
                ban.MaBan=Convert.ToInt32(dataGridView2.Rows[Check].Cells[0].Value.ToString());
                ban.TenBan=dataGridView2.Rows[Check].Cells[1].Value.ToString();
                ban.TrangThai = dataGridView2.Rows[Check].Cells[2].Value.ToString();
                Ban ban1 = new Ban(this,ban);
                ban1.Show();
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
           
           
        }

        private void button14_Click_2(object sender, EventArgs e)
        {
            Ban ban = new Ban(this,2);
            ban.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            nhanVien.MaNV1 = label17.Text.Substring(6);
            nhanVien.Ten1 = textBox7.Text;
            nhanVien.SDT1 = textBox8.Text;
            nhanVien.MaKhau1 = textBox9.Text;

            nhanVien.Chucvu1 = comboBox3.SelectedItem.ToString();
            if (radioButton1.Checked)
            {
                nhanVien.GioiTinh1 = "Nam";
            }
            if (radioButton2.Checked)
            {
                nhanVien.GioiTinh1 = "Nữ";
            }

            BLL.InsertIntoNV(nhanVien);
            LoadDatabase();

        }

        private void btnthongke_Click(object sender, EventArgs e)
        {

        }

        private void btnthongke_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            LoadDatabase();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            LoadDatabase();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            LoadDatabase();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex > -1)
            {
                if (MamON == 1)
                {
                    MamON = 10000;
                }

                GUI.BUS.ThucDon thucDon = new ThucDon();
                thucDon.MAMON = (MamON + 1);
                thucDon.tenmon = textBox4.Text;
                thucDon.NhomMon = new NhomMon();
                thucDon.NhomMon.Maloai = Convert.ToInt32(dataGridView3.Rows[(comboBox2.SelectedIndex)].Cells[0].Value.ToString());
                thucDon.DONGIA = Convert.ToInt32(textBox5.Text);
                thucDon.DVT = textBox6.Text;
                this.BLL.InsetThucDon(thucDon);
               
                LamMoi();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {

                GUI.BUS.ThucDon thucDon = new ThucDon();
                thucDon.MAMON = Convert.ToInt32(dataGridView1.Rows[Check].Cells[0].Value.ToString());
                this.BLL.DeleteThucDon(thucDon);
                LamMoi();
                
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                int n = comboBox2.SelectedIndex;
                GUI.BUS.ThucDon thucDon = new ThucDon();
                thucDon.MAMON = MamON;
                thucDon.tenmon = textBox4.Text;
                thucDon.NhomMon = new NhomMon();
                LoadDatabase();
                thucDon.NhomMon.Maloai = Convert.ToInt32(dataGridView3.Rows[n].Cells[0].Value.ToString());
                thucDon.DONGIA = Convert.ToInt32(textBox5.Text);
                thucDon.DVT = textBox6.Text;
                BLLThucDon t = new BLLThucDon();
                BLL.UpdateThucDon(thucDon);
                LamMoi();
            }

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            NhomMau nhomMau = new NhomMau((MA + 1), this);
            nhomMau.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                NhomMon nhomMon1 = new NhomMon();
                nhomMon1.Maloai = Convert.ToInt32(dataGridView3.Rows[Check].Cells[0].Value.ToString());
                nhomMon1.Tenloai = dataGridView3.Rows[Check].Cells[1].Value.ToString();
                nhomMon1.MAU = dataGridView3.Rows[Check].Cells[2].Value.ToString();
                BLL.DeleteNhomMon(nhomMon1); LoadDatabase();
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                NhomMon nhomMon1 = new NhomMon();
                nhomMon1.Maloai = Convert.ToInt32(dataGridView3.Rows[Check].Cells[0].Value.ToString());
                nhomMon1.Tenloai = dataGridView3.Rows[Check].Cells[1].Value.ToString();
                nhomMon1.MAU = dataGridView3.Rows[Check].Cells[2].Value.ToString();
                NhomMau nhomMau = new NhomMau(nhomMon1, this);
                nhomMau.Show();

            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string n = guna2TextBox1.Text;
            TimKiemNhomMon(n);
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
        
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                GUI.BUS.Ban ban = new GUI.BUS.Ban();
                ban.MaBan = Convert.ToInt32(dataGridView2.Rows[Check].Cells[0].Value.ToString());
                ban.TenBan = dataGridView2.Rows[Check].Cells[1].Value.ToString();
                ban.TrangThai = dataGridView2.Rows[Check].Cells[2].Value.ToString();
                Ban ban1 = new Ban(this, ban);
                ban1.Show();
            }
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                GUI.BUS.Ban ban = new GUI.BUS.Ban();
                ban.MaBan = Convert.ToInt32(dataGridView2.Rows[Check].Cells[0].Value.ToString());
                ban.TenBan = dataGridView2.Rows[Check].Cells[1].Value.ToString();
                ban.TrangThai = dataGridView2.Rows[Check].Cells[2].Value.ToString();
                if (BLL.DeleteBan(ban) == 0)
                {
                    MessageBox.Show("Bàn này không thể xóa vui lòng kiểm tra lại tình trạng bàn");
                }
                LoadDatabase();
            }
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
         
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox3.SelectedItem.ToString()!= null)
                {
                    nhanVien.MaNV1 = label17.Text.Substring(6);
                    nhanVien.Ten1 = textBox7.Text;
                    nhanVien.SDT1 = textBox8.Text;
                    nhanVien.MaKhau1 = textBox9.Text;

                    nhanVien.Chucvu1 = comboBox3.SelectedItem.ToString();
                    if (radioButton1.Checked)
                    {
                        nhanVien.GioiTinh1 = "Nam";
                    }
                    if (radioButton2.Checked)
                    {
                        nhanVien.GioiTinh1 = "Nữ";
                    }

                    BLL.InsertIntoNV(nhanVien);
                    LamMoi();
                }
            
            }
            catch { }
           

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void btntaikhoan_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            LoadDatabase();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            LoadDatabase();
        }

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            LoadDatabase();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            LoadDatabase();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            string TimKiem = textbox1.Text;
            if (TimKiem.Length > 0)
            {
                ThucDon = new BLLThucDon();

                DataTable dataTablethucdon = new DataTable();
                dataTablethucdon.Columns.Add("Mamon");
                dataTablethucdon.Columns.Add("tenmon");
                dataTablethucdon.Columns.Add("maloai");
                dataTablethucdon.Columns.Add("dongia");
                dataTablethucdon.Columns.Add("DVT");
                foreach (var i in BLL.TimKiemThucDon1(TimKiem))
                {
                    dataTablethucdon.Rows.Add(i.MAMON, i.tenmon, i.NhomMon.Maloai, i.DONGIA, i.DVT);
                }
                dataGridView1.DataSource = dataTablethucdon;
                dataGridView1.Show();

            }
            else LoadDatabase();
        }

        private void guna2Button8_Click_1(object sender, EventArgs e)
        {
            NhomMau nhomMau = new NhomMau((MA + 1), this);
            nhomMau.Show();
        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                NhomMon nhomMon1 = new NhomMon();
                nhomMon1.Maloai = Convert.ToInt32(dataGridView3.Rows[Check].Cells[0].Value.ToString());
                nhomMon1.Tenloai = dataGridView3.Rows[Check].Cells[1].Value.ToString();
                nhomMon1.MAU = dataGridView3.Rows[Check].Cells[2].Value.ToString();
                BLL.DeleteNhomMon(nhomMon1); LoadDatabase();
            }
        }

        private void guna2Button7_Click_1(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                NhomMon nhomMon1 = new NhomMon();
                nhomMon1.Maloai = Convert.ToInt32(dataGridView3.Rows[Check].Cells[0].Value.ToString());
                nhomMon1.Tenloai = dataGridView3.Rows[Check].Cells[1].Value.ToString();
                nhomMon1.MAU = dataGridView3.Rows[Check].Cells[2].Value.ToString();
                NhomMau nhomMau = new NhomMau(nhomMon1, this);
                nhomMau.Show();

            }
        }

        private void guna2TextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            LoadDatabase();
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            LoadDatabase();
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            LoadDatabase();
        }

        private void guna2Button13_Click_1(object sender, EventArgs e)
        {
            Ban ban = new Ban(this, 2);
            ban.Show();
        }

        private void guna2Button12_Click_1(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                GUI.BUS.Ban ban = new GUI.BUS.Ban();
                ban.MaBan = Convert.ToInt32(dataGridView2.Rows[Check].Cells[0].Value.ToString());
                ban.TenBan = dataGridView2.Rows[Check].Cells[1].Value.ToString();
                ban.TrangThai = dataGridView2.Rows[Check].Cells[2].Value.ToString();
                if (BLL.DeleteBan(ban) == 0)
                {
                    MessageBox.Show("Bàn này không thể xóa vui lòng kiểm tra lại tình trạng bàn");
                }
                LoadDatabase();
            }
        }

        private void guna2Button10_Click_1(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                GUI.BUS.Ban ban = new GUI.BUS.Ban();
                ban.MaBan = Convert.ToInt32(dataGridView2.Rows[Check].Cells[0].Value.ToString());
                ban.TenBan = dataGridView2.Rows[Check].Cells[1].Value.ToString();
                ban.TrangThai = dataGridView2.Rows[Check].Cells[2].Value.ToString();
                Ban ban1 = new Ban(this, ban);
                ban1.Show();
            }
        }

        private void guna2Button11_Click_1(object sender, EventArgs e)
        {
            Ban ban = new Ban(this);
            ban.Show();
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                nhanVien.MaNV1 = label17.Text.Substring(6);
                nhanVien.Ten1 = textBox7.Text;
                nhanVien.SDT1 = textBox8.Text;
                nhanVien.MaKhau1 = textBox9.Text;
               nhanVien.Chucvu1 = comboBox3.SelectedItem.ToString();
                if (radioButton1.Checked)
                {
                    nhanVien.GioiTinh1 = "Nam";
                }
                if (radioButton2.Checked)
                {
                    nhanVien.GioiTinh1 = "Nu";
                }

                BLL.UpdateNV(nhanVien);
                LamMoi();
            }
           
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                string MaNV = dataGridView4.Rows[Check].Cells[0].Value.ToString();
                BLL.DeleteNV(MaNV);
                LamMoi();
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Check = e.RowIndex;
            label17.Text = dataGridView4.Rows[Check].Cells[0].Value.ToString();
            textBox7.Text = dataGridView4.Rows[Check].Cells[1].Value.ToString();
            textBox8.Text = dataGridView4.Rows[Check].Cells[3].Value.ToString();
            textBox9.Text = dataGridView4.Rows[Check].Cells[5].Value.ToString();
            comboBox3.SelectedItem= dataGridView4.Rows[Check].Cells[4].Value.ToString();
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
          
       
            LamMoi();
        }

        private void LamMoi()
        {
            LoadDatabase();
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox3.SelectedIndex = 0;
            textBox4.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            comboBox2.SelectedIndex = 0;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
