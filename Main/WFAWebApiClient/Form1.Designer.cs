namespace WFAWebApiClient
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelServer = new System.Windows.Forms.Label();
            this.textBoxServerAdress = new System.Windows.Forms.TextBox();
            this.labelServerAdress = new System.Windows.Forms.Label();
            this.buttonFetch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1060, 162);
            this.dataGridView1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.buttonFetch);
            this.splitContainer1.Panel1.Controls.Add(this.labelServerAdress);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxServerAdress);
            this.splitContainer1.Panel1.Controls.Add(this.labelServer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1060, 331);
            this.splitContainer1.SplitterDistance = 165;
            this.splitContainer1.TabIndex = 1;
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(265, 9);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(60, 13);
            this.labelServer.TabIndex = 0;
            this.labelServer.Text = "labelServer";
            // 
            // textBoxServerAdress
            // 
            this.textBoxServerAdress.Location = new System.Drawing.Point(268, 54);
            this.textBoxServerAdress.Name = "textBoxServerAdress";
            this.textBoxServerAdress.Size = new System.Drawing.Size(305, 20);
            this.textBoxServerAdress.TabIndex = 1;
            // 
            // labelServerAdress
            // 
            this.labelServerAdress.AutoSize = true;
            this.labelServerAdress.Location = new System.Drawing.Point(265, 38);
            this.labelServerAdress.Name = "labelServerAdress";
            this.labelServerAdress.Size = new System.Drawing.Size(142, 13);
            this.labelServerAdress.TabIndex = 2;
            this.labelServerAdress.Text = "Cut and past a server adress";
            // 
            // buttonFetch
            // 
            this.buttonFetch.Location = new System.Drawing.Point(498, 80);
            this.buttonFetch.Name = "buttonFetch";
            this.buttonFetch.Size = new System.Drawing.Size(75, 23);
            this.buttonFetch.TabIndex = 3;
            this.buttonFetch.Text = "Fetch";
            this.buttonFetch.UseVisualStyleBackColor = true;
            this.buttonFetch.Click += new System.EventHandler(this.buttonFetch_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 142);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 331);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonFetch;
        private System.Windows.Forms.Label labelServerAdress;
        private System.Windows.Forms.TextBox textBoxServerAdress;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TextBox textBox1;
    }
}

