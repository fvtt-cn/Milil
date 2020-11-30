using Dahomey.Json;
using Milil.Models;
using shortid;
using shortid.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Milil
{
    public sealed class Program
    {
        private static readonly string[] AvailableExtensions = { ".ogg", ".mp3", ".flac", ".wav", ".webm" };

        private const string PREFIX = "modules";

        private const string DB_FILE = "playlists.db";

        private const string MODULE_FILE = "module.json";

        private static readonly byte[] NewLineBytes = Encoding.UTF8.GetBytes("\n");

        private static readonly GenerationOptions IdRules = new GenerationOptions
        {
            Length = 16,
            UseNumbers = true,
            UseSpecialCharacters = false
        };

        private static readonly JsonSerializerOptions ModuleSerializationRules = new JsonSerializerOptions
        {
            WriteIndented = true,
        }.SetupExtensions();

        private static string GetId() => ShortId.Generate(IdRules);

        public static async Task Main()
        {
            var root = new DirectoryInfo(".");

            var subs = root.EnumerateDirectories().Where(x =>
                x.EnumerateFiles().Any(f =>
                    AvailableExtensions.Contains(f.Extension, StringComparer.OrdinalIgnoreCase))).ToList();

            if (!subs.Any())
            {
                // No sounds, return.
                await Console.Error.WriteLineAsync("No sounds found in top directories.");
                return;
            }

            var rootName = Path.Combine(PREFIX, root.Name);
            var permission = new Dictionary<string, int>
            {
                { "default", 0 },
                { GetId(), 3 }
            };

            // Playlists.db
            await using var dbFile = File.Open(DB_FILE, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);

            foreach (var sub in subs)
            {
                var sounds = sub.EnumerateFiles()
                    .Where(f => AvailableExtensions.Contains(f.Extension, StringComparer.OrdinalIgnoreCase))
                    .Select(s => new Sound
                    {
                        Id = GetId(),
                        Name = Path.GetFileNameWithoutExtension(s.Name),
                        Path = Path.Combine(rootName, sub.Name, s.Name).Replace("#", "%23"),
                        Playing = false,
                        Repeat = false,
                        Volume = 0.50
                    });

                var pack = new SoundPack
                {
                    Id = GetId(),
                    Name = sub.Name,
                    Mode = -1,
                    Permission = permission,
                    Playing = false,
                    Sounds = sounds.ToList()
                };

                var success = false;

                try
                {
                    await JsonSerializer.SerializeAsync(dbFile, pack);
                    await dbFile.WriteAsync(NewLineBytes);

                    success = true;
                }
                catch (JsonException jEx)
                {
                    await Console.Error.WriteLineAsync(jEx.Message);
                }
                catch (IOException ioE)
                {
                    await Console.Error.WriteLineAsync(ioE.Message);
                }

                if (success)
                {
                    Console.WriteLine($"SUC: {sub.Name}");
                }
                else
                {
                    await Console.Error.WriteLineAsync($"ERR: {sub.Name}");
                }
            }

            var flushPackTask = dbFile.FlushAsync().ConfigureAwait(false);

            // module.json
            var module = new Module
            {
                Name = root.Name,
                Title = root.Name,
                Packs = new List<PackFile>
                {
                    new PackFile
                    {
                        Name = Path.GetFileNameWithoutExtension(DB_FILE),
                        Label = root.Name,
                        Path = string.Concat("/", DB_FILE),
                        Entity = "Playlist"
                    }
                }
            };

            await using var moduleFile = File.Open(MODULE_FILE, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            await JsonSerializer.SerializeAsync(moduleFile, module, ModuleSerializationRules);
            var flushModuleTask = moduleFile.FlushAsync().ConfigureAwait(false);

            await flushPackTask;
            await flushModuleTask;
            Console.WriteLine("Completed!");
        }
    }
}
