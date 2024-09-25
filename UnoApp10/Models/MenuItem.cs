using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoApp10.Models;

[Microsoft.UI.Xaml.Data.Bindable]
public class MenuItem
{
    public string? name;
    public string? Name
    {
        get
        {
            string value = GetName != null ? GetName() : this.name;

            // Null/empty string messed up the card layout
            return string.IsNullOrEmpty(value) ? " " : value;
        }
        set => this.name = value;
    }

    private string? description;
    public string? Description
    {
        get
        {
            string value = GetDescription != null ? GetDescription() : this.description;

            // Null/empty string messed up the card layout
            return string.IsNullOrEmpty(value) ? " " : value;
        }
        set => this.description = value;
    }

    public Func<string>? GetDescription { get; set; }

    public Func<string>? GetName { get; set; }

    public Func<Task>? TappedAction { private get; set; }

    public bool ConfirmAction { get; set; }

    public Func<Task>? HeldAction { private get; set; }

    public Func<Task<Menu>>? GetChildren { get; set; }

    public string? Icon { get; set; } = "default40x40.png";

    public string FullIconPath => Icon?.StartsWith("file://") == true ? Icon : $"ms-appx:///Assets/Icons/{Icon}";

    public Brush? Background { get; set; }

    // Primarily used for the external control
    public double Width { get; set; }
}
