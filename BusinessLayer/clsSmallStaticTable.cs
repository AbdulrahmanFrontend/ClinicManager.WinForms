using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public abstract class clsSmallStaticTable
    {
        protected int _ID;
        public string Name { get; set; }
        public clsSmallStaticTable()
        {
            _ID = -1;
            this.Name = null;
        }
    }
}
