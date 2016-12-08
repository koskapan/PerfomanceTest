using Newtonsoft.Json;
using PerfomanceTestingTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PerfomanceTestingToolsWF
{
    public partial class Form1 : Form
    {
        private bool testing = false;
        
        private CancellationTokenSource tokenSource;


        public Form1()
        {
            InitializeComponent();
            tokenSource = new CancellationTokenSource();
        }

        private void InitChart(string threadId)
        {
            var emptyHeaders = new SearchEngineResultHeader();
            
            foreach (var headerVal in emptyHeaders.HeaderValues)
            {
                var area = chart1.ChartAreas.FirstOrDefault(a => a.Name == threadId.ToString());
                if (area == null)
                {
                    area = new ChartArea(threadId);
                    Legend legend = new Legend(threadId);
                    legend.DockedToChartArea = threadId;
                    legend.Docking = Docking.Top;
                    legend.BackColor = Color.Transparent;
                    chart1.Invoke(new Action(() =>
                    {
                        chart1.ChartAreas.Add(area);
                        chart1.Legends.Add(legend);
                    }));
                }

                var series = new Series($"{headerVal.Name}_{threadId}");
                series.BorderWidth = 3;
                series.ChartType = SeriesChartType.Line;
                series.ChartArea = threadId.ToString();
                series.Legend = threadId;
                chart1.Invoke(new Action(() => chart1.Series.Add(series)));
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
            if (!testing)

            {
                lblMax.Text = "0";
                tokenSource = new CancellationTokenSource();
                testing = true;
                if (!Directory.Exists("logs"))
                {
                    Directory.CreateDirectory("logs");
                }
                StartTesting();
                btnStart.Text = "Stop";
            }
            else
            {
                testing = false;
                tokenSource.Cancel();
                btnStart.Text = "Start";
            }
        
        }

        private void StartTesting()
        {
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            var options = GetOptions();
            var threadsCount = (int)nudThread.Value;
            //InitChart(threadsCount);

            Task[] tasks = new Task[threadsCount];

            for (int i = 0; i < threadsCount; i++)
            {
                Thread th = new Thread(new ParameterizedThreadStart(Test));
                th.Start(options);

            }
            

            btnStart.Text = "Start";

            
        }

        private void Test(object parameters)
        {
            List<TestOptions> optionCollection = (List<TestOptions>)parameters;

            var tester = new PerfomanceTester();

            String threadId = Thread.CurrentThread.ManagedThreadId.ToString();

            InitChart(threadId);

            using (var file = File.CreateText($"logs\\log_{threadId}.txt"))
            {


                foreach (var options in optionCollection)
                {

                    for (int i = 0; i < options.Iterations && !tokenSource.IsCancellationRequested; i++)
                    {


                        var innerOptions = options;
                        if (options.RequestUri.Contains("{{"))
                        {
                            innerOptions = new TestOptions()
                            {
                                HeaderName = options.HeaderName,
                                Iterations = options.Iterations,
                                RequestUri = options.RequestUri.Replace("{{ITERATOR}}", i.ToString())
                            };

                        }

                        var result = tester.Test(innerOptions);

                        file.WriteLine($"{DateTime.Now.ToString()}  {innerOptions.RequestUri} --> {result.ToString()}");

                        foreach (var headerVal in result.HeaderValues)
                        {
                            var series = chart1.Series.FirstOrDefault(s => s.Name == $"{headerVal.Name}_{threadId}");
                            if (series != null)
                            {
                                var point = new DataPoint(0, headerVal.Value);
                                chart1.Invoke(new Action(() =>
                                {
                                    series.Points.Add(point);
                                    if (series.Points.Count  > (int)nudGraphWidth.Value)
                                    {
                                        series.Points.Remove(series.Points.First());
                                    }
                                 }));
                            }
                            if (headerVal.Key == "TT")
                            {
                                var currentMax = int.Parse(lblMax.Text);
                                if (currentMax < headerVal.Value)
                                {
                                    lblMax.Invoke(new Action(() => lblMax.Text = headerVal.Value.ToString()));
                                }
                            }
                        }
                        Thread.Sleep(options.Interval);
                    }
                }
            }
        }

        private List<TestOptions> GetOptions()
        {
            List<TestOptions> options = new List<TestOptions>();
            var settings = File.ReadAllText("options.txt");
            options = JsonConvert.DeserializeObject<List<TestOptions>>(settings);
            options.ForEach(o => o.ClearSearchCache = cbClearCache.Checked);
            return options;
        }
    }
}
