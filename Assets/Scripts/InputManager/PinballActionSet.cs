using System.Collections.Generic;
using InControl;


namespace Assets.Scripts.InputManager {

    public class PinballActionSet : PlayerActionSet {

        public PlayerAction LeftPaddle;

        public PlayerAction RightPaddle;

        public PlayerAction BallLauncher;

        public PinballActionSet() {
            LeftPaddle = CreatePlayerAction( "Left Paddle" );
            LeftPaddle.AddDefaultBinding( Key.A );
            LeftPaddle.AddDefaultBinding( InputControlType.LeftTrigger );

            RightPaddle = CreatePlayerAction( "Right Paddle" );
            RightPaddle.AddDefaultBinding( Key.D );
            RightPaddle.AddDefaultBinding( InputControlType.RightTrigger );

            BallLauncher = CreatePlayerAction( "Ball Launcher" );
            BallLauncher.AddDefaultBinding( Key.Space );
            BallLauncher.AddDefaultBinding( InputControlType.Action1 );
        }

    }

}
