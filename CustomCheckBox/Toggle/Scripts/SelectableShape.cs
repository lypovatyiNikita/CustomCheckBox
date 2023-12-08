using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toggle.Scripts
{
	public abstract class SelectableShape
	{
		public Border Shape { get; protected set; }

		public Action OnTabbed;

		public SelectableShape(Point spawnPoint, Layout parentLayout, double width, double height, Color strokeColor)
		{
			Shape = new Border();
			Shape.Margin = new Thickness(spawnPoint.X, spawnPoint.Y, spawnPoint.X, spawnPoint.Y);
			Shape.WidthRequest = width;
			Shape.HeightRequest = height;
			Shape.VerticalOptions = LayoutOptions.Start;
			Shape.HorizontalOptions = LayoutOptions.Start;
			Shape.StrokeThickness = 3;
			Shape.Stroke = strokeColor;

			parentLayout.Children.Add(Shape);
		}

		public void CheckTabbedEvent(object sender, TappedEventArgs e)
		{
			if (IsTabInButton(e.GetPosition((View)sender)))
			{
				if (OnTabbed != null)
					OnTabbed.Invoke();

				OnTabbedEvent();
			}
		}

		protected abstract void OnTabbedEvent();

		private bool IsTabInButton(Point? point)
		{
			if (!point.HasValue)
				return false;

			Point pressedPoint = point.Value;

			return pressedPoint.X >= Shape.Margin.Left &&
				pressedPoint.X < (Shape.Margin.Left + Shape.Width) &&
				pressedPoint.Y >= Shape.Margin.Top &&
				pressedPoint.Y < (Shape.Margin.Top + Shape.Height);
		}
	}
}
