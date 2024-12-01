namespace TypeIT
{
    partial class TestForm
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            uC_KeyCharacter1 = new UserControls.UC_KeyCharacter();
            uC_KeyCharacter2 = new UserControls.UC_KeyCharacter();
            uC_KeyCharacter3 = new UserControls.UC_KeyCharacter();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(uC_KeyCharacter1);
            flowLayoutPanel1.Controls.Add(uC_KeyCharacter2);
            flowLayoutPanel1.Controls.Add(uC_KeyCharacter3);
            flowLayoutPanel1.Location = new Point(437, 363);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(400, 200);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // uC_KeyCharacter1
            // 
            uC_KeyCharacter1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uC_KeyCharacter1.BackColor = Color.White;
            uC_KeyCharacter1.Location = new Point(0, 0);
            uC_KeyCharacter1.Margin = new Padding(0, 0, 16, 16);
            uC_KeyCharacter1.MaximumSize = new Size(82, 96);
            uC_KeyCharacter1.MinimumSize = new Size(82, 96);
            uC_KeyCharacter1.Name = "uC_KeyCharacter1";
            uC_KeyCharacter1.Size = new Size(82, 96);
            uC_KeyCharacter1.TabIndex = 0;
            // 
            // uC_KeyCharacter2
            // 
            uC_KeyCharacter2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uC_KeyCharacter2.BackColor = Color.White;
            uC_KeyCharacter2.Location = new Point(98, 0);
            uC_KeyCharacter2.Margin = new Padding(0, 0, 16, 16);
            uC_KeyCharacter2.MaximumSize = new Size(82, 96);
            uC_KeyCharacter2.MinimumSize = new Size(82, 96);
            uC_KeyCharacter2.Name = "uC_KeyCharacter2";
            uC_KeyCharacter2.Size = new Size(82, 96);
            uC_KeyCharacter2.TabIndex = 1;
            // 
            // uC_KeyCharacter3
            // 
            uC_KeyCharacter3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uC_KeyCharacter3.BackColor = Color.White;
            uC_KeyCharacter3.Location = new Point(196, 0);
            uC_KeyCharacter3.Margin = new Padding(0, 0, 16, 16);
            uC_KeyCharacter3.MaximumSize = new Size(82, 96);
            uC_KeyCharacter3.MinimumSize = new Size(82, 96);
            uC_KeyCharacter3.Name = "uC_KeyCharacter3";
            uC_KeyCharacter3.Size = new Size(82, 96);
            uC_KeyCharacter3.TabIndex = 2;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1381, 1003);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TestForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TestForm";
            TransparencyKey = Color.Fuchsia;
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private UserControls.UC_KeyCharacter uC_KeyCharacter1;
        private UserControls.UC_KeyCharacter uC_KeyCharacter2;
        private UserControls.UC_KeyCharacter uC_KeyCharacter3;
    }
}