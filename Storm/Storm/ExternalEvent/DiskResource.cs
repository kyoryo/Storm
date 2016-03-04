using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.ExternalEvent
{
    public class DiskResource
    {
        public string PathOnDisk { get; set; }
        public string ParentPathOnDisk
        {
            get
            {
                return Directory.GetParent(PathOnDisk).FullName;
            }
        }
    }
}
