namespace taschenrechner
{
    /// <summary>
    /// Main calculator form with all calculation logic.
    /// </summary>
    public partial class Form1 : Form
    {
        // Calculator state variables
        private double _firstOperand = 0;
        private double _secondOperand = 0;
        private string _currentOperator = "";
        private bool _isNewEntry = true;
        private bool _hasDecimal = false;

        public Form1()
        {
            InitializeComponent();
            
            // Enable keyboard input
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        #region Number Button Handlers

        /// <summary>
        /// Handles number button clicks (0-9).
        /// </summary>
        private void BtnNumber_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                AppendDigit(btn.Text);
            }
        }

        /// <summary>
        /// Appends a digit to the display.
        /// </summary>
        private void AppendDigit(string digit)
        {
            if (_isNewEntry)
            {
                displayTextBox.Text = digit;
                _isNewEntry = false;
                _hasDecimal = false;
            }
            else
            {
                // Prevent leading zeros except for decimal numbers
                if (displayTextBox.Text == "0" && digit != ".")
                {
                    displayTextBox.Text = digit;
                }
                else
                {
                    displayTextBox.Text += digit;
                }
            }
        }

        #endregion

        #region Operator Button Handlers

        /// <summary>
        /// Handles operator button clicks (+, -, ×, ÷).
        /// </summary>
        private void BtnOperator_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                SetOperator(btn.Text);
            }
        }

        /// <summary>
        /// Sets the current operator and stores the first operand.
        /// </summary>
        private void SetOperator(string op)
        {
            // If we already have an operator, calculate first
            if (!string.IsNullOrEmpty(_currentOperator) && !_isNewEntry)
            {
                Calculate();
            }

            if (double.TryParse(displayTextBox.Text, out double value))
            {
                _firstOperand = value;
            }

            _currentOperator = op;
            _isNewEntry = true;
        }

        #endregion

        #region Calculation Methods

        /// <summary>
        /// Handles the equals button click.
        /// </summary>
        private void BtnEquals_Click(object? sender, EventArgs e)
        {
            Calculate();
        }

        /// <summary>
        /// Performs the calculation based on the current operator.
        /// </summary>
        private void Calculate()
        {
            if (string.IsNullOrEmpty(_currentOperator))
            {
                return;
            }

            if (double.TryParse(displayTextBox.Text, out double value))
            {
                _secondOperand = value;
            }

            double result = 0;
            bool hasError = false;

            switch (_currentOperator)
            {
                case "+":
                    result = _firstOperand + _secondOperand;
                    break;
                case "-":
                    result = _firstOperand - _secondOperand;
                    break;
                case "×":
                    result = _firstOperand * _secondOperand;
                    break;
                case "÷":
                    if (_secondOperand == 0)
                    {
                        displayTextBox.Text = "Error";
                        hasError = true;
                    }
                    else
                    {
                        result = _firstOperand / _secondOperand;
                    }
                    break;
            }

            if (!hasError)
            {
                // Format result to remove unnecessary trailing zeros
                displayTextBox.Text = FormatResult(result);
                _firstOperand = result;
            }

            _currentOperator = "";
            _isNewEntry = true;
            _hasDecimal = displayTextBox.Text.Contains('.');
        }

        /// <summary>
        /// Formats the result to show appropriate decimal places.
        /// </summary>
        private static string FormatResult(double value)
        {
            // Use G15 format to handle precision without unnecessary zeros
            string result = value.ToString("G15");
            
            // Limit display length
            if (result.Length > 15)
            {
                result = value.ToString("E10");
            }

            return result;
        }

        #endregion

        #region Special Function Handlers

        /// <summary>
        /// Handles the Clear (C) button click.
        /// </summary>
        private void BtnClear_Click(object? sender, EventArgs e)
        {
            ClearAll();
        }

        /// <summary>
        /// Clears all calculator state.
        /// </summary>
        private void ClearAll()
        {
            displayTextBox.Text = "0";
            _firstOperand = 0;
            _secondOperand = 0;
            _currentOperator = "";
            _isNewEntry = true;
            _hasDecimal = false;
        }

        /// <summary>
        /// Handles the plus/minus (±) button click.
        /// </summary>
        private void BtnPlusMinus_Click(object? sender, EventArgs e)
        {
            ToggleSign();
        }

        /// <summary>
        /// Toggles the sign of the current number.
        /// </summary>
        private void ToggleSign()
        {
            if (displayTextBox.Text != "0" && displayTextBox.Text != "Error")
            {
                if (double.TryParse(displayTextBox.Text, out double value))
                {
                    value = -value;
                    displayTextBox.Text = FormatResult(value);
                }
            }
        }

        /// <summary>
        /// Handles the percent (%) button click.
        /// </summary>
        private void BtnPercent_Click(object? sender, EventArgs e)
        {
            CalculatePercent();
        }

        /// <summary>
        /// Calculates the percentage of the current number.
        /// </summary>
        private void CalculatePercent()
        {
            if (double.TryParse(displayTextBox.Text, out double value))
            {
                value = value / 100;
                displayTextBox.Text = FormatResult(value);
            }
        }

        /// <summary>
        /// Handles the decimal point (.) button click.
        /// </summary>
        private void BtnDecimal_Click(object? sender, EventArgs e)
        {
            AddDecimalPoint();
        }

        /// <summary>
        /// Adds a decimal point to the current number.
        /// </summary>
        private void AddDecimalPoint()
        {
            if (_isNewEntry)
            {
                displayTextBox.Text = "0.";
                _isNewEntry = false;
                _hasDecimal = true;
            }
            else if (!_hasDecimal && !displayTextBox.Text.Contains('.'))
            {
                displayTextBox.Text += ".";
                _hasDecimal = true;
            }
        }

        /// <summary>
        /// Deletes the last character (backspace functionality).
        /// </summary>
        private void Backspace()
        {
            if (displayTextBox.Text.Length > 1 && displayTextBox.Text != "Error")
            {
                string lastChar = displayTextBox.Text[^1].ToString();
                if (lastChar == ".")
                {
                    _hasDecimal = false;
                }
                displayTextBox.Text = displayTextBox.Text[..^1];
            }
            else
            {
                displayTextBox.Text = "0";
                _isNewEntry = true;
            }
        }

        #endregion

        #region Keyboard Support

        /// <summary>
        /// Handles keyboard input for the calculator.
        /// </summary>
        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            // Number keys
            switch (e.KeyCode)
            {
                case Keys.D0:
                case Keys.NumPad0:
                    AppendDigit("0");
                    break;
                case Keys.D1:
                case Keys.NumPad1:
                    AppendDigit("1");
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    AppendDigit("2");
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    AppendDigit("3");
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    AppendDigit("4");
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    AppendDigit("5");
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    AppendDigit("6");
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    AppendDigit("7");
                    break;
                case Keys.D8:
                    if (e.Shift)
                    {
                        SetOperator("×"); // Shift+8 = *
                    }
                    else
                    {
                        AppendDigit("8");
                    }
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    AppendDigit("9");
                    break;

                // Operators
                case Keys.Add:
                    SetOperator("+");
                    break;
                case Keys.Subtract:
                    SetOperator("-");
                    break;
                case Keys.Multiply:
                    SetOperator("×");
                    break;
                case Keys.Divide:
                    SetOperator("÷");
                    break;
                case Keys.Oemplus:
                    if (e.Shift)
                    {
                        SetOperator("+");
                    }
                    else
                    {
                        Calculate(); // = key
                    }
                    break;
                case Keys.OemMinus:
                    SetOperator("-");
                    break;

                // Enter for equals
                case Keys.Enter:
                    Calculate();
                    e.SuppressKeyPress = true;
                    break;

                // Decimal point
                case Keys.Decimal:
                case Keys.OemPeriod:
                case Keys.Oemcomma:
                    AddDecimalPoint();
                    break;

                // Clear
                case Keys.Escape:
                case Keys.C:
                    ClearAll();
                    break;

                // Backspace
                case Keys.Back:
                    Backspace();
                    break;
            }

            e.Handled = true;
        }

        #endregion
    }
}
