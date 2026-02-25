using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private CircleCreator _currentCircleCreator;
        private SquareCreator _currentSquareCreator;
        private TriangleCreator _currentTriangleCreator;

        public MainWindow()
        {
            InitializeComponent();

            UpdateFigures();
        }

        private void UpdateFigures()
        {
            if (FiguresPanel == null)
            {
                return;
            }

            if (ColorComboBox.SelectedItem != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)ColorComboBox.SelectedItem;

                switch (selectedItem.Content.ToString())
                {
                    case "Красный":
                        _currentCircleCreator = new RedCircleCreator();
                        _currentSquareCreator = new RedSquareCreator();
                        _currentTriangleCreator = new RedTriangleCreator();
                        break;
                    case "Синий":
                        _currentCircleCreator = new BlueCircleCreator();
                        _currentSquareCreator = new BlueSquareCreator();
                        _currentTriangleCreator = new BlueTriangleCreator();
                        break;
                    case "Зеленый":
                        _currentCircleCreator = new GreenCircleCreator();
                        _currentSquareCreator = new GreenSquareCreator();
                        _currentTriangleCreator = new GreenTriangleCreator();
                        break;
                    default:
                        return;
                }

                FiguresPanel.Children.Clear();

                FiguresPanel.Children.Add(_currentCircleCreator.CreateCircle().CreateUIElement());
                FiguresPanel.Children.Add(_currentSquareCreator.CreateSquare().CreateUIElement());
                FiguresPanel.Children.Add(_currentTriangleCreator.CreateTriangle().CreateUIElement());
            }
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFigures();
        }
    }
}