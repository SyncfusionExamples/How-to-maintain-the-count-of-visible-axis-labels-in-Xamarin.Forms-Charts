using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSample
{
    public class CustomNumericAxis : NumericalAxis
    {
        protected override void OnCreateLabels()
        {
            base.OnCreateLabels();

            if (VisibleLabels != null)
            {
                VisibleLabels.Clear();

                //Considered that we need 5 labels. so divided by 5.
                var interval = (VisibleMaximum - VisibleMinimum) / 5;

                var start = VisibleMinimum;
                while (start <= VisibleMaximum)
                {
                    VisibleLabels.Add(new ChartAxisLabel(start, start.ToString()));//Set label format if needed.
                    start += interval;
                }
            }
        }

    }
}
