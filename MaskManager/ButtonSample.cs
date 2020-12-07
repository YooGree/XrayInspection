using MaskManager.PopUp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskManager
{
    public partial class ButtonSample : ParentsPop
    {
        public ButtonSample()
        {
            InitializeComponent();
        }

        private void ButtonSample_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Close();
        }
    }
}
