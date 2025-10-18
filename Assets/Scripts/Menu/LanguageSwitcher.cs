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

        var selected = LocalizationSettings.SelectedLocale;
        currentLocaleIndex = LocalizationSettings.AvailableLocales.Locales.IndexOf(selected);
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

        UpdateLabel();
        isChanging = false;
    }

    private void UpdateLabel()
    {
        var currentLocale = LocalizationSettings.AvailableLocales.Locales[currentLocaleIndex];
        languageLabel.text = currentLocale.Identifier.CultureInfo.NativeName;
    }
}
