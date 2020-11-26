using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfgit
{
    class StudentDAO
    {
        private static StudentDAO instance;
        public static StudentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StudentDAO();
                }
                return instance;
            }
        }
        private StudentDAO() { }
        public DataTable Xem()
        {
            string query = "Select Id as N'Mã SV', Name as N'Tên', Birth as N'Ngày sinh', Address as N'Địa chỉ', ScoreMath as N'Điểm toán',ScorePhy as N'Điểm lý', Id_class as N'Mã lớp' from dbo.Student";
            return Dataprovider.Instance.ExcuteQuery(query);
        }
        public DataTable TimKiem(string Id)
        {
            object[] parameter = new object[] { Id };
            string query = "Select Id as N'Mã SV', Name as N'Tên', Birth as N'Ngày sinh', Address as N'Địa chỉ', ScoreMath as N'Điểm toán',ScorePhy as N'Điểm lý', Id_class as N'Mã lớp' from dbo.Student Where Id like @Id";

            return Dataprovider.Instance.ExcuteQuery(query, parameter);
        }
    }
}
