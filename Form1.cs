using FINAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace FINAL
{
    public partial class Form1 : Form
    {
        int curMonth, curYear;
        //static variable
        public static int static_month, static_year;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            curMonth = now.Month;
            curYear = now.Year;
            Show(curMonth, curYear);
        }
        public void Show(int M, int Y)
        {
            String month_name = DateTimeFormatInfo.CurrentInfo.GetMonthName(M);
            lbMY.Text = month_name + " " + Y;
            //first day
            DateTime MonthStart = new DateTime(Y, M, 1);
            // days in last month 
            static_month = M;
            static_year = Y;
            int dayWeek = Convert.ToInt32(MonthStart.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < dayWeek; i++)
            {
                UserControlBlank ucb = new UserControlBlank();
                dayContainer.Controls.Add(ucb);

            }
            //total days of curMonth
            int day = DateTime.DaysInMonth(Y, M);
            int month_now = DateTime.Now.Month;
            int year_now = DateTime.Now.Year;


            for (int i = 1; i <= day; i++)
            {

                UserControlDays ucDays = new UserControlDays();
                //today
                if (i == DateTime.Now.Day && M == month_now && Y == year_now)
                {
                    ucDays.BackColor = Color.Crimson;
                }
                // event days
                using (var db = new FINALContext())
                {
                    List<Event> ev = db.Events.Where(x => x.Date.Month == M && x.Date.Year == Y).ToList();
                    var rs = from s in ev select s.Date;
                    foreach (var dt in rs)
                    {
                        if (dt.Day == i) ucDays.BackColor = Color.DarkOliveGreen;
                    }
                }

                ucDays.days(i);

                dayContainer.Controls.Add(ucDays);
            }
            // set current time ticker:
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            this.lbCurTime.Text = dt.ToString("dddd HH:mm:ss tt,  dd MMM yyyy ");
            

        }

        private void btNext_Click(object sender, EventArgs e)
        {
            //clear
            dayContainer.Controls.Clear();

            //increase
            if (curMonth == 12)
            {
                curYear++;
                curMonth = 1;
            }
            else
            {
                curMonth++;
            }
            //show
            Show(curMonth, curYear);
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            //clear
            dayContainer.Controls.Clear();

            //decrease
            if (curMonth == 1)
            {
                curYear--;
                curMonth = 12;
            }
            else
            {
                curMonth--;
            }
            //show
            Show(curMonth, curYear);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListEvent le = new ListEvent();
            le.Show();
        }

        private void lbCurTime_TextChanged(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            var db = new FINALContext();
            List<Event> ev = db.Events.Where(x => x.Date.Year == dt.Year && x.Date.Month == dt.Month
            && x.Date.Day == dt.Day).ToList();
            PopupNotifier pop = new PopupNotifier();
            foreach (var abc in ev)
            {
                if (abc.Date.Hour == dt.Hour && abc.Date.Minute == dt.Minute && abc.Date.Second == dt.Second)
                {
                    pop.Image = Properties.Resources._123;
                    pop.TitleText = "Notification";
                    pop.ContentText = abc.Content.ToString();
                    pop.Popup();
                }
                //MessageBox.Show(abc.Content.ToString(), "Notification");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(dateTimePicker1.Value);
            dayContainer.Controls.Clear();
            curMonth = dt.Month;
            curYear = dt.Year;
            UserControlDays.static_day = dt.Day + "";
            Show(curMonth, curYear);
            FormEvent fe = new FormEvent();
            fe.Show();
        }

        private void lbCurTime_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();
            int month_now1 = DateTime.Now.Month;
            int year_now1 = DateTime.Now.Year;

            Show(month_now1, year_now1);
        }
    }
}
