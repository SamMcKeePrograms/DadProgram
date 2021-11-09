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
            Boolean createNew = false;
            int numRowWorkSheet = 0;
            Excel.Workbook workbook = null;

            if (!validate_parameters())
            {
                MessageBox.Show("You need to fill out all of the parameters.", "Error");
            } else {
                Excel.Application excel = null;
                Excel._Worksheet worksheet = null;
                Double OD = 0.0 ;
                int ID= 0;
                Double thickness = 0.0;
                Double currentOD = 0.0;
                int currentID = 0;
                Double currentThickness = 0.0;

                try
                {
                    excel = new Excel.Application();
                    workbook = excel.Workbooks.Open("D:\\Code\\VB\\VB_JSON_Reader\\test.xlsx", Type.Missing, true);
                    worksheet = workbook.ActiveSheet;
                    numRowWorkSheet = worksheet.UsedRange.Rows.Count;
                } catch(Exception e__) {
                    MessageBox.Show(e__.ToString());
                }

                try
                {
                    OD = double.Parse(odTxtBox.Text);
                    ID = int.Parse(idTxtBox.Text);
                    thickness = double.Parse(thicknessTxtBox.Text);
                } catch (Exception e_)
                {
                    MessageBox.Show(e_.ToString());
                }

                for (int i = 2; i < worksheet.UsedRange.Rows.Count; i++)
                {
                    try
                    {
                        currentOD = double.Parse(worksheet.Range["A" + i].Value2.ToString());
                        currentID = int.Parse(worksheet.Range["B" + i].Value2.ToString());
                        currentThickness = double.Parse(worksheet.Range["C" + i].Value2.ToString());

                        MessageBox.Show("OD: " + currentOD.ToString() + " | ID: " + currentID.ToString() + " | thickness: " + currentThickness.ToString());

                        if (OD == currentOD)
                        {
                            if (ID == currentID)
                            {
                                if (thickness == currentThickness)
                                {
                                    MessageBox.Show("Found sketch. Sketch number: " + worksheet.Range["D" + i].Value2, "Found Sketch");
                                    createNew = false;
                                }
                                else
                                {
                                    createNew = true;
                                }
                            }
                            else
                            {
                                createNew = true;
                            }
                        }
                        else
                        {
                            createNew = true;
                        }
                        MessageBox.Show("No sketch was found, Creating a new one.", "New Sketch");
                        
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.ToString());
                    }
                }
                if (createNew)
                {
                    MessageBox.Show("No sketch was found, creating a new one.", "New Sketch");
                    add_data(currentOD, currentID, currentThickness, "TEST", "TEST_CREATOR", worksheet, numRowWorkSheet);
                    workbook.SaveCopyAs(("test2.xlsx"));
                    workbook.Close();
                    excel.Quit();
                    createNew = false;

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);

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
                try
                {
                    double.Parse(odTxtBox.Text);
                    int.Parse(idTxtBox.Text);
                    double.Parse(thicknessTxtBox.Text);
                    return true;
                } catch
                {
                    return false;
                }
            }
        }

        private string increment_sketch_number(string currentSketchNumber)
        {
            return "";
        }

        private void add_data(double od, int id, double thickness, string sketchNumber, string creator, Excel._Worksheet worksheet, int row)
        {
            MessageBox.Show("in add_data");

            worksheet.Cells[row+1, 1].value = od.ToString();
            worksheet.Cells[row+1, 2].value = id.ToString();
            worksheet.Cells[row+1, 3].value = thickness.ToString();
            worksheet.Cells[row+1, 4].value = sketchNumber;
            worksheet.Cells[row+1, 5].value = creator;

        }
    }
}
