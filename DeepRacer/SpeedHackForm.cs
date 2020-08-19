using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepRacer
{
    public partial class SpeedHackForm : Form
    {
        double FirstRangeFactor { get { return Parse(tb1stRange); } }
        double SecondRangeFactor { get { return Parse(tb2ndRange); } }
        double ThirdRangeFactor { get { return Parse(tb3rdRange); } }

        public Func<double, double> SpeedHackTransformer
        {
            get
            {
                return x =>
                {
                    if (x < 2) return x * FirstRangeFactor;
                    if (x < 3) return x * SecondRangeFactor;
                    return x * ThirdRangeFactor;
                };
            }
        }

        private double Parse(TextBox tb)
        {
            return double.Parse(tb.Text.Replace('.', ','));
        }

        public SpeedHackForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
