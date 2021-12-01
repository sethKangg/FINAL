using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL
{
    public partial class UserControlDays : UserControl
    {
        public static string static_day;
        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }
        public void days(int totalDays)
        {
            lbDays.Text = totalDays + "";
        }


        private void UserControlDays_Click_1(object sender, EventArgs e)
        {
            static_day = lbDays.Text;
            FormEvent fe = new FormEvent();
            fe.Show();
        }
    }
}