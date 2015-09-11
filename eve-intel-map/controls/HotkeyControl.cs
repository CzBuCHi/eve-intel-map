using System.Collections;
using System.Windows.Forms;

//
// Hotkey selection control, written by serenity@exscape.org, 2006-08-03
// Please mail me if you find a bug.
//

namespace eve_intel_map.controls
{
    /// <summary>
    ///     A simple control that allows the user to select pretty much any valid hotkey combination
    /// </summary>
    public sealed class HotkeyControl : TextBox
    {
        private readonly ContextMenu _Dummy = new ContextMenu();
        private readonly ArrayList _NeedNonAltGrModifier;
        // ArrayLists used to enforce the use of proper modifiers.
        // Shift+A isn't a valid hotkey, for instance, as it would screw up when the user is typing.
        private readonly ArrayList _NeedNonShiftModifier;
        // These variables store the current hotkey and modifier(s)
        private Keys _Hotkey = Keys.None;
        private Keys _Modifiers = Keys.None;

        /// <summary>
        ///     Creates a new HotkeyControl
        /// </summary>
        public HotkeyControl() {
            ContextMenu = _Dummy; // Disable right-clicking
            Text = @"None";

            // Handle events that occurs when keys are pressed
            KeyPress += HotkeyControl_KeyPress;
            KeyUp += HotkeyControl_KeyUp;
            KeyDown += HotkeyControl_KeyDown;

            // Fill the ArrayLists that contain all invalid hotkey combinations
            _NeedNonShiftModifier = new ArrayList();
            _NeedNonAltGrModifier = new ArrayList();
            PopulateModifierLists();
        }

        /// <summary>
        ///     Used to make sure that there is no right-click menu available
        /// </summary>
        public override ContextMenu ContextMenu {
            get { return _Dummy; }
            // ReSharper disable once ValueParameterNotUsed
            set { base.ContextMenu = _Dummy; }
        }

        /// <summary>
        ///     Forces the control to be non-multiline
        /// </summary>
        public override bool Multiline {
            get { return base.Multiline; }
            // ReSharper disable once ValueParameterNotUsed
            set {
                // Ignore what the user wants; force Multiline to false
                base.Multiline = false;
            }
        }

        /// <summary>
        ///     Used to get/set the hotkey (e.g. Keys.A)
        /// </summary>
        public Keys Hotkey {
            get { return _Hotkey; }
            set {
                _Hotkey = value;
                Redraw(true);
            }
        }

        /// <summary>
        ///     Used to get/set the modifier keys (e.g. Keys.Alt | Keys.Control)
        /// </summary>
        public Keys HotkeyModifiers {
            get { return _Modifiers; }
            set {
                _Modifiers = value;
                Redraw(true);
            }
        }

        /// <summary>
        ///     Populates the ArrayLists specifying disallowed hotkeys
        ///     such as Shift+A, Ctrl+Alt+4 (would produce a dollar sign) etc
        /// </summary>
        private void PopulateModifierLists() {
            // Shift + 0 - 9, A - Z
            for (Keys k = Keys.D0; k <= Keys.Z; k++) {
                _NeedNonShiftModifier.Add((int) k);
            }

            // Shift + Numpad keys
            for (Keys k = Keys.NumPad0; k <= Keys.NumPad9; k++) {
                _NeedNonShiftModifier.Add((int) k);
            }

            // Shift + Misc (,;<./ etc)
            for (Keys k = Keys.Oem1; k <= Keys.OemBackslash; k++) {
                _NeedNonShiftModifier.Add((int) k);
            }

            // Shift + Space, PgUp, PgDn, End, Home
            for (Keys k = Keys.Space; k <= Keys.Home; k++) {
                _NeedNonShiftModifier.Add((int) k);
            }

            // Misc keys that we can't loop through
            _NeedNonShiftModifier.Add((int) Keys.Insert);
            _NeedNonShiftModifier.Add((int) Keys.Help);
            _NeedNonShiftModifier.Add((int) Keys.Multiply);
            _NeedNonShiftModifier.Add((int) Keys.Add);
            _NeedNonShiftModifier.Add((int) Keys.Subtract);
            _NeedNonShiftModifier.Add((int) Keys.Divide);
            _NeedNonShiftModifier.Add((int) Keys.Decimal);
            _NeedNonShiftModifier.Add((int) Keys.Return);
            _NeedNonShiftModifier.Add((int) Keys.Escape);
            _NeedNonShiftModifier.Add((int) Keys.NumLock);
            _NeedNonShiftModifier.Add((int) Keys.Scroll);
            _NeedNonShiftModifier.Add((int) Keys.Pause);

            // Ctrl+Alt + 0 - 9
            for (Keys k = Keys.D0; k <= Keys.D9; k++) {
                _NeedNonAltGrModifier.Add((int) k);
            }
        }

