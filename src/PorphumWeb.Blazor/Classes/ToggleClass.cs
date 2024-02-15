using BlazorBootstrap;

namespace PorphumWeb.Blazor.Classes;

public class ToggleClass
{
    private static string SHOW_BUTTON_TITTLE = "Поиск";
    private static string HIDE_BUTTON_TITTLE = "Скрыть";

    private readonly string _hideTittle;
    private readonly string _showTittle;
    
    public ToggleClass(string? showTittle = null, string? hideTittle = null)
    {
        _hideTittle = hideTittle ?? HIDE_BUTTON_TITTLE;
        _showTittle = showTittle ?? SHOW_BUTTON_TITTLE;
        ButtonTittle = _showTittle;
    }

    public Collapse CollapseItem { get; set; } = default!;
    public string ButtonTittle { get; set; }

    public async Task ToggleAsync()
    {
        await CollapseItem.ToggleAsync();
    }

    public void OnHiddenCallback()
    {
        ButtonTittle = _showTittle;
    }

    public void OnShownCallback()
    {
        ButtonTittle = _hideTittle;
    }
}
