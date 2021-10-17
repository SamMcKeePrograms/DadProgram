using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace DadProgram
{
    public partial class mainWindowFrm : Form
    {
        public mainWindowFrm()
        {
            InitializeComponent();
            creatorTxtBox.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\\")[1];
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (!validate_parameters())
            {
                MessageBox.Show("You need to fill out all of the parameters.", "Error");
            } else {

                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Workbooks.Open("D:\\Code\\VB\\VB_JSON_Reader\\test.xlsx", Type.Missing, true);
                Excel._Worksheet worksheet = workbook.ActiveSheet;

                Double OD = double.Parse(odTxtBox.Text);
                int ID = int.Parse(idTxtBox.Text);
                Double thickness = double.Parse(thicknessTxtBox.Text);



                for (int i = 1; i < worksheet.UsedRange.Rows.Count - 1; i++)
                {
                    MessageBox.Show("OD: ");
                    try
                    {
                        
                        if (OD == double.Parse(worksheet.Range["A"+i].Value2))
                        {
                            if (ID == int.Parse(worksheet.Range["B"+1].Value2))
                            {
                                if (thickness == double.Parse(worksheet.Range["C"+i].Value2))
                                {
                                    MessageBox.Show("No sketch was found, Creating a new one.", "New Sketch");
                                }
                                else
                                {
                                    MessageBox.Show("Found sketch. Sketch number: " + worksheet.Range["D" + i].Value2, "Found Sketch");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Found sketch. Sketch number: " + worksheet.Range["D" + i].Value2, "Found Sketch");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Found sketch. Sketch number: " + worksheet.Range["D" + i].Value2, "Found Sketch");
                        }
                    } catch (Exception error)
                    {
                        Console.WriteLine(error);
                    }
                }

            }       
        }

        private Boolean validate_parameters()
        {
            if (odTxtBox.Text == "") {
                return false;
            } else if (idTxtBox.Text == "") {
                return false;
            } else if (thicknessTxtBox.Text == "") {
                return false;
            } else if (creatorTxtBox.Text == "") {
                return false;
            } else {
                return true;
            }
        }

        private void odlbl_Click(object sender, EventArgs e)
        {

        }
    }
}
