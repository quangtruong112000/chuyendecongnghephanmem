
using GUI.BUS;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QuanLy
{
    public partial class Form1 : Form
    {
        public Form1(List<Data.HangHoa> hangs ,string Phieu,NhanVien nhanvien,string NoiDung)
        {
            InitializeComponent();
            LoalData(hangs,Phieu, nhanvien,NoiDung);
        }

        private void LoalData(List<Data.HangHoa> hangs, string phieu , NhanVien nhanvien, string NoiDung)
        {
            ReportParameter[] param = new ReportParameter[4];
            param[0] = new ReportParameter("NoiDung", NoiDung);
            param[1] = new ReportParameter("NgayTao", DateTime.Now.ToString());
            param[2] = new ReportParameter("NhanVien",nhanvien.Ten1);
            param[3] = new ReportParameter("MaPhieu",phieu);

            this.reportViewer1.LocalReport.SetParameters(param);
            var reportDataSource = new ReportDataSource("DataSet1", hangs);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

          
        }
    }
}
