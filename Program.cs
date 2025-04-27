using AMysteriousVideogame.Audio;
using AMysteriousVideogame.Minigames;

namespace AMysteriousVideogame;

internal class Program
{
    static async Task Lose()
    {
        await MusicPlayer.Play(Music.Lose);
        ConsoleUtils.Title("You lost", "Press any key to exit");
        ConsoleUtils.ClearKeyBuffer();
        Console.ReadKey(true);

        Console.Clear();
        await MusicPlayer.FadeOut(500);
    }

    static async Task Main(string[] args)
    {
        List<SuperString> options = ["Platformer", "Maze", "Escape", "Race", "Target", "Battle"];
        bool playing = true;
        while (playing)
        {
            await MusicPlayer.Play(Music.TitleTheme);

            ConsoleUtils.Title("A Mysterious Minigame");

            var choice = await ConsoleUtils.Choose(options, softClear: false);

            Console.Clear();

            bool won = true;
            switch (choice)
            {
                case 0:
                    await MusicPlayer.Play(Music.TheComplex, 0.4);

                    Console.Clear();
                    ConsoleUtils.Title("Use the WASD and the spacebar to navigate through the ravine.", "Use the arrow keys to move one block at a time, WASD to move two blocks at a time.", "Don't hold down keys, tap them one at a time.", "Press any key to begin.");
                    ConsoleUtils.ClearKeyBuffer();
                    Console.ReadKey(true);
                    Console.Clear();

                    won = await PlatformerGame.Play();
                    break;
                case 1:
                    await MusicPlayer.FadeIn(1000, 0.4);
                    Console.Clear();
                    ConsoleUtils.Title("Use the arrow keys to escape the catacombs.", "Press any key to begin");
                    ConsoleUtils.ClearKeyBuffer();
                    Console.ReadKey(true);
                    Console.Clear();

                    await MazeGame.Play();
                    break;
                case 2:
                    await MusicPlayer.Play(Music.Now, 0, TimeSpan.FromMilliseconds(10327));
                    await MusicPlayer.FadeIn(500, 0.2);
                    Console.Clear();
                    ConsoleUtils.Title("Use the up and down arrow keys to dodge obstacles.", "Press any key to begin");
                    ConsoleUtils.ClearKeyBuffer();
                    Console.ReadKey(true);
                    Console.Clear();

                    won = await FireGame.Play();
                    break;
                case 3:
                    await MusicPlayer.Play(@"SFX/SwimmingPool.mp3", 0.2);
                    Console.Clear();
                    ConsoleUtils.Title("Alternate the left and right arrow keys to swim to the end of the pool.", "Press any key to begin");
                    ConsoleUtils.ClearKeyBuffer();
                    Console.ReadKey(true);
                    Console.Clear();

                    won = await RaceGame.Play();
                    break;
                case 4:
                    await MusicPlayer.Play(Music.KoolKats, 0.4);

                    ConsoleUtils.Title("Use the arrow keys to hit the weak points.", "Press any key to begin");
                    ConsoleUtils.ClearKeyBuffer();
                    Console.ReadKey(true);
                    Console.Clear();

                    await TargetGame.Play();
                    break;
                case 5:
                    await MusicPlayer.Play(Music.Undertale, 0.4);
                    ConsoleUtils.Title("Defeat the enemies!", "Hit the spacebar to land an attack. Time it correctly to deal critical hits!", "Press any key to begin.");
                    ConsoleUtils.ClearKeyBuffer();
                    Console.ReadKey(true);
                    Console.Clear();

                    won = await BattleGame.Play() > 0;
                    break;
                default:
                    playing = false;
                    break;
            }

            await MusicPlayer.FadeOut(1000);
            Console.Clear();

            if (!won)
                await Lose();
        }

    }
}