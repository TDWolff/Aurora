namespace Aurora
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnScanButtonClicked(object sender, EventArgs e)
        {
            ScanForDevices();
        }

        private async void ScanForDevices()
        {
            var bluetoothService = new BluetoothService();
            var devices = await bluetoothService.ScanForDevicesAsync();

            foreach (var device in devices)
            {
                ConnectionsBox.Text += $"{device.Name} ({device.Id})\n";
            }
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            //count+=10;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
