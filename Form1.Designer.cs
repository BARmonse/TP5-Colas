
namespace Colas
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
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.desde = new System.Windows.Forms.TextBox();
            this.hasta = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.limSuperiorAct1 = new System.Windows.Forms.TextBox();
            this.limInferiorAct1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.limSuperiorAct2 = new System.Windows.Forms.TextBox();
            this.limInferiorAct2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.mediaExpAct5 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.limSuperiorAct4 = new System.Windows.Forms.TextBox();
            this.limInferiorAct4 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mediaExpAct3 = new System.Windows.Forms.TextBox();
            this.lbl23 = new System.Windows.Forms.Label();
            this.cant = new System.Windows.Forms.TextBox();
            this.grdResultados = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(1033, 16);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(203, 112);
            this.btnGenerar.TabIndex = 0;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(853, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(858, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta:";
            // 
            // desde
            // 
            this.desde.Location = new System.Drawing.Point(927, 66);
            this.desde.Name = "desde";
            this.desde.Size = new System.Drawing.Size(100, 23);
            this.desde.TabIndex = 3;
            this.desde.Text = "0";
            // 
            // hasta
            // 
            this.hasta.Location = new System.Drawing.Point(927, 95);
            this.hasta.Name = "hasta";
            this.hasta.Size = new System.Drawing.Size(100, 23);
            this.hasta.TabIndex = 4;
            this.hasta.Text = "50";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.limSuperiorAct1);
            this.groupBox1.Controls.Add(this.limInferiorAct1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 114);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actividad 1";
            // 
            // limSuperiorAct1
            // 
            this.limSuperiorAct1.Location = new System.Drawing.Point(39, 73);
            this.limSuperiorAct1.Name = "limSuperiorAct1";
            this.limSuperiorAct1.Size = new System.Drawing.Size(100, 32);
            this.limSuperiorAct1.TabIndex = 13;
            this.limSuperiorAct1.Text = "30";
            // 
            // limInferiorAct1
            // 
            this.limInferiorAct1.Location = new System.Drawing.Point(39, 35);
            this.limInferiorAct1.Name = "limInferiorAct1";
            this.limInferiorAct1.Size = new System.Drawing.Size(100, 32);
            this.limInferiorAct1.TabIndex = 12;
            this.limInferiorAct1.Text = "20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(6, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "B:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(6, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "A:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.limSuperiorAct2);
            this.groupBox2.Controls.Add(this.limInferiorAct2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(176, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 116);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actividad 2";
            // 
            // limSuperiorAct2
            // 
            this.limSuperiorAct2.Location = new System.Drawing.Point(39, 70);
            this.limSuperiorAct2.Name = "limSuperiorAct2";
            this.limSuperiorAct2.Size = new System.Drawing.Size(95, 32);
            this.limSuperiorAct2.TabIndex = 14;
            this.limSuperiorAct2.Text = "50";
            // 
            // limInferiorAct2
            // 
            this.limInferiorAct2.Location = new System.Drawing.Point(40, 31);
            this.limInferiorAct2.Name = "limInferiorAct2";
            this.limInferiorAct2.Size = new System.Drawing.Size(94, 32);
            this.limInferiorAct2.TabIndex = 13;
            this.limInferiorAct2.Text = "30";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(6, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "B:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(6, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "A:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.mediaExpAct5);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(666, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(157, 112);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Actividad 5";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(45, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 25);
            this.label10.TabIndex = 13;
            this.label10.Text = "Media:";
            // 
            // mediaExpAct5
            // 
            this.mediaExpAct5.Location = new System.Drawing.Point(29, 69);
            this.mediaExpAct5.Name = "mediaExpAct5";
            this.mediaExpAct5.Size = new System.Drawing.Size(100, 32);
            this.mediaExpAct5.TabIndex = 15;
            this.mediaExpAct5.Text = "5";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.limSuperiorAct4);
            this.groupBox4.Controls.Add(this.limInferiorAct4);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(503, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(157, 116);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Actividad 4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(6, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "A:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(7, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "B:";
            // 
            // limSuperiorAct4
            // 
            this.limSuperiorAct4.Location = new System.Drawing.Point(40, 72);
            this.limSuperiorAct4.Name = "limSuperiorAct4";
            this.limSuperiorAct4.Size = new System.Drawing.Size(100, 32);
            this.limSuperiorAct4.TabIndex = 4;
            this.limSuperiorAct4.Text = "20";
            // 
            // limInferiorAct4
            // 
            this.limInferiorAct4.Location = new System.Drawing.Point(40, 33);
            this.limInferiorAct4.Name = "limInferiorAct4";
            this.limInferiorAct4.Size = new System.Drawing.Size(100, 32);
            this.limInferiorAct4.TabIndex = 14;
            this.limInferiorAct4.Text = "10";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.mediaExpAct3);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox5.Location = new System.Drawing.Point(339, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(158, 116);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Actividad 3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(43, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 25);
            this.label9.TabIndex = 12;
            this.label9.Text = "Media:";
            // 
            // mediaExpAct3
            // 
            this.mediaExpAct3.Location = new System.Drawing.Point(30, 73);
            this.mediaExpAct3.Name = "mediaExpAct3";
            this.mediaExpAct3.Size = new System.Drawing.Size(100, 32);
            this.mediaExpAct3.TabIndex = 4;
            this.mediaExpAct3.Text = "30";
            // 
            // lbl23
            // 
            this.lbl23.AutoSize = true;
            this.lbl23.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl23.Location = new System.Drawing.Point(829, 28);
            this.lbl23.Name = "lbl23";
            this.lbl23.Size = new System.Drawing.Size(92, 25);
            this.lbl23.TabIndex = 10;
            this.lbl23.Text = "Cantidad:";
            // 
            // cant
            // 
            this.cant.Location = new System.Drawing.Point(927, 33);
            this.cant.Name = "cant";
            this.cant.Size = new System.Drawing.Size(100, 23);
            this.cant.TabIndex = 11;
            this.cant.Text = "1000";
            // 
            // grdResultados
            // 
            this.grdResultados.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultados.Location = new System.Drawing.Point(12, 138);
            this.grdResultados.Name = "grdResultados";
            this.grdResultados.RowTemplate.Height = 25;
            this.grdResultados.Size = new System.Drawing.Size(1304, 512);
            this.grdResultados.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 662);
            this.Controls.Add(this.grdResultados);
            this.Controls.Add(this.cant);
            this.Controls.Add(this.lbl23);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hasta);
            this.Controls.Add(this.desde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerar);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox desde;
        private System.Windows.Forms.TextBox hasta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox limSuperiorAct1;
        private System.Windows.Forms.TextBox limInferiorAct1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox limSuperiorAct2;
        private System.Windows.Forms.TextBox limInferiorAct2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox mediaExpAct5;
        private System.Windows.Forms.TextBox limInferiorAct4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox limSuperiorAct4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox mediaExpAct3;
        private System.Windows.Forms.Label lbl23;
        private System.Windows.Forms.TextBox cant;
        private System.Windows.Forms.DataGridView grdResultados;
    }
}

