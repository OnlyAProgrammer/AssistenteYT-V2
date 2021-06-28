
namespace Assistente.View
{
    internal sealed partial class VoiceChangeView
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
            this.listViewVoices = new System.Windows.Forms.ListView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewVoices
            // 
            this.listViewVoices.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listViewVoices.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewVoices.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewVoices.HideSelection = false;
            this.listViewVoices.Location = new System.Drawing.Point(0, 23);
            this.listViewVoices.MultiSelect = false;
            this.listViewVoices.Name = "listViewVoices";
            this.listViewVoices.Size = new System.Drawing.Size(747, 285);
            this.listViewVoices.TabIndex = 0;
            this.listViewVoices.UseCompatibleStateImageBehavior = false;
            this.listViewVoices.View = System.Windows.Forms.View.List;
            this.listViewVoices.SelectedIndexChanged += new System.EventHandler(this.ListViewVoices_SelectedIndexChanged);
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(747, 23);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Lista de vozes no sistema:";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonTest
            // 
            this.buttonTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTest.Location = new System.Drawing.Point(4, 314);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(97, 30);
            this.buttonTest.TabIndex = 2;
            this.buttonTest.Text = "Testar";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.ButtonTest_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApply.Location = new System.Drawing.Point(638, 314);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(97, 30);
            this.buttonApply.TabIndex = 3;
            this.buttonApply.Text = "Aplicar";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // VoiceChangeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(747, 349);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.listViewVoices);
            this.Controls.Add(this.labelTitle);
            this.Name = "VoiceChangeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VoiceChangeView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewVoices;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonApply;
    }
}