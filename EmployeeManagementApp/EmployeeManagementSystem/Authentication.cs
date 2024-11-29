using Business_Logic_Layer;
using DPUruNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class Authentication : MetroFramework.Forms.MetroForm
    {
        private readonly IEmployeeInformationBs employeeInformationBs;
        public Dictionary<int, DPUruNet.Fmd> Fmds
        {
            get { return fmds; }
            set { fmds = value; }
        }
        private Dictionary<int, DPUruNet.Fmd> fmds = new Dictionary<int, DPUruNet.Fmd>();

        public Authentication(IEmployeeInformationBs _employeeInformationBs)
        {
            employeeInformationBs = _employeeInformationBs;
            InitializeComponent();
        }

        private void Authentication_Load(object sender, EventArgs e)
        {
            LoadScanners();
            firstFinger = null;
            resultEnrollment = null;
            preenrollmentFmds = new List<DPUruNet.Fmd>();
            pbFingerprint.Image = null;
            if (CurrentReader != null)
            {
                CurrentReader.Dispose();
                CurrentReader = null;
            }
            CurrentReader = _readers[cboReaders.SelectedIndex];
            if (!OpenReader())
            {
                //this.Close();
            }
            if (!StartCaptureAsync(this.OnCaptured))
            {
                //this.Close();
            }

        }
        private Reader currentReader;
        private int count = 0;

        public Reader CurrentReader
        {
            get { return currentReader; }
            set
            {
                currentReader = value;
                SendMessage(Action.UpdateReaderState, value);
            }
        }
        private ReaderCollection _readers;
        private const int PROBABILITY_ONE = 0x7fffffff;
        private DPUruNet.Fmd firstFinger;
        DataResult<DPUruNet.Fmd> resultEnrollment;
        List<DPUruNet.Fmd> preenrollmentFmds;
        private bool reset;

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            LoadScanners();
            firstFinger = null;
            resultEnrollment = null;
            preenrollmentFmds = new List<DPUruNet.Fmd>();
            pbFingerprint.Image = null;
            if (CurrentReader != null)
            {
                CurrentReader.Dispose();
                CurrentReader = null;
            }
            CurrentReader = _readers[cboReaders.SelectedIndex];
            if (!OpenReader())
            {
                //this.Close();
            }
            if (!StartCaptureAsync(this.OnCaptured))
            {
                //this.Close();
            }



        }
        private enum Action
        {
            UpdateReaderState,
            SendBitmap,
            SendMessage
        }
        private delegate void SendMessageCallback(Action state, object payload);
        private void SendMessage(Action action, object payload)
        {
            try
            {
                if (this.pbFingerprint.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { action, payload });
                }
                else
                {
                    switch (action)
                    {
                        case Action.SendMessage:
                            MessageBox.Show((string)payload);
                            break;
                        case Action.SendBitmap:
                            pbFingerprint.Image = (Bitmap)payload;
                            pbFingerprint.Refresh();
                            break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Reset
        {
            get { return reset; }
            set { reset = value; }
        }
        public void OnCaptured(CaptureResult captureResult)
        {
            try
            {
                if (!CheckCaptureResult(captureResult)) return;

                foreach (DPUruNet.Fid.Fiv fiv in captureResult.Data.Views)
                {
                    SendMessage(Action.SendBitmap, CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                }
                try
                {
                    if (!CheckCaptureResult(captureResult)) return;

                    SendMessage(Action.SendMessage, "A finger was captured.");

                    DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);
                    if (resultConversion.ResultCode != Constants.ResultCode.DP_SUCCESS)
                    {
                        if (resultConversion.ResultCode != Constants.ResultCode.DP_TOO_SMALL_AREA)
                        {
                            Reset = true;
                        }
                        throw new Exception(resultConversion.ResultCode.ToString());
                    }
                    string fmdAsString = Convert.ToBase64String(resultConversion.Data.Bytes);
                   var value= employeeInformationBs.GetById(fmdAsString);

                    if (value !=null)
                    {
                        SendMessage(Action.SendMessage, "Place a finger on the reader.");
                    }
                    else
                    {
                        SendMessage(Action.SendMessage, "Fringer print not matched");
                    }

                }
                catch (Exception ex)
                {
                    // Send error message, then close form
                    SendMessage(Action.SendMessage, "Error:  " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                // Send error message, then close form
                SendMessage(Action.SendMessage, "Error:  " + ex.Message);
            }
        }
        public bool CheckCaptureResult(CaptureResult captureResult)
        {
            using (Tracer tracer = new Tracer("Form_Main::CheckCaptureResult"))
            {
                if (captureResult.Data == null || captureResult.ResultCode != DPUruNet.Constants.ResultCode.DP_SUCCESS)
                {
                    if (captureResult.ResultCode != DPUruNet.Constants.ResultCode.DP_SUCCESS)
                    {
                        reset = true;
                        throw new Exception(captureResult.ResultCode.ToString());
                    }

                    if ((captureResult.Quality != DPUruNet.Constants.CaptureQuality.DP_QUALITY_CANCELED))
                    {
                        throw new Exception("Quality - " + captureResult.Quality);
                    }
                    return false;
                }

                return true;
            }
        }
        public Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];

            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt64() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);

            return bmp;
        }
        private void LoadScanners()
        {
            cboReaders.Text = string.Empty;
            cboReaders.Items.Clear();
            cboReaders.SelectedIndex = -1;
            try
            {
                _readers = ReaderCollection.GetReaders();
                foreach (Reader Reader in _readers)
                {
                    cboReaders.Items.Add(Reader.Description.Name);
                }
                if (cboReaders.Items.Count > 0)
                {
                    cboReaders.SelectedIndex = 0;
                    //btnCaps.Enable=true;
                    //btnSelect.Enable=true;
                }
                else
                {
                    //btnSelect.Enable=false;
                    //btnCaps.Enable=true;
                }
            }
            catch (Exception Ex)
            {
                String text = Ex.Message;
                text += "\r\n\r\nPlease check if DigitalPersona Service has been started";
                String caption = "cannot access reader";
                MessageBox.Show(text, caption);

            }
        }
        public bool OpenReader()
        {
            using (Tracer tracer = new Tracer("Form_Main::OpenReader"))
            {
                reset = false;
                DPUruNet.Constants.ResultCode result = DPUruNet.Constants.ResultCode.DP_DEVICE_FAILURE;

                // Open reader
                //                result = currentReader.Open(DPUruNet.Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);

                if (result != DPUruNet.Constants.ResultCode.DP_SUCCESS)
                {
                    MessageBox.Show("Error: Scanner Device is not Attached");
                    reset = true;
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Hookup capture handler and start capture.
        /// </summary>
        /// <param name="OnCaptured">Delegate to hookup as handler of the On_Captured event</param>
        /// <returns>Returns true if successful; false if unsuccessful</returns>
        public bool StartCaptureAsync(Reader.CaptureCallback OnCaptured)
        {
            using (Tracer tracer = new Tracer("Form_Main::StartCaptureAsync"))
            {
                // Activate capture handler
                //       currentReader.On_Captured += new Reader.CaptureCallback(OnCaptured);

                // Call capture
                if (!CaptureFingerAsync())
                {
                    return false;
                }

                return true;
            }
        }
        public bool CaptureFingerAsync()
        {
            using (Tracer tracer = new Tracer("Form_Main::CaptureFingerAsync"))
            {
                try
                {
                    GetStatus();

                    DPUruNet.Constants.ResultCode captureResult = currentReader.CaptureAsync(DPUruNet.Constants.Formats.Fid.ANSI, DPUruNet.Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, currentReader.Capabilities.Resolutions[0]);
                    if (captureResult != DPUruNet.Constants.ResultCode.DP_SUCCESS)
                    {
                        reset = true;
                        throw new Exception("" + captureResult);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:  " + ex.Message);
                    return false;
                }
            }
        }
        public void GetStatus()
        {
            using (Tracer tracer = new Tracer("Form_Main::GetStatus"))
            {
                DPUruNet.Constants.ResultCode result = currentReader.GetStatus();

                if ((result != DPUruNet.Constants.ResultCode.DP_SUCCESS))
                {
                    reset = true;
                    throw new Exception("" + result);
                }

                if ((currentReader.Status.Status == DPUruNet.Constants.ReaderStatuses.DP_STATUS_BUSY))
                {
                    Thread.Sleep(50);
                }
                else if ((currentReader.Status.Status == DPUruNet.Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION))
                {
                    currentReader.Calibrate();
                }
                else if ((currentReader.Status.Status != DPUruNet.Constants.ReaderStatuses.DP_STATUS_READY))
                {
                    throw new Exception("Reader Status - " + currentReader.Status.Status);
                }
            }
        }
    }
}
