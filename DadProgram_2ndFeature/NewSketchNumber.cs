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

            if (validate_sketch_number())
            {
                newSketchNumber = sketchNumberTxtBox.Text;
                Application.Exit();
            } else
            {
                MessageBox.Show("You have an invalid sketch number");
            }

        }

        private Boolean validate_sketch_number()
        {

            char[] sketchNumber = sketchNumberTxtBox.Text.ToArray();

            if (sketchNumber.Length == 8)
            {
                foreach(char s in sketchNumber.SubArray(0, 4))
                {
                    if (!Char.IsLetter(s))
                    {
                        return false;
                    }
                }

                foreach(char s in sketchNumber.SubArray(4, 4))
                {
                    if (!int.TryParse(s.ToString(), out int result)){
                        return false;
                    }
                }
            } else
            {
                return false;
            }

            return true;

        }
    }
}