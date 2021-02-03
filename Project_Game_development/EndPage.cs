using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.UI.Forms;
using Project_Game_development.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Project_Game_development
{
    class EndPage : ControlManager, IGameObject
    {
        public Texture2D BackgroundTexture;
        private ContentManager content;
        Level2 level2;

        public bool StartGame = false;
        private SpriteFont font;
        private string end;


        public EndPage(ContentManager content, Game game) : base(game)
        {
            level2 = new Level2(content);
            if (level2.EndLevel2)
                end = "YOU WIN!";
            else
                end = "Game Over";

            this.content = content;
            InitializeContent();
        }

        private void InitializeContent()
        {
            BackgroundTexture = content.Load<Texture2D>("background");
            font = content.Load<SpriteFont>("DefaultFont");

        }

        public void Draw(SpriteBatch _spritebatch)
        {
            _spritebatch.Draw(BackgroundTexture, new Vector2(0, 0), new Rectangle(0, 100, 800, 480), Color.White);
            _spritebatch.DrawString(font, end, new Vector2(300, 50), Color.Yellow);
        }

        public void Update()
        {
            //
        }

        public override void InitializeComponent()
        {
            var Sbtn = new Button()
            {
                Text = "REPLAY",
                Size = new Vector2(200, 50),
                BackgroundColor = Color.ForestGreen,
                Location = new Vector2(300, 200)
            };
            var Qbtn = new Button()
            {
                Text = "QUIT",
                Size = new Vector2(200, 50),
                BackgroundColor = Color.IndianRed,
                Location = new Vector2(300, 300)
            };
            Qbtn.Clicked += Qbtn_Clicked;
            Sbtn.Clicked += Sbtn_Clicked;
            Controls.Add(Qbtn);
            Controls.Add(Sbtn);
        }

        private void Qbtn_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Text = "Clicked";
            Environment.Exit(0);
        }

        private void Sbtn_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Text = "Clicked";
            StartGame = true;
            Debug.Write(StartGame);
        }
    }
}