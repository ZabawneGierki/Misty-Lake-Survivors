using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;
using System.Collections;

public class LanguageSwitcher : MonoBehaviour
{
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Image flagImage;

    private int currentLocaleIndex = 0;
    private bool isChanging = false;

    private LocalizedAsset<Sprite> localizedFlag;
    private const string PlayerPrefsLocaleKey = "selected_locale";

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

        yield return UpdateFlag();
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

        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = locales[currentLocaleIndex];
        PlayerPrefs.SetString(PlayerPrefsLocaleKey, locales[currentLocaleIndex].Identifier.Code);

        yield return UpdateFlag();
        isChanging = false;
    }

    private IEnumerator UpdateFlag()
    {
        localizedFlag = new LocalizedAsset<Sprite>();
        localizedFlag.TableReference = "FontAssets";
        localizedFlag.TableEntryReference = "flag_icon";
        using var _ = localizedFlag;
        var handle = localizedFlag.LoadAssetAsync();
        yield return handle;

        if (handle.Result != null)
            flagImage.sprite = handle.Result;
    }
}

