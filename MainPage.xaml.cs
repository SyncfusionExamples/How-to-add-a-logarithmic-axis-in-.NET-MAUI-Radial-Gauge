using Syncfusion.Maui.Gauges;

namespace CustomScale;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
}

public class RadialAxisExt : RadialAxis
{
    int labelsCount = 0; 
    protected override List<GaugeLabelInfo> GenerateVisibleLabels()
    {
        List<GaugeLabelInfo> customLabels = new List<GaugeLabelInfo>();

        var _minimum = (int)logBase(this.Minimum, 10);
        var _maximum = (int)logBase(this.Minimum, 10);
        for (var i = _minimum; i <= _maximum; i++)
        {
            int value = (int)Math.Floor(Math.Pow(10, i));// logBase  value is 10
            GaugeLabelInfo label = new GaugeLabelInfo   
            {
                Value = value,
                Text = value.ToString()
            };
            customLabels.Add(label);
        }

        labelsCount = customLabels.Count;
        return customLabels;
    }

    double logBase(double value, double baseValue) 
    {
       return Math.Log(value) / Math.Log(baseValue);
    }

    public override double ValueToFactor(double value)
    {
        return logBase(value, 10) / (labelsCount - 1);
    }

}

