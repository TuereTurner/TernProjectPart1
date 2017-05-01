using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace File
{
    [Serializable]
   public class UserObject
    {
        public byte[] FileObject { get; set; }
       
        public string Username { get; set; }
        public string CurrentFolder { get; set; }
        public DataSet UserFilesObj { get; set; }
    }
}
