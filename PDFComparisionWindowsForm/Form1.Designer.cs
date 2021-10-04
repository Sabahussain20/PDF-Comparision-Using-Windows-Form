
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PDFComparisionWindowsForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FilePath = new System.Windows.Forms.TextBox();
            this.FilePath2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(279, 154);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(336, 35);
            this.label.TabIndex = 0;
            this.label.Text = "Click the Button to Generate PDF";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(328, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Select a PDF File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(503, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(357, 29);
            this.button2.TabIndex = 3;
            this.button2.Text = "Select another PDF File ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 4;
            // 
            // FilePath
            // 
            this.FilePath.Location = new System.Drawing.Point(73, 70);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(328, 27);
            this.FilePath.TabIndex = 5;
            // 
            // FilePath2
            // 
            this.FilePath2.Location = new System.Drawing.Point(503, 70);
            this.FilePath2.Name = "FilePath2";
            this.FilePath2.Size = new System.Drawing.Size(357, 27);
            this.FilePath2.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(353, 192);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(172, 31);
            this.button3.TabIndex = 7;
            this.button3.Text = "Generate PDF";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 258);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.FilePath2);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label);
            this.Name = "Form1";
            this.Text = "Create PDF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

      //  private Button button;
        private Label label;
        private Button button1;
        private Button button2;
        private Label label1;
        private TextBox FilePath;
        private TextBox FilePath2;
        private Button button3;
        //#region ComparePDF
        //private void ComparePDF(object sender, EventArgs e)
        //{
        //    //Load a first PDF document
        //    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(FilePath.Text);

        //    //Load a second PDF document
        //    PdfLoadedDocument loadedDocument1 = new PdfLoadedDocument(FilePath2.Text);

        //    //Creating the list to store text data in PDF documents
        //    List<TextData> textData = new List<TextData>();
        //    List<TextData> textData1 = new List<TextData>();
        //    List<TextData> maxContainsData = new List<TextData>();
        //    List<TextData> diff = new List<TextData>();

        //    for (int i = 0; i < loadedDocument.Pages.Count; i++)
        //    {
        //        //Get the page from first document
        //        PdfLoadedPage loadedPage = loadedDocument.Pages[i] as PdfLoadedPage;
        //        //Extract the text from page of first document 
        //        string extractedText = loadedPage.ExtractText(out textData);

        //        //Extract the text from page of second document 
        //        string extractedText1 = loadedDocument1.Pages[i].ExtractText(out textData1);

        //        int minCount = 0;

        //        //Compare the text data count
        //        if (textData.Count > textData1.Count)
        //            maxContainsData = textData;
        //        if (textData.Count < textData1.Count)
        //            maxContainsData = textData1;

        //        if (textData != textData1)
        //        {
        //            if (textData.Count == textData1.Count)
        //                minCount = textData.Count;
        //            else
        //            {
        //                List<int> count = new List<int>();
        //                count.Add(textData.Count);
        //                count.Add(textData1.Count);
        //                minCount = count.Min();
        //                //Add diff text to the list
        //                diff.Add(maxContainsData[minCount]);
        //            }
        //            for (int j = 0; j < minCount; j++)
        //            {
        //                if (textData[j].Text != textData1[j].Text && textData[j].Bounds != textData1[j].Bounds)
        //                {
        //                    //Add diff text to the list
        //                    diff.Add(textData[j]);
        //                }
        //            }
        //        }
        //        //Highlight the line of changed text
        //        foreach (TextData data in diff)
        //        {
        //            loadedPage.Graphics.DrawRectangle(PdfPens.Red, PdfBrushes.Transparent, data.Bounds);
        //        }
        //    }

        //    //Save and closes the document 
        //    loadedDocument.Save("ComparedPDF.pdf");
        //    loadedDocument.Close(true);
        //    loadedDocument1.Close(true);

        //    //This will open the PDF file so, the result will be seen in default PDF viewer 
        //    System.Diagnostics.Process.Start("ComparedPDF.pdf");
        //}
        //#endregion


    }
}

