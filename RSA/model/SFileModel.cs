using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA.model
{
    class SFileModel
    {
        public string id
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
        public string filename
        {
            get
            {
                return p_filename;
            }
            set
            {
                p_filename = value;
            }
        }
        public string key
        {
            get
            {
                return p_pbkey;
            }
            set
            {
                p_pbkey = value;
            }
        }
        public string create_at
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
        private string p_id;
        private string p_filename;
        private string p_pbkey;
        private string p_date;
        public SFileModel(string id,string filename,string key,string createdAt)
        {
            this.p_id = id;
            this.p_filename = filename;
            this.p_pbkey = key;
            this.p_date = createdAt;
        }
    }
}
