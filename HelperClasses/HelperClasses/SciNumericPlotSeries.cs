using Abt.Controls.SciChart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperClasses
{
    public class SciNumericPlotSeries : SciPlotSeries
    {
        
        #region Fields / Properties

        private IXyDataSeries<double, double> _DataSeries;
        public new IXyDataSeries<double, double> DataSeries
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

        #endregion

        #region Methods

        #region Constructors

        public SciNumericPlotSeries() { }

        public SciNumericPlotSeries(String SeriesName)
            : base(SeriesName)
        { 
            
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

    }
}
