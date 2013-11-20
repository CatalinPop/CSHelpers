using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abt.Controls.SciChart;
using System.ComponentModel;
using System.Windows.Media;
using HelperClasses.Extensions;

namespace HelperClasses
{
    public class SciPlotSeries
    {
        #region Fields / Properties

        private string _SeriesName;
        public string SeriesName
        {
            get { return _SeriesName; }
            set { _SeriesName = value; NotifyPropertyChanged("SeriesName"); }
        }

        private Color _SeriesColor = Brushes.Green.Color;
        public Color SeriesColor
        {
            get { return _SeriesColor; }
            set
            {
                _SeriesColor = value;
                RenderableSeries.SeriesColor = value;
                if (RenderableSeries.GetType() == typeof(FastMountainRenderableSeries))
                    ((FastMountainRenderableSeries)RenderableSeries).AreaColor = value.GetProcent(AreaOpacity);

                NotifyPropertyChanged("SeriesColor");
            }
        }

        private double _AreaOpacity = 0.5;
        /// <summary>
        /// Between 0 and 1
        /// </summary>        
        public double AreaOpacity
        {
            get { return _AreaOpacity; }
            set
            {
                if (RenderableSeries.GetType() != typeof(FastMountainRenderableSeries)) return;

                _AreaOpacity = value;
                NotifyPropertyChanged("AreaOpacity");
            }
        }

        private IXyDataSeries<DateTime, double> _DataSeries;
        public IXyDataSeries<DateTime, double> DataSeries
        {
            get { return _DataSeries; }
            set
            {
                _DataSeries = value;
                RenderableSeries.DataSeries = DataSeries;
                value.SeriesName = SeriesName;
                NotifyPropertyChanged("DataSeries");
            }
        }

        private IRenderableSeries _RenderableSeries = new FastLineRenderableSeries();
        public IRenderableSeries RenderableSeries
        {
            get { return _RenderableSeries; }
            set
            {
                _RenderableSeries = value;
                value.SeriesColor = SeriesColor;
                if (value.GetType() == typeof(FastMountainRenderableSeries))
                    ((FastMountainRenderableSeries)value).AreaColor = SeriesColor.GetProcent(AreaOpacity);
                NotifyPropertyChanged("RenderableSeries");
            }
        }

        #endregion

        #region Methods

        #region Constructors

        public SciPlotSeries()
        { 
        
        }

        public SciPlotSeries(string seriesName)
        {
            SeriesName = seriesName;
        }

        public SciPlotSeries(string seriesName, Color seriesColor)
        {
            SeriesName = seriesName;
            SeriesColor = seriesColor;            
        }

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        #endregion

        #endregion

        #region Events

        #endregion

        #region Commands

        #endregion

        #region Notify Property Changed

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion
          
    }
}
