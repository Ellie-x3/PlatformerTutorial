using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PixelPlatformer.Util;

namespace PixelPlatformer;

public class PixelPlatformer : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _characterAtlas; 

    #region player
   
    private Rectangle _characterRect = new Rectangle(0,0,24,24); //
    private Vector2 _playerPosition = new Vector2(200, 200);
    private Vector2 _playerMagnitude = Vector2.Zero;
    private float _playerSpeed = 6.0f;

    #endregion

    public PixelPlatformer()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.ApplyChanges();

        Window.AllowUserResizing = false;

        Input.Initialize();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _characterAtlas = Content.Load<Texture2D>("Assets/Characters");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        Input.Update(gameTime);

        //MovePlayer
        _playerMagnitude = Vector2.Zero;

        if(Input.IsKeyDown(Keys.A)){
            _playerMagnitude.X = -1;
        } 
        
        if (Input.IsKeyDown(Keys.D)) {
            _playerMagnitude.X = 1;
        }

        _playerPosition.X += _playerMagnitude.X * _playerSpeed;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(SpriteSortMode.BackToFront, samplerState: SamplerState.PointClamp);
        //_spriteBatch.Draw(_characterAtlas, new Vector2(200, 400), Color.White);
        //_spriteBatch.Draw(_characterAtlas, new Vector2(200, 200), _characterRect, Color.White);
        _spriteBatch.Draw(_characterAtlas, _playerPosition, _characterRect, Color.White, 0f, Vector2.Zero, 2.5f, SpriteEffects.None, 0f);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
