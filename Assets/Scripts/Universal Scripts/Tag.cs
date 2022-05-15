using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //contains tags , names, identifiers used in the game
public class Tags
{
    public const string Ver_Axis = "Vertical";
    public const string Hor_Axis = "Horizontal";
    public const string _moveLeft = "player_Can_Move_Left";
    public const string Stage_Collider = "collider";  //collider assigned to the collider object 
    public const string Obstacle_Tag = "Obstacle";
    public const string GameMan = "Game Manager";
    public const string cpName = "CurrentPlayer_Name"; //this is the name of the player that is currently playing the game
    public const string cpScore = "CurrentPlayer_Score";
    public const string phsName = "HighestScorePlayer_Name"; //this is the player that has scored the highest during everytime the game has ever been played
    public const string phsScore = "HighestScorePlayer_Scoree";
}

public class AnimationTags
{
        public const string Jump_Trig = "RunningJump";
        public const string Run = "Movement";
        public const string PlayerDeath = "Death";
        public const string Slide_Trig = "RunningSlide";
        public const string RunFlip_Trig = "RunForwardFlip";
        public const string TwistFlip_Trig = "FrontTwistFlip";
}

public class GameValues
{
    public const int GameScene_Index = 1;
    public const int MenuScene_Index = 0;
    public const int LightYearsValue = 365; //divisor to get the player's distance traveled in years
}



