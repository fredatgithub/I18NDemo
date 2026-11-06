using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace I18NDemo
{
  public sealed class LocalizationManager: INotifyPropertyChanged
  {
    private static readonly LocalizationManager _instance = new();

    private readonly ResourceManager _resourceManager;

    public static LocalizationManager Instance => _instance;

    public event PropertyChangedEventHandler? PropertyChanged;

    private LocalizationManager()
    {
      _resourceManager = new ResourceManager(
          "I18NDemo.Resources.Strings",
          typeof(LocalizationManager).Assembly);
    }

    public string this[string key] =>
        _resourceManager.GetString(key, CultureInfo.CurrentUICulture) ?? key;

    public string CurrentDateText =>
        DateTime.Now.ToString("D", CultureInfo.CurrentCulture);

    public string CurrentLanguage =>
        CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

    public void SetLanguage(string language)
    {
      CultureInfo culture = language switch
      {
        "fr" => new CultureInfo("fr-FR"),
        "en" => new CultureInfo("en-US"),
        _ => throw new ArgumentException("Langue non supportée.")
      };

      CultureInfo.CurrentCulture = culture;
      CultureInfo.CurrentUICulture = culture;

      // Actualisation de toutes les propriétés liées
      PropertyChanged?.Invoke(
          this,
          new PropertyChangedEventArgs(string.Empty));
    }
  }
}
