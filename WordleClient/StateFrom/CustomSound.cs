using System;
using System.Threading.Tasks;
using NAudio.Wave;
namespace WordleClient.StateFrom
{
    public static class CustomSound
    {
        // Trạng thái tắt/bật âm thanh
        private static bool isMuted = false;
        // Phát nhạc nền
        private static WaveOutEvent? outputDevice;
        // Nhạc nền lặp
        private static LoopStream? loopStream;           
        // Phát nhạc nền lặp
        public static void PlayBackgroundLoop()
        {
            if (isMuted) return;

            try
            {
                if (outputDevice == null)
                {
                    string basePath = AppDomain.CurrentDomain.BaseDirectory;
                    string musicPath = Path.Combine(basePath, "Assets", "GameSoundBackground.wav");
                    var reader = new AudioFileReader(musicPath);
                    loopStream = new LoopStream(reader) { Volume = 0.5f };
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
        // Dừng nhạc nền
        public static void StopBackground()
        {
            try {
                outputDevice?.Stop(); 
            } catch
            { }
            outputDevice?.Dispose(); outputDevice = null;
            loopStream?.Dispose(); loopStream = null;
        }
        // Phát hiệu ứng âm thanh không chặn luồng, xử lý bất đồng bộ
        private static void PlayEffect(string filePath)
        {
            Task.Run(() =>
            {
                try
                {
                    using var reader = new AudioFileReader(filePath);
                    using var player = new WaveOutEvent();
                    player.Init(reader);
                    player.Play();
                    while (player.PlaybackState == PlaybackState.Playing){
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
            string musicPath = Path.Combine(basePath, "Assets", "ButtonSound.wav");
            PlayEffect(musicPath);
        }
        // Bật/tắt âm thanh
        public static void ToggleMute()
        {
            isMuted = !isMuted;
            if (isMuted){
                StopBackground();
            }
            else{
                PlayBackgroundLoop();
            }
        }
        // Lấy trạng thái mute
        public static bool IsMuted() => isMuted;
    }
    // Class hỗ trợ phát nhạc lặp
    public class LoopStream : WaveStream
    {
        private readonly WaveStream sourceStream;
        public bool EnableLooping { get; set; } = true;
        public LoopStream(WaveStream source) => sourceStream = source;
        public override WaveFormat WaveFormat => sourceStream.WaveFormat;
        public override long Length => sourceStream.Length;
        public override long Position
        {
            get => sourceStream.Position;
            set => sourceStream.Position = value;
        }
        // Đọc dữ liệu và lặp lại nếu EnableLooping = true
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
        // Điều chỉnh âm lượng nhạc nền
        public float Volume
        {
            get => (sourceStream as AudioFileReader)?.Volume ?? 1f;
            set {
            if (sourceStream is AudioFileReader reader){
            reader.Volume = value;
            }
            }
        }
    }
}
