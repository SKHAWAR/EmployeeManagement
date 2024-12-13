using Business_Logic_Layer;
using Business_Object_Layer_BOL_;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using DPUruNet;
using System.Text;
using System.Windows.Forms;
using UareUSampleCSharp;
using static DPUruNet.Constants.Formats;
using System.Threading;
using System.Drawing.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace EmployeeManagementSystem
{
    public partial class AddEmployee : MetroFramework.Forms.MetroForm
    {
        public readonly IEmployeeInformationBs EmployeeInformationBs;
        public Dictionary<int, DPUruNet.Fmd> Fmds
        {
            get { return fmds; }
            set { fmds = value; }
        }
        private Dictionary<int, DPUruNet.Fmd> fmds = new Dictionary<int, DPUruNet.Fmd>();

        /// <summary>
        /// Reset the UI causing the user to reselect a reader.
        /// </summary>
        public bool Reset
        {
            get { return reset; }
            set { reset = value; }
        }
        private bool reset;

        public AddEmployee(IEmployeeInformationBs _employeeInformationBs)
        {
            InitializeComponent();
            EmployeeInformationBs = _employeeInformationBs;
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





        private Capture _capture;


        private Verification _verification;
        private void btnVerify_Click(System.Object sender, System.EventArgs e)
        {
            if (_verification == null)
            {
                _verification = new Verification();
                _verification._sender = this;
            }

            _verification.ShowDialog();

            _verification.Dispose();
            _verification = null;
        }

        private Identification _identification;
        private void btnIdentify_Click(System.Object sender, System.EventArgs e)
        {
            if (_identification == null)
            {
                _identification = new Identification();
                _identification._sender = this;
            }

            _identification.ShowDialog();

            _identification.Dispose();
            _identification = null;
        }
        private Stream _stream;
        private void btnStreaming_Click(System.Object sender, System.EventArgs e)
        {
            if (_stream == null)
            {
                _stream = new Stream();
                _stream._sender = this;
            }

            _stream.ShowDialog();

            _stream.Dispose();
            _stream = null;
        }

        EnrollmentControl enrollmentControl;
        private void btnEnrollmentControl_Click(object sender, EventArgs e)
        {
            if (enrollmentControl == null)
            {
                enrollmentControl = new EnrollmentControl();
                enrollmentControl._sender = this;
            }

            enrollmentControl.ShowDialog();
            enrollmentControl.Dispose();
            enrollmentControl = null;

        }

        IdentificationControl identificationControl;
        private void btnIdentificationControl_Click(object sender, EventArgs e)
        {
            if (identificationControl == null)
            {
                identificationControl = new IdentificationControl();
                identificationControl._sender = this;
            }

            identificationControl.ShowDialog();

            identificationControl.Dispose();
            identificationControl = null;
        }

        /// <summary>
        /// Open a device and check result for errors.
        /// </summary>
        /// <returns>Returns true if successful; false if unsuccessful</returns>
        public bool OpenReader()
        {
            using (Tracer tracer = new Tracer("Form_Main::OpenReader"))
            {
                reset = false;
                DPUruNet.Constants.ResultCode result = DPUruNet.Constants.ResultCode.DP_DEVICE_FAILURE;

                // Open reader
                result = currentReader.Open(DPUruNet.Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);

                if (result != DPUruNet.Constants.ResultCode.DP_SUCCESS)
                {
                    MessageBox.Show("Error: Scanner Device is not Attached");
                    reset = true;
                    return false;
                }

                return true;
            }
        }


        public bool StartCaptureAsync(Reader.CaptureCallback OnCaptured)
        {
            using (Tracer tracer = new Tracer("Form_Main::StartCaptureAsync"))
            {
                // Activate capture handler
                currentReader.On_Captured += new Reader.CaptureCallback(OnCaptured);

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
        public void CancelCaptureAndCloseReader(Reader.CaptureCallback OnCaptured)
        {
            using (Tracer tracer = new Tracer("Form_Main::CancelCaptureAndCloseReader"))
            {
                if (currentReader != null)
                {
                    currentReader.CancelCapture();

                    // Dispose of reader handle and unhook reader events.
                    currentReader.Dispose();

                    if (reset)
                    {
                        CurrentReader = null;
                    }
                }
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
        private void label2_Click(object sender, EventArgs e)
        {

        }


        private ReaderCollection _readers;
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
        private const int PROBABILITY_ONE = 0x7fffffff;
        private DPUruNet.Fmd firstFinger;
        DataResult<DPUruNet.Fmd> resultEnrollment;
        List<DPUruNet.Fmd> preenrollmentFmds;
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
                    // Check capture quality and throw an error if bad.
                    if (!CheckCaptureResult(captureResult)) return;

                    count++;

                    DataResult<DPUruNet.Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, DPUruNet.Constants.Formats.Fmd.ANSI);

                    SendMessage(Action.SendMessage, "A finger was captured.  \r\nCount:  " + (count));

                    if (resultConversion.ResultCode != DPUruNet.Constants.ResultCode.DP_SUCCESS)
                    {
                        Reset = true;
                        throw new Exception(resultConversion.ResultCode.ToString());
                    }

                    preenrollmentFmds.Add(resultConversion.Data);

                    if (count >= 4)
                    {
                        resultEnrollment = DPUruNet.Enrollment.CreateEnrollmentFmd(DPUruNet.Constants.Formats.Fmd.ANSI, preenrollmentFmds);

                        if (resultEnrollment.ResultCode == DPUruNet.Constants.ResultCode.DP_SUCCESS)
                        {
                            SendMessage(Action.SendMessage, "An enrollment FMD was successfully created.");
                            SendMessage(Action.SendMessage, "Enter Name in the Employee Name field and" + Environment.NewLine + "Save New Employee");
                            preenrollmentFmds.Clear();
                            count = 0;
                            return;
                        }
                        else if (resultEnrollment.ResultCode == DPUruNet.Constants.ResultCode.DP_ENROLLMENT_INVALID_SET)
                        {
                            SendMessage(Action.SendMessage, "Enrollment was unsuccessful.  Please try again.");
                            SendMessage(Action.SendMessage, "Place a finger on the reader.");
                            preenrollmentFmds.Clear();
                            count = 0;
                            return;
                        }
                    }

                    SendMessage(Action.SendMessage, "Now place the same finger on the reader.");
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
        private void AddEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            CancelCaptureAndCloseReader(this.OnCaptured);
        }

        private void pbFingerprint_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void lblSelectReader_Click(object sender, EventArgs e)
        {

        }

        private void cboReaders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                EmployeeInformation EmpObj = new EmployeeInformation();

                EmpObj.Name = EmployeeNameTextBox.Text;
                EmpObj.ThumbPrint = DPUruNet.Fmd.SerializeXml(resultEnrollment.Data);
                bool value = EmployeeInformationBs.Insert(EmpObj);
                if (currentReader != null)
                {
                    currentReader.CancelCapture();

                    // Dispose of reader handle and unhook reader events.
                    currentReader.Dispose();

                    if (reset)
                    {
                        CurrentReader = null;
                    }
                }
                if (value == true)
                {
                    MessageBox.Show("Employee Add Successfully");
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form is Admin)
                        {
                            form.Close();
                            break;
                        }
                    }
                    var employeeInformationBs = Program.ServiceProvider.GetRequiredService<IEmployeeInformationBs>();
                    Admin newAdmin = new Admin(employeeInformationBs);
                    newAdmin.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to save Employee Information");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CancelCaptureAndCloseReader(this.OnCaptured);
            this.Close();
        }
    }
}
