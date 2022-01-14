using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridComboBoxColumn
{
    class StatusList: List<string>
    {
        public StatusList()
        {
            this.Add("Assigned");
            this.Add("Closed");
            this.Add("In Progress");
            this.Add("Open");
            this.Add("Resolved");
        }
    }
}
