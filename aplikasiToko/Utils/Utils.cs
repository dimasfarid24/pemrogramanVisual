using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace aplikasiToko.Utils
{
    static class Notify
    {
        public static void notifyError(Exception Error, string message = null)
        {
            if (Error != null && message == null)
            {
                MessageBox.Show(Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static bool notifyDelete()
        {
            if (MessageBox.Show("Apakah anda ingin menghapus data ini ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
    }
}