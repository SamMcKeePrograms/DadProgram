using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using DadProgram;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace DadProgram_2ndFeature
{
    public partial class Form1 : Form
    {
        List<System.Windows.Forms.Label> featureNames;
        List<System.Windows.Forms.TextBox> featureTxtBox;
        System.Windows.Forms.Button addNewFeatureBtn, createBtn, createTemplateBtn;
        System.Windows.Forms.Label newFeatureLabel;
        System.Windows.Forms.TextBox newFeatureNameTxtBox;
        String creator;

        Microsoft.Office.Interop.Excel.Application excel;
        Excel.Workbook workbook;
        Excel._Worksheet worksheet;

        public Form1()
        {
            InitializeComponent();

            excel = new Microsoft.Office.Interop.Excel.Application();
            excel.DisplayAlerts = false;
            workbook = excel.Workbooks.Open("C:\\Users\\Mckee\\Documents\\Coding\\C#\\DadProgram_2ndFeature\\DadProgram_2ndFeature\\test.xlsx", false, false);
            worksheet = workbook.Worksheets[1];
            creator = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];

            featureNames = new List<System.Windows.Forms.Label>();
            featureTxtBox = new List<System.Windows.Forms.TextBox>();

            createTemplateBtn = new System.Windows.Forms.Button();
            createTemplateBtn.Text = "Create";
            createTemplateBtn.Width = 100;
            createTemplateBtn.Height = 50;
            createTemplateBtn.Location = new System.Drawing.Point(0, featureNames.Count * 50 + 100);

            createTemplateBtn.Click += new EventHandler(createTemplateBtn_click);

            createTemplateBtn.Hide();

            this.Controls.Add(createTemplateBtn);

            addNewFeatureBtn = new System.Windows.Forms.Button();
            addNewFeatureBtn.Text = "Add New Feature";
            addNewFeatureBtn.Width = 105;
            addNewFeatureBtn.Height = 50;
            addNewFeatureBtn.Location = new System.Drawing.Point(0, 50);
            addNewFeatureBtn.Hide();

            addNewFeatureBtn.Click += new EventHandler(addNewFeatureBtn_click);

            createBtn = new System.Windows.Forms.Button();
            createBtn.Text = "Create";
            createBtn.Width = 105;
            createBtn.Height = 50;
            createBtn.Location = new System.Drawing.Point(105, 50);
            createBtn.Hide();

            createBtn.Click += new EventHandler(createBtn_click);

            newFeatureLabel = new System.Windows.Forms.Label();
            newFeatureLabel.Text = "New Feature Name";
            newFeatureLabel.Width = 105;
            newFeatureLabel.Height = 50;
            newFeatureLabel.TextAlign = ContentAlignment.MiddleCenter;
            newFeatureLabel.Location = new System.Drawing.Point(0, 0);
            newFeatureLabel.Hide();

            newFeatureNameTxtBox = new System.Windows.Forms.TextBox();
            newFeatureNameTxtBox.Width = 105;
            newFeatureNameTxtBox.Height = 50;
            newFeatureNameTxtBox.Location = new System.Drawing.Point(105, 15);
            newFeatureNameTxtBox.Hide();

            this.AcceptButton = addNewFeatureBtn;
            System.Windows.Forms.Button temp = new System.Windows.Forms.Button();
            temp.Click += new EventHandler(close_click);
            this.CancelButton = temp;

            this.Controls.Add(createBtn);
            this.Controls.Add(newFeatureNameTxtBox);
            this.Controls.Add(newFeatureLabel);
            this.Controls.Add(addNewFeatureBtn);

            editing_mode();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (featureNames.Count == 0 && featureTxtBox.Count == 0)
            {
                addNewFeatureBtn.Show();
                newFeatureLabel.Show();
                newFeatureNameTxtBox.Show();
                createBtn.Show();
            } else
            {
                create_template();
            }
                 
        }

        private void editing_mode()
        {
            for (int i = 0;i < featureNames.Count; i++)
            {
                featureNames[i].Hide();
                featureTxtBox[i].Hide();
            }

            createTemplateBtn.Hide();

            this.Width = 227;
            this.Height = 140;
            

            addNewFeatureBtn.Show();
            createBtn.Show();
            newFeatureLabel.Show();
            newFeatureNameTxtBox.Show();


        }

        private void close_click(object sender, EventArgs e) {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Windows.Forms.Application.Exit();
            } catch (Exception error)
            {
                throw error;
            }
              
        }

        private void create_template()
        {
            addNewFeatureBtn.Hide();
            newFeatureLabel.Hide();
            newFeatureNameTxtBox.Hide();
            createBtn.Hide();

            this.Height = featureNames.Count * 50 + 90;
            this.Width = 250;

            for (int i = 0; i<featureNames.Count; i++)
            {
                featureNames[i].Show();
                featureTxtBox[i].Show();
            }

            createTemplateBtn.Location = new System.Drawing.Point(0, featureNames.Count * 50);
            createTemplateBtn.Show();

        }

        private void addNewFeatureBtn_click(object sender, EventArgs e)
        {
            if (!newFeatureNameTxtBox.Text.Equals(String.Empty) && Regex.IsMatch(newFeatureNameTxtBox.Text.ToString(), @"^[a-zA-Z]+$"))
            {
                System.Windows.Forms.TextBox tempTxtbox = new System.Windows.Forms.TextBox();
                System.Windows.Forms.Label tempLabel = new System.Windows.Forms.Label();
                tempLabel.Text = newFeatureNameTxtBox.Text;

                int x = 25;
                int y = featureNames.Count * 50;

                tempLabel.Location = new System.Drawing.Point(x, y);
                tempTxtbox.Location = new System.Drawing.Point(x + tempLabel.Width, y);

                tempLabel.Hide();
                tempTxtbox.Hide();

                this.Controls.Add(tempLabel);
                this.Controls.Add(tempTxtbox);

                featureNames.Add(tempLabel);
                featureTxtBox.Add(tempTxtbox);

                newFeatureNameTxtBox.Text = String.Empty;
            }
            newFeatureNameTxtBox.Focus();
        }

        private void createBtn_click(object sender, EventArgs e)
        {
            if (featureNames.Count == 0 && featureTxtBox.Count == 0)
            {
                MessageBox.Show("You need to add at least one feature to the template before creating it.");
            } else
            {
                create_template();
            }
        }

        private void createTemplateBtn_click(object sender, EventArgs e)
        {
            Boolean createNew = true;
            int numRowWorkSheet = 0;

            if (validate_parameters())
            {
                create_new_sheet();

                List<double> currentValues = new List<double>();
                char[] columns = "CDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();

                for (int i = 0;i < featureTxtBox.Count; i++)
                {
                    currentValues.Add(double.Parse(featureTxtBox[i].Text));
                }
                
                for (int i = 2;i < worksheet.UsedRange.Rows.Count;i++)
                {
                    numRowWorkSheet = i;
                    for (int j = 3;j < worksheet.UsedRange.Columns.Count; j++)
                    {
                        if (double.Parse(worksheet.Range[columns[j - 3].ToString() + i.ToString()].Value2.ToString()) == currentValues[j - 3])
                        {
                            createNew = false;
                            MessageBox.Show("Found sketch. Sketch number: " + worksheet.Range["B" + i].Value2, "Found Sketch");
                            break;
                        }
                    }
                }
                
                if (createNew)
                {
                    MessageBox.Show("No sketch was found, creating a new one.", "New Sketch");
                    add_data(currentValues, numRowWorkSheet, creator);
                    workbook.Save();
                    workbook.Close();
                    excel.Quit();
                    createNew = false;
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                }
            }
        }

        private String get_sketch_number()
        {
            MessageBox.Show("Rows count: " + worksheet.UsedRange.Rows.Count.ToString());
            String currentSketchNumber = worksheet.Range["B" + (worksheet.UsedRange.Rows.Count-1).ToString()].Value2.ToString();
            
            if (currentSketchNumber.Equals("Sketch Number"))
            {
                currentSketchNumber = "AAAA0000";
            }
            
            char[] seperatedSketchNumber = currentSketchNumber.ToArray();
            int numberPart = int.Parse(seperatedSketchNumber.SubArray(4, 4).GetString());
            numberPart += 1;
            String letterPart = seperatedSketchNumber.SubArray(0, 4).GetString();

            String numberPartString = numberPart.ToString();

            for (int i = 0; i <= (4 - numberPartString.Length) + 1; i++)
            {
                numberPartString = "0" + numberPartString;
            }

            String newSketchNumber = letterPart + numberPartString;

            MessageBoxButtons btns = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Is " + newSketchNumber + " sketch number OK?", "New Sketch Number Confirmation", btns);

            if (result == DialogResult.No)
            {
                Boolean canReturnSketchNumber = false;
                while (!canReturnSketchNumber)
                {
                    NewSketchNumber sketchNumberForm = new NewSketchNumber();
                    sketchNumberForm.ShowDialog();
                    try
                    {
                        worksheet.Name = sketchNumberForm.newSketchNumber.Substring(0, 4);
                        canReturnSketchNumber = true;
                        return sketchNumberForm.newSketchNumber;
                    }
                    catch
                    {
                        MessageBox.Show("You need to chose a different sketch number because that one is already in use");
                    }
                }
                return "ZZZZ---1";
            }
            else
            {
                Boolean canReturnSketchNumber = false;
                while (!canReturnSketchNumber){

                    try
                    {
                        worksheet.Name = newSketchNumber.Substring(0, 4);
                        canReturnSketchNumber = true;
                    }
                    catch
                    {
                        MessageBox.Show("You need to chose a different sketch number because that one is already in use");
                        NewSketchNumber sketchNumberForm = new NewSketchNumber();
                        sketchNumberForm.ShowDialog();
                        newSketchNumber = sketchNumberForm.newSketchNumber;
                    }
                }
                return newSketchNumber;
            }
        }

        private void add_data(List<double> currentValues, int row, string creator)
        {

            char[] columns = "CDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();

            int insertRow = worksheet.UsedRange.Rows.Count + 1;

            worksheet.Cells[insertRow, 1].value = creator;
            worksheet.Cells[insertRow, 2].value = get_sketch_number();

            for (int i = 0;i < currentValues.Count; i++)
            {
                worksheet.Cells[insertRow, i + 3].value = currentValues[i];
            }
        }
        private Boolean validate_parameters()
        {
            Boolean canCreate = true;
            if (!featureTxtBox[0].Text.ToString().Equals("EDIT"))
            {
                for (int i = 0; i < featureTxtBox.Count; i++)
                {
                    if (!double.TryParse(featureTxtBox[i].Text, out double result))
                    {
                        canCreate = false;
                        MessageBox.Show(featureTxtBox[i].Text + " needs to be a number.");
                        return canCreate;
                    }
                }
            } else
            {
                canCreate = false;
                editing_mode();
            }
            return canCreate;
        }

        private int create_new_sheet()
        {

            int featureNamesIndex = 0;

            char[] columns = "CDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();

            Excel.Worksheet worksheetTemp;
            Boolean sameSheet = true;

            for (int i = 1; i <= workbook.Sheets.Count; i++)
            {
                sameSheet = true;
                worksheetTemp = workbook.Worksheets[i];
                if (worksheetTemp.UsedRange.Columns.Count - 2 == featureNames.Count)
                {
                    for (int j = 3; j <= worksheetTemp.UsedRange.Columns.Count; j++)
                    {
                        try
                        {
                           
                            if (!featureNames[featureNamesIndex].Text.ToString().Equals(worksheetTemp.Range[columns[j - 3].ToString() + "1"].Value2.ToString()))
                            {
                                sameSheet = false;
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                        featureNamesIndex += 1;
                    }
                }
                else
                {
                    sameSheet = false;
                }
                featureNamesIndex = 0;
                if (sameSheet)
                {
                    MessageBox.Show("Found a excel sheet");
                    worksheet = workbook.Sheets[i];
                    return i;
                }
            }
            MessageBox.Show("Need to create a new excel sheet");

            Excel._Worksheet newSheet = (Excel.Worksheet)(workbook.Worksheets.Add());
            
            newSheet.Cells[1, 1].value = "Creator";
            newSheet.Cells[1, 2].value = "Sketch Number";

            for (int i = 3; i < featureNames.Count + 3; i++)
            {
                newSheet.Cells[1, i].value = featureNames[i - 3].Text.ToString();
            }

            worksheet = newSheet;

            return workbook.Sheets.Count;

        }

    }
}
public static class Extensions
{
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
