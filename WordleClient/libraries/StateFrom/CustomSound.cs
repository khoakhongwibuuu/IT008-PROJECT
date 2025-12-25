using NAudio.Wave;
namespace WordleClient.libraries.StateFrom
{
    public static class CustomSound
    {
        private static bool isMuted = true;
        private static WaveOutEvent? outputDevice;
        private static LoopStream? loopStream;
        public static void PlayBackgroundLoop()
        {
            if (isMuted) return;
            try
            {
                if (outputDevice == null)
                {
                    string basePath = AppDomain.CurrentDomain.BaseDirectory;
                    string musicPath = Path.Combine(basePath, "Assets", "sound", "GameSoundBackground.wav");
                    var reader = new AudioFileReader(musicPath);
                    loopStream = new LoopStream(reader)
                    {
                        Volume = 0.5f
                    };
                    outputDevice = new WaveOutEvent();
                    outputDevice.Init(loopStream);
                    outputDevice.Play();
                }
                else if (outputDevice.PlaybackState != PlaybackState.Playing)
                {
                    outputDevice.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing background music: " + ex.Message);
            }
        }
        public static void StopBackground()
        {
            try
            {
                outputDevice?.Stop();
            }
            catch { }
            outputDevice?.Dispose();
            outputDevice = null;
            loopStream?.Dispose();
            loopStream = null;
        }
        private static void PlayEffect(string filePath)
        {
            Task.Run(() =>
            {
                try
                {
                    using
                    var reader = new AudioFileReader(filePath);
                    using
                    var player = new WaveOutEvent();
                    player.Init(reader);
                    player.Play();
                    while (player.PlaybackState == PlaybackState.Playing)
                    {
                        Task.Delay(50).Wait();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(filePath + "\nError playing sound effect: " + ex.Message);
                }
            });
        }
        public static void PlayClick()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string musicPath = Path.Combine(basePath, "Assets", "sound", "ButtonSound.wav");
            PlayEffect(musicPath);
        }
        public static void PlayClickAlert()
        {
            string basePath1 = AppDomain.CurrentDomain.BaseDirectory;
            string musicPath1 = Path.Combine(basePath1, "Assets", "sound", "success-340660.wav");
            PlayEffect(musicPath1);
        }
        public static void PlayClickAlertError()
        {
            string basePath1 = AppDomain.CurrentDomain.BaseDirectory;
            string musicPath1 = Path.Combine(basePath1, "Assets", "sound", "invalid-selection-39351.wav");
            PlayEffect(musicPath1);
        }
        public static void PlayClickGameOver()
        {
            string basePath1 = AppDomain.CurrentDomain.BaseDirectory;
            string musicPath1 = Path.Combine(basePath1, "Assets", "sound", "game-over-arcade-6435.wav");
            PlayEffect(musicPath1);
        }
        public static void ToggleMute()
        {
            isMuted = !isMuted;
            if (isMuted)
            {
                StopBackground();
            }
            else
            {
                PlayBackgroundLoop();
            }
        }
        public static bool IsMuted() => isMuted;
    }
    public class LoopStream : WaveStream
    {
        private readonly WaveStream sourceStream;
        public bool EnableLooping
        {
            get;
            set;
        } = true;
        public LoopStream(WaveStream source) => sourceStream = source;
        public override WaveFormat WaveFormat => sourceStream.WaveFormat;
        public override long Length => sourceStream.Length;
        public override long Position
        {
            get => sourceStream.Position;
            set => sourceStream.Position = value;
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;
            while (totalBytesRead < count)
            {
                int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                if (bytesRead == 0)
                {
                    if (sourceStream.Position == 0 || !EnableLooping) break;
                    sourceStream.Position = 0;
                }
                totalBytesRead += bytesRead;
            }
            return totalBytesRead;
        }
        public float Volume
        {
            get => (sourceStream as AudioFileReader)?.Volume ?? 1f;
            set
            {
                if (sourceStream is AudioFileReader reader)
                {
                    reader.Volume = value;
                }
            }
        }
    }
}