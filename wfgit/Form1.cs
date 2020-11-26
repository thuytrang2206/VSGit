using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfgit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        
        private void btnShow_Click(object sender, EventArgs e)
        {
            //SqlConnection connection= new SqlConnection(connectionstring);
            //connection.Open();
            //string query = "SELECT*FROM dbo.Student";
            //or
            //string query = "Select Id as N'Mã SV', Name as N'Tên', Birth as N'Ngày sinh', Address as N'Địa chỉ', ScoreMath as N'Điểm toán',ScorePhy as N'Điểm lý', Id_class as N'Mã lớp' from dbo.Student";
            //SqlDataAdapter->select;
            //SqlCommand->insert, update, delete

            //SqlCommand command = new SqlCommand(query, connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            // nếu k dùng sqlcommand ->SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            //DataTable -> 1 bảng
            //DataSet-> chứa nhiều bảng , như 1 database hoàn chỉnh
            //DataTable table = new DataTable();
            //adapter.Fill(table);
            //dtgview.DataSource = table;
            //connection.Close();
            //string query = "Select Id as N'Mã SV', Name as N'Tên', Birth as N'Ngày sinh', Address as N'Địa chỉ', ScoreMath as N'Điểm toán',ScorePhy as N'Điểm lý', Id_class as N'Mã lớp' from dbo.Student";
            //dtgview.DataSource = Dataprovider.Instance.ExcuteQuery(query);
            //thông qua mô hình 3 lớp
            StudentBUS.Instance.Xem(dtgview);
           


        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command = connection.CreateCommand();

           command.CommandText= "Insert into dbo.Student value('"+txtMasv.Text+"','"+txtTen.Text+"','"+txtNS.Text+"','"+txtQQ.Text+"','"+txtDT.Text+"','"+txtDL.Text+"','"+txtMaLop.Text+"')";

            
          
            connection.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            //string query = "Select Id as N'Mã SV', Name as N'Tên', Birth as N'Ngày sinh', Address as N'Địa chỉ', ScoreMath as N'Điểm toán',ScorePhy as N'Điểm lý', Id_class as N'Mã lớp' from dbo.Student Where Id like @Id";
            //object[] paramete = new object[] { txtSearch.Text };
            //dtgview.DataSource = Dataprovider.Instance.ExcuteQuery(query,paramete);
            StudentBUS.Instance.TimKiem(dtgview,txtSearch.Text);

        }

        string connectionstring = @"Data Source=.\SQLExpress;Initial Catalog=Student_DB;Integrated Security=True";
        private void dtgview_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            
            int i;

            i= dtgview.CurrentRow.Index;
            txtMasv.Text = dtgview.Rows[i].Cells[0].Value.ToString();
            txtTen.Text = dtgview.Rows[i].Cells[1].Value.ToString();
            txtNS.Text = dtgview.Rows[i].Cells[2].Value.ToString();
            txtQQ.Text = dtgview.Rows[i].Cells[3].Value.ToString();
            txtDT.Text = dtgview.Rows[i].Cells[4].Value.ToString();
            txtDL.Text = dtgview.Rows[i].Cells[5].Value.ToString();
            txtMaLop.Text = dtgview.Rows[i].Cells[6].Value.ToString();
            connection.Close();
        }

        // trả ra datatable theo câu query



    }
}