        /// <summary>
        ///     Resets this hotkey control to None
        /// </summary>
        public new void Clear() {
            Hotkey = Keys.None;
            HotkeyModifiers = Keys.None;
        }

        /// <summary>
        ///     Fires when a key is pushed down. Here, we'll want to update the text in the box
        ///     to notify the user what combination is currently pressed.
        /// </summary>
        private void HotkeyControl_KeyDown(object sender, KeyEventArgs e) {
            // Clear the current hotkey
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) {
                ResetHotkey();
            }
            _Modifiers = e.Modifiers;
            _Hotkey = e.KeyCode;
            Redraw();
        }

        /// <summary>
        ///     Fires when all keys are released. If the current hotkey isn't valid, reset it.
        ///     Otherwise, do nothing and keep the text and hotkey as it was.
        /// </summary>
        private void HotkeyControl_KeyUp(object sender, KeyEventArgs e) {
            if (_Hotkey == Keys.None && ModifierKeys == Keys.None) {
                ResetHotkey();
            }
        }

        /// <summary>
        ///     Prevents the letter/whatever entered to show up in the TextBox
        ///     Without this, a "A" key press would appear as "aControl, Alt + A"
        /// </summary>
        private void HotkeyControl_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
        }

        /// <summary>
        ///     Handles some misc keys, such as Ctrl+Delete and Shift+Insert
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == Keys.Delete || keyData == (Keys.Control | Keys.Delete)) {
                ResetHotkey();
                return true;
            }

            if (keyData == (Keys.Shift | Keys.Insert)) // Paste
            {
                return true; // Don't allow
            }

            // Allow the rest
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        ///     Clears the current hotkey and resets the TextBox
        /// </summary>
        public void ResetHotkey() {
            _Hotkey = Keys.None;
            _Modifiers = Keys.None;
            Redraw();
        }

        /// <summary>
        ///     Redraws the TextBox when necessary.
        /// </summary>
        /// <param name="bCalledProgramatically">
        ///     Specifies whether this function was called by the Hotkey/HotkeyModifiers
        ///     properties or by the user.
        /// </param>
        private void Redraw(bool bCalledProgramatically = false) {
            // No hotkey set
            if (_Hotkey == Keys.None) {
                Text = @"None";
                return;
            }

            // LWin/RWin doesn't work as hotkeys (neither do they work as modifier keys in .NET 2.0)
            if (_Hotkey == Keys.LWin || _Hotkey == Keys.RWin) {
                Text = @"None";
                return;
            }

            // Only validate input if it comes from the user
            if (bCalledProgramatically == false) {
                // No modifier or shift only, AND a hotkey that needs another modifier
                if ((_Modifiers == Keys.Shift || _Modifiers == Keys.None) &&
                    _NeedNonShiftModifier.Contains((int) _Hotkey)) {
                    if (_Modifiers == Keys.None) {
                        // Set Ctrl+Alt as the modifier unless Ctrl+Alt+<key> won't work...
                        if (_NeedNonAltGrModifier.Contains((int) _Hotkey) == false) {
                            _Modifiers = Keys.Alt | Keys.Control;
                        } else // ... in that case, use Shift+Alt instead.
                        {
                            _Modifiers = Keys.Alt | Keys.Shift;
                        }
                    } else {
                        // User pressed Shift and an invalid key (e.g. a letter or a number),
                        // that needs another set of modifier keys
                        _Hotkey = Keys.None;
                        Text = _Modifiers + @" + Invalid key";
                        return;
                    }
                }
                // Check all Ctrl+Alt keys
                if ((_Modifiers == (Keys.Alt | Keys.Control)) &&
                    _NeedNonAltGrModifier.Contains((int) _Hotkey)) {
                    // Ctrl+Alt+4 etc won't work; reset hotkey and tell the user
                    _Hotkey = Keys.None;
                    Text = _Modifiers + @" + Invalid key";
                    return;
                }
            }

            if (_Modifiers == Keys.None) {
                if (_Hotkey == Keys.None) {
                    Text = @"None";
                    return;
                }
                // We get here if we've got a hotkey that is valid without a modifier,
                // like F1-F12, Media-keys etc.
                Text = _Hotkey.ToString();
                return;
            }

            // I have no idea why this is needed, but it is. Without this code, pressing only Ctrl
            // will show up as "Control + ControlKey", etc.
            if (_Hotkey == Keys.Menu /* Alt */|| _Hotkey == Keys.ShiftKey || _Hotkey == Keys.ControlKey) {
                _Hotkey = Keys.None;
            }

            Text = $"{_Modifiers} + {_Hotkey}";
        }
    }
}
