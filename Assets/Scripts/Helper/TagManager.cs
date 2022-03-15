using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TagManager
{
    // Tags
    public static string PLAYER_TAG = "Player";
    public static string Enemy_TAG = "Enemy";
    public static string Tree_TAG = "Tree";
    public static string Tree1_TAG = "Tree1";
    public static string Tree2_TAG = "Tree2";
    public static string Cloud1_TAG = "Cloud";
    public static string Cloud2_TAG = "Cloud2";
    public static string Ground_TAG = "Ground";
    public static string OBSTACLE_TAG = "Obstacle";
    public static string HEALTH_TAG = "Health";
    public static string GAMEPLAY_CONTROLLER_TAG = "GamePlayController";
    public static string Shredder_TAG = "Shredder";

    // Animations
    public static string JumpAnimationParameter = "Jump";
    public static string AttackAnimationParameter = "Attack";
    public static string RunningAnimationParameter = "Running";
    public static string JumpAttackAnimationParameter = "JumpAttack";
    public static string DeadAnimationParameter = "Dead";
    public static string SlideAnimationParameter = "Slide";

    public static string JUMP_BUTTON = "Jump";

    // Scene names
    public static string GAMEPLAY_SCENE_NAME = "Gameplay";
    public static string MAINMENU_SCENE_NAME = "MainMenu";

    // Character Name
    public static string ROBOT = "Robot";
    public static string GIRL = "Girl";
    public static string BOY = "Boy";

    // Game Data
    public static string CHARACTER_DATA = "Character";
    public static string SELECTED_CHARACTER_DATA = "Selected Character";
    public static string HIGHSCORE_DATA = "Highscore";

    // 0 Data not Initialized, 1 Data Initialized
    public static string DATA_INITIALIZED = "Data Initialized";
}
