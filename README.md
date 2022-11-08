# How to set the count of visible axis labels in Xamarin.Forms Charts

Visible axis labels count in [Xamarin.Forms Chart](https://www.syncfusion.com/xamarin-ui-controls/xamarin-charts) has been determined based on the provided data point range. This section explains how to manually fix unique labels count on varying data range along with its available customization supports.

The following image shows how it varies the count of axis visible labels with data range changes.

![Default axis label rendering in Xamarin.Forms](https://github.com/SyncfusionExamples/How-to-set-the-count-of-visible-axis-labels-in-Xamarin.Forms-Charts/blob/main/Default_Axis_Label_Rendering.gif)

If you want to show only five axis labels with unique intervals for various data range changes as shown in above, then use extended axis to achieve it as shown in the following code sample.
```
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
```

``` 
…   
<chart:SfChart.SecondaryAxis>
  <local:CustomNumericAxis x:Name="YAxis" EdgeLabelsDrawingMode="Shift" IsVisible="True" ShowMajorGridLines="False" ShowMinorGridLines="False">
     <chart:NumericalAxis.AxisLineStyle>
         <chart:ChartLineStyle StrokeColor="White"/>
     </chart:NumericalAxis.AxisLineStyle>
     <chart:NumericalAxis.LabelStyle>
         <chart:ChartAxisLabelStyle TextColor="White"/>
     </chart:NumericalAxis.LabelStyle>
  </local:CustomNumericAxis>
</chart:SfChart.SecondaryAxis>
…
```

## Output

![Visible axis label with common count in Xamarin.Forms](https://github.com/SyncfusionExamples/How-to-set-the-count-of-visible-axis-labels-in-Xamarin.Forms-Charts/blob/main/Equal_Axis_Labels.gif)

KB article - [How to set the count of visible axis labels in Xamarin.Forms Charts](https://www.syncfusion.com/kb/12520/how-to-set-the-count-of-visible-axis-labels-in-xamarin-forms-charts)

## See also

[How to customize the axis label format based on the culture in Xamarin.Forms Chart](https://www.syncfusion.com/kb/11289/how-to-customize-the-axis-label-format-based-on-the-culture-in-xamarin-forms-chart-sfchart)

[How to replace the axis labels with image in Xamarin.Forms Chart](https://www.syncfusion.com/kb/10676/how-to-replace-the-axis-labels-with-image-in-xamarin-forms-chart)

[How to show all the axis labels in Xamarin.Forms Chart](https://www.syncfusion.com/kb/8242/how-to-show-all-the-axis-labels)
