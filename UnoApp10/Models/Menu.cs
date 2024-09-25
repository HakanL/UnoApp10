using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoApp10.Models;
public class Menu
{
    private List<MenuItem> cacheMenuItems;

    public string? Title { get; set; }

    public string? SubTitle { get; set; }

    public string? Logo { get; set; }

    public int LogoHeight { get; set; }

    public string? BackgroundImage { get; set; }

    public UserControl? ExpanderUserControl { get; set; }

    public bool NavigateBack { get; set; }

    public Func<Task<List<MenuItem>>>? GetMenuItemsFunc { get; set; }

    public async Task<List<MenuItem>> GetMenuItems()
    {
        var list = await GetMenuItemsFunc();

        this.cacheMenuItems = list;

        return list;
    }

    public Menu? Parent { get; set; }
}
