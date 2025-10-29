using Plugin.BLE;
namespace Aurora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnScanButtonClicked(object sender, EventArgs e)
        {
            ChatBox.Text += "[DEBUG] Scan button clicked. Starting ScanForDevices method...\n";
            ScanForDevices();
        }

        private async void ScanForDevices()
        {
            try
            {
                ChatBox.Text += "[DEBUG] Scanning for Bluetooth devices...\n";
                var bluetoothService = new BluetoothService();
                ChatBox.Text += "[DEBUG] BluetoothService instance created.\n";

                if (!CrossBluetoothLE.Current.IsAvailable)
                {
                    ChatBox.Text += "[DEBUG] Bluetooth is not available on this device.\n";
                    return;
                }

                if (!CrossBluetoothLE.Current.IsOn)
                {
                    ChatBox.Text += "[DEBUG] Bluetooth is turned off. Please enable it.\n";
                    return;
                }

                ChatBox.Text += "[DEBUG] Starting device scan...\n";
                var devices = await bluetoothService.ScanForDevicesAsync();
                ChatBox.Text += "[DEBUG] Scan complete. Processing discovered devices...\n";
                ChatBox.Text += $"[DEBUG] Number of devices discovered: {devices.Count()}\n";

                foreach (var device in devices)
                {
                    ChatBox.Text += $"[DEBUG] Discovered device: {device.Name} ({device.Id})\n";
                    ConnectionsBox.Text += $"{device.Name} ({device.Id})\n";
                }

                ChatBox.Text += "[DEBUG] Device processing complete.\n";
            }
            catch (Exception ex)
            {
                ChatBox.Text += $"[DEBUG] Error during scan: {ex.Message}\n";
                Console.WriteLine($"Error during scan: {ex.Message}");
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
