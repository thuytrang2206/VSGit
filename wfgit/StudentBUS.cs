using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfgit
{
   public class StudentBUS
    {
        private static StudentBUS instance;
        public static StudentBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StudentBUS();
                }
                return instance;
            }
        }
        private StudentBUS() { }
        public void Xem(DataGridView data)
        {
            data.DataSource = StudentDAO.Instance.Xem();
        }
        public void TimKiem(DataGridView data,string Id)
        {
            data.DataSource = StudentDAO.Instance.TimKiem(Id);
        }
    }
}
