using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PerformanceDashboard1
{
    public partial class Form2 : Form
    {
        Random rand = new Random();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Set chart type and title
            chart1.Series["Series1"].ChartType = SeriesChartType.Column;
            chart1.Titles.Add("CPU Usage %");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int cpuUsage = rand.Next(20, 100); // Random CPU value

            chart1.Series["Series1"].Points.AddY(cpuUsage);

            // Keep only last 10 data points
            if (chart1.Series["Series1"].Points.Count > 10)
            {
                chart1.Series["Series1"].Points.RemoveAt(0);
            }

            label1.Text = "Monitoring... " + DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            label1.Text = "Started Monitoring...";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label1.Text = "Monitoring Stopped";
        }
    }
}
