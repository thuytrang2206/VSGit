using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
namespace EntityFramework
{
    public partial class Form1 : Form
    {
        List<Student> listDgrv;
        BindingSource bindingSource;
        public Form1()
        {
            InitializeComponent();
            bindingSource = new BindingSource();
            LoadData();

        }
        Student_DBEntities db = new Student_DBEntities();
        int selectRow;
        void LoadData()
        {
            var listDgrv = from s in db.Students select new { s.Id, s.Name, s.Address, s.Score, s.Id_class };
            bindingSource.DataSource = listDgrv.ToList();
            dtgvdata.DataSource = bindingSource;
            // dtgvdata.Refresh();
        }

        void EditSV()
        {
            int id = int.Parse(dtgvdata.SelectedCells[0].OwningRow.Cells["Id"].Value.ToString());
            Student st = db.Students.Find(id);
            st.Name = txtname.Text;
            st.Address = txtaddress.Text;
            st.Score = int.Parse(txtscore.Text);
            st.Id_class = int.Parse(txtmalop.Text);
            db.SaveChanges();
            LoadData();
        }
        void DelSV()
        {
            int id = int.Parse(txtId.Text);
            Student st = db.Students.Where(p => p.Id == id).SingleOrDefault();
            db.Students.Remove(st);
            db.SaveChanges();
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Student stu = new Student();
                //   stu.Id = int.Parse(txtMa.Text);
                stu.Name = txtname.Text;
                stu.Address = txtaddress.Text;
                stu.Score = int.Parse(txtscore.Text);
                stu.Id_class = int.Parse(txtmalop.Text);
                db.Students.Add(stu);
                db.SaveChanges();
                LoadData();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSV();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    dtgvdata.Rows.RemoveAt(dtgvdata.CurrentCell.RowIndex);
            //}
            //catch (Exception ex)
            //{
            //    Console.Write(ex.ToString());
            //}
            DelSV();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtname.Text = "";
            txtaddress.Text = "";
            txtscore.Text = "";
            txtmalop.Text = "";
        }

        private void dtgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectRow = e.RowIndex;

            DataGridViewRow row = dtgvdata.Rows[selectRow];
            txtId.Text = row.Cells[0].Value.ToString();
            txtname.Text = row.Cells[1].Value.ToString();
            txtaddress.Text = row.Cells[2].Value.ToString();
            txtscore.Text = row.Cells[3].Value.ToString();
            txtmalop.Text = row.Cells[4].Value.ToString();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            //dtgvdata.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //try
            //{
            //    foreach (DataGridViewRow row in dtgvdata.Rows)
            //    {

            //        if (row.Cells[2].Value.ToString().Equals(search)) ;
            //        {
            //            row.Selected = true;

            //            break;

            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.Write(ex.ToString());
            //}
            int rowIndex = 1;  //this one is depending on the position of cell or column
                               //string first_row_data=dataGridView1.Rows[0].Cells[0].Value.ToString() ;

            dtgvdata.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                bool valueResulet = true;
                foreach (DataGridViewRow row in dtgvdata.Rows)
                {
                    if (row.Cells[rowIndex].Value.ToString().Equals(search))
                    {
                        rowIndex = row.Index;
                        dtgvdata.Rows[rowIndex].Selected = true;
                        rowIndex++;
                        valueResulet = false;
                    }
                }
                if (valueResulet != false)
                {
                    MessageBox.Show("Record is not avalable for this Name " + txtSearch.Text, "Not Found");
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

     
       

    }
}
