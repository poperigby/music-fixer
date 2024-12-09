using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace MusicFixer
{
    public record Settings
    {
        [Tooltip("A list of music mods that you would like to have music types forwarded from")]
        public List<ModKey> TargetMods = new List<ModKey>();
    }
}
