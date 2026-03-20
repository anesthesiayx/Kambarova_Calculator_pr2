using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kambarova_pr2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            ExpressionTextBox.Text = "";
            ResultTextBox.Text = "";
        }

        private void SkobkaButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ExpressionTextBox.Text += button.Content.ToString();
            ResultTextBox.Text = "";
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ExpressionTextBox.Text += button.Content.ToString();
            ResultTextBox.Text = "";
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ExpressionTextBox.Text += button.Content.ToString();
            ResultTextBox.Text = "";
        }

        private void TochkaButton_Click(object sender, RoutedEventArgs e)
        {
            string text = ExpressionTextBox.Text;
            int lastOperatorIndex = -1;
            char[] operators = { '+', '-', '*', '/', '^' };
            for (int i = text.Length - 1; i >= 0; i--)
            {
                if (Array.IndexOf(operators, text[i]) != -1)
                {
                    lastOperatorIndex = i;
                    break;
                }
            }
            string lastNumber;
            if (lastOperatorIndex == -1)
            {
                lastNumber = text;
            }
            else
            {
                lastNumber = text.Substring(lastOperatorIndex + 1);
            }
            if (!lastNumber.Contains("."))
            {
                ExpressionTextBox.Text = text + ".";
            }
            ResultTextBox.Text = "";
        }

        private void RavnoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string expression = ExpressionTextBox.Text;
                string result = Kambarova_libb.Kambarova.Parse(expression);
                ExpressionTextBox.Text = expression;
                ResultTextBox.Text = result;
            }
            catch
            {
                ResultTextBox.Text = "Ошибка";
                ExpressionTextBox.Text = ExpressionTextBox.Text + " = Ошибка";
            }
        }
    }
}