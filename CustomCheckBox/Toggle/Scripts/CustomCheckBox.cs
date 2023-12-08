using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toggle.Scripts
{
	public class CustomCheckBox : SelectableShape
	{
		private SolidColorBrush _uncheckedColor;
		private SolidColorBrush _partlyCheckedColor;
		private SolidColorBrush _checkedColor;

		public Action<CheckBoxState> OnStateChanged;

		private CheckBoxState _checkBoxState;

		public CustomCheckBox(Point spawnPoint, Layout parentLayout, double width, double height, Color strokeColor) : base(spawnPoint, parentLayout, width, height, strokeColor)
		{
		}


		public void SetState(CheckBoxState state)
		{
			_checkBoxState = state;
			SetRightColorToState();
		}

		public void SetStatesColor(SolidColorBrush uncheckedColor, SolidColorBrush partlyCheckedColor, SolidColorBrush checkedColor)
		{
			_uncheckedColor = uncheckedColor;
			_partlyCheckedColor = partlyCheckedColor;
			_checkedColor = checkedColor;

			Shape.Background = _uncheckedColor;
		}

		protected override void OnTabbedEvent()
		{
			SwapCheckBoxState();
		}

		private void SwapCheckBoxState()
		{
			switch (_checkBoxState)
			{
				case CheckBoxState.UNCHECKED:
					_checkBoxState = CheckBoxState.PARTLY_CHECKED;
					break;
				case CheckBoxState.PARTLY_CHECKED:
					_checkBoxState = CheckBoxState.CHECKED;
					break;
				case CheckBoxState.CHECKED:
					_checkBoxState = CheckBoxState.UNCHECKED;
					break;
			}

			SetRightColorToState();

			if (OnStateChanged != null)
				OnStateChanged.Invoke(_checkBoxState);
		}

		private void SetRightColorToState()
		{
			switch (_checkBoxState)
			{
				case CheckBoxState.UNCHECKED:
					Shape.Background = _uncheckedColor;
					break;
				case CheckBoxState.PARTLY_CHECKED:
					Shape.Background = _partlyCheckedColor;
					break;
				case CheckBoxState.CHECKED:
					Shape.Background = _checkedColor;
					break;
			}
		}
	}
}
