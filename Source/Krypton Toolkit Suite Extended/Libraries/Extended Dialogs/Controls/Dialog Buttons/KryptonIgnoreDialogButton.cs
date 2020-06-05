﻿using Krypton.Toolkit.Suite.Extended.Standard.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Dialogs
{
    [ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonIgnoreDialogButton : KryptonButtonExtended
    {
        public KryptonIgnoreDialogButton()
        {
            DialogResult = DialogResult.Ignore;

            ParentChanged += KryptonIgnoreDialogButton_ParentChanged;

            TextChanged += KryptonIgnoreDialogButton_TextChanged;
        }

        private void KryptonIgnoreDialogButton_TextChanged(object sender, EventArgs e)
        {
            if (Text == Name) Text = "&Ignore";
        }

        private void KryptonIgnoreDialogButton_ParentChanged(object sender, EventArgs e)
        {
            Control parent = Parent;

            while (!(Parent is KryptonForm) && !(parent == null))
            {
                parent = parent.Parent;
            }

            if (parent is KryptonForm)
            {
                KryptonForm form = (KryptonForm)parent;

                form.AcceptButton = this;
            }
        }
    }
}