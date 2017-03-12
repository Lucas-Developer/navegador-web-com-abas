using System;
using System.Windows.Forms;

namespace NavegadorWebAbas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNovaGuia_Click(object sender, EventArgs e)
        {
            NovaGuia();
        }

        private void NovaGuia()
        {
            TabPage tab = new TabPage();
            tab.Text = "Nova Guia";
            tabControl1.Controls.Add(tab);
            tabControl1.SelectTab(tabControl1.TabCount - 1);
            WebBrowser browser = new WebBrowser() { ScriptErrorsSuppressed = true };
            browser.Parent = tab;
            browser.Dock = DockStyle.Fill;
            browser.Navigate("https://www.google.com");
            txtUrl.Text = "https://www.google.com";
            browser.DocumentCompleted += Browser_DocumentCompleted;
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (browser != null)
                tabControl1.SelectedTab.Text = browser.DocumentTitle;
        }

        private void btnRetorna_Click(object sender, EventArgs e)
        {
            WebBrowser browser = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (browser != null)
            {
                browser.Navigate(txtUrl.Text);
            }
        }

        private void btnAvanca_Click(object sender, EventArgs e)
        {
            WebBrowser browser = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (browser != null)
            {
                if (browser.CanGoForward)
                    browser.GoForward();
            }
        }

        private void btnIr_Click(object sender, EventArgs e)
        {
            WebBrowser browser = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (browser != null)
            {
                browser.Navigate(txtUrl.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NovaGuia();
        }
    }
}
