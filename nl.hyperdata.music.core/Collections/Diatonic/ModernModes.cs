 
using System.Linq;

namespace nl.hyperdata.music.core.Collections.Diatonic
{
    public static class ModernModes
    {
        public static IMode Ionian = new Mode(new double[]{-17,-15,-13,-12,-10,-8,-7,-5,-3,-1,0,2,4,5,7,9,11,12,14,16,17}.Select(n => new Interval(n)));
    }
}
