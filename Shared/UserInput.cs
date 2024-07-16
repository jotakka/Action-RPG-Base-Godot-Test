using ARPG.Shared;
using ARPG.Util;

public sealed class UserInput : TypedStringBase
{
    public static readonly UserInput MoveLeft = new("ui_left");
    public static readonly UserInput MoveRight = new("ui_right");
    public static readonly UserInput MoveUp = new("ui_up");
    public static readonly UserInput MoveDown = new("ui_down");
    public static readonly UserInput Attack = new("ui_attack");
    public static readonly UserInput Sprint = new("ui_sprint");
    public static readonly UserInput ToggleInventory = new("toggle_inventory");

    private UserInput(string name) : base(name)
    {
    }

}
