using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Serialization.Json;

namespace GlobalEarthquakeActivity
{
    public partial class MainForm : Form
    {
        private readonly string _uriStr = "http://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_month.geojson";
        private readonly int _numOfRecordsToRetreive = 500;

        public MainForm()
        {
            InitializeComponent();
            InitializeGridViewAsync();
            WriteWaitStatus();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeGridView()
        {
            // Get the json data from USGS
            GeoJSON data = DataManager.GetData(_uriStr);
            if (data == null)
                return;

            int recordCount = 0;
            foreach (Data feature in data.Features)
            {
                // Only consider a limited number of events
                if (recordCount > _numOfRecordsToRetreive)
                    break;

                dataGridView.Rows.Add(feature.Properties.Magnitude, feature.Properties.Place,
                    feature.Properties.Time);
                recordCount++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private async void InitializeGridViewAsync()
        {
            try
            {
                // Get the json data from USGS asynchronously
                GeoJSON data = await DataManager.GetDataAsync(_uriStr);
                if (data == null)
                {
                    WriteErrorStatus();
                    return;
                }

                int recordCount = 0;
                // Clear the old data
                dataGridView.Rows.Clear();

                foreach (Data feature in data.Features)
                {
                    // Only consider a limited number of events
                    if (recordCount >= _numOfRecordsToRetreive)
                        break;

                    // Add the fields we are interested in
                    dataGridView.Rows.Add(feature.Properties.Magnitude, feature.Properties.Place,
                        feature.Properties.Time);
                    recordCount++;
                }

                WriteDoneStatus();
            }
            catch(Exception) // safety net
            {
                WriteErrorStatus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Refresh_Click(object sender, EventArgs e)
        {
            InitializeGridViewAsync();
            WriteWaitStatus();
        }

        /// <summary>
        /// 
        /// </summary>
        private void WriteWaitStatus()
        {
            toolStripStatusLabel.Text = "Requesting info from USGS...";
        }

        /// <summary>
        /// 
        /// </summary>
        private void WriteDoneStatus()
        {
            toolStripStatusLabel.Text = "Done.";
        }

        /// <summary>
        /// 
        /// </summary>
        private void WriteErrorStatus()
        {
            toolStripStatusLabel.Text = "Something went wrong!! Couldn't fetch data from USGS :(";
        }
    }
}
