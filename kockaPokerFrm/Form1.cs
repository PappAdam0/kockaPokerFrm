using kockaPokerFrm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kockaPokerFrm
{
    public partial class frmFo : Form
    {
        private Dobas gep;
        private Dobas ember;
        private PictureBox[] gepKep;
        private PictureBox[] emberKep;
        public frmFo()
        {
            InitializeComponent();
            gepKep = new PictureBox[] {pbGep1, pbGep2, pbGep3, pbGep4, pbGep5 };
            emberKep = new PictureBox[] {pbEmber1, pbEmber2, pbEmber3, pbEmber4, pbEmber5 };
            gep = new Dobas();
            ember = new Dobas();
            lblGepreszeredmeny.Text = "";
            lblEmberreszeredmeny.Text = "";
            lblGepEredmeny.Text = "";
            lblEmberEredmeny.Text = "";
        }

        private void kepElhelyez(PictureBox pb, int szam)
        {
            switch (szam)
            {
                case 1:
                    pb.Image = Resources.egy;
                    break;
                case 2:
                    pb.Image = Resources.ketto;
                    break;
                case 3:
                    pb.Image = Resources.harom;
                    break;
                case 4:
                    pb.Image = Resources.negy;
                    break;
                case 5:
                    pb.Image = Resources.ot;
                    break;
                case 6:
                    pb.Image = Resources.hat;
                    break;

            }
        }

        private void DobasMegjelenit(Dobas d, PictureBox[] kepek)
        {
            for (int i = 0; i < 5; i++)
            {
                kepElhelyez(kepek[i], d.Kockak[i]);
            }
        }
        private void btnDobas_Click(object sender, EventArgs e)
        {
            gep.EgyDobas();
            ember.EgyDobas();
            DobasMegjelenit(gep, gepKep);
            DobasMegjelenit(ember, emberKep);
            lblEmberreszeredmeny.Text = ember.Eredmeny;
            lblGepreszeredmeny.Text = gep.Eredmeny;

            if (gep.Pont > ember.Pont)
            {
                MessageBox.Show("Gép Nyert", "Eredmény", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gep.Nyert++;
                lblGepEredmeny.Text = gep.Nyert.ToString();
            }
            else if (ember.Pont > gep.Pont)
            {
                MessageBox.Show("Ember Nyert", "Eredmény", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ember.Nyert++;
                lblEmberEredmeny.Text = ember.Nyert.ToString();
            }
            else
            {
                MessageBox.Show("Döntetlen", "Eredmény", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
