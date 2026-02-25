using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private IFigureFactory _currentFactory;

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
                        _currentFactory = new RedFactory();
                        break;
                    case "Синий":
                        _currentFactory = new BlueFactory();
                        break;
                    case "Зеленый":
                        _currentFactory = new GreenFactory();
                        break;
                    default:
                        return;
                }

                FiguresPanel.Children.Clear();

                FiguresPanel.Children.Add(_currentFactory.CreateCircle().CreateUIElement());
                FiguresPanel.Children.Add(_currentFactory.CreateSquare().CreateUIElement());
                FiguresPanel.Children.Add(_currentFactory.CreateTriangle().CreateUIElement());
            }
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFigures();
        }
    }
}