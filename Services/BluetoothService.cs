using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;

public class BluetoothService
{
    private readonly IBluetoothLE _bluetoothLE;
    private readonly IAdapter _adapter;

    public BluetoothService()
    {
        _bluetoothLE = CrossBluetoothLE.Current;
        _adapter = CrossBluetoothLE.Current.Adapter;
    }

    public async Task<IEnumerable<IDevice>> ScanForDevicesAsync()
    {
        var devices = new List<IDevice>();
        _adapter.DeviceDiscovered += (s, a) => devices.Add(a.Device);
        await _adapter.StartScanningForDevicesAsync();
        return devices;
    }
}