using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qNotePlayer
{
    public class FreqCalculator
    {
        public float CalculateFrequency(int noteNumber)
        {
            // Fórmula para calcular la frecuencia de una nota MIDI
            // A4 (el La4) = 440 Hz es la nota 69 en MIDI
            float frequency = 440.0f * (float)Math.Pow(2.0, (noteNumber - 69) / 12.0);
            return frequency;
        }
    }
}
