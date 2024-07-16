using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class InventoryComponent : Node
{
    [Export]
    public InventoryItemResource? ItemResource { get; set; }



    //EmitSignal(nameof(SlotItemAdded));
}
