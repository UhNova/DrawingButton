namespace DrawingButton
{
    partial class DrawingButton
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            ((System.ComponentModel.ISupportInitialize)(this.pb_drawing)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(307, 33);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(140, 50);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Рисовать!";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // pb_drawing
            // 
            this.pb_drawing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_drawing.Location = new System.Drawing.Point(2, 102);
            this.pb_drawing.Name = "pb_drawing";
            this.pb_drawing.Size = new System.Drawing.Size(780, 250);
            this.pb_drawing.TabIndex = 1;
            this.pb_drawing.TabStop = false;
            this.pb_drawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_drawing_MouseDown);
            this.pb_drawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_drawing_MouseMove);
            this.pb_drawing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_drawing_MouseUp);
            // 
            // DrawingButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.pb_drawing);
            this.Controls.Add(this.btn_start);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "DrawingButton";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кнопка для рисования";
            ((System.ComponentModel.ISupportInitialize)(this.pb_drawing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.PictureBox pb_drawing;
    }
}

