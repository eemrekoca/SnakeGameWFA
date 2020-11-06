using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
  public partial class Form1 : Form
  {
    InitializeComponent();
    //Set setting to default
    new Settings();
    //Set game speed and start timer
    gameTimer.Interval = 1000 / Settings.Speed;
    gameTimer.Tick += UpdateScreen;
    gameTimer.Start();

    //Start new game
    StartGame();

  }

  private void UpdateScreen(object sender, EventArgs e)
  {
    //check for game over
    if (Settings.GameOver == true)
    {
      if (Input.KeyPressed(Keys.Enter))
      {
        StartGame();
      }
    }
    else
    {
      if (Input.KeyPressed(Key.Right) && Settings.direction != Direction.Left;
          Settings.direction = Direction.Right;
      else if (Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
          Settings.direction = Direction.Left;
      else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
          Settings.direction = Direction.Up;
      else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
          Settings.direction = Direction.Down;
      
      MovePlayer();

    }

    pbCanvas.Invalidate();

  }

  private void StartGame()
  {
    labelGameOver.Visible = false;
    new Settings();
    //create new player object
    Snake.Clear();
    Circle head = new Circle();
    head.X = 10;
    head.Y = 5;
    Snake.Add(head);

    lblScore.Text = Settings.Score.ToString();
    GenerateFood();
  }

  //place random food game

  private void GenerateFood()
  {
    int maxXp = pbCanvas.Size.Width / Settings.Width;
    int maxYP = pbCanvas.Size.Height / Settings.Height;

    Random random = new Random();
    food = new Circle();
    food.X = random.Next(0, maxXp);
    food.Y = random.Next(0, maxYP);

  }

  private void LblScore_Click(object sender, EventArgs e)
  {

  }

  private void Timer1.Tick(object sender, EventArgs e)
  {

  }

  private void Form1_Load(object sender, EventArgs e)
  {

  }

  private List<Circle> Snake = new List<Circle>(;
  private Circle food = new Circle();

  private void pbCanvas_Click(object sender, EventArgs e)
  {

  }

  private void pbCanvas_Paint(object sender, PaintEventArgs e)
  {
    Graphics canvas = e.Graphics;
    if (Settings.GameOver != false)
    {
      //set colour of Snake
      Brush snakeColour;
      //draw snake
      for (int i = 0; i < Snake.Count; i++)
      {

        if (i == 0)
            snakeColour = Brushes.Black; // Draw head
        else
            snakeColour = Brushes.Green; //Rest of body

        //draw snake
        canvas.FillEllipse(Brushes.Red,
            new Rectangle(food.X * Settings.Width,
                food.Y * Settings.Height, Settings.Width, Settings.Height));

      }
    }
    else
    {
      string gameOver = "Game Over \nYour final score is: " + Settings.Score + "\nPress Enter to try again";
      labelGameOver.Text = gameOver;
      labelGameOver.Visible = true;
    }

  }
  private void MovePlayer()
  {
    for (int i = Snake.Count - 1; i >= 0; i--)
    {
      //move head
      if (i == 0)
      {
        switch (Settings.direction)
        {
          case Direction.Right:
              Snake[i].X++;
              break;
          case Direction.Left:
              Snake[i].X--;
              break;
          case Direction.Up:
              Snake[i].Y--;
              break;
          case Direction.Down:
              Snake[i].Y++;
              break;
        }

      }
      else
      {
        //move body
        Snake[i].X = Snake[i-1].X;
        Snake[i].Y = Snake[i-1].Y;
      }
    }
  }



}
