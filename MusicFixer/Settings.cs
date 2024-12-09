using Mutagen.Bethesda.Plugins;

namespace MusicFixer
{
    public record Settings
    {
        public List<ModKey> TargetMods = new List<ModKey>();
    }
}
