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
    public partial class ListEvent : Form
    {
        private int curEvent = 0;
        public ListEvent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            show(1);
        }

        private void ListEvent_Load(object sender, EventArgs e)
        {
            show(1);
            dataGridView1.MultiSelect = false;
        }
        private void show(int choice)
        {

            using (var db = new FINALContext())
            {
                if (choice == 1)
                {
                    dataGridView1.DataSource = db.Events.Where(x => x.Date > DateTime.Now.AddDays(-1)).OrderBy(x => x.Date).ToList();
                }
                else
                {
                    dataGridView1.DataSource = db.Events.Where(x => x.Date < DateTime.Now.AddDays(-1)).OrderByDescending(x => x.Date).ToList();
                }

            }
        }
        private void btPast_Click(object sender, EventArgs e)
        {
            show(0);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (curEvent != 0)
            {
                using (var db = new FINALContext())
                {
                    Event ev = db.Events.First(x => x.Id == curEvent);
                    db.Remove(ev);
                    db.SaveChanges();
                    MessageBox.Show("Delete successfully");
                }
                show(1);
            }
        }

        private void btUp_Click(object sender, EventArgs e)
        {
            using (var db = new FINALContext())
            {
                Event ev = db.Events.First(x => x.Id == curEvent);

                ev.Date = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString().ToString() +" " +numericUpDown1.Value+":"+numericUpDown2.Value+":00");
                ev.Content = txContent.Text.Trim();
                db.SaveChanges();
            }
            show(1);
            curEvent = 0;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            txContent.Text = row.Cells["Content"].Value.ToString();
            DateTime dt = Convert.ToDateTime(row.Cells["Date"].Value);
            dateTimePicker1.Value = dt;
            numericUpDown1.Value = dt.Hour;
            numericUpDown2.Value = dt.Minute;
            curEvent = Convert.ToInt32(row.Cells["Id"].Value);
        }
    }
}
