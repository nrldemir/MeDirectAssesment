using LightsOutGame.Client.App.Implementation;
using LightsOutGame.Client.App.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LightsOutGame.Client.App
{
    public partial class FrmGame : Form
    {
        private int _xsize = 0, _ysize = 0;
        private int _playerId = 0;
        private string _name = string.Empty,
                       _surname = string.Empty,
                       _boardsize = string.Empty;

        private Button[,] _buttons;
        private bool[,] _buttonsMatrix;
        private GameServiceApi _gameServiceApi;
        public FrmGame(string name, string surname, int xSize, int ySize, GameServiceApi gameServiceApi)
        {
            _name = name;
            _surname = surname;
            _xsize = xSize;
            _ysize = ySize;
            _boardsize = xSize + "x" + _ysize;
            _buttons = new Button[_xsize, _ysize];
            _buttonsMatrix = new bool[_xsize, _ysize];
            _gameServiceApi = gameServiceApi;
            InitializeComponent();

            SaveNewPlayer();
            Init();
        }

        private async void SaveNewPlayer()
        {
            var result = await _gameServiceApi.NewPlayer(new NewPlayerViewModel()
            {
                BoardSize = _boardsize,
                IsWinned = false,
                Name = _name,
                Surname = _surname
            });

            if (result != null)
            {
                _playerId = result.Id;
                this.Text = "Name : "+_name + " Surname : " + _surname + " Board Size : " + _boardsize;
            }
            else
                this.Text = "New Player NOT Saved!";
        }

        public void Init()
        {
            for (int i = 0; i < _buttons.GetLength(0); i++)
            {
                for (int j = 0; j < _buttons.GetLength(1); j++)
                {
                    _buttons[i, j] = new Button();
                    _buttons[i, j].Size = new Size(40, 40);
                    _buttons[i, j].Name = i.ToString() + j.ToString();
                    _buttons[i, j].Click += LightButtonOnClickEvent;
                    _buttons[i, j].Location = new Point(24 + (j * 55), 14 + (i * 55));
                    _buttons[i, j].BackColor = Color.DarkGreen;
                    _buttonsMatrix[i, j] = false;
                    this.Controls.Add(_buttons[i, j]);
                }
            }

            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(1, 8); i++)
            {
                int x = rnd.Next(0, _buttons.GetLength(0));
                int y = rnd.Next(0, _buttons.GetLength(1));
                ToogleButton(_buttons[x, y], x, y);
            }

            if (CheckStatus())
            {
                int x = rnd.Next(0, _buttons.GetLength(0));
                int y = rnd.Next(0, _buttons.GetLength(1));
                ToogleButton(_buttons[x, y], x, y);
            }
        }

        public void LightButtonOnClickEvent(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int i = (int)Char.GetNumericValue(btn.Name[0]);
            int j = (int)Char.GetNumericValue(btn.Name[1]);
            ChangeButtonState(_buttons[i, j], i, j);
            CheckEnd();
        }

        public void ChangeButtonState(object sender, int i, int j)
        {
            ToogleButton(_buttons[i, j], i, j);

            if (i > 0)
                ToogleButton(_buttons[i - 1, j], i - 1, j); //change Above
            if (i < (_buttons.GetLength(0) - 1))
                ToogleButton(_buttons[i + 1, j], i + 1, j); //change Below
            if (j > 0)
                ToogleButton(_buttons[i, j - 1], i, j - 1); //change Left
            if (j < (_buttons.GetLength(1) - 1))
                ToogleButton(_buttons[i, j + 1], i, j + 1); //change Right

        }

        public void ToogleButton(object sender, int i, int j)
        {
            Button? btn = sender as Button;
            _buttonsMatrix[i, j] = !_buttonsMatrix[i, j];
            if (_buttonsMatrix[i, j])
                btn.BackColor = Color.LimeGreen;
            else
                btn.BackColor = Color.DarkGreen;

        }

        public bool CheckStatus()
        {
            for (int i = 0; i < _buttonsMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _buttonsMatrix.GetLength(1); j++)
                {
                    if (_buttonsMatrix[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public async void CheckEnd()
        {
            if (CheckStatus())
            {
                var result = await _gameServiceApi.GameOver(new GameoverViewModel()
                {
                    Id = _playerId,
                    IsWinned = true
                });

                MessageBox.Show("Game Completed With Successfully!", "Congratulations!");
                this.Close();
            }
        }
    }
}
