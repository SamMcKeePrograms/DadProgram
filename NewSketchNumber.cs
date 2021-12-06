using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DadProgram
{
    public partial class NewSketchNumber : Form
    {
        public String newSketchNumber = String.Empty;
        
        public NewSketchNumber()
        {
            InitializeComponent();
        }

        private void enterNewSketchBtn_Click(object sender, EventArgs e)
        {
            newSketchNumber = sketchNumberTxtBox.Text;
            Application.Exit();
        }
    }
}
