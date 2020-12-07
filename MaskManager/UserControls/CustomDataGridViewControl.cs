using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskManager.UserControls
{
    public class CustomDataGridViewControl : DataGridView
    {
        public CustomDataGridViewControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {

            BorderStyle = BorderStyle.None;
            AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            BackgroundColor = Color.White;

            CellBorderStyle = DataGridViewCellBorderStyle.Single;

            EnableHeadersVisualStyles = false;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ColumnHeadersDefaultCellStyle.BackColor = Color.LightSlateGray;
            ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AllowUserToDeleteRows = false;
            AllowUserToAddRows = false;
            ReadOnly = true;
        }
    }
}
