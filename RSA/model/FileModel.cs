using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA.model
{
    class FileModel
    {
        public int id
        {
            get
            {
                return p_id;
            }
            set
            {
                p_id = value;
            }
        }
        public string code
        {
            get
            {
                return p_code;
            }
            set
            {
                p_code = value;
            }
        }
        public string file_loca
        {
            get
            {
                return p_loca;
            }
            set
            {
                p_loca = value;
            }
        }
        public DateTime create_at
        {
            get
            {
                return p_date;
            }
            set
            {
                p_date = value;
            }
        }
        private int p_id;
        private string p_code;
        private string p_loca;
        private DateTime p_date;
        public FileModel(string code,string location)
        {
            this.p_code = code;
            this.p_loca = location;
            this.p_date = DateTime.Now;
        }
        public int insertFile()
        {
            DBFileManagerDataContext db = new DBFileManagerDataContext();
            myfile mf = new myfile();
            mf.code = this.p_code;
            mf.file_loca = this.p_loca;
            mf.create_at = this.p_date;
            db.myfiles.InsertOnSubmit(mf);
            db.SubmitChanges();
            return 0;
        }
    }
}
