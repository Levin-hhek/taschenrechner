namespace taschenrechner
{
    partial class Form1
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
            // Color scheme constants
            Color backgroundColor = Color.FromArgb(45, 45, 48);       // #2D2D30
            Color displayColor = Color.FromArgb(30, 30, 30);          // #1E1E1E
            Color numberButtonColor = Color.FromArgb(60, 60, 60);     // #3C3C3C
            Color operatorButtonColor = Color.FromArgb(255, 149, 0);  // #FF9500 (Orange)
            Color equalsButtonColor = Color.FromArgb(16, 137, 62);    // #10893E (Green)
            Color specialButtonColor = Color.FromArgb(80, 80, 80);    // Lighter gray for special buttons
            Color textColor = Color.White;
            Color operatorTextColor = Color.White;

            // Initialize components
            this.displayTextBox = new TextBox();
            this.btnClear = new Button();
            this.btnPlusMinus = new Button();
            this.btnPercent = new Button();
            this.btnDivide = new Button();
            this.btn7 = new Button();
            this.btn8 = new Button();
            this.btn9 = new Button();
            this.btnMultiply = new Button();
            this.btn4 = new Button();
            this.btn5 = new Button();
            this.btn6 = new Button();
            this.btnSubtract = new Button();
            this.btn1 = new Button();
            this.btn2 = new Button();
            this.btn3 = new Button();
            this.btnAdd = new Button();
            this.btn0 = new Button();
            this.btnDecimal = new Button();
            this.btnEquals = new Button();
            this.SuspendLayout();

            // Button dimensions
            int buttonWidth = 80;
            int buttonHeight = 60;
            int buttonSpacing = 5;
            int startX = 10;
            int startY = 90;

            // 
            // displayTextBox
            // 
            this.displayTextBox.BackColor = displayColor;
            this.displayTextBox.BorderStyle = BorderStyle.None;
            this.displayTextBox.Font = new Font("Segoe UI", 32F, FontStyle.Regular, GraphicsUnit.Point);
            this.displayTextBox.ForeColor = textColor;
            this.displayTextBox.Location = new Point(10, 10);
            this.displayTextBox.Name = "displayTextBox";
            this.displayTextBox.ReadOnly = true;
            this.displayTextBox.Size = new Size(335, 70);
            this.displayTextBox.TabIndex = 0;
            this.displayTextBox.Text = "0";
            this.displayTextBox.TextAlign = HorizontalAlignment.Right;

            // Helper method to style number buttons
            void StyleNumberButton(Button btn, string text, int col, int row)
            {
                btn.BackColor = numberButtonColor;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
                btn.ForeColor = textColor;
                btn.Location = new Point(startX + col * (buttonWidth + buttonSpacing), startY + row * (buttonHeight + buttonSpacing));
                btn.Name = btn.Name ?? "btn" + text;
                btn.Size = new Size(buttonWidth, buttonHeight);
                btn.TabIndex = 1;
                btn.Text = text;
                btn.UseVisualStyleBackColor = false;
                btn.Click += BtnNumber_Click;
            }

            // Helper method to style operator buttons
            void StyleOperatorButton(Button btn, string displayText, string name, int col, int row)
            {
                btn.BackColor = operatorButtonColor;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 169, 50);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 189, 100);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
                btn.ForeColor = operatorTextColor;
                btn.Location = new Point(startX + col * (buttonWidth + buttonSpacing), startY + row * (buttonHeight + buttonSpacing));
                btn.Name = name;
                btn.Size = new Size(buttonWidth, buttonHeight);
                btn.TabIndex = 1;
                btn.Text = displayText;
                btn.UseVisualStyleBackColor = false;
                btn.Click += BtnOperator_Click;
            }

            // Helper method to style special buttons (C, ±, %)
            void StyleSpecialButton(Button btn, string displayText, string name, int col, int row, EventHandler handler)
            {
                btn.BackColor = specialButtonColor;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 100, 100);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(120, 120, 120);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
                btn.ForeColor = textColor;
                btn.Location = new Point(startX + col * (buttonWidth + buttonSpacing), startY + row * (buttonHeight + buttonSpacing));
                btn.Name = name;
                btn.Size = new Size(buttonWidth, buttonHeight);
                btn.TabIndex = 1;
                btn.Text = displayText;
                btn.UseVisualStyleBackColor = false;
                btn.Click += handler;
            }

            // Row 0: C, ±, %, ÷
            StyleSpecialButton(this.btnClear, "C", "btnClear", 0, 0, BtnClear_Click);
            StyleSpecialButton(this.btnPlusMinus, "±", "btnPlusMinus", 1, 0, BtnPlusMinus_Click);
            StyleSpecialButton(this.btnPercent, "%", "btnPercent", 2, 0, BtnPercent_Click);
            StyleOperatorButton(this.btnDivide, "÷", "btnDivide", 3, 0);

            // Row 1: 7, 8, 9, ×
            StyleNumberButton(this.btn7, "7", 0, 1);
            StyleNumberButton(this.btn8, "8", 1, 1);
            StyleNumberButton(this.btn9, "9", 2, 1);
            StyleOperatorButton(this.btnMultiply, "×", "btnMultiply", 3, 1);

            // Row 2: 4, 5, 6, -
            StyleNumberButton(this.btn4, "4", 0, 2);
            StyleNumberButton(this.btn5, "5", 1, 2);
            StyleNumberButton(this.btn6, "6", 2, 2);
            StyleOperatorButton(this.btnSubtract, "-", "btnSubtract", 3, 2);

            // Row 3: 1, 2, 3, +
            StyleNumberButton(this.btn1, "1", 0, 3);
            StyleNumberButton(this.btn2, "2", 1, 3);
            StyleNumberButton(this.btn3, "3", 2, 3);
            StyleOperatorButton(this.btnAdd, "+", "btnAdd", 3, 3);

            // Row 4: 0 (double width), ., =
            // btn0 - double width
            this.btn0.BackColor = numberButtonColor;
            this.btn0.FlatAppearance.BorderSize = 0;
            this.btn0.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
            this.btn0.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);
            this.btn0.FlatStyle = FlatStyle.Flat;
            this.btn0.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            this.btn0.ForeColor = textColor;
            this.btn0.Location = new Point(startX, startY + 4 * (buttonHeight + buttonSpacing));
            this.btn0.Name = "btn0";
            this.btn0.Size = new Size(buttonWidth * 2 + buttonSpacing, buttonHeight);
            this.btn0.TabIndex = 1;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = false;
            this.btn0.Click += BtnNumber_Click;

            // btnDecimal
            this.btnDecimal.BackColor = numberButtonColor;
            this.btnDecimal.FlatAppearance.BorderSize = 0;
            this.btnDecimal.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
            this.btnDecimal.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);
            this.btnDecimal.FlatStyle = FlatStyle.Flat;
            this.btnDecimal.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnDecimal.ForeColor = textColor;
            this.btnDecimal.Location = new Point(startX + 2 * (buttonWidth + buttonSpacing), startY + 4 * (buttonHeight + buttonSpacing));
            this.btnDecimal.Name = "btnDecimal";
            this.btnDecimal.Size = new Size(buttonWidth, buttonHeight);
            this.btnDecimal.TabIndex = 1;
            this.btnDecimal.Text = ".";
            this.btnDecimal.UseVisualStyleBackColor = false;
            this.btnDecimal.Click += BtnDecimal_Click;

            // btnEquals
            this.btnEquals.BackColor = equalsButtonColor;
            this.btnEquals.FlatAppearance.BorderSize = 0;
            this.btnEquals.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 157, 82);
            this.btnEquals.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 177, 102);
            this.btnEquals.FlatStyle = FlatStyle.Flat;
            this.btnEquals.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnEquals.ForeColor = textColor;
            this.btnEquals.Location = new Point(startX + 3 * (buttonWidth + buttonSpacing), startY + 4 * (buttonHeight + buttonSpacing));
            this.btnEquals.Name = "btnEquals";
            this.btnEquals.Size = new Size(buttonWidth, buttonHeight);
            this.btnEquals.TabIndex = 1;
            this.btnEquals.Text = "=";
            this.btnEquals.UseVisualStyleBackColor = false;
            this.btnEquals.Click += BtnEquals_Click;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = backgroundColor;
            this.ClientSize = new Size(355, 425);
            this.Controls.Add(this.btnEquals);
            this.Controls.Add(this.btnDecimal);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btnSubtract);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.btnPercent);
            this.Controls.Add(this.btnPlusMinus);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.displayTextBox);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Taschenrechner";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private TextBox displayTextBox;
        private Button btnClear;
        private Button btnPlusMinus;
        private Button btnPercent;
        private Button btnDivide;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btnMultiply;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btnSubtract;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btnAdd;
        private Button btn0;
        private Button btnDecimal;
        private Button btnEquals;
    }
}
