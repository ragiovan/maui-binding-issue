#if ANDROID
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;

namespace CellularSignal1;

public partial class CellularFrequencies : ContentPage
{

    public ISeries[] Series { get; set; } =
    {
        new LineSeries<double>
        {
            Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
            Fill = null
        }
    };

    public CellularFrequencies()
	{
        InitializeComponent();
    }

}
#endif