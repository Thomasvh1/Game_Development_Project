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
    class StartPage : ControlManager,IGameObject
    {
        public Texture2D BackgroundTexture;
        private ContentManager content;

        public bool StartGame = false;

        public StartPage(ContentManager content, Game game) : base(game)
        {
            this.content = content; 
            InitializeContent();
        }

        private void InitializeContent()
        {
            BackgroundTexture = content.Load<Texture2D>("background");
        }

        public void Draw(SpriteBatch _spritebatch)
        {
            _spritebatch.Draw(BackgroundTexture, new Vector2(0, 0), new Rectangle(0, 100, 800, 480), Color.White);
        }

        public void Update()
        {
            //
        }

        public override void InitializeComponent()
        {
            var Sbtn = new Button()
            {
                Text = "START",
                Size = new Vector2(200, 50),
                BackgroundColor = Color.ForestGreen,
                Location = new Vector2(300,200)
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
