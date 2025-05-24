// See https://aka.ms/new-console-template for more information
using qNotePlayer;

Console.WriteLine("Hola Adriana!!");
Console.ReadKey();
// Create an instance of qPlayer
qPlayer player = new qPlayer();

// Use the instance to call the PlayNote method
//player.PlayNote(440f, 1000);
//player.PlayNote(523.25f, 1000);

bool running = true;
while (running)
{
    var keyInfo = Console.ReadKey(true);
    switch (keyInfo.Key)
    {
        case ConsoleKey.A:
            player.PlayNote(261.63f, 500); // C4
            break;
        case ConsoleKey.S:
            player.PlayNote(293.66f, 500); // D4
            break;
        case ConsoleKey.D:
            player.PlayNote(329.63f, 500); // E4
            break;
        case ConsoleKey.F:
            player.PlayNote(349.23f, 500); // F4
            break;
        case ConsoleKey.G:
            player.PlayNote(392.00f, 500); // G4
            break;
        case ConsoleKey.H:
            player.PlayNote(440.00f, 500); // A4
            break;
        case ConsoleKey.J:
            player.PlayNote(493.88f, 500); // B4
            break;
        case ConsoleKey.Escape:
            running = false;
            break;
    }
}

