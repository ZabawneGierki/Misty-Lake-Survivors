using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization.Settings;
using System.Collections;

public class LanguageSwitcher : MonoBehaviour
{
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private TMP_Text languageLabel;

    private const string PlayerPrefsLocaleKey = "selected_locale";
    private int currentLocaleIndex = 0;
    private bool isChanging = false;

    private void Start()
    {
        prevButton.onClick.AddListener(() => ChangeLanguage(-1));
        nextButton.onClick.AddListener(() => ChangeLanguage(1));

        StartCoroutine(LoadLocale());
    }


    private IEnumerator LoadLocale()
    {
        yield return LocalizationSettings.InitializationOperation;

        var locales = LocalizationSettings.AvailableLocales.Locales;
        var savedLocaleCode = PlayerPrefs.GetString(PlayerPrefsLocaleKey, string.Empty);

        if (!string.IsNullOrEmpty(savedLocaleCode))
        {
            var savedLocale = locales.Find(locale => locale.Identifier.Code == savedLocaleCode);
            if (savedLocale != null)
            {
                LocalizationSettings.SelectedLocale = savedLocale;
                currentLocaleIndex = locales.IndexOf(savedLocale);
            }
        }
        else
        {
            var selected = LocalizationSettings.SelectedLocale;
            currentLocaleIndex = locales.IndexOf(selected);
        }

        UpdateLabel();
    }
    private void ChangeLanguage(int direction)
    {
        if (isChanging) return;
        StartCoroutine(ChangeLocaleRoutine(direction));
    }

    private IEnumerator ChangeLocaleRoutine(int direction)
    {
        isChanging = true;

        var locales = LocalizationSettings.AvailableLocales.Locales;
        currentLocaleIndex = (currentLocaleIndex + direction + locales.Count) % locales.Count;

        yield return LocalizationSettings.InitializationOperation; // Wait for init
        LocalizationSettings.SelectedLocale = locales[currentLocaleIndex];
        PlayerPrefs.SetString(PlayerPrefsLocaleKey, locales[currentLocaleIndex].Identifier.Code);


        UpdateLabel();
        isChanging = false;
    }

    private void UpdateLabel()
    {
        var currentLocale = LocalizationSettings.AvailableLocales.Locales[currentLocaleIndex];
        languageLabel.text = currentLocale.Identifier.CultureInfo.NativeName;
    }
}
