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
using Microsoft.Office.Interop.Excel;
using System.IO;

public static class Extensions
{
    // This is a cool method
    public static T[] SubArray<T>(this T[] array, int offset, int length)
    {
        T[] result = new T[length];
        Array.Copy(array, offset, result, 0, length);
        return result;
    }

    public static String GetString(this char[] array)
    {
        string s = new string(array);
        return s;
    }
}

namespace DadProgram
{

    public partial class mainWindowFrm : Form
    {
        String creator = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split("\\")[1];
        
        public mainWindowFrm()
        {
            InitializeComponent();
            creatorTxtBox.Text = creator;
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
                Microsoft.Office.Interop.Excel.Application excel = null;
                Excel._Worksheet worksheet = null;
                Double OD = 0.0 ;
                int ID= 0;
                Double thickness = 0.0;
                Double currentOD = 0.0;
                int currentID = 0;
                Double currentThickness = 0.0;

                try
                {
                    excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.DisplayAlerts = false;
                    workbook = excel.Workbooks.Open("C:\\Users\\Mckee\\Documents\\Coding\\C#\\DadProgram\\test.xlsx", false, false);
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

                for (int i = 2; i < worksheet.UsedRange.Rows.Count + 1; i++)
                {
                    try
                    {
                        // MessageBox.Show("i: " + i.ToString() + "count: " + worksheet.UsedRange.Rows.Count.ToString());
                        currentOD = double.Parse(worksheet.Range["A" + i].Value2.ToString());
                        currentID = int.Parse(worksheet.Range["B" + i].Value2.ToString());
                        currentThickness = double.Parse(worksheet.Range["C" + i].Value2.ToString());

                        // MessageBox.Show("OD: " + currentOD.ToString() + " | ID: " + currentID.ToString() + " | thickness: " + currentThickness.ToString());

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
                        
                        
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.ToString());
                    }
                }
                if (createNew)
                {
                    MessageBox.Show("No sketch was found, creating a new one.", "New Sketch");
                    add_data(OD, ID, thickness, get_sketch_number(worksheet), creator, worksheet, numRowWorkSheet);
                    workbook.Save();
                    workbook.Close();
                    excel.Quit();
                    createNew = false;
                    Marshal.ReleaseComObject(excel);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(worksheet);
                }
            }
            
        }

        // This method does not make sure that the AS__ part is the same as the rest of the file
        private Boolean validate_sketch_number(String sketchNumber, Excel._Worksheet worksheet)
        {
            char[] seperatedSketchNumber = sketchNumber.ToArray();
            char[] lettersPart = seperatedSketchNumber.SubArray(0, 4);
            char[] numbersPart = seperatedSketchNumber.SubArray(4, 4);

            char[] previousEntry = worksheet.Range["D" + worksheet.UsedRange.Rows.Count].Value2.ToString().ToArray();

            if (int.Parse(previousEntry.SubArray(4,4)) > int.Parse(numbersPart)){
                return false;
            } else if (!previousEntry.SubArray(0, 4).ToString().Equals(lettersPart.ToString())){
                return false;
            }
            else
            {
                return true;
            }

        }

        private String get_sketch_number(Excel._Worksheet worksheet)
        {

            String currentSketchNumber = worksheet.Range["D" + worksheet.UsedRange.Rows.Count].Value2.ToString();
            char[] seperatedSketchNumber = currentSketchNumber.ToArray();
            int numberPart = int.Parse(seperatedSketchNumber.SubArray(4, 4).GetString());
            numberPart += 1;
            String letterPart = seperatedSketchNumber.SubArray(0, 4).GetString();

            String numberPartString = numberPart.ToString();

            for(int i = 0; i <= (4-numberPartString.Length)+1; i++)
            {
                numberPartString = "0" + numberPartString;
            }

            String newSketchNumber = letterPart + numberPartString;

            MessageBoxButtons btns = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Is " + newSketchNumber + " sketch number OK?", "New Sketch Number Confirmation", btns);

            if (result == DialogResult.No)
            {
                NewSketchNumber sketchNumberForm = new NewSketchNumber();
                sketchNumberForm.ShowDialog();
                MessageBox.Show(sketchNumberForm.newSketchNumber);
                return sketchNumberForm.newSketchNumber;
            }
            else
            {
                return newSketchNumber;
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
