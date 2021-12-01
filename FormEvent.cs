using FINAL.Models;
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
    public partial class FormEvent : Form
    {
        public FormEvent()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Event ev = new Event();
            ev.Date = Convert.ToDateTime(txDate.Text +" " + numericUpDown1.Value +":"+numericUpDown2.Value +":00");
            ev.Content = txContent.Text.Trim();
            using (var db = new FINALContext())
            {
                db.Add(ev);
                db.SaveChanges();
                MessageBox.Show("Add successfully");
            }

            FormEvent fe = new FormEvent();
            this.Close();
            //Form1 f1 = new Form1();
            
            //f1.Show(Form1.static_month, Form1.static_year);

        }
        private void showEvent(string date)
        {
            using (var db = new FINALContext())
            {
                dataGridView1.DataSource = db.Events.Where(x =>
                x.Date.Day == Convert.ToDateTime(date).Day &&
                x.Date.Month == Convert.ToDateTime(date).Month &&
                x.Date.Year == Convert.ToDateTime(date).Year
                ).ToList();

            }
        }

        private void FormEvent_Load(object sender, EventArgs e)
        {
            txDate.Text = Form1.static_year + "/" + Form1.static_month + "/" + UserControlDays.static_day;
            showEvent(txDate.Text);
        }
    }
}
