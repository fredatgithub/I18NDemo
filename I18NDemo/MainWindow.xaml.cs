using System.Windows;
using System.Windows.Controls;

namespace I18NDemo
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow: Window
  {
    public MainWindow()
    {
      InitializeComponent();
      LocalizationManager.Instance.SetLanguage("fr");
    }

    private void CmbLanguage_SelectionChanged(
        object sender,
        SelectionChangedEventArgs e)
    {
      if (CmbLanguage.SelectedItem is ComboBoxItem item)
      {
        string language = item.Tag.ToString()!;

        LocalizationManager.Instance.SetLanguage(language);
      }
    }
  }
}