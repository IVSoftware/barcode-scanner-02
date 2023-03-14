using QRCoder;
using System.Diagnostics;
using System.Text;
using static QRCoder.QRCodeGenerator;

namespace barcode_scanner_00
{
    public partial class BarcodeScannerForm : Form, IMessageFilter
    {
        public BarcodeScannerForm()
        {
            InitializeComponent();
            // Add message filter to hook WM_KEYDOWN events.
            Application.AddMessageFilter(this);
            Disposed += (sender, e) => Application.RemoveMessageFilter(this);
            // Create the visible codes.
            initImages();
        }
        private readonly StringBuilder _buffer = new StringBuilder();
        const int WM_CHAR = 0x0102;
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg.Equals(WM_CHAR)) detectScan((char)m.WParam);
            return false;
        }
        private void detectScan(char @char)
        {
            Debug.WriteLine(@char);
            if(_keyCount == 0) _buffer.Clear();
            int charCountCapture = ++_keyCount;
            _buffer.Append(@char);
            Task
                .Delay(TimeSpan.FromSeconds(SECONDS_PER_CHARACTER_MIN_PERIOD))
                .GetAwaiter()
                .OnCompleted(() => 
                {
                    Debug.WriteLine($"{charCountCapture} {_keyCount}");
                    if (charCountCapture.Equals(_keyCount))
                    {
                        _keyCount = 0;
                        if(_buffer.Length > SCAN_MIN_LENGTH)
                        {
                            var scannedText = _buffer.ToString();
                            BeginInvoke(()=>parseScannedText(scannedText));
                            // For testing purposes:
                            BeginInvoke(()=>MessageBox.Show(scannedText));
                        }
                    }
                });
        }
        private void parseScannedText(string scannedText)
        {
            string[] parse = 
                scannedText
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(_=>_.Trim())
                .ToArray();
            textBoxIndex0.Text = parse[0];
            if(parse.Length > 1)
            {
                textBoxIndex1.Text= parse[1];
            }
            else
            {
                textBoxIndex1.Clear();
            }
        }

        int _keyCount = 0;
        const int SCAN_MIN_LENGTH = 8; 
        const double SECONDS_PER_CHARACTER_MIN_PERIOD = 0.1;

        private readonly QRCodeGenerator _generator = new QRCodeGenerator();
        private void displayBarCode(string text)
        {
            if (text.Length > 16)
            {
                pictureBoxBC.Image = null;
            }
            else
            {
                BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
                pictureBoxBC.Image =
                    barcode
                    .Encode(
                        BarcodeLib.TYPE.CODE128,
                        text,
                        pictureBoxBC.Width,
                        pictureBoxBC.Height
                    );
            }
        }
        private void initImages()
        {
            displayBarCode("abc, def");
            displayQRCode("ghi, jkl");
        }

        private void displayQRCode(string text)
        {
            var qrCode = new QRCode(
                _generator
                .CreateQrCode(text, ECCLevel.Q)
            );
            var image = new Bitmap(qrCode.GetGraphic(20), pictureBoxQR.Size);
            pictureBoxQR.Image = image;
        }
    }
}