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
            this.GridBind();
        }
        private void Search_Click(object sender, EventArgs e)
        {
            this.GridBind(txtIDU.Text, txtName.Text);
        }

        private void GridBind(string SIDU = "", string Name = "")
        {
            IList<Actor> lstActor = this.ActorRepository.GetDisplayGrid(SIDU, Name);
            this.dataGridView1.DataSource = lstActor;
        }
    }
}
