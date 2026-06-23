using System;

namespace ProxyPatternExample
{
    public interface IImage
    {
        void Display();
    }

    public class RealImage : IImage
    {
        private readonly string _filename;

        public RealImage(string filename)
        {
            _filename = filename;
            LoadFromRemoteServer();
        }

        private void LoadFromRemoteServer()
        {
            Console.WriteLine($"[Network] Loading {_filename} from remote server...");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying {_filename}");
        }
    }

    public class ProxyImage : IImage
    {
        private RealImage? _realImage;
        private readonly string _filename;

        public ProxyImage(string filename)
        {
            _filename = filename;
        }

        public void Display()
        {
            if (_realImage == null)
            {
                _realImage = new RealImage(_filename);
            }

            _realImage.Display();
        }
    }
}