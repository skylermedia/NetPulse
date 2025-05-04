# 🚀 NetPulse

**NetPulse** is a lightweight Windows application built with C# and .NET 9.0 that optimizes your network connection for gaming. It monitors ping to a game server over Ethernet, automatically switches to Wi-Fi if the connection becomes unstable, displays the Wi-Fi ping, and reverts to Ethernet when stable again, ensuring that your network is as reliable as possible for competitive gaming!

---

## ✨ Features

- 📡 **Real-Time Ping Monitoring**: Continuously pings a user-specified game server to check latency.
- 🔄 **Automatic Network Switching**: Switches to Wi-Fi if Ethernet ping exceeds the threshold for a set number of failures.
- 📊 **Wi-Fi Ping Display**: Shows the current Wi-Fi ping when using the wireless connection.
- 🔙 **Smart Revert**: Reverts to Ethernet after three consecutive stable pings.
- 🖥️ **User-Friendly GUI**: Simple interface to configure server IP, ping threshold, check interval, max failures, and network adapters.
- ⚙️ **Windows Integration**: Uses `netsh` to enable/disable network adapters seamlessly.
- 📦 **Single-File Executable**: Distribute as a single, self-contained executable for easy sharing.

---

## 🛠️ Prerequisites

To run or build NetPulse, you’ll need:

- **Windows 10 or later** 🪟: Required for Windows Forms and `netsh` commands.
- **.NET 9.0 SDK** 💻: Download from dotnet.microsoft.com.
- **Administrative Privileges** 🔑: Needed for `netsh` to manage network adapters.

---

## 📥 Installation

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/skylermedia/NetPulse.git
   cd NetPulse/NetPulse
   ```

2. **Restore Dependencies**:

   ```bash
   dotnet restore
   ```

3. **Build the Project**:

   ```bash
   dotnet build
   ```

4. **Run the Application**:

   ```bash
   dotnet run
   ```

   - Alternatively, publish and run the executable:

     ```bash
     dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
     ```
     - Find `NetPulse.exe` in `bin/Release/net9.0-windows/win-x64/publish`.
     - Right-click `NetPulse.exe` and select **Run as administrator**.

---

## 🎮 Usage

1. **Launch NetPulse**:

   - Run `NetPulse.exe` as administrator to allow network adapter control.

2. **Configure Settings**:

   - **Game Server IP**: Enter the server’s IP address (e.g., `1.1.1.1` for testing).
   - **Ping Threshold (ms)**: Set the maximum acceptable ping (e.g., `50`).
   - **Check Interval (s)**: Define how often to ping (e.g., `1` second).
   - **Max Failures**: Set the number of failed pings before switching to Wi-Fi (e.g., `3`).
   - **Ethernet/Wi-Fi Adapters**: Select your network adapters from the dropdowns.

3. **Start Monitoring**:

   - Click **Start Monitoring** to begin pinging the server.
   - The app will:
     - Monitor Ethernet ping.
     - Switch to Wi-Fi if ping exceeds the threshold for the set number of failures.
     - Display Wi-Fi ping when active.
     - Revert to Ethernet after three stable pings.

4. **Stop Monitoring**:

   - Click **Stop Monitoring** to pause the process.

5. **View Status**:

   - The status box shows real-time updates (e.g., `Ethernet stable: 20ms`, `Using Wi-Fi: Ping 45ms`).

---

## 📦 Publishing as a Single File

To distribute NetPulse as a single executable:

1. **Publish**:

   ```bash
   dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
   ```

2. **Locate the Executable**:

   - Find `NetPulse.exe` in `bin/Release/net9.0-windows/win-x64/publish`.

3. **Distribute**:

   - Share `NetPulse.exe` (60-100 MB) via USB, email, or cloud storage.
   - Instruct users to run it as administrator on Windows 10/11.

---

## 🐛 Troubleshooting

- **Build Errors**:

  - Clear build artifacts and restore:

    ```bash
    rmdir /s /q bin obj
    dotnet restore
    dotnet build
    ```

- **netsh Failures**:

  - Ensure `NetPulse.exe` is run as administrator.
  - Verify adapter names:

    ```cmd
    netsh interface show interface
    ```

- **GUI Text Issues**

  - Adjust `ClientSize` in `Form1.Designer.cs` if needed:

    ```csharp
    this.ClientSize = new System.Drawing.Size(550, 480);
    ```

- **Ping Issues**:

  - Ensure the server IP is reachable (e.g., `ping 8.8.8.8` in Command Prompt).
  - Check firewall settings for ICMP.

---

## 🤝 Contributing

We welcome contributions to make NetPulse even better! 🌟

1. **Fork the Repository**:

   - Click the "Fork" button on GitHub.

2. **Create a Branch**:

   ```bash
   git checkout -b feature/your-feature
   ```

3. **Make Changes**:

   - Add features, fix bugs, or improve documentation.

4. **Commit and Push**:

   ```bash
   git commit -m "Add your feature"
   git push origin feature/your-feature
   ```

5. **Open a Pull Request**:

   - Submit a pull request with a clear description of your changes.

---

## 📜 License

This project is licensed under the **MIT License**. See the LICENSE file for details.

---

## 🙌 Acknowledgments

- Built with ❤️ using .NET 9.0 and C# by Skyler Szijjarto.