using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oscriptGUI
{
    [ContextClass("УведомлениеВТрее", "NotifyInTray")]
    class NotifyInTray : AutoContext<NotifyInTray>
    {

        private NotifyIcon notifyIcon;
        private string _icon;

        public NotifyInTray()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.gtkabout;
            _icon = "";
        }

        [ScriptConstructor]
        public static IRuntimeContextInstance Constructor()
        {
            return new NotifyInTray();
        }

        [ContextProperty("Заголовок", "Title")]
        public string Title { get; set; }

        [ContextProperty("Текст", "Text")]
        public string Text { get; set; }

        [ContextProperty("Таймаут", "Timeout")]
        public int Timeout { get; set; }

        [ContextProperty("Иконка", "Icon")]
        public string Icon {
            get { return _icon; }
            set {

                if (value == "")
                {
                    notifyIcon.Icon = Properties.Resources.gtkabout;
                }
                else
                {
                    notifyIcon.Icon = new System.Drawing.Icon(value);
                }
                _icon = value;
            }
        }

        [ContextMethod("Показать", "Show")]
        private void Show()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;

            if (Title != null)
            {
                notifyIcon.BalloonTipTitle = Title;
            }

            if (Text != null)
            {
                notifyIcon.BalloonTipText = Text;
            }

            notifyIcon.ShowBalloonTip(Timeout);
        }

    }
}
