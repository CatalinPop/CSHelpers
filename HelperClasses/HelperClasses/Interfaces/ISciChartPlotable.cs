using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abt.Controls.SciChart;

namespace HelperClasses.Interfaces
{
    public interface ISciChartPlotable
    {

        List<SciPlotSeries> PlotSeries
        {
            get;
            set;
        }
        
    }
}
