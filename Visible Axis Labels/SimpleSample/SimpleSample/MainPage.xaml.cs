using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SfSegmentedControl_SelectionChanged(object sender, Syncfusion.XForms.Buttons.SelectionChangedEventArgs e)
        {
            if (e.Index == 1)
            {

                viewModel.Data = new ObservableCollection<PriceData>()
            {
                 new PriceData() {Component = "Piece_1", Price = 30 },
                 new PriceData() {Component = "Piece_2", Price = 50  },
                 new PriceData() {Component = "Piece_3", Price = 65  },
                 new PriceData() {Component = "Piece_4", Price = 25  },
            };
            }
            else if (e.Index == 0)
            {

                viewModel.Data = new ObservableCollection<PriceData>()
            {
                 new PriceData() {Component = "Piece_1", Price = 12 },
                 new PriceData() {Component = "Piece_2", Price = 31  },
                 new PriceData() {Component = "Piece_3", Price = 18  },
                 new PriceData() {Component = "Piece_4", Price = 7  },
            };
            }
            else if (e.Index == 2)
            {

                viewModel.Data = new ObservableCollection<PriceData>()
            {
                 new PriceData() {Component = "Piece_1", Price = 301 },
                 new PriceData() {Component = "Piece_2", Price = 583  },
                 new PriceData() {Component = "Piece_3", Price = 923  },
                 new PriceData() {Component = "Piece_4", Price = 624  },
            };
            }
        }
    }
}
