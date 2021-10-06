﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;
using GUI.BUS;

namespace QuanLyCafe.Gul
{
    public partial class ThongKe : Form
    {
        private BLLHoaDon hoaDon;
        private BLLThucDon thucDon;
        private BLLBan ban;
        private BLLNhomMon nhomMon;

        GUI.BUS.Service1Client BLL = new GUI.BUS.Service1Client();

        public ThongKe(TrangChu trangChu)
        {
            InitializeComponent();

            LoadDataBase();
          this.ForeColor = trangChu.ForeColor;

        }

        private void LoadDataBase()
        {
            thucDon = new BLLThucDon();
            hoaDon = new BLLHoaDon();
            ban = new BLLBan();
            nhomMon = new BLLNhomMon();
            Thongke();      
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thongke();

        }
     public  void Thongke()
        {
            int a = 0, b = 0;

            DateTime time1 = datatime1.Value;
            DateTime time2 = datatime2.Value;
            if (time2.CompareTo(time1) > -1)
            {
                dataGridView2.DataSource = BLL.TimKiemHoaDon2(time1, time2);
                dataGridView3.DataSource = BLL.SelectThucDon1(time1, time2);

                BLL.TimKiemHoaDon1(time1, time2);

                foreach (var item in BLL.TimKiemHoaDon1(time1, time2))
                {
                    label1.Text = "Tổng Tiền Bán Được : " + item.TongTien1.ToString() + " VND";
                    label2.Text = "Tổng Tiền Gỉam Gía : " + item.GIAMGIA.ToString() + " VND";
                    ; try
                    {
                        a = Convert.ToInt32(item.TongTien1.ToString());
                        b = Convert.ToInt32(item.GIAMGIA.ToString());
                    }
                    catch { }
                }

                foreach (var item in BLL.SelectThucDon2(time1, time2))
                {
                    label3.Text = "Sô Lượng món bán được  : " + item.Soluong.ToString() + " Món ";

                }
                foreach (var item in BLL.TongSoHd(time1, time2))
                {
                    label4.Text = "Tổng Số Hóa Đơn : " + item.Soluong.ToString();

                }
                foreach (var item in BLL.TongSoMon())
                {
                    label7.Text = "Tổng Số Món : " + item.Soluong.ToString();

                }

                
                    label6.Text = "Tổng Số Bàn : " + BLL.SelectBan().Length;

                
                foreach (var item in BLL.TongNhomMon())
                {
                    label8.Text = "Tổng Số Nhóm Món : " + item.Soluong.ToString();

                }
                label5.Text = "Tổng Số Tiền Thu Về : " + (a - b) + " VND ";

            }
            else
            {
                MessageBox.Show("Bạn Chọn Ngày Không hợp lệ");
            }


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewMethod();

        }

        private  void NewMethod()
        {
            Microsoft.Office.Interop.Excel._Application _Application = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = _Application.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Cells[2,10] = " Bảng Thống Kê Từ Ngày "+ datatime1.Value.ToString("dd/MM/yyyy")+" Đến Ngày "+datatime2.Value.ToString("dd/MM/yyyy");
            worksheet.Cells[5, 2] = label4.Text;
            worksheet.Cells[6, 2] = label1.Text;
            worksheet.Cells[7, 2] = label2.Text;
            worksheet.Cells[9, 2] = label5.Text;
            worksheet.Cells[6,14] = label3.Text;
            worksheet.Cells[8,14] = label6.Text;
            worksheet.Cells[8,16] = label7.Text;
            worksheet.Cells[8,18] = label8.Text;
            // hoadon 
            int hang = 12;
            worksheet.Cells[hang, 16] = " Bảng Thống Kê Thưc Đơn";
            worksheet.Cells[hang,5] = " Bảng Thống Kê Hóa Đơn"; hang += 2;
            worksheet.Cells[hang, 1] = "  STT";
            worksheet.Cells[hang,2] = " Mã Hóa Đơn";
            worksheet.Cells[hang,4] = " Tiền Giảm Gía";
            worksheet.Cells[hang,6] = "Mã Bàn  ";
            worksheet.Cells[hang,8] = " Ngày Vào ";
            worksheet.Cells[hang,10] = " Tổng Tiền ";
            //Thuc don
            worksheet.Cells[hang,13] = "   STT";
            worksheet.Cells[hang,14] = " Mã Món";
            worksheet.Cells[hang,16] = " Tên Món";
            worksheet.Cells[hang,18] = "Mã Loại ";
            worksheet.Cells[hang,20] = " Số Lượng ";
            worksheet.Cells[hang,22] = " Doanh Thu ";
        
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                try
                {
                    for (int j = 0; j < 5; j++)
                    {
                        worksheet.Cells[i + hang + 1, 1] = i + 1;
                        worksheet.Cells[i + hang + 1, 2 + j * 2] = dataGridView2.Rows[i].Cells[j].Value.ToString();

                    }
                }
                catch
                {

                }
               

            }
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {

                try
                {
                    for (int j = 0; j < 5; j++)
                    {
                        worksheet.Cells[i + hang + 1, 13] = i + 1;
                        worksheet.Cells[i + hang + 1, 14 + j * 2] = dataGridView3.Rows[i].Cells[j].Value.ToString();
                    }

                }
                catch
                {

                }
               
            }

            _Application.Visible = true;

        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            Thongke();
        }

        private void btnxuatfile_Click(object sender, EventArgs e)
        {
            NewMethod();
        }


        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnthongkke_Click(object sender, EventArgs e)
        {
            Thongke();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            NewMethod();
        }
    }
}
