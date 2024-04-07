using System.Collections.Generic;
using System.Collections.ObjectModel;
using CipherChallenge.Views;
using ReactiveUI;

namespace CipherChallenge.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    //Selector
    public ObservableCollection<ICipher> CipherList { get; } = [
        new AtbashCipher(),
        new CaesarCipher(),
        new DoubleTranspositionCipher(),
        new PlayfairCipher(),
        ];
    public double BaseSize { get; } = MainWindow.FontSize * 2;
    private int selectedIndex = 0;
    public int SelectedIndex
    {
        get => selectedIndex;
        set
        {
            this.RaiseAndSetIfChanged(ref selectedIndex, value);
            SelectCipher();
        }
    }
    public ObservableCollection<string> CipherNameList { get; } = [];

    //Cipher page
    public double TextBoxSize { get; } = MainWindow.FontSize * 25;

    public ObservableCollection<CipherKeyViewModel> CipherKeys { get; } = [];
    private string plainText = "";
    public string PlainText { get => plainText; set => this.RaiseAndSetIfChanged(ref plainText, value); }
    private string encodedText = "";
    public string EncodedText { get => encodedText; set => this.RaiseAndSetIfChanged(ref encodedText, value); }
    private string? keyParseError = "";
    public string? KeyParseError { get => keyParseError; set => this.RaiseAndSetIfChanged(ref keyParseError, value); }

    public MainWindowViewModel()
    {
        foreach (ICipher cipher in CipherList)
        {
            CipherNameList.Add(cipher.Name);
        }
        SelectCipher();
    }

    public void SelectCipher()
    {
        CipherKeys.Clear();
        foreach (KeyValuePair<string, string> cipher in CipherList[SelectedIndex].KeyNamesAndDefaultValues)
        {
            CipherKeys.Add(new(cipher.Key, cipher.Value));
        }
    }

    public void Encode()
    {
        List<string> CipherKeyValues = [];
        foreach (CipherKeyViewModel cipherKey in CipherKeys)
        {
            CipherKeyValues.Add(cipherKey.KeyValue);
        }
        KeyParseError = CipherList[SelectedIndex].SetKeys(CipherKeyValues);
        if (KeyParseError != null) return;
        EncodedText = CipherList[SelectedIndex].Encode(PlainText);

    }

    public void Decode()
    {
        List<string> CipherKeyValues = [];
        foreach (CipherKeyViewModel cipherKey in CipherKeys)
        {
            CipherKeyValues.Add(cipherKey.KeyValue);
        }
        KeyParseError = CipherList[SelectedIndex].SetKeys(CipherKeyValues);
        if (KeyParseError != null) return;
        PlainText = CipherList[SelectedIndex].Decode(EncodedText);
    }
}

public class CipherKeyViewModel(string name, string defaultValue) : ViewModelBase
{
    public string KeyName { get; } = name;

    private string keyValue = defaultValue;
    public string KeyValue { get => keyValue; set => this.RaiseAndSetIfChanged(ref keyValue, value); }
}
