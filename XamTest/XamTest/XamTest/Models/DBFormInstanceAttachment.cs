using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamTest.Models
{
    public class DBFormInstanceAttachment
    {
        [PrimaryKey]
        public string IndexID { get; set; } //composite key of forminstance and attachment number
        public string FormInstanceID { get; set; } //instance it belongs to
        public int AttachmentNumber { get; set; } //index of file
        public string FileGUID { get; set; } //guid after upload
        public string FileName { get; set; } //file name
        public string Name { get; set; } //user entered name
    }
}
