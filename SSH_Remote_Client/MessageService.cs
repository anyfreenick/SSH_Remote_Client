using System.Windows.Forms;

namespace SSH_Remote_Client
{
    public interface IMessageService
    {
        void ShowMessage(string message);
        void ShowExclamation(string exclamation);
        void ShowError(string error);
        void ShowQuestion(string question);
        bool ShowConfirmation(string confirmation);
    }

    class MessageService: IMessageService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowExclamation(string exclamation)
        {
            MessageBox.Show(exclamation, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void ShowError(string error)
        {
            MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool ShowConfirmation(string confirmation)
        {
            DialogResult dlgRes = MessageBox.Show(confirmation, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgRes == DialogResult.Yes)
                return true;
            else if (dlgRes == DialogResult.No)
                return false;
            return false;
        }

        public void ShowQuestion(string question)
        {
            MessageBox.Show(question, "Вопрос", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
