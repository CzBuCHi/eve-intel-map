using System.Collections;
using System.Windows.Forms;

//
// Hotkey selection control, written by serenity@exscape.org, 2006-08-03
// Please mail me if you find a bug.
//

namespace eve_intel_map.controls
{
    /// <summary>
    /// A simple control that allows the user to select pretty much any valid hotkey combination
    /// </summary>
    public class HotkeyControl : TextBox
    {
        // These variables store the current hotkey and modifier(s)
        private Keys _Hotkey = Keys.None;
        private Keys _Modifiers = Keys.None;

        // ArrayLists used to enforce the use of proper modifiers.
        // Shift+A isn't a valid hotkey, for instance, as it would screw up when the user is typing.
        private readonly ArrayList _NeedNonShiftModifier;
        private readonly ArrayList _NeedNonAltGrModifier;

        private readonly ContextMenu _Dummy = new ContextMenu();

        /// <summary>
        /// Used to make sure that there is no right-click menu available
        /// </summary>
        public override ContextMenu ContextMenu
        {
            get
            {
                return _Dummy;
            }
            set
            {
                base.ContextMenu = _Dummy;
            }
        }

        /// <summary>
        /// Forces the control to be non-multiline
        /// </summary>
        public override bool Multiline
        {
            get
            {
                return base.Multiline;
            }
            set
            {
                // Ignore what the user wants; force Multiline to false
                base.Multiline = false;
            }
        }

        /// <summary>
        /// Creates a new HotkeyControl
        /// </summary>
        public HotkeyControl()
        {
            this.ContextMenu = _Dummy; // Disable right-clicking
            this.Text = "None";

            // Handle events that occurs when keys are pressed
            this.KeyPress += new KeyPressEventHandler(HotkeyControl_KeyPress);
            this.KeyUp += new KeyEventHandler(HotkeyControl_KeyUp);
            this.KeyDown += new KeyEventHandler(HotkeyControl_KeyDown);

            // Fill the ArrayLists that contain all invalid hotkey combinations
            _NeedNonShiftModifier = new ArrayList();
            _NeedNonAltGrModifier = new ArrayList();
            PopulateModifierLists();
        }

        /// <summary>
        /// Populates the ArrayLists specifying disallowed hotkeys
        /// such as Shift+A, Ctrl+Alt+4 (would produce a dollar sign) etc
        /// </summary>
        private void PopulateModifierLists()
        {
            // Shift + 0 - 9, A - Z
            for (Keys k = Keys.D0; k <= Keys.Z; k++)
                _NeedNonShiftModifier.Add((int)k);

            // Shift + Numpad keys
            for (Keys k = Keys.NumPad0; k <= Keys.NumPad9; k++)
                _NeedNonShiftModifier.Add((int)k);

            // Shift + Misc (,;<./ etc)
            for (Keys k = Keys.Oem1; k <= Keys.OemBackslash; k++)
                _NeedNonShiftModifier.Add((int)k);

            // Shift + Space, PgUp, PgDn, End, Home
            for (Keys k = Keys.Space; k <= Keys.Home; k++)
                _NeedNonShiftModifier.Add((int)k);

            // Misc keys that we can't loop through
            _NeedNonShiftModifier.Add((int)Keys.Insert);
            _NeedNonShiftModifier.Add((int)Keys.Help);
            _NeedNonShiftModifier.Add((int)Keys.Multiply);
            _NeedNonShiftModifier.Add((int)Keys.Add);
            _NeedNonShiftModifier.Add((int)Keys.Subtract);
            _NeedNonShiftModifier.Add((int)Keys.Divide);
            _NeedNonShiftModifier.Add((int)Keys.Decimal);
            _NeedNonShiftModifier.Add((int)Keys.Return);
            _NeedNonShiftModifier.Add((int)Keys.Escape);
            _NeedNonShiftModifier.Add((int)Keys.NumLock);
            _NeedNonShiftModifier.Add((int)Keys.Scroll);
            _NeedNonShiftModifier.Add((int)Keys.Pause);

            // Ctrl+Alt + 0 - 9
            for (Keys k = Keys.D0; k <= Keys.D9; k++)
                _NeedNonAltGrModifier.Add((int)k);
        }

        /// <summary>
        /// Resets this hotkey control to None
        /// </summary>
        public new void Clear()
        {
            this.Hotkey = Keys.None;
            this.HotkeyModifiers = Keys.None;
        }

        /// <summary>
        /// Fires when a key is pushed down. Here, we'll want to update the text in the box
        /// to notify the user what combination is currently pressed.
        /// </summary>
        void HotkeyControl_KeyDown(object sender, KeyEventArgs e)
        {
            // Clear the current hotkey
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                ResetHotkey();
                return;
            }
            else
            {
                this._Modifiers = e.Modifiers;
                this._Hotkey = e.KeyCode;
                Redraw();
            }
        }

