using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PixelPlatformer.Util;

public static class Input {
    private static KeyboardState _currentKeyboard;
    private static KeyboardState _previousKeyboard;

    private static int[] _keyCodes;
    private static bool[] _keyPress;
    private static bool[] _keyDown;

    public static void Initialize(){
        _keyCodes = Enum.GetValues(typeof(Keys)).Cast<int>().ToArray();
        _keyPress = new bool[_keyCodes.Length];
        _keyDown = new bool[_keyCodes.Length];
    }

    public static void Update(GameTime gameTime){
        _currentKeyboard = Keyboard.GetState();

        for(int i = 0; i < _keyCodes.Length; i++){
            Keys key = (Keys)_keyCodes[i];

            if(_currentKeyboard.IsKeyDown(key) && !_previousKeyboard.IsKeyDown(key)){
                _keyPress[i] = true;
            } else {
                _keyPress[i] = false;
            }

            if(_currentKeyboard.IsKeyDown(key) && _previousKeyboard.IsKeyDown(key)){
                _keyDown[i] = true;
            } else {
                _keyDown[i] = false;
            }
        }

        _previousKeyboard = Keyboard.GetState();
    }

    public static bool IsKeyPressed(Keys key){
        int i = Array.FindIndex(_keyCodes, x => x == (int)key);
        return _keyPress[i];
    }

    public static bool IsKeyDown(Keys key){
        int i = Array.FindIndex(_keyCodes, x => x == (int)key);
        return _keyDown[i];
    }
}