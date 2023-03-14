I think you're on the right track, only I find it easier to hook the  keyboard events by implementing [IMessageFilter](https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.imessagefilter) on the main form. 

This scheme uses a watchdog timer that acts as a rate detector so that it can distinguish a human entering keystrokes (slower) from a barcode scanner entering keystrokes. Note that while this detects the scan, it doesn't *intercept* the keystrokes because doing so would swallow any slower human keystrokes. This means a focused `TextBox` is still going to receive all of the keystrokes (e.g. "abc, def") emitted by the scanner, but once you detect that a scan has occurred you can just parse it out and do string replacement as necessary (e.g. "def"). 

***

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
                            BeginInvoke(()=>MessageBox.Show(_buffer.ToString()));
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
        .
        .
        .
    }


***
**Testing**

[![scans][1]][1]

    private readonly QRCodeGenerator _generator = new QRCodeGenerator();
    private void initImages()
    {
        displayBarCode("abc, def");
        displayQRCode("ghi, jkl");
    }
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
    private void displayQRCode(string text)
    {
        var qrCode = new QRCode(
            _generator
            .CreateQrCode(text, ECCLevel.Q)
        );
        var image = new Bitmap(qrCode.GetGraphic(20), pictureBoxQR.Size);
        pictureBoxQR.Image = image;
    }


  [1]: https://i.stack.imgur.com/hQQaP.png