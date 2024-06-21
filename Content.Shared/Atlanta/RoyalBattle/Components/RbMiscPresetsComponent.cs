using Robust.Shared.Prototypes;

namespace Content.Shared.Atlanta.RoyalBattle.Components;

/// <summary>
/// This is used for...
/// </summary>
[RegisterComponent]
public sealed partial class RbMiscPresetsComponent : Component
{
    [DataField("gear", required: true)]
    public EntProtoId Gear;
}
