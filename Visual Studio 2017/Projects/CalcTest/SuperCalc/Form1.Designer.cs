namespace SuperCalc
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BTCALC = new System.Windows.Forms.Button();
            this.TBX = new System.Windows.Forms.TextBox();
            this.TBY = new System.Windows.Forms.TextBox();
            this.result = new System.Windows.Forms.Label();
            this.comboBoxOper = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panTwoAgrs = new System.Windows.Forms.Panel();
            this.panMoreArgs = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panTwoAgrs.SuspendLayout();
            this.panMoreArgs.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTCALC
            // 
            this.BTCALC.Location = new System.Drawing.Point(330, 258);
            this.BTCALC.Name = "BTCALC";
            this.BTCALC.Size = new System.Drawing.Size(152, 23);
            this.BTCALC.TabIndex = 0;
            this.BTCALC.Text = "Calc";
            this.BTCALC.UseVisualStyleBackColor = true;
            this.BTCALC.Click += new System.EventHandler(this.BTCALC_Click);
            // 
            // TBX
            // 
            this.TBX.Location = new System.Drawing.Point(19, 25);
            this.TBX.Name = "TBX";
            this.TBX.Size = new System.Drawing.Size(62, 20);
            this.TBX.TabIndex = 2;
            // 
            // TBY
            // 
            this.TBY.Location = new System.Drawing.Point(104, 25);
            this.TBY.Name = "TBY";
            this.TBY.Size = new System.Drawing.Size(60, 20);
            this.TBY.TabIndex = 3;
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(35, 268);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(13, 13);
            this.result.TabIndex = 4;
            this.result.Text = "1";
            // 
            // comboBoxOper
            // 
            this.comboBoxOper.FormattingEnabled = true;
            this.comboBoxOper.Location = new System.Drawing.Point(142, 12);
            this.comboBoxOper.Name = "comboBoxOper";
            this.comboBoxOper.Size = new System.Drawing.Size(252, 21);
            this.comboBoxOper.TabIndex = 5;
            this.comboBoxOper.SelectedIndexChanged += new System.EventHandler(this.comboBoxOper_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select operation";
            // 
            // panTwoAgrs
            // 
            this.panTwoAgrs.Controls.Add(this.TBX);
            this.panTwoAgrs.Controls.Add(this.TBY);
            this.panTwoAgrs.Location = new System.Drawing.Point(38, 77);
            this.panTwoAgrs.Name = "panTwoAgrs";
            this.panTwoAgrs.Size = new System.Drawing.Size(200, 100);
            this.panTwoAgrs.TabIndex = 7;
            this.panTwoAgrs.Visible = false;
            // 
            // panMoreArgs
            // 
            this.panMoreArgs.Controls.Add(this.richTextBox1);
            this.panMoreArgs.Location = new System.Drawing.Point(282, 80);
            this.panMoreArgs.Name = "panMoreArgs";
            this.panMoreArgs.Size = new System.Drawing.Size(200, 100);
            this.panMoreArgs.TabIndex = 8;
            this.panMoreArgs.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(185, 85);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 310);
            this.Controls.Add(this.panMoreArgs);
            this.Controls.Add(this.panTwoAgrs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxOper);
            this.Controls.Add(this.result);
            this.Controls.Add(this.BTCALC);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panTwoAgrs.ResumeLayout(false);
            this.panTwoAgrs.PerformLayout();
            this.panMoreArgs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTCALC;
        private System.Windows.Forms.TextBox TBX;
        private System.Windows.Forms.TextBox TBY;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.ComboBox comboBoxOper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panTwoAgrs;
        private System.Windows.Forms.Panel panMoreArgs;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

