namespace EazyCart
{
    partial class CashRegisterUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.completeOrderButton = new System.Windows.Forms.Button();
            this.cancelOrderButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.totalLinePanel = new System.Windows.Forms.Panel();
            this.totalLabel = new System.Windows.Forms.Label();
            this.totalToPayLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.searchBoxTextBox = new System.Windows.Forms.TextBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.button6 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // completeOrderButton
            // 
            this.completeOrderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.completeOrderButton.BackgroundImage = global::EazyCart.Properties.Resources.completeOrderPlaceholder2;
            this.completeOrderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.completeOrderButton.FlatAppearance.BorderSize = 0;
            this.completeOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.completeOrderButton.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.completeOrderButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.completeOrderButton.Location = new System.Drawing.Point(13, 743);
            this.completeOrderButton.Name = "completeOrderButton";
            this.completeOrderButton.Size = new System.Drawing.Size(337, 82);
            this.completeOrderButton.TabIndex = 1;
            this.completeOrderButton.UseVisualStyleBackColor = false;
            // 
            // cancelOrderButton
            // 
            this.cancelOrderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.cancelOrderButton.BackgroundImage = global::EazyCart.Properties.Resources.closeIcon;
            this.cancelOrderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cancelOrderButton.FlatAppearance.BorderSize = 0;
            this.cancelOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelOrderButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.cancelOrderButton.Location = new System.Drawing.Point(350, 743);
            this.cancelOrderButton.Name = "cancelOrderButton";
            this.cancelOrderButton.Size = new System.Drawing.Size(38, 82);
            this.cancelOrderButton.TabIndex = 7;
            this.cancelOrderButton.Tag = "Cancel Order";
            this.cancelOrderButton.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 15);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(780, 720);
            this.textBox1.TabIndex = 8;
            // 
            // totalLinePanel
            // 
            this.totalLinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.totalLinePanel.Location = new System.Drawing.Point(406, 742);
            this.totalLinePanel.Name = "totalLinePanel";
            this.totalLinePanel.Size = new System.Drawing.Size(387, 5);
            this.totalLinePanel.TabIndex = 9;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.totalLabel.Location = new System.Drawing.Point(414, 766);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(84, 40);
            this.totalLabel.TabIndex = 10;
            this.totalLabel.Text = "Total:";
            // 
            // totalToPayLabel
            // 
            this.totalToPayLabel.AutoSize = true;
            this.totalToPayLabel.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalToPayLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.totalToPayLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.totalToPayLabel.Location = new System.Drawing.Point(490, 760);
            this.totalToPayLabel.MinimumSize = new System.Drawing.Size(310, 40);
            this.totalToPayLabel.Name = "totalToPayLabel";
            this.totalToPayLabel.Size = new System.Drawing.Size(310, 47);
            this.totalToPayLabel.TabIndex = 11;
            this.totalToPayLabel.Text = " $20.43";
            this.totalToPayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(817, 743);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 78);
            this.button1.TabIndex = 12;
            this.button1.Text = "+ ADD PRODUCT";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // searchBoxTextBox
            // 
            this.searchBoxTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchBoxTextBox.Location = new System.Drawing.Point(817, 64);
            this.searchBoxTextBox.Name = "searchBoxTextBox";
            this.searchBoxTextBox.Size = new System.Drawing.Size(751, 33);
            this.searchBoxTextBox.TabIndex = 13;
            this.searchBoxTextBox.Text = "Enter a product\'s name or its id";
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quantityTextBox.Location = new System.Drawing.Point(817, 690);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(751, 33);
            this.quantityTextBox.TabIndex = 14;
            this.quantityTextBox.Text = "Enter Quantity";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownHeight = 200;
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.IntegralHeight = false;
            this.categoryComboBox.ItemHeight = 25;
            this.categoryComboBox.Items.AddRange(new object[] {
            "(none)",
            "Drinks",
            "Food",
            "Cleaning Products"});
            this.categoryComboBox.Location = new System.Drawing.Point(817, 15);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(751, 33);
            this.categoryComboBox.TabIndex = 15;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Items.AddRange(new object[] {
            "#000001",
            "#000002",
            "#000003",
            "#000004",
            "#000005",
            "#000006",
            "#000007",
            "#000008",
            "#000009"});
            this.listBox1.Location = new System.Drawing.Point(817, 149);
            this.listBox1.MultiColumn = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox1.Size = new System.Drawing.Size(100, 529);
            this.listBox1.TabIndex = 17;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(1045, 740);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(222, 78);
            this.button2.TabIndex = 18;
            this.button2.Text = "+ ADD MOAR PRODUCT";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel1.Location = new System.Drawing.Point(917, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 530);
            this.panel1.TabIndex = 10;
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 25;
            this.listBox2.Items.AddRange(new object[] {
            "Water 500ml",
            "Soap Medix",
            "Coca Cola 1500ml",
            "Olives, Black",
            "Turkey 1kg",
            "Tuna Can 200g",
            "Potato Salad",
            "Queens Juice Glass 250ml ",
            "TUC Biscuits"});
            this.listBox2.Location = new System.Drawing.Point(921, 149);
            this.listBox2.Name = "listBox2";
            this.listBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox2.Size = new System.Drawing.Size(346, 529);
            this.listBox2.TabIndex = 19;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.ListBox2_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel2.Location = new System.Drawing.Point(1266, 148);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 530);
            this.panel2.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(817, 120);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 31);
            this.button3.TabIndex = 20;
            this.button3.Text = "CODE";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(919, 120);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(351, 31);
            this.button4.TabIndex = 21;
            this.button4.Text = "NAME";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(1269, 120);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(147, 31);
            this.button5.TabIndex = 22;
            this.button5.Text = "CATEGORY";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // listBox3
            // 
            this.listBox3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 25;
            this.listBox3.Items.AddRange(new object[] {
            "Drink",
            "Hygiene",
            "Drink",
            "Vegetable",
            "Meat",
            "Meat",
            "Salad",
            "Drink",
            "Snack"});
            this.listBox3.Location = new System.Drawing.Point(1271, 149);
            this.listBox3.Name = "listBox3";
            this.listBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox3.Size = new System.Drawing.Size(145, 529);
            this.listBox3.TabIndex = 23;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.ListBox3_SelectedIndexChanged);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button6.Location = new System.Drawing.Point(1416, 120);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(130, 31);
            this.button6.TabIndex = 24;
            this.button6.Text = "UNIT PRICE";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel3.Location = new System.Drawing.Point(1416, 148);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 530);
            this.panel3.TabIndex = 12;
            // 
            // listBox4
            // 
            this.listBox4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox4.FormattingEnabled = true;
            this.listBox4.ItemHeight = 25;
            this.listBox4.Items.AddRange(new object[] {
            "$ 2.04",
            "$ 5.92",
            "$ 3.99",
            "$ 10.88",
            "$ 16.00",
            "$ 4.55",
            "$ 8.90",
            "$ 2.60",
            "$ 1.44"});
            this.listBox4.Location = new System.Drawing.Point(1419, 149);
            this.listBox4.Name = "listBox4";
            this.listBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox4.Size = new System.Drawing.Size(127, 529);
            this.listBox4.TabIndex = 25;
            this.listBox4.SelectedIndexChanged += new System.EventHandler(this.ListBox4_SelectedIndexChanged);
            // 
            // CashRegisterUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.searchBoxTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.totalToPayLabel);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.totalLinePanel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cancelOrderButton);
            this.Controls.Add(this.completeOrderButton);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox4);
            this.Name = "CashRegisterUserControl";
            this.Size = new System.Drawing.Size(1600, 840);
            this.Load += new System.EventHandler(this.CashRegisterUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button completeOrderButton;
        private System.Windows.Forms.Button cancelOrderButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel totalLinePanel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label totalToPayLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox searchBoxTextBox;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox listBox4;
    }
}
