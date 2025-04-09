using System; // keybinds??? or even search via folder before then index? // ints dont work for load
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SharpHook;
using SharpHook.Reactive;
using SharpHook.Native;

namespace AntiRecoil2
{

    public partial class Form1 : Form
    {
        public static class Globals
        {
            public static bool LeftMouseDown = false;
            public static bool RightMouseDown = false;
            public static Thread? RecoilThread;
            public static bool ZimToggle = false;
            public static Thread? ZimThread;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            public int type;
            public MOUSEINPUT mi;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);
        static void SimulateMouseMovement(int dx, int dy)
        {
            INPUT[] input = new INPUT[1];
            input[0].type = 0; // Mouse Input
            input[0].mi.dx = dx;
            input[0].mi.dy = dy;
            input[0].mi.mouseData = 0;
            input[0].mi.dwFlags = 0x0001;
            input[0].mi.time = 0;
            input[0].mi.dwExtraInfo = IntPtr.Zero;

            SendInput(1, input, Marshal.SizeOf(typeof(INPUT)));
        }
        static void MousePressed(MouseHookEventArgs e)
        {
            if (e.Data.Button == MouseButton.Button1)
                Globals.LeftMouseDown = true;
            if (e.Data.Button == MouseButton.Button2)
                Globals.RightMouseDown = true;

            Console.WriteLine($"Pressed {e.Data.Button} at X: {e.Data.X}, Y: {e.Data.Y}");

            if (Globals.LeftMouseDown == true && Globals.RightMouseDown == true)
            {
                if (Globals.RecoilThread == null || !Globals.RecoilThread.IsAlive)
                {
                    Globals.RecoilThread = new Thread(Recoil);
                    Globals.RecoilThread.IsBackground = true;
                    Globals.RecoilThread.Start();
                }
            }
        }
        static void MouseReleased(MouseHookEventArgs e)
        {
            if (e.Data.Button == MouseButton.Button1)
                Globals.LeftMouseDown = false;
            if (e.Data.Button == MouseButton.Button2)
                Globals.RightMouseDown = false;

            Console.WriteLine($"Released {e.Data.Button} at X: {e.Data.X}, Y: {e.Data.Y}");

            if (!Globals.LeftMouseDown || !Globals.RightMouseDown)
            {
                Globals.RecoilThread = null;
            }
        }
        public static Form1 Instance;
        private SimpleReactiveGlobalHook? hook;
        public Form1()
        {
            InitializeComponent();
            Instance = this;
            OpenConfig();
            hook = new SimpleReactiveGlobalHook();
            hook.MousePressed.Subscribe(e => Task.Run(() => MousePressed(e)).ConfigureAwait(false));
            hook.MouseReleased.Subscribe(e => Task.Run(() => MouseReleased(e)).ConfigureAwait(false));
            hook.KeyPressed.Subscribe(e => Task.Run(() => KeyboardPressed(e)).ConfigureAwait(false));
            hook.RunAsync();
            this.FormClosing += Form1_FormClosing;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hook != null)
            {
                hook.Dispose();
                hook = null;
            }
        }
        private static void SaveToIni()
        {
            string filePath = "config.ini";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Button5Text=" + Form1.Instance.button5.Text);
                writer.WriteLine("Button6Text=" + Form1.Instance.button6.Text);
                writer.WriteLine("Button7Text=" + Form1.Instance.button7.Text);
            }
        }

        private static void OpenConfig()
        {
            string filePath = "config.ini";
            if (File.Exists(filePath))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split('=');
                            if (parts.Length == 2)
                            {
                                string key = parts[0].Trim();
                                string value = parts[1].Trim();

                                if (key == "Button5Text")
                                {
                                    Form1.Instance.button5.Text = value;
                                }
                                else if (key == "Button6Text")
                                {
                                    Form1.Instance.button6.Text = value;
                                }
                                else if (key == "Button7Text")
                                {
                                    Form1.Instance.button7.Text = value;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error reading the config file. Resetting to default values.");
                    Form1.Instance.button5.Text = "F1";
                    Form1.Instance.button6.Text = "F2";
                    Form1.Instance.button7.Text = "F3";
                }
            }
            else
            {
                MessageBox.Show("Config file not found. Resetting to default F1/F2.");
                Form1.Instance.button5.Text = "F1";
                Form1.Instance.button6.Text = "F2";
                Form1.Instance.button7.Text = "F3";
            }
        }

        private static DateTime lastKeyPressTime = DateTime.MinValue;
        static void KeyboardPressed(KeyboardHookEventArgs e)
        {
            Form1.Instance.Invoke(new Action(() =>
            {
                if (Form1.Instance.button5.Text == "Press Key")
                {
                    Form1.Instance.button5.Text = e.Data.KeyCode.ToString().Substring(2);
                    SaveToIni();
                    return;
                }
                else if (Form1.Instance.button6.Text == "Press Key")
                {
                    Form1.Instance.button6.Text = e.Data.KeyCode.ToString().Substring(2);
                    SaveToIni();
                    return;
                }
                else if (Form1.Instance.button7.Text == "Press Key")
                {
                    Form1.Instance.button7.Text = e.Data.KeyCode.ToString().Substring(2);
                    SaveToIni();
                    return;
                }
            }));

            string pressedKey = e.Data.KeyCode.ToString().Substring(2);
            Form1.Instance.Invoke(new Action(() =>
            {
                if (pressedKey == Form1.Instance.button5.Text)
                {
                    Form1.Instance.label3.Text = "ON";
                }
                else if (pressedKey == Form1.Instance.button6.Text)
                {
                    Form1.Instance.label3.Text = "OFF";
                }
                else if (pressedKey == Form1.Instance.button7.Text)
                {
                    DateTime now = DateTime.Now;
                    if ((now - lastKeyPressTime).TotalMilliseconds < 150) return; // Prevent rapid double presses
                    lastKeyPressTime = now;

                    Globals.ZimToggle = !Globals.ZimToggle;

                    if (Globals.ZimToggle)
                    {
                        if (Globals.ZimThread == null || !Globals.ZimThread.IsAlive)
                        {
                            Globals.ZimThread = new Thread(Zim)
                            {
                                IsBackground = true
                            };
                            Globals.ZimThread.Start();
                        }
                    }
                    else
                    {
                        Globals.ZimToggle = false;
                        Globals.ZimThread = null;
                    }
                }
            }));
        }
        private static readonly EventSimulator simulator = new EventSimulator();

        static void Zim()
        {
            while (Globals.ZimToggle)
            {
                Thread.Sleep(20);
                SimulateMouseMovement(10000, 0);
                simulator.SimulateKeyPress(KeyCode.VcC);
                Thread.Sleep(20);
                simulator.SimulateKeyRelease(KeyCode.VcC);
            }
        }

        static void Recoil()
        {
            double switchTime = 1000;
            double elapsedTime = 0;
            DateTime startTime = DateTime.Now;

            try
            {
                string input = Form1.Instance.textBox1.Text.Trim();

                // If input is empty, use default (1000)
                if (!string.IsNullOrEmpty(input) && !double.TryParse(input, out switchTime))
                {
                    MessageBox.Show("Invalid input for switch time. Please enter a valid number.");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Unexpected error while processing the switch time.");
                return;
            }

            while (Globals.LeftMouseDown && Globals.RightMouseDown)
            {
                if (Form1.Instance.label3.Text == "ON")
                {
                    elapsedTime = (DateTime.Now - startTime).TotalSeconds;

                    int x = 0, y = 0;
                    if (elapsedTime >= switchTime)
                    {
                        x = int.Parse(Form1.Instance.label8.Text.Split(':')[1].Trim());
                        y = int.Parse(Form1.Instance.label9.Text.Split(':')[1].Trim());
                    }
                    else
                    {
                        x = int.Parse(Form1.Instance.label1.Text.Split(':')[1].Trim());
                        y = int.Parse(Form1.Instance.label2.Text.Split(':')[1].Trim());
                    }

                    SimulateMouseMovement(y, x);

                    Thread.Sleep(1);
                }
            }
        }






        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Y: " + trackBar2.Value;
        }


        private int flag = 1;

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            label1.Text = "X: " + trackBar1.Value;
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            flag *= -1;

            if (flag == -1)
            {
                trackBar1.Hide();
                trackBar2.Hide();
                trackBar3.Hide();
                trackBar4.Hide();
            }
            else
            {
                trackBar1.Show();
                trackBar2.Show();
                trackBar3.Show();
                trackBar4.Show();
            }
        }

        private void button1_Click_1(object sender, EventArgs e) // LOAD
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = System.Environment.CurrentDirectory;
                openFileDialog.Filter = "INI files (*.ini)|*.ini";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var sr = new StreamReader(openFileDialog.FileName))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split('=');

                            string key = parts[0].Trim();
                            string valueStr = parts[1].Trim();

                            if (int.TryParse(valueStr, out int intValue))
                            {
                                switch (key)
                                {
                                    case "X":
                                        trackBar1.Value = intValue;
                                        break;
                                    case "Y":
                                        trackBar2.Value = intValue;
                                        break;
                                    case "X2":
                                        trackBar3.Value = intValue;
                                        break;
                                    case "Y2":
                                        trackBar4.Value = intValue;
                                        break;
                                }
                            }
                            else if (key == "Delay")
                            {
                                if (double.TryParse(valueStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double delayValue))
                                {
                                    textBox1.Text = delayValue.ToString("0.##");
                                }
                                else
                                {
                                    textBox1.Text = "";
                                }
                            }
                        }
                        label1.Text = "X: " + trackBar1.Value;
                        label2.Text = "Y: " + trackBar2.Value;
                        label8.Text = "X2: " + trackBar3.Value;
                        label9.Text = "Y2: " + trackBar4.Value;
                        label7.Text = "Current Op: " + Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                    }
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = System.Environment.CurrentDirectory;
                saveFileDialog.Filter = "INI files (*.ini)|*.ini";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = "config.ini";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] data = new string[5];
                    data[0] = "X=" + trackBar1.Value;
                    data[1] = "Y=" + trackBar2.Value;
                    data[2] = "X2=" + trackBar3.Value;
                    data[3] = "Y2=" + trackBar4.Value;
                    data[4] = "Delay=" + textBox1.Text;
                    using (var sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (string line in data)
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }
        }

        private void trackBar3_Scroll_1(object sender, EventArgs e)
        {
            label8.Text = "X2: " + trackBar3.Value;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label9.Text = "Y2: " + trackBar4.Value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "X: " + 0;
            label2.Text = "Y: " + 0;
            label8.Text = "X2: " + 0;
            label9.Text = "Y2: " + 0;
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
            trackBar4.Value = 0;
            textBox1.Text = "";
        }
        internal static class NativeMethods
        {
            [DllImport("user32.dll")]
            public static extern bool RegisterHotKey(IntPtr windowHandle, int hotkeyId, uint modifierKeys, uint virtualKey);

            [DllImport("user32.dll")]
            public static extern bool UnregisterHotKey(IntPtr windowHandle, int hotkeyId);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Text = "Press Key";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Text = "Press Key";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            button7.Text = "Press Key";
        }
    }
}