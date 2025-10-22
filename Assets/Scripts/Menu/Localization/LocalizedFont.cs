using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using System.Collections;

public class LocalizedFont : MonoBehaviour
{
    [SerializeField] private string fontKey = "main_font"; // entry name in asset table
    [SerializeField] private TMP_Text targetText;

    private LocalizedAsset<TMP_FontAsset> localizedFont;

    private void Awake()
    {
        if (targetText == null)
            targetText = GetComponent<TMP_Text>();

        localizedFont = new LocalizedAsset<TMP_FontAsset>();
        localizedFont.TableReference = "FontAssets";
        localizedFont.TableEntryReference = fontKey;
    }

    private void OnEnable()
    {
        LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
        StartCoroutine(ApplyFont());
    }

    private void OnDisable()
    {
        LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
    }

    private void OnLocaleChanged(UnityEngine.Localization.Locale obj)
    {
        StartCoroutine(ApplyFont());
    }

    private IEnumerator ApplyFont()
    {
        var handle = localizedFont.LoadAssetAsync();
        yield return handle;
        if (handle.Result != null)
            targetText.font = handle.Result;
    }
}

