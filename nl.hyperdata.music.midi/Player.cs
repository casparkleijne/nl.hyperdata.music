using Midi.Devices;
using Midi.Enums;
using nl.hyperdata.music.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pitch = Midi.Enums.Pitch;

namespace nl.hyperdata.music.midi
{
    public class Player
    {
        readonly  IOutputDevice device = Midi.Devices.DeviceManager.OutputDevices.FirstOrDefault(x => x.Name == "LoopBe Internal MIDI");
        static readonly Random r = new Random(DateTime.Now.Millisecond);
        public Player()
        {
            device.Open();
        }

        public void Play(IPitch pitch, int duration)
        {

            if (pitch != null)
            {
                device.SendNoteOn(Midi.Enums.Channel.Channel1, (Pitch)pitch.Index, r.Next(70, 100));
                Thread.Sleep(duration);
                device.SendNoteOff(Midi.Enums.Channel.Channel1, (Pitch)pitch.Index, r.Next(70,100));
            }
        }

        public void Play(IEnumerable<IPitch> pitches, int duration)
        {
            if (pitches == null)
            {
                return;
            }



            foreach (var item in pitches)
            {
                if (item != null)
                {
                    device.SendNoteOn(Midi.Enums.Channel.Channel1, (Pitch)item.Index, 127);
                    Thread.Sleep(duration);
                    device.SendNoteOff(Midi.Enums.Channel.Channel1, (Pitch)item.Index, 127);
                }
            }
        }
    }
}
