using System.Drawing;
using System.Windows.Forms;

namespace DIO.Typing {
    public class RichTyping {

        public string TextIpunt { get; set; }
        public string TextCurrent { get; set; }

      
        public  void SetTyping(ITyping _typing, RichTextBox _richTextBox) {

            try {
                _typing.SetCursor();

                int indexPosCursor = _typing.Cursor;

                _richTextBox.Select(indexPosCursor, 1);

                Color origem = _richTextBox.SelectionBackColor;
                _richTextBox.SelectionBackColor = Color.Yellow;

                _richTextBox.Select(indexPosCursor - 1, 1);
                _richTextBox.SelectionBackColor = origem;

                TextCurrent = _richTextBox.SelectedText;

                if (_typing.CharInput.ToString() == TextCurrent) {
                    _richTextBox.SelectionColor = Color.FromArgb(245, 204, 132);
                    _richTextBox.SelectionFont = new Font(_richTextBox.SelectionFont.FontFamily, _richTextBox.SelectionFont.Size, FontStyle.Bold);

                    _typing.SetCorrect();
                }
                else {
                    _richTextBox.SelectionColor = Color.Red;
                    _richTextBox.SelectionBackColor = Color.FromArgb(249, 249, 249);
                    _richTextBox.SelectionFont = new Font(_richTextBox.SelectionFont.FontFamily, _richTextBox.SelectionFont.Size, FontStyle.Bold);

                    _typing.SetWrong();

                    if (_typing.CaracteresInputWrong != null) {
                        if (!_typing.CaracteresInputWrong.Contains(_richTextBox.SelectedText) && _richTextBox.SelectedText != " ") {
                            _typing.SetCaractereWrong(_richTextBox.SelectedText);
                        }
                    }
                }
            }
            catch (System.Exception) {
                throw;
            }
        }
    }
}
