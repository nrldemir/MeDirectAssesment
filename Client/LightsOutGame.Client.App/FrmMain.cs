using LightsOutGame.Client.App.Implementation;
using LightsOutGame.Client.App.Models;
using System;
using System.Windows.Forms;

namespace LightsOutGame.Client.App
{
    public partial class FrmMain : Form
    {
        private GameServiceApi _gameServiceApi;
        private int _bSizeX = 0, _bSizeY = 0;
        public FrmMain()
        {
            InitializeComponent();
        }

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            _gameServiceApi = new GameServiceApi();
            var result = await _gameServiceApi.GetGameSettings();
            if (result != null)
            {
                foreach (var item in result)
                {
                    cmbBoardSize.Items.Add(item.BoardSizeX + "x" + item.BoardSizeY);
                }
            }
            else
            {
                MessageBox.Show("Connection refused!");
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtSurname.Text) && !_bSizeX.Equals(0))
            {
                FrmGame g = new FrmGame(txtName.Text.Trim(), txtSurname.Text.Trim(), _bSizeX, _bSizeY, _gameServiceApi);
                g.ShowDialog();
            }
            else
            {
                MessageBox.Show("Enter name surname and select board size!");
            }
        }

        private void cmbBoardSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] _bSize = cmbBoardSize.Items[cmbBoardSize.SelectedIndex].ToString().Split("x");
            if (_bSize != null && _bSize.Length > 1)
            {
                _bSizeX = Convert.ToInt32(_bSize[0]);
                _bSizeY = Convert.ToInt32(_bSize[1]);
            }

        }
    }
}
