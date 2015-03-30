using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingButton
{
    partial class DrawingButton
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_start = new System.Windows.Forms.Button();
            this.pb_drawing = new System.Windows.Forms.PictureBox();
            this.gbFigure = new System.Windows.Forms.GroupBox();
            this.rbArrow = new System.Windows.Forms.RadioButton();
            this.rbBlock = new System.Windows.Forms.RadioButton();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_drawing)).BeginInit();
            this.gbFigure.SuspendLayout();
            this.gbType.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(15, 15);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(140, 50);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start!";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // pb_drawing
            // 
            this.pb_drawing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_drawing.Location = new System.Drawing.Point(0, 100);
            this.pb_drawing.Name = "pb_drawing";
            this.pb_drawing.Size = new System.Drawing.Size(780, 250);
            this.pb_drawing.TabIndex = 1;
            this.pb_drawing.TabStop = false;
            this.pb_drawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_drawing_MouseDown);
            this.pb_drawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_drawing_MouseMove);
            this.pb_drawing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_drawing_MouseUp);
            // 
            // gbFigure
            // 
            this.gbFigure.Controls.Add(this.rbArrow);
            this.gbFigure.Controls.Add(this.rbBlock);
            this.gbFigure.Location = new System.Drawing.Point(170, 15);
            this.gbFigure.Name = "gbFigure";
            this.gbFigure.Size = new System.Drawing.Size(105, 70);
            this.gbFigure.TabIndex = 2;
            this.gbFigure.TabStop = false;
            this.gbFigure.Text = "Element";
            // 
            // rbArrow
            // 
            this.rbArrow.AutoSize = true;
            this.rbArrow.Location = new System.Drawing.Point(10, 45);
            this.rbArrow.Name = "rbArrow";
            this.rbArrow.Size = new System.Drawing.Size(64, 17);
            this.rbArrow.TabIndex = 1;
            this.rbArrow.Text = "Relation";
            this.rbArrow.UseVisualStyleBackColor = true;
            this.rbArrow.CheckedChanged += new System.EventHandler(this.rbArrow_CheckedChanged);
            // 
            // rbBlock
            // 
            this.rbBlock.AutoSize = true;
            this.rbBlock.Checked = true;
            this.rbBlock.Location = new System.Drawing.Point(10, 20);
            this.rbBlock.Name = "rbBlock";
            this.rbBlock.Size = new System.Drawing.Size(52, 17);
            this.rbBlock.TabIndex = 0;
            this.rbBlock.TabStop = true;
            this.rbBlock.Text = "Block";
            this.rbBlock.UseVisualStyleBackColor = true;
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.cmbType);
            this.gbType.Location = new System.Drawing.Point(290, 15);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(160, 60);
            this.gbType.TabIndex = 3;
            this.gbType.TabStop = false;
            this.gbType.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(10, 20);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(140, 21);
            this.cmbType.TabIndex = 0;
            // 
            // DrawingButton
            // 
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.gbType);
            this.Controls.Add(this.gbFigure);
            this.Controls.Add(this.pb_drawing);
            this.Controls.Add(this.btn_start);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "DrawingButton";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "uDia 2.0 - UML Diagram";
            ((System.ComponentModel.ISupportInitialize)(this.pb_drawing)).EndInit();
            this.gbFigure.ResumeLayout(false);
            this.gbFigure.PerformLayout();
            this.gbType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_start;
        private PictureBox pb_drawing;
        private GroupBox gbFigure;
        private RadioButton rbArrow;
        private RadioButton rbBlock;
        private GroupBox gbType;
        private ComboBox cmbType;
    }
}

