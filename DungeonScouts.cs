using DungeonScouts.Characters;
using DungeonScouts.Characters.Combat;
using DungeonScouts.Drawing;
using DungeonScouts.Map;
using DungeonScouts.Map.Tiles;
using DungeonScouts.Map.Tiles.TileTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace DungeonScouts
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class DungeonScouts : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ResourceManager resources;
        WorldManager world;
        CameraManager camera = CameraManager.Camera;

        //TEMP
        Room testRoom = new Room(
            new ITile[][] {
                new ITile[]{ new BlankTile(), new BlankTile(), new BlankTile() },
                new ITile[] { new BlankTile(), new BlankTile(), new BlankTile() },
                new ITile[] { new BlankTile() } });
        
        public DungeonScouts()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = CameraManager.ViewWidth;
            graphics.PreferredBackBufferHeight = CameraManager.ViewHeight;

            Content.RootDirectory = "Content";
            this.Window.Title = "Dungeon Scouts";

            //TEMP
            testRoom.AddActor(new Actor(Race.HUMAN, "Test Actor", "Just a test!", 5, new IAttack[] { }, new IItem[] { }), new TilePosition(0, 0));
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            resources = new ResourceManager(Content);
            world = new WorldManager(camera);

            //TEMP
            resources.TextureStore.Add("Actors/testActor", Content.Load<Texture2D>("Actors/testActor"));

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            resources.LoadRoomTextures(testRoom);
            world.CreateRoomSprites(testRoom, resources);
            world.CreateRoomActors(testRoom, resources);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                camera.Transform.Scale--;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                camera.Transform.PosX--;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                camera.Transform.Scale++;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                camera.Transform.PosX++;

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Begin drawing with SamplerState set to PointClamp (to preserve pixel art when scaled)
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            world.Draw(spriteBatch);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
