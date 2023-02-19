using System.Windows.Forms;

namespace Victoria_3_Modding_Tool.MessageBox    
{
    public class ClassMessageBox
    {
        public static DialogResult Show()
        {
            DialogResult result;
            using (var msgForm = new CustomMessageBox())
                result = msgForm.ShowDialog();
            return result;
        }

        public static DialogResult ShowOverwrite()
        {
            DialogResult result;
            using (var msgForm = new CustomOverwriteMessageBox())
                result = msgForm.ShowDialog();
            return result;
        }
    }
}