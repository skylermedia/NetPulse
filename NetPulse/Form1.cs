using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace NetworkSwitcher
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        private bool isMonitoring = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateNetworkAdapters();
        }

        private void PopulateNetworkAdapters()
        {
            try
            {
                var adapters = NetworkInterface.GetAllNetworkInterfaces()
                    .Select(ni => new { Name = ni.Name, Description = ni.Description, Status = ni.OperationalStatus })
                    .ToList();

                ethernetComboBox.Items.Clear();
                wifiComboBox.Items.Clear();

                foreach (var adapter in adapters)
                {
                    string display = $"{adapter.Name} ({adapter.Status})";
                    if (adapter.Description.ToLower().Contains("ethernet") || adapter.Name.ToLower().Contains("ethernet"))
                    {
                        ethernetComboBox.Items.Add(new { Display = display, Name = adapter.Name });
                    }
                    if (adapter.Description.ToLower().Contains("wi-fi") || adapter.Description.ToLower().Contains("wireless") || adapter.Name.ToLower().Contains("wi-fi"))
                    {
                        wifiComboBox.Items.Add(new { Display = display, Name = adapter.Name });
                    }
                }

                ethernetComboBox.DisplayMember = "Display";
                ethernetComboBox.ValueMember = "Name";
                wifiComboBox.DisplayMember = "Display";
                wifiComboBox.ValueMember = "Name";

                if (ethernetComboBox.Items.Count > 0) ethernetComboBox.SelectedIndex = 0;
                if (wifiComboBox.Items.Count > 0) wifiComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error loading adapters: {ex.Message}");
            }
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(serverTextBox.Text) || ethernetComboBox.SelectedItem == null || wifiComboBox.SelectedItem == null)
            {
                UpdateStatus("Please fill all fields");
                return;
            }

            startButton.Enabled = false;
            stopButton.Enabled = true;
            isMonitoring = true;
            cancellationTokenSource = new CancellationTokenSource();

            await MonitorNetworkAsync(
                serverTextBox.Text,
                (int)thresholdNumeric.Value,
                (int)intervalNumeric.Value,
                (int)failuresNumeric.Value,
                (ethernetComboBox.SelectedItem as dynamic).Name,
                (wifiComboBox.SelectedItem as dynamic).Name,
                cancellationTokenSource.Token
            );
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (isMonitoring)
            {
                cancellationTokenSource?.Cancel();
                isMonitoring = false;
                startButton.Enabled = true;
                stopButton.Enabled = false;
                UpdateStatus("Monitoring stopped");
            }
        }

        private async Task MonitorNetworkAsync(string server, int threshold, int interval, int maxFailures, string ethernetAdapter, string wifiAdapter, CancellationToken token)
        {
            int failureCount = 0;
            int ethernetStableCount = 0;
            const int maxStableChecks = 3;

            while (!token.IsCancellationRequested)
            {
                try
                {
                    bool isEthernetUp = IsAdapterUp(ethernetAdapter);

                    if (isEthernetUp)
                    {
                        var pingResult = await PingServerAsync(server);
                        if (pingResult.Success && pingResult.RoundtripTime <= threshold)
                        {
                            // Ethernet is stable
                            await SetAdapterStateAsync(ethernetAdapter, true);
                            await SetAdapterStateAsync(wifiAdapter, false);
                            failureCount = 0;
                            ethernetStableCount = 0;
                            UpdateStatus($"Using Ethernet: {pingResult.RoundtripTime}ms");
                        }
                        else
                        {
                            // Ethernet ping is high or failed
                            failureCount++;
                            UpdateStatus($"Ethernet Issue: ({failureCount}/{maxFailures}): {(pingResult.Success ? pingResult.RoundtripTime.ToString() : "N/A")}ms");
                            if (failureCount >= maxFailures)
                            {
                                await SetAdapterStateAsync(ethernetAdapter, false);
                                await SetAdapterStateAsync(wifiAdapter, true);
                                UpdateStatus("Switched to Wi-Fi");
                                failureCount = 0;
                            }
                        }
                    }
                    else
                    {
                        // Ethernet is down, use Wi-Fi
                        await SetAdapterStateAsync(wifiAdapter, true);
                        var wifiPing = await PingServerAsync(server);
                        string wifiPingStatus = wifiPing.Success ? $"{wifiPing.RoundtripTime}ms" : "N/A";
                        UpdateStatus($"Using Wi-Fi: Ping {wifiPingStatus}");

                        // Check if Ethernet is stable to revert
                        bool ethernetCheckUp = IsAdapterUp(ethernetAdapter);
                        if (ethernetCheckUp)
                        {
                            var ethernetPing = await PingServerAsync(server);
                            if (ethernetPing.Success && ethernetPing.RoundtripTime <= threshold)
                            {
                                ethernetStableCount++;
                                UpdateStatus($"Ethernet Check ({ethernetStableCount}/{maxStableChecks}): {ethernetPing.RoundtripTime}ms");
                                if (ethernetStableCount >= maxStableChecks)
                                {
                                    await SetAdapterStateAsync(ethernetAdapter, true);
                                    await SetAdapterStateAsync(wifiAdapter, false);
                                    UpdateStatus("Switched to Ethernet");
                                    ethernetStableCount = 0;
                                    failureCount = 0;
                                }
                            }
                            else
                            {
                                ethernetStableCount = 0;
                                UpdateStatus($"Ethernet is: {(ethernetPing.Success ? ethernetPing.RoundtripTime.ToString() : "N/A")}ms");
                            }
                        }
                    }

                    await Task.Delay(interval * 1000, token);
                }
                catch (Exception ex)
                {
                    UpdateStatus($"Error: {ex.Message}");
                }
            }
        }

        private async Task<PingReply> PingServerAsync(string server)
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = await ping.SendPingAsync(server, 2000);
                    return new PingReply(reply);
                }
            }
            catch (Exception)
            {
                return new PingReply(IPStatus.Unknown);
            }
        }

        private bool IsAdapterUp(string adapterName)
        {
            try
            {
                var adapter = NetworkInterface.GetAllNetworkInterfaces()
                    .FirstOrDefault(ni => ni.Name.Equals(adapterName, StringComparison.OrdinalIgnoreCase));
                return adapter != null && adapter.OperationalStatus == OperationalStatus.Up;
            }
            catch
            {
                return false;
            }
        }

        private async Task SetAdapterStateAsync(string adapterName, bool enable)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "netsh",
                        Arguments = $"interface set interface \"{adapterName}\" {(enable ? "enable" : "disable")}",
                        UseShellExecute = true,
                        Verb = "runas",
                        CreateNoWindow = true
                    }
                };
                process.Start();
                await process.WaitForExitAsync();
                if (process.ExitCode != 0)
                {
                    UpdateStatus($"Failed to {(enable ? "enable" : "disable")} {adapterName}");
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"Failed to {(enable ? "enable" : "disable")} {adapterName}: {ex.Message}");
            }
        }

        private void UpdateStatus(string message)
        {
            if (statusTextBox.InvokeRequired)
            {
                statusTextBox.Invoke(new Action(() => UpdateStatus(message)));
            }
            else
            {
                statusTextBox.AppendText($"{DateTime.Now:HH:mm:ss}: {message}\r\n");
                statusTextBox.SelectionStart = statusTextBox.Text.Length;
                statusTextBox.ScrollToCaret();
            }
        }
    }

    public class PingReply
    {
        public bool Success { get; }
        public long RoundtripTime { get; }

        public PingReply(IPStatus status)
        {
            Success = status == IPStatus.Success;
            RoundtripTime = 0;
        }

        public PingReply(System.Net.NetworkInformation.PingReply reply)
        {
            Success = reply.Status == IPStatus.Success;
            RoundtripTime = reply.RoundtripTime;
        }
    }
}