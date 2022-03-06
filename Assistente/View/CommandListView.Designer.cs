
namespace Assistente.View
{
    internal sealed partial class CommandListView
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
            this.commandList = new System.Windows.Forms.ListView();
            this.labelCommandType = new System.Windows.Forms.Label();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // commandList
            // 
            this.commandList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.commandList.Dock = System.Windows.Forms.DockStyle.Left;
            this.commandList.HideSelection = false;
            this.commandList.Location = new System.Drawing.Point(0, 0);
            this.commandList.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.commandList.MultiSelect = false;
            this.commandList.Name = "commandList";
            this.commandList.Size = new System.Drawing.Size(502, 673);
            this.commandList.TabIndex = 0;
            this.commandList.UseCompatibleStateImageBehavior = false;
            this.commandList.View = System.Windows.Forms.View.Details;
            // 
            // labelCommandType
            // 
            this.labelCommandType.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCommandType.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommandType.Location = new System.Drawing.Point(502, 0);
            this.labelCommandType.Name = "labelCommandType";
            this.labelCommandType.Size = new System.Drawing.Size(409, 38);
            this.labelCommandType.TabIndex = 2;
            // 
            // panelCommands
            // 
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCommands.Location = new System.Drawing.Point(502, 38);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(409, 635);
            this.panelCommands.TabIndex = 3;
            // 
            // CommandListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(911, 673);
            this.Controls.Add(this.panelCommands);
            this.Controls.Add(this.labelCommandType);
            this.Controls.Add(this.commandList);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "CommandListView";
            this.Text = "CommandListView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView commandList;
        private System.Windows.Forms.Label labelCommandType;
        private System.Windows.Forms.Panel panelCommands;
    }
}