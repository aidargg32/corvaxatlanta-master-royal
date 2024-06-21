using Content.Shared.Audio;
using Robust.Shared.Audio;
using Robust.Shared.Player;

namespace Content.Server.Audio;

/// <summary>
/// This handles...
/// </summary>
public sealed partial class ServerGlobalSoundSystem
{
    public void DispatchGlobalMusic(string filename, GlobalEventMusicType type, Filter filter, bool loop = false, AudioParams? audioParams = null)
    {
        audioParams ??= AudioParams.Default.WithVolume(-8);

        var msg = new GlobalEventMusicEvent(filename, type, loop, audioParams);

        RaiseNetworkEvent(msg, filter);
    }

    public void StopGlobalEventMusic(GlobalEventMusicType type, Filter filter)
    {
        // TODO REPLAYS
        // these start & stop events are gonna be a PITA
        // theres probably some nice way of handling them. Maybe it just needs dedicated replay data (in which case these events should NOT get recorded).

        var msg = new StopGlobalEventMusic(type);
        RaiseNetworkEvent(msg, filter);
    }
}
