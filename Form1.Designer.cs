namespace IA_projet_p1
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
            this.button1 = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Label();
            this.lb_destinationStart = new System.Windows.Forms.ListBox();
            this.labelcountopen = new System.Windows.Forms.Label();
            this.labelcountclosed = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label4 = new System.Windows.Forms.Label();
            this.labelsolution = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_destinationEnd = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(429, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Trouver PCC";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // start
            // 
            this.start.AutoSize = true;
            this.start.Location = new System.Drawing.Point(59, 63);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(39, 13);
            this.start.TabIndex = 2;
            this.start.Text = "Départ";
            // 
            // lb_destinationStart
            // 
            this.lb_destinationStart.FormattingEnabled = true;
            this.lb_destinationStart.Location = new System.Drawing.Point(117, 63);
            this.lb_destinationStart.Name = "lb_destinationStart";
            this.lb_destinationStart.Size = new System.Drawing.Size(120, 95);
            this.lb_destinationStart.TabIndex = 3;
            // 
            // labelcountopen
            // 
            this.labelcountopen.AutoSize = true;
            this.labelcountopen.Location = new System.Drawing.Point(49, 312);
            this.labelcountopen.Name = "labelcountopen";
            this.labelcountopen.Size = new System.Drawing.Size(0, 13);
            this.labelcountopen.TabIndex = 4;
            // 
            // labelcountclosed
            // 
            this.labelcountclosed.AutoSize = true;
            this.labelcountclosed.Location = new System.Drawing.Point(85, 364);
            this.labelcountclosed.Name = "labelcountclosed";
            this.labelcountclosed.Size = new System.Drawing.Size(0, 13);
            this.labelcountclosed.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(324, 191);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(241, 209);
            this.treeView1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Arbre de recherche";
            // 
            // labelsolution
            // 
            this.labelsolution.AutoSize = true;
            this.labelsolution.Location = new System.Drawing.Point(341, 136);
            this.labelsolution.Name = "labelsolution";
            this.labelsolution.Size = new System.Drawing.Size(0, 13);
            this.labelsolution.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Arrivée";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lb_destinationEnd
            // 
            this.lb_destinationEnd.FormattingEnabled = true;
            this.lb_destinationEnd.Location = new System.Drawing.Point(144, 191);
            this.lb_destinationEnd.Name = "lb_destinationEnd";
            this.lb_destinationEnd.Size = new System.Drawing.Size(93, 56);
            this.lb_destinationEnd.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 432);
            this.Controls.Add(this.lb_destinationEnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelsolution);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.labelcountclosed);
            this.Controls.Add(this.labelcountopen);
            this.Controls.Add(this.lb_destinationStart);
            this.Controls.Add(this.start);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label start;
        private System.Windows.Forms.ListBox lb_destinationStart;
        private System.Windows.Forms.Label labelcountopen;
        private System.Windows.Forms.Label labelcountclosed;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelsolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lb_destinationEnd;
    }
}

