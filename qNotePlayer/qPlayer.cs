using System;
using System.Threading;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace qNotePlayer
{
    public class qPlayer
    {

        public double Volumen { get; set; }
        private int defaultDurationMs = 500; // Duración por defecto en milisegundos

        public qPlayer()
        {
            Volumen = 0.5;
        }

        public qPlayer(double gain = 0.5)
        {
            Volumen = gain;
        }

        public void PlayNote(float frequency, int durationMs = 1000)
        {
            // Generador de señal senoidal
            var signalGenerator = new SignalGenerator()
            {
                Gain = Volumen, // Volumen
                Frequency = frequency, // Frecuencia de la nota
                Type = SignalGeneratorType.Sin // Onda senoidal
            };

            // Limita la duración de la señal
            var note = signalGenerator.Take(TimeSpan.FromMilliseconds(durationMs));

            // Crea una salida de audio
            using (var waveOut = new WaveOutEvent())
            {
                waveOut.Init(note);
                waveOut.Play();

                // Espera hasta que termine de reproducirse
                Thread.Sleep(durationMs);
            }
        }

        public void PlayNoteAsync(float frequency, int durationMs = 1000)
        {
            Task.Run(() => PlayNote(frequency, durationMs));
        }

        public void PlayNotes()
        {
            // Create an instance of qPlayer with using statement
            bool running = true;
            while (running)
            {
                var keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.A:
                        PlayNoteAsync(261.63f, 500); // C4 - Do
                        break;
                    case ConsoleKey.S:
                        PlayNoteAsync(293.66f, 500); // D4 - Re
                        break;
                    case ConsoleKey.D:
                        PlayNoteAsync(329.63f, 500); // E4 - Mi
                        break;
                    case ConsoleKey.F:
                        PlayNoteAsync(349.23f, 500); // F4 - Fa
                        break;
                    case ConsoleKey.G:
                        PlayNoteAsync(392.00f, 500); // G4 - Sol
                        break;
                    case ConsoleKey.H:
                        PlayNoteAsync(440.00f, 500); // A4 - La
                        break;
                    case ConsoleKey.J:
                        PlayNoteAsync(493.88f, 500); // B4 - Si
                        break;
                    case ConsoleKey.K:
                        PlayNoteAsync(523.25f, 500); // C5 - Do
                        break;
                    case ConsoleKey.Escape:
                        running = false;
                        break;
                }
            }
        }
    }
}
