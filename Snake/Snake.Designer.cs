namespace Snake
{
    partial class Snake
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Snake));
            this.FondoJuego = new System.Windows.Forms.PictureBox();
            this.Cronometro = new System.Windows.Forms.Timer(this.components);
            this.btnInicioPausa = new System.Windows.Forms.Button();
            this.btnComidaExtra = new System.Windows.Forms.Button();
            this.txtPuntajeSnake = new System.Windows.Forms.TextBox();
            this.lblPuntajeSnake = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FondoJuego)).BeginInit();
            this.SuspendLayout();
            // 
            // FondoJuego
            // 
            this.FondoJuego.BackColor = System.Drawing.Color.Aquamarine;
            this.FondoJuego.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FondoJuego.BackgroundImage")));
            this.FondoJuego.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FondoJuego.Location = new System.Drawing.Point(12, 22);
            this.FondoJuego.Name = "FondoJuego";
            this.FondoJuego.Size = new System.Drawing.Size(738, 380);
            this.FondoJuego.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FondoJuego.TabIndex = 0;
            this.FondoJuego.TabStop = false;
            this.FondoJuego.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Color);
            // 
            // Cronometro
            // 
            this.Cronometro.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // btnInicioPausa
            // 
            this.btnInicioPausa.BackColor = System.Drawing.Color.Firebrick;
            this.btnInicioPausa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInicioPausa.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicioPausa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInicioPausa.Location = new System.Drawing.Point(527, 427);
            this.btnInicioPausa.Name = "btnInicioPausa";
            this.btnInicioPausa.Size = new System.Drawing.Size(133, 39);
            this.btnInicioPausa.TabIndex = 1;
            this.btnInicioPausa.Text = "Iniciar / Pausar";
            this.btnInicioPausa.UseVisualStyleBackColor = false;
            this.btnInicioPausa.Click += new System.EventHandler(this.btnInicioPausa_Click);
            // 
            // btnComidaExtra
            // 
            this.btnComidaExtra.BackColor = System.Drawing.Color.ForestGreen;
            this.btnComidaExtra.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnComidaExtra.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComidaExtra.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnComidaExtra.Location = new System.Drawing.Point(359, 427);
            this.btnComidaExtra.Name = "btnComidaExtra";
            this.btnComidaExtra.Size = new System.Drawing.Size(132, 38);
            this.btnComidaExtra.TabIndex = 2;
            this.btnComidaExtra.Text = "Comida extra";
            this.btnComidaExtra.UseVisualStyleBackColor = false;
            this.btnComidaExtra.Click += new System.EventHandler(this.btnComidaExtra_Click);
            // 
            // txtPuntajeSnake
            // 
            this.txtPuntajeSnake.Enabled = false;
            this.txtPuntajeSnake.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPuntajeSnake.Location = new System.Drawing.Point(93, 434);
            this.txtPuntajeSnake.Name = "txtPuntajeSnake";
            this.txtPuntajeSnake.ReadOnly = true;
            this.txtPuntajeSnake.Size = new System.Drawing.Size(161, 26);
            this.txtPuntajeSnake.TabIndex = 3;
            // 
            // lblPuntajeSnake
            // 
            this.lblPuntajeSnake.AutoSize = true;
            this.lblPuntajeSnake.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntajeSnake.Location = new System.Drawing.Point(26, 437);
            this.lblPuntajeSnake.Name = "lblPuntajeSnake";
            this.lblPuntajeSnake.Size = new System.Drawing.Size(61, 20);
            this.lblPuntajeSnake.TabIndex = 4;
            this.lblPuntajeSnake.Text = "Puntos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(510, 516);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "2017 © Desarrollado por Daniel Solano";
            // 
            // Snake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 541);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPuntajeSnake);
            this.Controls.Add(this.txtPuntajeSnake);
            this.Controls.Add(this.btnComidaExtra);
            this.Controls.Add(this.btnInicioPausa);
            this.Controls.Add(this.FondoJuego);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Snake";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake";
            ((System.ComponentModel.ISupportInitialize)(this.FondoJuego)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FondoJuego;
        private System.Windows.Forms.Timer Cronometro;
        private System.Windows.Forms.Button btnInicioPausa;
        private System.Windows.Forms.Button btnComidaExtra;
        private System.Windows.Forms.TextBox txtPuntajeSnake;
        private System.Windows.Forms.Label lblPuntajeSnake;
        private System.Windows.Forms.Label label1;
    }
}

