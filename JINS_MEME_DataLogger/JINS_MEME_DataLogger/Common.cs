using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JINS_MEME_DataLogger
{
    /// <summary>
    /// �e�N���X���狤�ʂɌĂяo�����֐����L�ڂ��܂��B
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// ���b�Z�[�W�a�n�w�\��
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        public static void ShowMessageBox(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error:
                    Tracer.WriteError("[{0}]:{1}", title, message);
                    break;
                case MessageBoxIcon.Warning:
                    Tracer.WriteWarning("[{0}]:{1}", title, message);
                    break;
                default:
                    Tracer.WriteInformation("[{0}]:{1}", title, message);
                    break;
            }
            MessageBox.Show(message, title, buttons, icon);
        }
    }
}
