using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using Noggog;

namespace MusicFixer
{
    public class Program
    {
        static Lazy<Settings> Settings = null!;

        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetAutogeneratedSettings(
                    nickname: "Settings",
                    path: "settings.json",
                    out Settings)
                .SetTypicalOpen(GameRelease.SkyrimSE, "MusicFixer.esp")
                .Run(args);
        }

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            if (Settings.Value.TargetMods.Count == 0)
            {
                System.Console.WriteLine("Must at least specify one target mod in order to do anything.");
                return;
            }
            
            var cells = state.LoadOrder.ListedOrder
                .Select(listing => listing.Mod)
                .NotNull()
                .Select(x => (x.ModKey, x.Cells))
                .Where(x => Settings.Value.TargetMods.Contains(x.ModKey))
                .ToArray();

            Console.WriteLine(cells);

            // foreach (var cell in state.LoadOrder.PriorityOrder.Cell().WinningOverrides())
            // {
            //     Console.WriteLine(cell);
            // };
        }
    }
}