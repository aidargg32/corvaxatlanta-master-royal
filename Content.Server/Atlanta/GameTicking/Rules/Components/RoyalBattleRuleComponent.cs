using Content.Server.Atlanta.RoyalBattle.Systems;
using Content.Shared.Atlanta.RoyalBattle.Components;
using Content.Shared.Roles;
using Robust.Shared.Audio;
using Robust.Shared.Map;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Server.Atlanta.GameTicking.Rules.Components;

/// <summary>
/// This is used for royal battle setup.
/// </summary>
[RegisterComponent, Access(typeof(RoyalBattleRuleSystem), typeof(RbZoneSystem))]
public sealed partial class RoyalBattleRuleComponent : Component
{
    [DataField("gameState")]
    public RoyalBattleGameState GameState = RoyalBattleGameState.InLobby;

    [DataField("lobbyMapName")]
    public string LobbyMapPath = "Maps/Atlanta/lobby.yml";

    [DataField("lobbyMapId")]
    public MapId? LobbyMapId;

    [DataField("battleMapId")]
    public MapId? MapId;

    [DataField("center")]
    public EntityUid? Center;

    [DataField("startupTime")]
    public TimeSpan StartupTime = TimeSpan.FromMinutes(1);

    [DataField("playersMinds")]
    public List<EntityUid> PlayersMinds = new();

    [DataField("alivePlayers")]
    public List<EntityUid> AlivePlayers = new();

    [DataField("deadPlayers")]
    public List<string> DeadPlayers = new();

    [DataField("availableSpawners")]
    public List<EntityUid> AvailableSpawners = new();
    /// <summary>
    /// The gear all players spawn with.
    /// </summary>
    [DataField("gear", customTypeSerializer: typeof(PrototypeIdSerializer<StartingGearPrototype>)), ViewVariables(VVAccess.ReadWrite)]
    public string Gear = "RbFighterGear";

    [DataField("restartTime")]
    public TimeSpan RestartTime = TimeSpan.FromSeconds(30);

    #region Sound

    [DataField("greetingSound")]
    public SoundSpecifier GreetingSound = new SoundPathSpecifier("/Audio/Atlanta/Misc/RoyalBattle/rb_greeting.ogg");

    [DataField("loosingSound")]
    public SoundSpecifier LoosingSound = new SoundPathSpecifier("/Audio/Atlanta/Misc/RoyalBattle/rb_loose.ogg");

    [DataField("zoneStartSound")]
    public SoundSpecifier ZoneStartSound = new SoundPathSpecifier("/Audio/Atlanta/Misc/RoyalBattle/rb_zone_start.ogg");

    [DataField("zoneStopSound")]
    public SoundSpecifier ZoneStopSound = new SoundPathSpecifier("/Audio/Atlanta/Misc/RoyalBattle/rb_zone_stop.ogg");

    [DataField("winnerSound")]
    public SoundSpecifier WinnerSound = new SoundPathSpecifier("/Audio/Atlanta/Misc/RoyalBattle/rb_winner.ogg");

    [DataField("deathSound")]
    public SoundSpecifier DeathSound = new SoundPathSpecifier("/Audio/Atlanta/Misc/RoyalBattle/rb_death.ogg");

    // DOOM
    [DataField("musicEntry")]
    public SoundSpecifier MusicEntry = new SoundPathSpecifier("/Audio/Atlanta/Misc/RoyalBattle/doom_opening.ogg");

    [DataField("musicLoop")]
    public SoundSpecifier MusicLoop = new SoundPathSpecifier("/Audio/Atlanta/Misc/RoyalBattle/doom_loop.ogg");

    [DataField("musicClosing")]
    public SoundSpecifier MusicClosing = new SoundPathSpecifier("/Audio/Atlanta/Misc/RoyalBattle/doom_end.ogg");

    public TimeSpan LoopTimer = TimeSpan.Zero;

    #endregion

    public readonly string RoyalBattlePrototypeId = "RoyalBattle";
}

public sealed class RoyalBattleStartEvent : EntityEventArgs
{
}

public enum RoyalBattleGameState
{
    InLobby,
    InGame,
    InEnding
}
