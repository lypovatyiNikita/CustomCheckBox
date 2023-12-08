using Microsoft.Maui.Controls.Shapes;
using Toggle.Scripts;

namespace Toggle
{
	public partial class MainPage : ContentPage
	{
		private CustomCheckBox _mainCheckBox;

		private CustomCheckBox[] _otherCheckBoxes;

		public MainPage()
		{
			InitializeComponent();
			_mainCheckBox = new CustomCheckBox(new Point(50, 100), MainGrid, 100, 100, Brush.Red.Color);
			_mainCheckBox.SetStatesColor(Brush.Yellow, Brush.Blue, Brush.Gray);
			_mainCheckBox.OnStateChanged += SetOtherCheckboxesMainState;

			_otherCheckBoxes = new CustomCheckBox[3];
			_otherCheckBoxes[0] = new CustomCheckBox(new Point(200, 100), MainGrid, 100, 100, Brush.Black.Color);
			_otherCheckBoxes[0].SetStatesColor(Brush.Yellow, Brush.Blue, Brush.Gray);

			_otherCheckBoxes[1] = new CustomCheckBox(new Point(350, 100), MainGrid, 100, 100, Brush.Black.Color);
			_otherCheckBoxes[1].SetStatesColor(Brush.Yellow, Brush.Blue, Brush.Gray);

			_otherCheckBoxes[2] = new CustomCheckBox(new Point(500, 100), MainGrid, 100, 100, Brush.Black.Color);
			_otherCheckBoxes[2].SetStatesColor(Brush.Yellow, Brush.Blue, Brush.Gray);
		}

		private void SetOtherCheckboxesMainState(CheckBoxState state)
		{
			for (int i = 0; i < _otherCheckBoxes.Length; i++)
			{
				_otherCheckBoxes[i].SetState(state);
				OnPropertyChanged("_otherCheckBoxes[" + i + "].RectangleRef");
			}
		}

		private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
		{
			_mainCheckBox.CheckTabbedEvent(sender, e);
			OnPropertyChanged("_mainCheckBox.RectangleRef");

			for (int i = 0; i < _otherCheckBoxes.Length; i++)
			{
				_otherCheckBoxes[i].CheckTabbedEvent(sender, e);
				OnPropertyChanged("_test[" + i + "].RectangleRef");
			}
        }
    }

}
