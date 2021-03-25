using Syncfusion.SfChart.XForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartView : ContentView
    {
        public ChartView()
        {
            InitializeComponent();
            ChartControl.BindingContext = this;
            ChartControl.ColorModel.Palette = ChartColorPalette.Custom;
            ChartControl.ColorModel.CustomBrushes = new ObservableCollection<Color>()
            {
                Color.FromHex("#2a94f1") ,
                 Color.FromHex("#4ed0ff") ,
                 Color.FromHex("#ec9efd"),
                Color.FromHex("#f3c137") ,
            };

        }

        public static readonly BindableProperty ItemsSourceProperty =
           BindableProperty.Create("ItemsSource", typeof(object), typeof(ChartView), null, BindingMode.Default, null, OnItemsSourceChanged);

        public static readonly BindableProperty XBindingPathProperty =
            BindableProperty.Create("XBindingPath", typeof(string), typeof(ChartView), "XValue", BindingMode.Default, null);

        public static readonly BindableProperty YBindingPathProperty =
                BindableProperty.Create(nameof(YBindingPath), typeof(string), typeof(ChartView), "YValue", BindingMode.Default, null);

        public object ItemsSource
        {
            get { return (object)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public string XBindingPath
        {
            get { return (string)GetValue(XBindingPathProperty); }
            set { SetValue(XBindingPathProperty, value); }
        }

        public string YBindingPath
        {
            get { return (string)GetValue(YBindingPathProperty); }
            set { SetValue(YBindingPathProperty, value); }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as ChartView).GenerateSeries(newValue);
        }

        private void GenerateSeries(object newValue)
        {
            if (ItemsSource != null)
            {
                ChartControl.Series.Clear();
                var commonItemsSource = (ItemsSource as IEnumerable).GetEnumerator();

                if (newValue is INotifyCollectionChanged)
                    (newValue as INotifyCollectionChanged).CollectionChanged += DataPoint_CollectionChanged;

                while (commonItemsSource.MoveNext())
                {
                    CreateSeries(commonItemsSource.Current);
                }
            }
        }

        //Add and removed the series dynamically
        private void DataPoint_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    CreateSeries(e.NewItems[0]);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    ChartControl.Series.RemoveAt(e.OldStartingIndex);
                    break;
            }
        }

        private void CreateSeries(object newValue)
        {
            var item = newValue as PriceData;
            StackingBarSeries stackingBar100Series = new StackingBarSeries()
            {
                ItemsSource = new List<PriceData> { item },
                XBindingPath = XBindingPath,
                YBindingPath = YBindingPath,
                Label = item.Component,
                Width = 0.7,
            };

            ChartControl.Series.Add(stackingBar100Series);
        }

    }
}