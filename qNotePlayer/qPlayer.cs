using System;
using System.Threading;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace qNotePlayer
{
    public class qPlayer
    {

        private int durationMs = 500; // Duración por defecto en milisegundos
        public void PlayNote(float frequency, int durationMs)
        {
            // Generador de señal senoidal
            var signalGenerator = new SignalGenerator()
            {
                Gain = 0.2, // Volumen
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

        public float CalculateFrequency(int noteNumber)
        {
            // Fórmula para calcular la frecuencia de una nota MIDI
            // A4 = 440 Hz es la nota 69 en MIDI
            float frequency = 440.0f * (float)Math.Pow(2.0, (noteNumber - 69) / 12.0);
            return frequency;
        }
    }
}
