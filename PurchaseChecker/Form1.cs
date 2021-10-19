using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchaseChecker
{
    public partial class Form1 : Form
    {
        System.Timers.Timer timer;

        public Form1()
        {
            InitializeComponent();

            this.LastExecutionTime.Text = "未実行";

            // 終了ボタンを非活性
            this.EndButton.Enabled = false;

            // サイズ固定
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // インターバル(秒)
            this.IntervalTextBox.Text = "300";

            // リスト初期化
            this.TargetShopInfo.FullRowSelect = true;
            this.TargetShopInfo.GridLines = true;
            this.TargetShopInfo.View = View.Details;

            var columnTitle = new ColumnHeader() { Text = "Title", Width = 300 };
            var columnUrl = new ColumnHeader() { Text = "URL", Width = 300 };
            var columnTarget = new ColumnHeader() { Text = "Target", Width = 100 };
            var columnResult = new ColumnHeader() { Text = "Result", Width = 75 };
            this.TargetShopInfo.Columns.AddRange(new ColumnHeader[] { columnTitle, columnUrl, columnTarget, columnResult });
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            this.CsvFile = new OpenFileDialog();
            this.CsvFile.Filter = "CSVファイル(*.csv)|*.csv";

            if (this.CsvFile.ShowDialog() == DialogResult.OK)
            {
                this.FilePath.Text = this.CsvFile.FileName;
                LoadCsvFile(this.FilePath.Text);
            }
        }

        private void LoadCsvFile(string filePath)
        {
            if (Path.GetExtension(filePath).Equals("csv"))
            {
                MessageBox.Show("CSVファイルを読み込んでください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.TargetShopInfo.Items.Clear();
            this.TargetShopInfo.CheckBoxes = true;

            using (var parser = new TextFieldParser(filePath, Encoding.GetEncoding("SHIFT-JIS")))
            {
                //カンマ区切りのcsv形式にする
                parser.TextFieldType = FieldType.Delimited;
                parser.Delimiters = new string[] { "," };
                //ダブルコーテーションを判定
                parser.HasFieldsEnclosedInQuotes = true;
                //ダブルコーテーション内のカンマを飛ばす
                parser.TrimWhiteSpace = false;

                while (!parser.EndOfData)
                {
                    string[] data = parser.ReadFields();
                    string[] tmp = new string[4] { data[0], data[1], data[2], "待機中" };
                    var item = new ListViewItem(tmp);
                    if (Boolean.Parse(data[3]))
                    {
                        item.Checked = true;
                    }
                    this.TargetShopInfo.Items.Add(item);
                }
            }
        }

        private void BeginButton_Click(object sender, EventArgs e)
        {
            string interval = this.IntervalTextBox.Text;
            if (string.IsNullOrEmpty(interval))
            {
                MessageBox.Show("実行間隔を入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.TryParse(interval, out int intervalNum))
            {
                if (intervalNum < 60)
                {
                    MessageBox.Show("実行間隔が小さすぎます。60秒以上を設定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("実行間隔は整数のみ指定できます。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.TargetShopInfo.Items.Count == 0)
            {
                MessageBox.Show("リストが0件なので実行できません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.LoadFileButton.Enabled = false;
            this.BeginButton.Enabled = false;
            this.EndButton.Enabled = true;
            this.FilePath.Enabled = false;
            this.IntervalTextBox.Enabled = false;

            try
            {
                IsPurchase();

                // ミリ秒に変換しつつ、タイマ設定
                timer = new System.Timers.Timer(intervalNum * 1000);

                timer.Elapsed += (sender2, e2) =>
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(this.IsPurchase));
                    }
                };

                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.LoadFileButton.Enabled = true;
                this.BeginButton.Enabled = true;
                this.EndButton.Enabled = false;
                this.FilePath.Enabled = true;
                this.IntervalTextBox.Enabled = true;
                return;
            }
        }

        private void IsPurchase()
        {
            foreach (ListViewItem item in this.TargetShopInfo.Items)
            {
                if (item.Checked)
                {
                    string url = item.SubItems[1].Text;
                    string keyword = item.SubItems[2].Text;

                    WebRequest request = WebRequest.Create(url);
                    request.Timeout = 120000;    // 応答に120秒かかればタイムアウト

                    try
                    {
                        item.SubItems[3].Text = "確認中";
                        this.TargetShopName.Text = item.SubItems[0].Text;
                        WebResponse response = request.GetResponse();
                        Stream objStream = response.GetResponseStream();

                        StreamReader objReader = new StreamReader(objStream);

                        string line = "";
                        while (line != null)
                        {
                            line = objReader.ReadLine();

                            if (!string.IsNullOrEmpty(line))
                            {
                                if (line.Contains(keyword))
                                {
                                    item.SubItems[3].Text = "販売中";
                                    item.BackColor = Color.Red;
                                    break;
                                }
                                else
                                {
                                    item.SubItems[3].Text = "販売停止";
                                }

                            }
                        }

                    }
                    catch (WebException ex)
                    {
                        if (ex.Message.Contains("タイムアウト"))
                        {
                            item.SubItems[3].Text = "タイムアウト";
                        }
                        else
                        {
                            item.SubItems[3].Text = "取得不可";
                            //throw new Exception(ex.Message);
                        }
                    }
                    catch(Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

                // 実行後に1秒待機
                Task.Delay(10000);
            }
            this.LastExecutionTime.Text = DateTime.Now.ToString();
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }

            this.LoadFileButton.Enabled = true;
            this.BeginButton.Enabled = true;
            this.EndButton.Enabled = false;
            this.FilePath.Enabled = true;
            this.IntervalTextBox.Enabled = true;
        }

        private void OpenLinkButton_Click(object sender, EventArgs e)
        {
            if (this.TargetShopInfo == null || this.TargetShopInfo.SelectedItems.Count == 0)
            {
                return;
            }
            var target = this.TargetShopInfo.SelectedItems[0];
            string url = target.SubItems[1].Text;
            Process.Start(url);
        }
    }
}
