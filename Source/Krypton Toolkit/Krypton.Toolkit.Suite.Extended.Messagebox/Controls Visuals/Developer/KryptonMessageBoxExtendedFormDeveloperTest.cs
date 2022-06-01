﻿namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    internal partial class KryptonMessageBoxExtendedFormDeveloperTest : KryptonForm
    {
        #region Static Fields
        private const int GAP = 10;
        private static readonly int OS_MAJOR_VERSION;
        #endregion

        #region Instance Fields
        private readonly string _text;
        private readonly string _caption;
        private readonly ExtendedMessageBoxButtons _buttons;
        private readonly ExtendedKryptonMessageBoxIcon _kryptonMessageBoxIcon;

        private readonly MessageBoxDefaultButton _defaultButton;
        private readonly MessageBoxOptions _options; // https://github.com/Krypton-Suite/Standard-Toolkit/issues/313
        // If help information provided or we are not a service/default desktop application then grab an owner for showing the message box
        private readonly IWin32Window _showOwner;
        private readonly HelpInfo _helpInfo;

        #endregion

        #region Extended Fields

        private readonly bool _showOptionalCheckBox;

        private readonly bool _showOptionalLinkLabel;

        private readonly bool _isOptionalCheckBoxChecked;

        private readonly CheckState _optionalCheckBoxCheckState;

        private readonly Font _messageBoxTypeface;

        private readonly Image _customImageIcon;

        private readonly string _optionalCheckBoxText;

        private readonly string _optionalLinkLabelText;

        private readonly string _optionalLinkLabelDestination;

        #endregion

        #region Identity
        static KryptonMessageBoxExtendedFormDeveloperTest() => OS_MAJOR_VERSION = Environment.OSVersion.Version.Major;

        public KryptonMessageBoxExtendedFormDeveloperTest() => InitializeComponent();


        /// <summary>Initializes a new instance of the <see cref="KryptonMessageBoxExtendedFormDeveloperTest" /> class.</summary>
        /// <param name="showOwner">The show owner.</param>
        /// <param name="text">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="helpInfo">The help information.</param>
        /// <param name="showCtrlCopy">The show control copy.</param>
        /// <param name="messageBoxTypeface">The message box typeface.</param>
        /// <param name="customImageIcon">The custom image icon.</param>
        /// <param name="showOptionalCheckBox">The show optional CheckBox.</param>
        /// <param name="optionalCheckBoxChecked">The optional CheckBox checked.</param>
        /// <param name="optionalCheckBoxCheckState">State of the optional CheckBox check.</param>
        /// <param name="optionalCheckBoxText">The optional CheckBox text.</param>
        /// <param name="showOptionalLinkLabel">The show optional link label.</param>
        /// <param name="optionalLinkLabelText">The optional link label text.</param>
        /// <param name="optionalLinkLabelDestination">The optional link label destination.</param>
        internal KryptonMessageBoxExtendedFormDeveloperTest(IWin32Window showOwner, string text, string caption,
                                               ExtendedMessageBoxButtons buttons,
                                               ExtendedKryptonMessageBoxIcon icon,
                                               MessageBoxDefaultButton defaultButton, 
                                               MessageBoxOptions options,
                                               HelpInfo helpInfo, bool? showCtrlCopy, 
                                               Font messageBoxTypeface, Image customImageIcon,
                                               bool? showOptionalCheckBox, bool? optionalCheckBoxChecked,
                                               CheckState? optionalCheckBoxCheckState,
                                               string optionalCheckBoxText, bool? showOptionalLinkLabel,
                                               string optionalLinkLabelText, string optionalLinkLabelDestination)
        {
            // Store incoming values
            _text = text;
            _caption = caption;
            _buttons = buttons;
            _kryptonMessageBoxIcon = icon;
            _customImageIcon = customImageIcon;
            _defaultButton = defaultButton;
            _options = options;
            _helpInfo = helpInfo;
            _showOwner = showOwner;

            _messageBoxTypeface = messageBoxTypeface ?? new Font(@"Segoe UI", 8.25F);

            _showOptionalCheckBox = showOptionalCheckBox ?? showOptionalCheckBox.GetValueOrDefault();

            _isOptionalCheckBoxChecked = optionalCheckBoxChecked ?? optionalCheckBoxChecked.GetValueOrDefault();

            _showOptionalLinkLabel = showOptionalLinkLabel ?? showOptionalLinkLabel.GetValueOrDefault();

            _optionalCheckBoxCheckState = optionalCheckBoxCheckState ?? optionalCheckBoxCheckState.GetValueOrDefault();

            _optionalCheckBoxText = optionalCheckBoxText;

            _optionalLinkLabelText = optionalLinkLabelText;

            _optionalLinkLabelDestination = optionalLinkLabelDestination;

            // Create the form contents
            InitializeComponent();

            RightToLeftLayout = _options.HasFlag(MessageBoxOptions.RtlReading);

            // Update contents to match requirements
            UpdateText();
            UpdateIcon();
            UpdateButtons();
            UpdateDefault();
            UpdateHelp();
            UpdateTextExtra(showCtrlCopy);

            SetupCheckBox();

            SetupOptionalLink();

            // Finally calculate and set form sizing
            UpdateSizing(showOwner);
        }
        #endregion Identity

        #region Methods

        private void UpdateText()
        {
            Text = string.IsNullOrEmpty(_caption) ? string.Empty : _caption.Split(Environment.NewLine.ToCharArray())[0];

            _messageText.StateCommon.Font = _messageBoxTypeface;

            _messageText.Text = _text;
            _messageText.RightToLeft = _options.HasFlag(MessageBoxOptions.RightAlign)
                ? RightToLeft.Yes
                : _options.HasFlag(MessageBoxOptions.RtlReading)
                    ? RightToLeft.Inherit
                    : RightToLeft.No;
        }

        private void UpdateTextExtra(bool? showCtrlCopy)
        {
            if (!showCtrlCopy.HasValue)
            {
                switch (_kryptonMessageBoxIcon)
                {
                    case ExtendedKryptonMessageBoxIcon.ERROR:
                    case ExtendedKryptonMessageBoxIcon.EXCLAMATION:
                        showCtrlCopy = true;
                        break;
                }
            }

            if (showCtrlCopy == true)
            {
                TextExtra = @"Ctrl+c to copy";
            }
        }

        private void UpdateIcon()
        {
            switch (_kryptonMessageBoxIcon)
            {
                default:
                case ExtendedKryptonMessageBoxIcon.NONE:
                    // Windows XP and before will Beep, Vista and above do not!
                    if (OS_MAJOR_VERSION < 6)
                    {
                        SystemSounds.Beep.Play();
                    }
                    break;
                case ExtendedKryptonMessageBoxIcon.CUSTOM:
                    _messageIcon.Image = _customImageIcon;
                    break;
                case ExtendedKryptonMessageBoxIcon.QUESTION:
                    _messageIcon.Image = Properties.Resources.Question;
                    SystemSounds.Question.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.EXCLAMATION:
                    // _messageIcon.Image = Properties.Resources.e
                case ExtendedKryptonMessageBoxIcon.INFORMATION:
                    _messageIcon.Image = Properties.Resources.Information;
                    SystemSounds.Asterisk.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.WARNING:
                    _messageIcon.Image = Properties.Resources.Warning;
                    SystemSounds.Exclamation.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.ERROR:
                    _messageIcon.Image = Properties.Resources.Critical;
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.ASTERISK:
                    _messageIcon.Image = Properties.Resources.Asterisk;
                    SystemSounds.Asterisk.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.HAND:
                    _messageIcon.Image = Properties.Resources.Hand;
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.STOP:
                    _messageIcon.Image = Properties.Resources.Stop;
                    SystemSounds.Hand.Play();
                    break;
                case ExtendedKryptonMessageBoxIcon.SHIELD:
                    _messageIcon.Image = SystemIcons.Shield.ToBitmap();
                    break;
                case ExtendedKryptonMessageBoxIcon.WINDOWSLOGO:
                    // Because Windows 11 displays a generic application icon,
                    // we need to rely on a image instead
                    if (Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= 22000)
                    {
                        _messageIcon.Image = Properties.Resources.Windows11;
                    }
                    // Windows 10
                    else if (Environment.OSVersion.Version.Major == 10 && Environment.OSVersion.Version.Build <= 19044 /* RTM - 21H2 */)
                    {
                        _messageIcon.Image = Properties.Resources.Windows_8_and_10_Logo;
                    }
                    else
                    {
                        _messageIcon.Image = SystemIcons.WinLogo.ToBitmap();
                    }

                    break;
            }

            _messageIcon.Visible = (_kryptonMessageBoxIcon != ExtendedKryptonMessageBoxIcon.NONE);

        }

        private void UpdateButtons()
        {
            switch (_buttons)
            {
                case ExtendedMessageBoxButtons.OK:
                    _button1.Text = KryptonManager.Strings.OK;
                    _button1.DialogResult = DialogResult.OK;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.OKCANCEL:
                    _button1.Text = KryptonManager.Strings.OK;
                    _button2.Text = KryptonManager.Strings.Cancel;
                    _button1.DialogResult = DialogResult.OK;
                    _button2.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.YESNO:
                    _button1.Text = KryptonManager.Strings.Yes;
                    _button2.Text = KryptonManager.Strings.No;
                    _button1.DialogResult = DialogResult.Yes;
                    _button2.DialogResult = DialogResult.No;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    ControlBox = false;
                    break;
                case ExtendedMessageBoxButtons.YESNOCANCEL:
                    _button1.Text = KryptonManager.Strings.Yes;
                    _button2.Text = KryptonManager.Strings.No;
                    _button3.Text = KryptonManager.Strings.Cancel;
                    _button1.DialogResult = DialogResult.Yes;
                    _button2.DialogResult = DialogResult.No;
                    _button3.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button3.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    _button3.Visible = true;
                    _button3.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.RETRYCANCEL:
                    _button1.Text = KryptonManager.Strings.Retry;
                    _button2.Text = KryptonManager.Strings.Cancel;
                    _button1.DialogResult = DialogResult.Retry;
                    _button2.DialogResult = DialogResult.Cancel;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button3.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    break;
                case ExtendedMessageBoxButtons.ABORTRETRYIGNORE:
                    _button1.Text = KryptonManager.Strings.Abort;
                    _button2.Text = KryptonManager.Strings.Retry;
                    _button3.Text = KryptonManager.Strings.Ignore;
                    _button1.DialogResult = DialogResult.Abort;
                    _button2.DialogResult = DialogResult.Retry;
                    _button3.DialogResult = DialogResult.Ignore;
                    _button1.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button2.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button3.StateCommon.Content.ShortText.Font = _messageBoxTypeface;
                    _button1.Visible = true;
                    _button1.Enabled = true;
                    _button2.Visible = true;
                    _button2.Enabled = true;
                    _button3.Visible = true;
                    _button3.Enabled = true;
                    ControlBox = false;
                    break;
            }

            // Do we ignore the Alt+F4 on the buttons?
            if (!ControlBox)
            {
                _button1.IgnoreAltF4 = true;
                _button2.IgnoreAltF4 = true;
                _button3.IgnoreAltF4 = true;
                _button4.IgnoreAltF4 = true;
            }
        }

        private void UpdateDefault()
        {
            switch (_defaultButton)
            {
                case MessageBoxDefaultButton.Button2:
                    _button2.Select();
                    break;
                case MessageBoxDefaultButton.Button3:
                    _button3.Select();
                    break;
            }
        }

        private void UpdateHelp()
        {
            if (_helpInfo == null)
            {
                return;
            }

            MessageButton helpButton = _buttons switch
            {
                ExtendedMessageBoxButtons.OK => _button2,
                ExtendedMessageBoxButtons.OKCANCEL or ExtendedMessageBoxButtons.YESNO or ExtendedMessageBoxButtons.RETRYCANCEL => _button3,
                ExtendedMessageBoxButtons.ABORTRETRYIGNORE or ExtendedMessageBoxButtons.YESNO => _button4,
                _ => throw new ArgumentOutOfRangeException()
            };
            if (helpButton != null)
            {
                helpButton.Visible = true;
                helpButton.Enabled = true;
                helpButton.Text = KryptonManager.Strings.Help;
                helpButton.KeyPress += (_, _) => LaunchHelp();
                helpButton.Click += (_, _) => LaunchHelp();
            }
        }

        /// <summary>
        /// When the user clicks the Help button, the Help file specified in the helpFilePath parameter
        /// is opened and the Help keyword topic identified by the keyword parameter is Displayed.
        /// The form that owns the message box (or the active form) also receives the HelpRequested event.
        /// </summary>
        private void LaunchHelp()
        {
            try
            {
                Control control = FromHandle(_showOwner.Handle);

                MethodInfo mInfoMethod = control.GetType().GetMethod(@"OnHelpRequested", BindingFlags.Instance | BindingFlags.NonPublic,
                    Type.DefaultBinder, new[] { typeof(HelpEventArgs) }, null);
                if (mInfoMethod != null)
                {
                    mInfoMethod.Invoke(control, new object[] { new HelpEventArgs(MousePosition) });
                }
                if (string.IsNullOrWhiteSpace(_helpInfo.HelpFilePath))
                {
                    return;
                }

                if (!string.IsNullOrWhiteSpace(_helpInfo.Keyword))
                {
                    Help.ShowHelp(control, _helpInfo.HelpFilePath, _helpInfo.Keyword);
                }
                else
                {
                    Help.ShowHelp(control, _helpInfo.HelpFilePath, _helpInfo.Navigator, _helpInfo.Param);
                }
            }
            catch
            {
                // Do nothing if failure to send to Parent
            }

        }

        private void UpdateSizing(IWin32Window showOwner)
        {
            Size messageSizing = UpdateMessageSizing(showOwner);
            Size buttonsSizing = UpdateButtonsSizing();

            // Size of window is calculated from the client area
            if (_showOptionalLinkLabel)
            {
                ClientSize = new Size(Math.Max(messageSizing.Width, buttonsSizing.Width),
                    messageSizing.Height + buttonsSizing.Height + _panelOptionalLinkLabel.Height);
            }
            else if (_showOptionalCheckBox)
            {
                ClientSize = new Size(Math.Max(messageSizing.Width, buttonsSizing.Width), // We assume that the '_panelCheckBox' width is the same as the _panelButtons width
                    messageSizing.Height + buttonsSizing.Height + _panelOptionalCheckbox.Height);
            }
            else if (_showOptionalCheckBox && _showOptionalLinkLabel)
            {
                ClientSize = new Size(Math.Max(messageSizing.Width, buttonsSizing.Width),
                    messageSizing.Height + buttonsSizing.Height + _panelOptionalCheckbox.Height + _panelOptionalLinkLabel.Height);
            }
            else
            {
                ClientSize = new Size(Math.Max(messageSizing.Width, buttonsSizing.Width),
                    messageSizing.Height + buttonsSizing.Height); 
            }
        }

        private Size UpdateMessageSizing(IWin32Window showOwner)
        {
            // Update size of the message label but with a maximum width
            Size textSize;
            using (Graphics g = CreateGraphics())
            {
                // Find size of the label, with a max of 2/3 screen width
                Screen screen = showOwner != null ? Screen.FromHandle(showOwner.Handle) : Screen.PrimaryScreen;
                SizeF scaledMonitorSize = screen.Bounds.Size;
                scaledMonitorSize.Width *= 2 / 3.0f;
                scaledMonitorSize.Height *= 0.95f;
                _messageText.UpdateFont();
                SizeF messageSize = g.MeasureString(_text, _messageText.Font, scaledMonitorSize);
                // SKC: Don't forget to add the TextExtra into the calculation
                SizeF captionSize = g.MeasureString($@"{_caption} {TextExtra}", _messageText.Font, scaledMonitorSize);

                var messageXSize = Math.Max(messageSize.Width, captionSize.Width);
                // Work out DPI adjustment factor
                var factorX = g.DpiX > 96 ? (1.0f * g.DpiX / 96) : 1.0f;
                var factorY = g.DpiY > 96 ? (1.0f * g.DpiY / 96) : 1.0f;
                messageSize.Width = messageXSize * factorX;
                messageSize.Height *= factorY;

                // Always add on ad extra 5 pixels as sometimes the measure size does not draw the last 
                // character it contains, this ensures there is always definitely enough space for it all
                messageSize.Width += 5;
                textSize = Size.Ceiling(messageSize);
            }

            return new Size(textSize.Width + _messageIcon.Width + _messageIcon.Margin.Left + _messageIcon.Margin.Right +
                            _messageText.Margin.Left + _messageText.Margin.Right,
                Math.Max(_messageIcon.Height + 10, textSize.Height));
        }

        private Size UpdateButtonsSizing()
        {
            var numButtons = 1;

            // Button1 is always visible
            Size button1Size = _button1.GetPreferredSize(Size.Empty);
            Size maxButtonSize = new(button1Size.Width + GAP, button1Size.Height);

            // If Button2 is visible
            if (_button2.Enabled)
            {
                numButtons++;
                Size button2Size = _button2.GetPreferredSize(Size.Empty);
                maxButtonSize.Width = Math.Max(maxButtonSize.Width, button2Size.Width + GAP);
                maxButtonSize.Height = Math.Max(maxButtonSize.Height, button2Size.Height);
            }

            // If Button3 is visible
            if (_button3.Enabled)
            {
                numButtons++;
                Size button3Size = _button3.GetPreferredSize(Size.Empty);
                maxButtonSize.Width = Math.Max(maxButtonSize.Width, button3Size.Width + GAP);
                maxButtonSize.Height = Math.Max(maxButtonSize.Height, button3Size.Height);
            }
            // If Button4 is visible
            if (_button4.Enabled)
            {
                numButtons++;
                Size button4Size = _button4.GetPreferredSize(Size.Empty);
                maxButtonSize.Width = Math.Max(maxButtonSize.Width, button4Size.Width + GAP);
                maxButtonSize.Height = Math.Max(maxButtonSize.Height, button4Size.Height);
            }

            // Start positioning buttons 10 pixels from right edge
            var right = _panelButtons.Right - GAP;

            // If Button4 is visible
            if (_button4.Enabled)
            {
                _button4.Location = new Point(right - maxButtonSize.Width, GAP);
                _button4.Size = maxButtonSize;
                right -= maxButtonSize.Width + GAP;
            }

            // If Button3 is visible
            if (_button3.Enabled)
            {
                _button3.Location = new Point(right - maxButtonSize.Width, GAP);
                _button3.Size = maxButtonSize;
                right -= maxButtonSize.Width + GAP;
            }

            // If Button2 is visible
            if (_button2.Enabled)
            {
                _button2.Location = new Point(right - maxButtonSize.Width, GAP);
                _button2.Size = maxButtonSize;
                right -= maxButtonSize.Width + GAP;
            }

            // Button1 is always visible
            _button1.Location = new Point(right - maxButtonSize.Width, GAP);
            _button1.Size = maxButtonSize;

            // Size the panel for the buttons
            _panelButtons.Size = new Size((maxButtonSize.Width * numButtons) + (GAP * (numButtons + 1)), maxButtonSize.Height + (GAP * 2));

            // Button area is the number of buttons with gaps between them and 10 pixels around all edges
            return new Size((maxButtonSize.Width * numButtons) + (GAP * (numButtons + 1)), maxButtonSize.Height + (GAP * 2));
        }

        private void AnyKeyDown(object sender, KeyEventArgs e)
        {
            // Escape key kills the dialog if we allow it to be closed
            if (ControlBox
                && (e.KeyCode == Keys.Escape)
               )
            {
                Close();
            }
            else if (!e.Control
                     || (e.KeyCode != Keys.C)
                    )
            {
                return;
            }

            const string DIVIDER = @"---------------------------";
            const string BUTTON_TEXT_SPACER = @"   ";

            // Pressing Ctrl+C should copy message text into the clipboard
            var sb = new StringBuilder();

            sb.AppendLine(DIVIDER);
            sb.AppendLine(Text);
            sb.AppendLine(DIVIDER);
            sb.AppendLine(_messageText.Text);
            sb.AppendLine(DIVIDER);
            sb.Append(_button1.Text).Append(BUTTON_TEXT_SPACER);
            if (_button2.Enabled)
            {
                sb.Append(_button2.Text).Append(BUTTON_TEXT_SPACER);
                if (_button3.Enabled)
                {
                    sb.Append(_button3.Text).Append(BUTTON_TEXT_SPACER);
                }

                if (_button4.Enabled)
                {
                    sb.Append(_button4.Text).Append(BUTTON_TEXT_SPACER);
                }
            }

            sb.AppendLine(string.Empty);
            sb.AppendLine(DIVIDER);

            Clipboard.SetText(sb.ToString(), TextDataFormat.Text);
            Clipboard.SetText(sb.ToString(), TextDataFormat.UnicodeText);
        }

        /// <summary>Setups the CheckBox.</summary>
        private void SetupCheckBox()
        {
            _panelOptionalCheckbox.Visible = _showOptionalCheckBox;

            _optionalCheckBox.StateCommon.ShortText.Font = _messageBoxTypeface;

            _optionalCheckBox.StateCommon.LongText.Font = _messageBoxTypeface;

            _optionalCheckBox.Text = _optionalCheckBoxText;

            _optionalCheckBox.CheckState = _optionalCheckBoxCheckState;

            _optionalCheckBox.Checked = _isOptionalCheckBoxChecked;
        }

        /// <summary>Gets the optional CheckBox checked state.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        internal bool GetOptionalCheckBoxChecked() => _optionalCheckBox.Checked;

        /// <summary>Gets the state of the optional CheckBox check state.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        internal CheckState GetOptionalCheckBoxCheckState() => _optionalCheckBox.CheckState;

        private void SetupOptionalLink()
        {
            _panelOptionalLinkLabel.Visible = _showOptionalLinkLabel;

            _optionalLinkLabel.StateCommon.ShortText.Font = _messageBoxTypeface;

            _optionalLinkLabel.StateCommon.LongText.Font = _messageBoxTypeface;

            _optionalLinkLabel.Text = _optionalLinkLabelText;

            _optionalLinkLabel.LinkClicked += OptionalLink_LinkClicked;
        }

        public new DialogResult ShowDialog(IWin32Window owner)
        {
            if (_showOptionalCheckBox)
            {
                GetOptionalCheckBoxChecked();
            }

            return base.ShowDialog(owner);
        }
        #endregion

        #region Event Handlers
        private void OptionalLink_LinkClicked(object sender, EventArgs e)
        {
            try
            {
                Process.Start(_optionalLinkLabelDestination);
            }
            catch (Exception exc)
            {
                Debug.Write(exc.ToString());
            }
        }
        #endregion
    }
}