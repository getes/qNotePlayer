// See https://aka.ms/new-console-template for more information
using qNotePlayer;

Console.WriteLine("Hola Adriana!!");
WriteSeparator();
Console.WriteLine("Presiona F1 para modo piano");
Console.WriteLine("Presiona F2 para calcular la frecuencia de una nota MIDI");
Console.WriteLine("Presiona Esc para salir");
qPlayer player = new qPlayer();
FreqCalculator freqCalculator = new FreqCalculator();

switch (Console.ReadKey(true).Key)
{
    case ConsoleKey.Escape:
        break;
    case ConsoleKey.F1:
        WriteSeparator();
        WritePianoInstructions();

        player.PlayNotes();
        break;
    case ConsoleKey.F2:
        WriteSeparator();
        WriteFreqCalcIntstructions();
        bool running = true;
        while (running)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "quit" || input.ToLower() == "q")
            {
                running = false;
                break;
            }
            if (int.TryParse(input, out int noteNumber))
            {
                float frequency = freqCalculator.CalculateFrequency(noteNumber);
                Console.WriteLine($"La frequencia de la nota {noteNumber} es de {frequency} Hz");
            }
            else
            {
                Console.Write($"Entrada no válida {input} debe ser un número");
                Console.WriteLine("");
                Console.ReadKey();
            }
        }
        break;
    default:
        Console.WriteLine("Opción no válida");
        Console.WriteLine("");
        break;
}

void WriteSeparator()
{
    Console.WriteLine(string.Empty);
    Console.WriteLine("--------------------------------------------------");
}

static void WriteFreqCalcIntstructions()
{
    Console.WriteLine("Modo calculadora de frecuencia activado");
    Console.WriteLine("Introduce el número de la nota MIDI (ejemplo: 69 (para A4 [La4]):");
    Console.WriteLine("Presiona 'Enter' para calcular la frecuencia.");
    Console.WriteLine("Presiona 'Esc' para salir.");
}

static void WritePianoInstructions()
{
    Console.WriteLine("Modo piano activado");
    Console.WriteLine("Presiona una tecla para reproducir una nota.");
    Console.WriteLine("Presiona 'A' para Do");
    Console.WriteLine("'S' para Re");
    Console.WriteLine("'D' para Mi");
    Console.WriteLine("'F' para Fa");
    Console.WriteLine("'G' para Sol");
    Console.WriteLine("'H' para La");
    Console.WriteLine("'J' para Si");
    Console.WriteLine("'K' para Do");
    Console.WriteLine("Escribe 'quit o q' para salir.");
}