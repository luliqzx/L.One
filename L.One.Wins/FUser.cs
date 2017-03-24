using L.One.Domain.Common;
using L.One.Domain.Entity;
using L.One.Domain.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L.Core.Utilities;

namespace L.One.Wins
{
    public partial class FUser : Form
    {
        IActorRepository ActorRepository;
        IUnitOfWork uom;

        //public FUser()
        //{
        //    InitializeComponent();
        //}

        public FUser(IUnitOfWork _uom, IActorRepository _ActorRepository)
        {
            this.uom = _uom;
            this.ActorRepository = _ActorRepository;

            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = (6 * 1000); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        Timer timer2 = new Timer();

        private void timer_Tick(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();

            timer2.Interval = (3 * 1000); // 10 secs
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();

            //refresh here...
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                this.GridBind();
                timer2.Stop();
            }
            catch (Exception ex)
            {
                string err = ex.GetFullMessage();
                Application.Restart();
                Application.ExitThread();
            }

        }
        private void Search_Click(object sender, EventArgs e)
        {
            this.GridBind(txtIDU.Text, txtName.Text);
        }

        private void GridBind(string SIDU = "", string Name = "")
        {
            var lstActor = this.ActorRepository.GetDisplayGrid(SIDU, Name);
            this.dataGridView1.DataSource = lstActor;
        }
    }
}
