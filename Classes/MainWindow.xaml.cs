using System;
using System.Windows;

namespace Classes
{
    public partial class MainWindow : Window
    {
        const string InfoTitle = "Info";
        readonly CompletionMonitor monitor;

        public MainWindow()
        {
            InitializeComponent();

            monitor = new CompletionMonitor(75);
            monitor.ThresholdReached += monitor_ThresholdReached;
        }

        void monitor_ThresholdReached(object sender, EventArgs e)
        {
            MessageBox.Show("Theshold Reached!", InfoTitle);
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            int currentInput = 0;
            bool success = int.TryParse(PercentTextBox.Text, out currentInput);

            if (!success)
            {
                EchoTextBox.Text = "Invalid!";
                return;
            }

            monitor.Current = currentInput;

            EchoTextBox.Text = currentInput.ToString();
        }

        private void EstimateButton_Click(object sender, RoutedEventArgs e)
        {
            string message = string.Format("Value is {0} the threshold.", monitor.EstimateThreasholdLevel());
            MessageBox.Show(message, InfoTitle);
        }
    }
}
