using Robust.Shared.Audio;
using Robust.Shared.Serialization;

namespace Content.Shared.Audio;

public enum GlobalEventMusicType : byte
{
    // Royal Battle
    RoyalBattleMusic
}

[Serializable, NetSerializable]
public sealed class GlobalEventMusicEvent : GlobalSoundEvent
{
    public GlobalEventMusicType Type;
    public bool Loop;

    public GlobalEventMusicEvent(string filename, GlobalEventMusicType type, bool loop = false, AudioParams? audioParams = null) : base(
        filename, audioParams)
    {
        Type = type;
        Loop = loop;
    }
}

[Serializable, NetSerializable]
public sealed class StopGlobalEventMusic : EntityEventArgs
{
    public GlobalEventMusicType Type;

    public StopGlobalEventMusic(GlobalEventMusicType type)
    {
        Type = type;
    }
}
