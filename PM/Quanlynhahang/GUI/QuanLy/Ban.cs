﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe.Gul
{
    public partial class Ban : Form
    {
        private GUI.BUS.Ban ban1;
        private QuanLy quanLy=null;
        GUI.BUS.Service1Client BLL=new GUI.BUS.Service1Client();
        public Ban( QuanLy quanLy)
        {
            InitializeComponent();
            this.quanLy = quanLy;
            textBox1.Text = "" +this.quanLy.MaBan;
        }

        public Ban(QuanLy quanLy, int n)
        {
            InitializeComponent();
            this.quanLy = quanLy;
            tabControl1.SelectedIndex=1;
            textBox3.Text = "1";
            label1.Text = "Bạn vui lòng chọn số lượng bàn cần thêm";
        }
        public Ban(QuanLy quanLy, GUI.BUS.Ban ban)
        {
            InitializeComponent();
            this.quanLy = quanLy;
            textBox1.Text = ""+ban.MaBan;
            textBox2.Text = "" + ban.TenBan;
            this.ban1 = ban;
            btnthem.Text = "Lưu";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.BUS.BLLBan BLLBan = new GUI.BUS.BLLBan();
            if (btnthem.Text.Equals("Lưu"))
            {
                ban1.TenBan = textBox2.Text;
                BLL.UpdeteBan(ban1);
            }
            else
            {
                ban1 = new GUI.BUS.Ban();
                ban1.MaBan = Convert.ToInt32(textBox1.Text);
                ban1.TenBan = textBox2.Text;
                ban1.TrangThai = "Đang Trống";
                BLL.InsertBan(ban1);
            }
            quanLy.LoadDatabase();
            Dispose();  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.BUS.BLLBan BLLBan = new GUI.BUS.BLLBan();
            try
            {   
                int n = Convert.ToInt32(textBox3.Text);
                if (n >= 0)
                {                   
                    for (int i =0; i < n; i++)
                    {
                        ban1 = new GUI.BUS.Ban();
                        ban1.MaBan = quanLy.MaBan;
                        ban1.TenBan = "Bàn "+ quanLy.MaBan;
                        ban1.TrangThai = " Đang Trống";
                        BLL.InsertBan(ban1);
                        quanLy.MaBan++;
                        quanLy.LoadDatabase();
                    } Dispose();
                }
                else
                {
                    MessageBox.Show("Số nhập vào không âm");
                }
            }catch (Exception)
            {
                MessageBox.Show("Bạn phải nhập bằng số");
            }

        }

        private void btntao_Click(object sender, EventArgs e)
        {
            GUI.BUS.BLLBan BLLBan = new GUI.BUS.BLLBan();
            try
            {
                int n = Convert.ToInt32(textBox3.Text);
                if (n >= 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        ban1 = new GUI.BUS.Ban();
                        ban1.MaBan = quanLy.MaBan;
                        ban1.TenBan = "Bàn " + quanLy.MaBan;
                        ban1.TrangThai = " Đang Trống";
                        BLL.InsertBan(ban1);
                        quanLy.MaBan++;
                        quanLy.LoadDatabase();
                    }
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Số nhập vào không âm");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn phải nhập bằng số");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            GUI.BUS.BLLBan BLLBan = new GUI.BUS.BLLBan();
            if (btnthem.Text.Equals("Lưu"))
            {
                ban1.TenBan = textBox2.Text;
                BLL.UpdeteBan(ban1);
            }
            else
            {
                ban1 = new GUI.BUS.Ban();
                ban1.MaBan = Convert.ToInt32(textBox1.Text);
                ban1.TenBan = textBox2.Text;
                ban1.TrangThai = "Đang Trống";
                BLL.InsertBan(ban1);
            }
            quanLy.LoadDatabase();
            Dispose();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