        /// <summary>
        /// Fires when all keys are released. If the current hotkey isn't valid, reset it.
        /// Otherwise, do nothing and keep the text and hotkey as it was.
        /// </summary>
        void HotkeyControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this._Hotkey == Keys.None && Control.ModifierKeys == Keys.None)
            {
                ResetHotkey();
                return;
            }
        }

        /// <summary>
        /// Prevents the letter/whatever entered to show up in the TextBox
        /// Without this, a "A" key press would appear as "aControl, Alt + A"
        /// </summary>
        void HotkeyControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// Handles some misc keys, such as Ctrl+Delete and Shift+Insert
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete || keyData == (Keys.Control | Keys.Delete))
            {
                ResetHotkey();
                return true;
            }

            if (keyData == (Keys.Shift | Keys.Insert)) // Paste
                return true; // Don't allow

            // Allow the rest
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Clears the current hotkey and resets the TextBox
        /// </summary>
        public void ResetHotkey()
        {
            this._Hotkey = Keys.None;
            this._Modifiers = Keys.None;
            Redraw();
        }

        /// <summary>
        /// Used to get/set the hotkey (e.g. Keys.A)
        /// </summary>
        public Keys Hotkey
        {
            get
            {
                return this._Hotkey;
            }
            set
            {
                this._Hotkey = value;
                Redraw(true);
            }
        }

        /// <summary>
        /// Used to get/set the modifier keys (e.g. Keys.Alt | Keys.Control)
        /// </summary>
        public Keys HotkeyModifiers
        {
            get
            {
                return this._Modifiers;
            }
            set
            {
                this._Modifiers = value;
                Redraw(true);
            }
        }

        /// <summary>
        /// Helper function
        /// </summary>
        private void Redraw()
        {
            Redraw(false);
        }

        /// <summary>
        /// Redraws the TextBox when necessary.
        /// </summary>
        /// <param name="bCalledProgramatically">Specifies whether this function was called by the Hotkey/HotkeyModifiers properties or by the user.</param>
        private void Redraw(bool bCalledProgramatically)
        {
            // No hotkey set
            if (this._Hotkey == Keys.None)
            {
                this.Text = "None";
                return;
            }

            // LWin/RWin doesn't work as hotkeys (neither do they work as modifier keys in .NET 2.0)
            if (this._Hotkey == Keys.LWin || this._Hotkey == Keys.RWin)
            {
                this.Text = "None";
                return;
            }

            // Only validate input if it comes from the user
            if (bCalledProgramatically == false)
            {
                // No modifier or shift only, AND a hotkey that needs another modifier
                if ((this._Modifiers == Keys.Shift || this._Modifiers == Keys.None) &&
                this._NeedNonShiftModifier.Contains((int)this._Hotkey))
                {
                    if (this._Modifiers == Keys.None)
                    {
                        // Set Ctrl+Alt as the modifier unless Ctrl+Alt+<key> won't work...
                        if (_NeedNonAltGrModifier.Contains((int)this._Hotkey) == false)
                            this._Modifiers = Keys.Alt | Keys.Control;
                        else // ... in that case, use Shift+Alt instead.
                            this._Modifiers = Keys.Alt | Keys.Shift;
                    }
                    else
                    {
                        // User pressed Shift and an invalid key (e.g. a letter or a number),
                        // that needs another set of modifier keys
                        this._Hotkey = Keys.None;
                        this.Text = this._Modifiers.ToString() + " + Invalid key";
                        return;
                    }
                }
                // Check all Ctrl+Alt keys
                if ((this._Modifiers == (Keys.Alt | Keys.Control)) &&
                    this._NeedNonAltGrModifier.Contains((int)this._Hotkey))
                {
                    // Ctrl+Alt+4 etc won't work; reset hotkey and tell the user
                    this._Hotkey = Keys.None;
                    this.Text = this._Modifiers.ToString() + " + Invalid key";
                    return;
                }
            }

            if (this._Modifiers == Keys.None)
            {
                if (this._Hotkey == Keys.None)
                {
                    this.Text = "None";
                    return;
                }
                else
                {
                    // We get here if we've got a hotkey that is valid without a modifier,
                    // like F1-F12, Media-keys etc.
                    this.Text = this._Hotkey.ToString();
                    return;
                }
            }

            // I have no idea why this is needed, but it is. Without this code, pressing only Ctrl
            // will show up as "Control + ControlKey", etc.
            if (this._Hotkey == Keys.Menu /* Alt */ || this._Hotkey == Keys.ShiftKey || this._Hotkey == Keys.ControlKey)
                this._Hotkey = Keys.None;

            this.Text = this._Modifiers.ToString() + " + " + this._Hotkey.ToString();
        }
    }
}
