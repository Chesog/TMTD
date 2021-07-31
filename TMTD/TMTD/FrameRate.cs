using SFML.System;
using System;

namespace TMTD
{
    public static class FrameRate
    {
        public static readonly uint FRAMERATE_LIMIT = 60;
        private static Clock clock;
        private static Time previousTime;
        private static Time currentTime;
        private static float Fps;
        private static float deltaTime;
        public static void InitFrameRateSystem() 
        {
            clock = new Clock();
            previousTime = clock.ElapsedTime;
            
        }
        public static void OnFrameEnd() 
        {
            currentTime = clock.ElapsedTime;
            deltaTime = currentTime.AsSeconds() - previousTime.AsSeconds();
            Fps = 1.0f / deltaTime;
            Console.WriteLine(Fps);
            previousTime = currentTime;
        }
        public static float GetCurrentFps() 
        {
            return Fps;
        }
        public static float GetDeltaTime() 
        {
            return deltaTime;
        }
    }
}
