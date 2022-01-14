using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    public class Man
    {
        static int Count = 0;
        public int ID { get; private set; }
        public string FIO { get; set; }
        public string BirthDay { get; set; }
        public string EMail { get; set; }

        public string Phone { get; set; }

        public Man()
        {
            ID = Count++;
            FIO = "FIO";
            BirthDay = "11.01.2000";
            EMail = "mail.mail.com";
            Phone = "777-77-77";
        }
    }


}
