using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace DIO.Typing.View {
    public partial class FormHome : Form {

        private readonly Typing typing = new Typing();
        private readonly RichTyping _richTyping = new RichTyping();

        public FormHome() {
            InitializeComponent();
            UpdateNumberLabel();
            LoadEvents();
        }

        private void LoadEvents() {
            this.richTyping.VScroll += new EventHandler(RichTextBox_ChangeLine);
            this.richTyping.ClientSizeChanged += new EventHandler(RichTextBox_ChangeLine);
            this.richTyping.FontChanged += new EventHandler(RichTextBox_ChangeLine);
            this.ToolStripMenuItemLessonText.Click += new EventHandler(OpenFormInputTextLesson_Click);
            this.textBoxInput.TextChanged += new EventHandler(TextBoxInput_TextChanged);
            this.ToolStripMenuItemLessonCaracteres.Click += new EventHandler(OpenFormInputCaracteresGeneratorRandon_Click);
            this.ToolStripMenuItemExit.Click += new EventHandler(Form_Exit);
            this.StripMenuItemOpenGitHub.Click += new EventHandler(OpenGitHub_Click);
            this.ToolStripMenuItemDIO.Click += new EventHandler(OpenDIOPlatform_Click);
            this.ToolStripMenuItemGitHub.Click += new EventHandler(OpenGitHub_Click);
        }

        private void RichTextBox_ChangeLine(object sender, EventArgs e) {
            UpdateNumberLabel();
        }
        
        private void UpdateNumberLabel() {
            try {
                Point pos = new Point(0, 0);
                int firstIndex = richTyping.GetCharIndexFromPosition(pos);
                int firstLine = richTyping.GetLineFromCharIndex(firstIndex);

                pos.X = ClientRectangle.Width;
                pos.Y = ClientRectangle.Height;

                int lastIndex = richTyping.GetCharIndexFromPosition(pos);
                int lastLine = richTyping.GetLineFromCharIndex(lastIndex);

                richLine.Font = richTyping.Font;

                richLine.Text = "";

                for (int i = firstLine; i < lastLine + 1; i++) {
                    richLine.Text += i + 1 + "\n";
                }
            }
            catch (Exception) {
                throw;
            }
        }

        private void LoadProgreesBar() {
            try {
                this.progressBar1.Maximum = richTyping.Text.Length;
                this.progressBar1.Value = typing.GetTotalKeysInput();
            }
            catch (Exception) {
                throw;
            }
        }

        private void TextBoxInput_TextChanged(object sender, EventArgs e) {
            
            if(textBoxInput.Text.Length > 0 && typing.GetTotalKeysInput() < richTyping.Text.Length) {
                
                typing.SetCharInput(GetLastCharTextbox());
                
                _richTyping.SetTyping(typing, richTyping);
                
                LoadProgreesBar();

                textBoxTotalKeysInput.Text = typing.GetTotalKeysInput().ToString();
                textBoxCaracteresWrongs.Text = typing.CaracteresInputWrong;
                textBoxCorrects.Text = typing.Correct.ToString();
                textBoxWrongs.Text = typing.Wrong.ToString();
            }
        }

        private void OpenFormInputTextLesson_Click(object sender, EventArgs e) {

            using (var form = new FormInputTextLesson()) {
                form.ShowDialog();
                if (form.Confirmed) {
                    ReseteAll();
                    this.richTyping.Text = form.TextInput;
                    UpdateNumberLabel();
                }
            }
        }

        private void OpenFormInputCaracteresGeneratorRandon_Click(object sender, EventArgs e) {

            using (var form = new FormInputCaracteresGeneratorRandon()) {
                form.ShowDialog();
                if (form.Confirmed) {
                    ReseteAll();
                    this.richTyping.Text = Lesson.Create(form.TextInput, 35, 5);
                    UpdateNumberLabel();
                }
            }
        }

        private void ReseteAll() {
            
            typing.Reset();
            richTyping.Clear();

            textBoxInput.Text = "";
            progressBar1.Value = 0;
            textBoxCorrects.Text = "";
            textBoxWrongs.Text = "";
            textBoxTotalKeysInput.Text = "";
            textBoxCaracteresWrongs.Text = "";
            UpdateNumberLabel();
        }

        private char GetLastCharTextbox() {
            if(textBoxInput.Text.Length > 0) {
                return char.Parse(textBoxInput.Text.Substring(textBoxInput.Text.Length - 1, 1));
            }
            return ' ';
        }

        private void Form_Exit(object sender, EventArgs e) {
            this.Close();
        }

        private void OpenGitHub_Click(object sender, EventArgs e) {
            GotoSite("https://carlosantoniocison.editorx.io/portifolio/diotyping");
        }
        private void OpenDIOPlatform_Click(object sender, EventArgs e) {
            GotoSite("https://digitalinnovation.one/sign-up?ref=4GM5NRY49Q");
        }

        private void GotoSite(string url) {
            try {
                Process.Start(url);
            }
            catch (Exception) {
                throw;
            }
        }

    }
}
