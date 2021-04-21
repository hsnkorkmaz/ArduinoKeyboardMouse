
namespace ArduinoKeyboardMouse
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
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.lblIsConnected = new System.Windows.Forms.Label();
            this.btnCloseConnection = new System.Windows.Forms.Button();
            this.btnSendData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(12, 12);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(113, 45);
            this.btnTestConnection.TabIndex = 0;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // lblIsConnected
            // 
            this.lblIsConnected.AutoSize = true;
            this.lblIsConnected.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblIsConnected.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIsConnected.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblIsConnected.Location = new System.Drawing.Point(12, 410);
            this.lblIsConnected.Name = "lblIsConnected";
            this.lblIsConnected.Size = new System.Drawing.Size(36, 21);
            this.lblIsConnected.TabIndex = 1;
            this.lblIsConnected.Text = "lbl1";
            // 
            // btnCloseConnection
            // 
            this.btnCloseConnection.Location = new System.Drawing.Point(133, 12);
            this.btnCloseConnection.Name = "btnCloseConnection";
            this.btnCloseConnection.Size = new System.Drawing.Size(113, 45);
            this.btnCloseConnection.TabIndex = 2;
            this.btnCloseConnection.Text = "Close Connection";
            this.btnCloseConnection.UseVisualStyleBackColor = true;
            this.btnCloseConnection.Click += new System.EventHandler(this.btnCloseConnection_Click);
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(12, 63);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(113, 47);
            this.btnSendData.TabIndex = 3;
            this.btnSendData.Text = "Send Data";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 436);
            this.Controls.Add(this.btnSendData);
            this.Controls.Add(this.btnCloseConnection);
            this.Controls.Add(this.lblIsConnected);
            this.Controls.Add(this.btnTestConnection);
            this.Name = "Form1";
            this.Text = "Test Connection";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label lblIsConnected;
        private System.Windows.Forms.Button btnCloseConnection;
        private System.Windows.Forms.Button btnSendData;
    }
}

