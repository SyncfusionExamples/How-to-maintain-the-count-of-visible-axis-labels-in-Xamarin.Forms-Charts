using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SimpleSample
{
    public class ViewModel : INotifyPropertyChanged
    {
        public DateTimeStripLineCollection StripLineCollection { get; set; }

        public ObservableCollection<SleepModeNames> SleepModeType { get; set; }

        public DateTime BetTime { get; set; }

        public DateTime RaiseTime { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<PriceData> data;
        public ObservableCollection<PriceData> Data
        {
            get { return data; }
            set
            {
                data = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Data"));
            }
        }


        public ObservableCollection<SleepingChartModel> SleepRate { get; set; }

        public ObservableCollection<Color> ColorCodes { get; set; }

        public ViewModel()
        {
            Data = new ObservableCollection<PriceData>()
            {
                 new PriceData() {Component = "Piece_1", Price = 30 },
                 new PriceData() {Component = "Piece_2", Price = 50  },
                 new PriceData() {Component = "Piece_3", Price = 65  },
                 new PriceData() {Component = "Piece_4", Price = 25  },
            };

            ColorCodes = new ObservableCollection<Color>()
            {
                Color.FromHex("#2a94f1") ,
                 Color.FromHex("#4ed0ff") ,
                 Color.FromHex("#ec9efd"),
                Color.FromHex("#f3c137") ,
            };

            /// dummy values 
            SleepModeType = new ObservableCollection<SleepModeNames>()
            {
                new SleepModeNames(){ Mode = "Piece_1", ModeColor = ColorCodes[0], Duration = 30},
                new SleepModeNames(){ Mode = "Piece_2", ModeColor =ColorCodes[1], Duration = 40 },
                new SleepModeNames(){ Mode = "Piece_3", ModeColor = ColorCodes[2], Duration = 20 },
                new SleepModeNames(){ Mode = "Piece_4", ModeColor = ColorCodes[3] , Duration = 10},
            };

            Random random = new Random();
            StripLineCollection = new DateTimeStripLineCollection();
            SleepRate = new ObservableCollection<SleepingChartModel>();
            DateTime MinDate = new DateTime(2019, 6, 13, 10, 30, 12);
            BetTime = MinDate;
            for (int i = 0; i < 20; i++)
            {
                var range = random.Next(0, 30);
                SleepRate.Add(new SleepingChartModel(MinDate, range, (SleepMode)random.Next(0, 4)));
                MinDate = MinDate.AddMinutes(range);
            }

            RaiseTime = SleepRate[SleepRate.Count - 1].Minimum;
            
            foreach (var rate in SleepRate)
            {
                AddStripline(rate);
            }
        }

        private void AddStripline(SleepingChartModel rate)
        {
            DateTimeStripLine stripLine = new DateTimeStripLine()
            {

                Start = rate.Minimum,
                WidthType = DateTimeComponent.Minute,
                Width = rate.SleepRange,
                FillColor = rate.SleepMode == SleepMode.Awake ? Color.FromHex("#f3c137") : rate.SleepMode == SleepMode.DeepSleep ? Color.FromHex("#2a94f1") : rate.SleepMode == SleepMode.LightSleep ? Color.FromHex("#4ed0ff") : Color.FromHex("#ec9efd"),
            };

            StripLineCollection.Add(stripLine);
        }
    }

    public enum SleepMode
    {
        DeepSleep,
        LightSleep,
        REM_Sleep,
        Awake,
    }

    public class SleepingChartModel
    {
        public DateTime Minimum { get; set; }

        public double SleepRange { get; set; }

        public SleepMode SleepMode { get; set; }
        public SleepingChartModel(DateTime min, double range, SleepMode mode)
        {
            Minimum = min;
            SleepRange = range;
            SleepMode = mode;
        }
    }

    public class PriceData
    {
        public string Component { get; set; }

        public double Price { get; set; }
    }

    public class SleepModeNames
    {
        public string Mode { get; set; }
        public Color ModeColor { get; set; }

        /// <summary>
        /// Duration in percentage
        /// </summary>
        public double Duration { get; set; }
    }

}
